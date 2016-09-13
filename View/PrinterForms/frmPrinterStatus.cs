
//  Copyright 2015 Jhorman Duban Rodríguez Pulgarín
//
//  This file is part of InkAlert.
//
//  InkAlert is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  InkAlert is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with InkAlert.  If not, see <http://www.gnu.org/licenses/>.
//
//  Jhorman Duban Rodríguez., hereby disclaims all copyright interest in
//  the program "InkAlert" (which makes passes at
//  compilers) written by Jhorman Duban Rodríguez.
//
//  Jhorman Duban Rodríguez,
//  5 January 2016
//  For more information, visit <http://www.codigoinnovador.com/projects/inkalert/>

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.InteropServices;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmPrinterStatus : BaseForms.frmGeneralBase
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        #region "Class References"
        PrinterSnmpUpdate myPrinter;
            Database database = new Database();
            DateEngine myDateEngine = new DateEngine();
            StoredProcedureParameters[] parameters;
            BackgroundWorker MyBackgroundDgPrinterRefresher = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            ColorConverter myConverter = new ColorConverter();
            Trick myTrick = new Trick();
            DataGridViewColumnSelector cs;
            FileManager myFileManager;
            frmICounterCycles myICounterCyclesForm = new frmICounterCycles();

        #endregion

        #region "Members"

            private int currentPrinterId = 0;
            public int CurrentPrinterId
            {
                get { return currentPrinterId; }
                set { currentPrinterId = value; }
            }

            private int currentPrinterModelId = 0;
            public int CurrentPrinterModelId
            {
                get { return currentPrinterModelId; }
                set { currentPrinterModelId = value; }
            }

            private string printerOperation = "";

            public string PrinterOperation
            {
                get { return printerOperation; }
                set { printerOperation = value; }
            }

        #endregion

        public frmPrinterStatus()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            myBackgroundPrinterUpdater.DoWork += new DoWorkEventHandler(myWorker_DoPrinterUpdate);
            myBackgroundPrinterUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_PrinterUpdateCompleted);
            myBackgroundPrinterUpdater.ProgressChanged += new ProgressChangedEventHandler(myWorker_PrinterUpdateProgressChanged);
            myBackgroundPrinterUpdater.WorkerReportsProgress = true;
            myBackgroundPrinterUpdater.WorkerSupportsCancellation = true;

            cs = new DataGridViewColumnSelector(dgPrinters);

            //Add filtered columns

            dgPrinters.ColumnsToBeFiltered = new string[] {
                "areaName",
                "valBlackLevel",
                "tonerKModel",
                "tonerKMaxLife",
                "valMagentaLevel",
                "valYellowLevel",
                "valCianLevel",
                "valFuserLevel",
                "valImagingUnitKLevel",
                "valTransferRollerLevel",
                "valRollersPickupForwardTray1Level",
                "dataDate",
                "printerConnectionType",
                "printerModelName",
                "printerMakeName",
                "printerTypeName",
                "monthlyCounterStatus",
                "storyNumber",
                "valBlackCounter",
                "locationName"
            };

            dgPrinters.AssignedContextMenuStrip = this.contextMenuPrinters;

        }

        private void Printers_Load(object sender, EventArgs e){

            myFileManager = new FileManager();
            myFileManager.FolderPath = Application.StartupPath + @"\Service\StartUp\";
            myFileManager.FileName = "PrinterListColumnCollection.db";
            string[] hiddenColumns = myFileManager.ReadFile().Split(',');

            foreach (DataGridViewColumn column in dgPrinters.Columns)
            {
                if (!hiddenColumns.Contains(column.Name.ToString()))
                {
                    column.Visible = false;
                }
            }

        }

        #region "Functions"

        /// <summary>
        /// Reloads the data in dgPrinters using a  background worker to
        /// retrieve data from the database
        /// </summary>
        public void gridRefresh()
        {
            try
            {
                //Check if BackgroundWorker MyBackgroundDgPrinterRefresher is busy and stop the operation
                //if true
                if (MyBackgroundDgPrinterRefresher.IsBusy)
                {
                    EventLogger.LogEvent(this, "MyBackgroundDgPrinterRefresher was called while it was still busy.",null);
                    return;
                }

                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, this.loadingImage);

                //Disable cmdAreas in parent form while this thread is
                //running
                myStartForm.cmdPrinterStatus.Enabled = false;

                //Set parent form status
                myStartForm.UpdateStatus("Cargando lista de impresoras. Por favor espere...", 0);

                // this allows our worker to report progress during work
                MyBackgroundDgPrinterRefresher.WorkerReportsProgress = true;

                //this stores the result true or false of the myPrinter.Read method
                bool readResult = false;

                // what to do in the background thread
                MyBackgroundDgPrinterRefresher.DoWork += new DoWorkEventHandler(
                delegate(object o, DoWorkEventArgs args)
                {
                    //BackgroundWorker b = o as BackgroundWorker;

                    myPrinter = new PrinterSnmpUpdate();
                    if (myPrinter.Read())
                    {

                        if (myPrinter.Table.Rows.Count > 0)
                        {

                            //lets have some fun with this
                            foreach (DataRow row in myPrinter.Table.Rows)
                            {
                                //First, lets show a valid date instead of a number
                                if (row["dataDate"].ToString() != "")
                                {
                                    row["dataDate"] = myDateEngine.FromDoubleToStringDate(row["dataDate"].ToString());

                                }
                                else
                                {
                                    row["dataDate"] = "Nunca";
                                }
                            }

                            //set image

                            myPrinter.Table.Columns.Add("printerStatusImage", typeof(Image));

                            for (int j = 0; j < myPrinter.Table.Rows.Count; j++)
                            {
                                string s = myPrinter.Table.Rows[j]["printerStatus"].ToString();
                                switch (s)
                                {
                                    case "0":
                                        myPrinter.Table.Rows[j]["printerStatusImage"] = Image.FromFile("Resources/offline.ico");
                                        break;
                                    case "1":
                                        myPrinter.Table.Rows[j]["printerStatusImage"] = Image.FromFile("Resources/online.ico");
                                        break;
                                    // ....etc....
                                }
                            }


                        }
                        readResult = true;
                    }
                    else
                    {
                        readResult = false;
                    }
                });

                // what to do when worker completes its task (notify the user)
                MyBackgroundDgPrinterRefresher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate(object o, RunWorkerCompletedEventArgs args)
                {
                    if (readResult == true)
                    {

                        dgPrinters.SetDataSource(myPrinter.Table);

                        int totalPrinters = myPrinter.Table.Rows.Count;
                        int onlinePrinters = myPrinter.Table.Select("printerStatus = '1'").Length;
                        int offlinePrinters = totalPrinters - onlinePrinters;

                        myStartForm.UpdateStatus("Listo",0);
                        myStartForm.UpdateStatusCounters(string.Format("{0} impresoras en la lista: {1} conectadas, {2} desconectadas", totalPrinters.ToString(), onlinePrinters.ToString(), offlinePrinters.ToString()));

                        //Enable cmdPrinters
                        myStartForm.cmdPrinterStatus.Enabled = true;

                        //Hide loading image
                        myStartForm.ToggleLoadingImage(this, false, this.loadingImage);


                    }
                    else
                    {
                        EventLogger.LogEvent(this,myPrinter.Error, null);
                        myStartForm.FullStatusUpdate("Ha ocurrido un error", 0, "No se ha podido conectar a la base de datos", "0 impresoras seleccionadas");
                        myStartForm.ToggleLoadingImage(this, false, loadingImage);
                        myStartForm.cmdPrinterStatus.Enabled = true;
                    }
                });

                MyBackgroundDgPrinterRefresher.RunWorkerAsync();


            }
            catch (Exception ee)
            {
                    EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

        }

        /// <summary>
        /// Converts the data in the the specified datagrid into a datatable.
        /// </summary>
        /// <param name="myDataGrid">The name of the datagrid to convert</param>
        /// <param name="updateMode">'OnlySelected' (adds  only the selected
        /// rows to the datatable or 'All' (adds all of the rows to the datatable) </param>
        /// <returns>Returns a datatable containing all data from the datagrid</returns>
        private DataTable dataTableFromDataGrid(DataGridView myDataGrid, string updateMode)
        {
            try
            {
                //Let's create dtOutPut to put the datagrid data
                DataTable dtOutPut = new DataTable();

                //Let's create an array of columns for dtOutPut
                DataColumn[] dcs = new DataColumn[] { };

                //Let's loop all the myDataGrid rows and add them to dtOutPut
                foreach (DataGridViewColumn c in myDataGrid.Columns)
                {
                    DataColumn dc = new DataColumn(); //New datacolumn
                    dc.ColumnName = c.Name; //Column name
                    dc.DataType = c.ValueType == null ? Type.GetType("System.String") : c.ValueType; //Value type
                    dtOutPut.Columns.Add(dc); //Let's add the datacolumn to dtOutPut

                }

                //Now, lets check updateMode...
                switch (updateMode)
                {
                    case "OnlySelected":

                        ////Set refresh pending to true

                        ////dgPrinters.DatasourceRefreshPending = true;

                        //Add only selected rows to dtOutPut
                        foreach (DataGridViewRow r in myDataGrid.SelectedRows)
                        {
                            DataRow drow = dtOutPut.NewRow();

                            foreach (DataGridViewCell cell in r.Cells)
                            {
                                drow[cell.OwningColumn.Name] = cell.Value;
                            }

                            dtOutPut.Rows.Add(drow);
                            //EventLogger.LogEvent(this, "Added a new row to dtOutPut", null);
                        }

                        break;

                    //Add all rows to dtOutPut
                    case "All":
                    Label_AddAllRows:
                        foreach (DataGridViewRow r in myDataGrid.Rows)
                        {
                            DataRow drow = dtOutPut.NewRow();

                            foreach (DataGridViewCell cell in r.Cells)
                            {
                                drow[cell.OwningColumn.Name] = cell.Value;
                            }

                            dtOutPut.Rows.Add(drow);
                        }

                        break;
                    default:
                        //If there is no updateMode, lets go to "All"
                        goto Label_AddAllRows;
                }

                return dtOutPut;
            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message.ToString() + " " + e.Source.ToString() + ": Error al crear la tabla temporal para almacenar la información de las impresoras.", e);
                return null;
            }

        }

        /// <summary>
        /// Sets the current printer id based on user selection.
        /// If user has selected more than one row, the current printer id will be
        /// the first id selected
        /// </summary>
        private void setCurrentPrinterId()
        {
            if (dgPrinters.SelectedRows.Count > 0)
            {
                try
                {
                    CurrentPrinterId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["id"].Value);
                }
                catch
                {
                    dgPrinters.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// Handles the creation and opening of myPrinterEditForm
        /// which is used to update or create new printers
        /// </summary>
        /// <param name="action">"Actualizar" or "Añadir"</param>
        /// <returns>Boolean true or false. True if the form could be created/
        /// opened or false if not.</returns>
        private bool handleNewPrinterForm(string action)
        {
            //Creates a new instance of myPrinterEditForm
            frmPrinterEdit myPrinterEditForm = new frmPrinterEdit();

            //Prefills the controls in myPrinterEditForm
            myPrinterEditForm.FillForm();

            if (action == "Actualizar")
            {
                //Creates a variable to store the data from the currently
                //selected row
                var selectedRow = dgPrinters.SelectedRows[0];

                //Sends the current printer id to the new myPrinterEditForm
                myPrinterEditForm.CurrentPrinterId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                try
                {
                    //Fills the controls in myPrinterEditForm, based on
                    //the data from selectedRow
                    myPrinterEditForm.cmbPrinterSerial.Text = selectedRow.Cells["printerSerial"].Value.ToString();
                    myPrinterEditForm.cmbPrinterMakeName.SelectedValue = Convert.ToInt32(selectedRow.Cells["printerMakeId"].Value);
                    myPrinterEditForm.cmbPrinterModel.SelectedValue = Convert.ToInt32(selectedRow.Cells["printerModelId"].Value);
                    myPrinterEditForm.cmbPrinterLocation.SelectedValue = Convert.ToInt32(selectedRow.Cells["printerLocationId"].Value);
                    myPrinterEditForm.cmbPrinterArea.SelectedValue = Convert.ToInt32(selectedRow.Cells["printerAreaId"].Value);
                    myPrinterEditForm.cmbPrinterConnectionType.SelectedValue = Convert.ToInt32(selectedRow.Cells["printerConnectionTypeId"].Value);
                }
                catch (Exception e)
                {

                    EventLogger.LogEvent(this, e.Message.ToString(),e);
                }

            }

            //Sets titles and text in myPrinterEditForm
            myPrinterEditForm.Text = action + " impresora";
            PrinterOperation = action;
            myPrinterEditForm.cmdSave.Text = PrinterOperation;

            myPrinterEditForm.ShowDialog();

            if (myPrinterEditForm.DialogResult == DialogResult.OK)
            {
                gridRefresh();
                return true;
            }
            return false;
        }
        

        #endregion

        #region "Interface Events"

        private void dgPrinters_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentPrinterId();

            if (dgPrinters.SelectedRows.Count == 1) {
                myStartForm.UpdateStatusSelection("1 impresora seleccionada");
            }else{
                myStartForm.UpdateStatusSelection(string.Format("{0} impresoras seleccionadas", dgPrinters.SelectedRows.Count.ToString()));
            }
        }

        private void dgPrinters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterId();
        }

        private void dgPrinters_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterId();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgPrinters.SelectedRows.Count > 0)
            {

                if(dgPrinters.SelectedRows[0].Cells["printerSerial"].Value.ToString().Trim() != dgPrinters.SelectedRows[0].Cells["valSerialNumber"].Value.ToString().Trim())
                {
                    MessageBox.Show("Esta opción solamente funciona cuando el serial que reporta la impresora instalada y el serial asignado son iguales. Por favor utilice el panel de Todas las impresoras para realizar esta acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                frmChangePrinterCommercialStatus myChangePrinterCommercialStatusForm = new frmChangePrinterCommercialStatus();

                myChangePrinterCommercialStatusForm.WhoOpenedThis = this;
                myChangePrinterCommercialStatusForm.CurrentPrinterId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["id"].Value);
                myChangePrinterCommercialStatusForm.CurrentAreaId= Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerAreaId"].Value);

                DialogResult result = myChangePrinterCommercialStatusForm.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    gridRefresh();
                }
            }

            // backup

            //if (dgPrinters.SelectedRows.Count > 0)
            //{
            //    DialogResult result = MessageBox.Show("¿Eliminar impresora?", "Eliminar impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //    if (result == System.Windows.Forms.DialogResult.OK)
            //    {
            //        parameters = new StoredProcedureParameters[1];
            //        parameters[0] = new StoredProcedureParameters("_id", CurrentPrinterId.ToString());

            //        if (database.RunStoredProcedure("Printer_Remove", parameters))
            //        {
            //            gridRefresh();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Falló la eliminación de la impresora. " + database.Error);
            //            EventLogger.LogEvent(this, database.Error,null);
            //        }
            //    }
            //}

        }

        private void actualizarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string updateMode = "All";//Send updateMode as an array parameter
                object[] arrObjects = new object[] { updateMode };//Declare the array of objects
                if (!myBackgroundPrinterUpdater.IsBusy)//Check if the worker is already in progress
                {
                    //.Enabled = false;//Disable the Start button
                    myBackgroundPrinterUpdater.RunWorkerAsync(arrObjects);//Call the background worker
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string updateMode = "OnlySelected";//Send updateMode as an array parameter
                object[] arrObjects = new object[] { updateMode };//Declare the array of objects
                if (!myBackgroundPrinterUpdater.IsBusy)//Check if the worker is already in progress
                {
                    //.Enabled = false;//Disable the Start button
                    myBackgroundPrinterUpdater.RunWorkerAsync(arrObjects);//Call the background worker

                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }


        }

        private void dgPrinters_Enter(object sender, EventArgs e)
        {
            try
            {
                int totalPrinters = myPrinter.Table.Rows.Count;
                int onlinePrinters = myPrinter.Table.Select("printerStatus = '1'").Length;
                int offlinePrinters = totalPrinters - onlinePrinters;

                myStartForm.FullStatusUpdate(
                    "Listo",
                    0,
                    string.Format("{0} impresoras en la lista: {1} conectadas, {2} desconectadas", totalPrinters.ToString(), onlinePrinters.ToString(), offlinePrinters.ToString()),
                    string.Format("{0} impresora(s) seleccionada(s)", dgPrinters.SelectedRows.Count.ToString()));
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

        }


        private void dgPrinters_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F5":
                    gridRefresh();
                    break;
                case "Delete":
                    eliminarToolStripMenuItem_Click(eliminarToolStripMenuItem, e);
                    break;
                default:
                    break;
            }
        }

        private void contactarHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {
                    string printerHostName = (string)dgPrinters.SelectedRows[0].Cells["areaHostName"].Value;

                    string printerIp = myPrinter.HostNameToIpAddress((string)dgPrinters.SelectedRows[0].Cells["areaHostName"].Value).ToString();

                    if (printerIp == myPrinter.DefaultIpAddress)
                    {
                        MessageBox.Show("No ha sido posible convertir el nombre de host " + printerHostName + " en una dirección Ip válida", "Error DNS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult userAnswer = new DialogResult();

                    if (pingIp(printerIp) == true)
                    {
                        userAnswer = MessageBox.Show("El dispositivo está en línea. ¿Desea hacer ping con la línea de comandos?","Dispositivo conectado",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    }
                    else
                    {
                        userAnswer = MessageBox.Show("La solicitud de Ping ha fallado\n\n¿Desea hacer ping con la línea de comandos?", "La solicitud de Ping ha fallado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }

                    if (userAnswer == DialogResult.Yes)
                    {
                        Process.Start("cmd", "/k ping " + printerIp);
                    }
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }
        }

        private void contactarIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult userAnswer = new DialogResult();

            string printerIp = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;

            if (pingIp(printerIp) == true)
            {
                userAnswer = MessageBox.Show("El dispositivo está en línea. ¿Desea hacer ping con la línea de comandos?", "Dispositivo conectado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                userAnswer = MessageBox.Show("La solicitud de Ping ha fallado\n\n¿Desea hacer ping con la línea de comandos?", "La solicitud de Ping ha fallado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

                if (userAnswer == DialogResult.Yes)
                {
                    Process.Start("cmd", "/k ping " + printerIp);
                }
        }

        private bool pingIp(string printerIp)
        {
            if(printerIp == string.Empty)
            {
                MessageBox.Show("Dirección IP no válida", "Dirección ip no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {

                    int timeout = 120;
                    Ping pingSender = new Ping();

                    PingReply reply = pingSender.Send(printerIp, timeout);

                    if (reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
                return false;
            }
        }

        private void abrirIPComoSitioWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {
                    int connectionTypeId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerConnectionTypeId"].Value);
                    if (connectionTypeId != Convert.ToInt32(PrinterConnectionType.Red))
                    {
                        MessageBox.Show("No se puede abrir el sitio web de un dispositivo que no está conectado por Red", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string printerIp = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;
                    if (!pingIp(printerIp))
                    {
                        MessageBox.Show("El dispositivo no está disponible en la red en este momento", "Dispositivo desconectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string areaName = (string)dgPrinters.SelectedRows[0].Cells["areaName"].Value;

                    myStartForm.AddBrowserTab("tabDatabaseAdmin" + printerIp, "Web de " + myTrick.Capitalise(areaName), "http://" + printerIp + "/");
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }
        }

        private void abrirIpComoCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {
                    string printerIp = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;

                    if (!pingIp(printerIp))
                    {
                        MessageBox.Show("El dispositivo no está disponible en la red en este momento", "Dispositivo desconectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int printerConnectionTypeId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerConnectionTypeId"].Value);

                    if (printerConnectionTypeId == Convert.ToInt32(PrinterConnectionType.USB))
                    {

                        using (NetworkShareAccesser.Access(printerIp, GlobalSetup.DefaultLocalDomainName, GlobalSetup.NetworkAdministrator, GlobalSetup.NetworkAdministratorPassword))
                        {
                            Process.Start(@"\\" + printerIp + @"\");
                        }
                    }
                    else
                    {
                        Process.Start(@"\\" + printerIp + @"\");
                    }
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
                MessageBox.Show(ee.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void handleSnmpService(string action, bool keepWindowOpen)
        {
            try
            {
                string printerIp = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;

                if (!pingIp(printerIp))
                {
                    MessageBox.Show("El dispositivo no está disponible en la red en este momento", "Dispositivo desconectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                int printerConnectionTypeId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerConnectionTypeId"].Value);

                if (printerConnectionTypeId != Convert.ToInt32(PrinterConnectionType.USB))
                {
                    MessageBox.Show("No se puede detener o iniciar un servicio en un dispositivo conectado a través de la red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                    string serviceName = Microsoft.VisualBasic.Interaction.InputBox("Nombre del servicio", "Nombre del servicio", "SNMP").Trim().ToString();

                if (serviceName.Trim().Length == 0)
                {
                    return;
                }

                if (dgPrinters.SelectedRows.Count > 0)
                {
                    string networkPassword = GlobalSetup.NetworkAdministratorPassword;
                    string networkDomain = GlobalSetup.WorkGroup;
                    string networkUserAdmin = GlobalSetup.NetworkAdministrator;
                    string psExecPath = GlobalSetup.PSExecPath + @"\psservice.exe";
                    string cmdParams = string.Format(@"/k {0} \\{1} -u {2}\{3} -p {4} {5} ""{6}""", psExecPath, printerIp, networkDomain, networkUserAdmin, networkPassword, action, serviceName);

                    if (!File.Exists(psExecPath))
                    {
                        MessageBox.Show("El archivo " + psExecPath + " no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    Process.Start("cmd", cmdParams);
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }
        }

        private void iniciarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleSnmpService("start", true);
        }

        private void detenerServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleSnmpService("stop", true);
        }

        private void detallesDeImpresoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinterDetails formPrinterDetails = new frmPrinterDetails();
            formPrinterDetails.CurrentPrinterId = this.CurrentPrinterId;
            formPrinterDetails.Show();
        }

        private void verEvoluciónDeTónerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgPrinters.SelectedRows.Count > 0)
            {
                string areaName = Convert.ToString(dgPrinters.SelectedRows[0].Cells["areaName"].Value);
                string printerId = Convert.ToString(dgPrinters.SelectedRows[0].Cells["id"].Value);

                string arguments = "-history -printerid:" + printerId + " -supplytype:toner";

                Process myProcess = Process.Start(Application.StartupPath + @"\SupplyHistory\SupplyHistory.exe", arguments);
            }
        }

        private void verTablaDeOidsEnVivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Visible == true)
            {
                this.dataGridView1.Visible = false;
            }
            else
            {
                this.dataGridView1.Visible = true;
            }
        }

        private void consolaTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create process
            Process pProcess = new Process();

            //strCommand is path and file name of command to run
            pProcess.StartInfo.FileName = Application.StartupPath.ToString() + "\\SNMPGet\\snmpget.exe";

            //strCommandParameters are parameters to pass to program
            pProcess.StartInfo.Arguments = " -v1 -c public -O v -O a -O U 127.0.0.1 .1.3.6.1.2.1.1.5.0";

            pProcess.StartInfo.UseShellExecute = false;


            pProcess.StartInfo.CreateNoWindow = true;

            //Set output of program to be written to process output stream
            pProcess.StartInfo.RedirectStandardOutput = true;

            //Optional
            pProcess.StartInfo.WorkingDirectory = Application.StartupPath.ToString() + "\\SNMPGet\\";

            //Start the process
            pProcess.Start();

            //Get program output
            string strOutput = pProcess.StandardOutput.ReadToEnd();

            char[] separator = { ':' };
            string[] returnedOidValue = strOutput.Split(separator, 2);

            object newOidValue = returnedOidValue[1].ToString();

            //Wait for process to finish
            pProcess.WaitForExit();


            MessageBox.Show(Convert.ToString((String)newOidValue));

        }

        private void actualizaciónManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string areaName = (string)dgPrinters.SelectedRows[0].Cells["areaName"].Value;
            int currentCounter = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["valBlackCounter"].Value);
            int currentTonerKLevel = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["valBlackLevel"].Value);

            frmManualUpdate formManualUpdate = new frmManualUpdate();
            formManualUpdate.CurrentCounter = currentCounter;
            formManualUpdate.CurrentTonerKLevel = currentTonerKLevel;

            formManualUpdate.Text = "Actualizar manualmente historial de " + areaName;

            myTrick.bindComboBox(formManualUpdate.cmbPrinters, "areaName", "id", "Printer_Get", "dtPrinters_ManualUpdatePrinterList", null);
            myTrick.bindComboBox(formManualUpdate.cmbPrinterSerial, "printerSerial", "id", "Printer_Get", "dtPrinters_ManualUpdateSerialList", null);

            formManualUpdate.Show();

            formManualUpdate.cmbPrinters.SelectedValue = CurrentPrinterId;
            formManualUpdate.cmbPrinterSerial.SelectedValue = CurrentPrinterId;

            formManualUpdate.cmbConsumableType.SelectedIndex = 0;
        }

        private void elegirColumnasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cs.showColumnMenu(dgPrinters, null);

        }

        private void frmPrinters_FormClosing(object sender, FormClosingEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewColumn column in dgPrinters.Columns)
            {
                FileManager myFileManager = new FileManager();

                if (column.Visible)
                {
                    sb.Append(column.Name.ToString() + ",");

                }
                myFileManager.FolderPath = Application.StartupPath + @"\Service\StartUp\";
                myFileManager.FileName = "PrinterListColumnCollection.db";
                myFileManager.Text = sb.ToString();
                myFileManager.RemoveFile();
                myFileManager.WriteToFile();
            }
        }

        private void suministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPrinters.SelectedRows.Count > 0)
                {
                    int printerModelId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerModelId"].Value);
                    int printerSerialId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["id"].Value);

                    frmConsumableInstall formConsumablesInstall = new frmConsumableInstall();
                    formConsumablesInstall.PrinterModelId = printerModelId;
                    formConsumablesInstall.PrinterSerialId = printerSerialId;
                    formConsumablesInstall.fillControls();
                    formConsumablesInstall.Show();
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }

        }

        #endregion

        private void dgPrinters_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //This will loop all of the rows every time they're sorted or
                //reloaded
                foreach (DataGridViewRow row in dgPrinters.Rows)
                {
                    //This will put red color on cells where the serial number
                    //that's stored in the db is different from the one
                    //reported by the printer
                    string storedSerial = row.Cells["printerSerial"].Value.ToString().Trim();
                    string retrievedSerial = row.Cells["valSerialNumber"].Value.ToString().Trim();
                    if (storedSerial != retrievedSerial)
                    {
                        row.Cells["printerSerial"].Style.BackColor = Color.LightCoral;
                        row.Cells["printerSerial"].Style.SelectionBackColor = Color.PaleVioletRed;
                        row.Cells["printerSerial"].ToolTipText = String.Format("El serial {0} almacenado en la base de datos\nno coincide con el serial {1} reportado por la máquina", storedSerial, retrievedSerial);
                    }

                    int lastUpdateDateValue = (row.Cells["valDataDate"].Value.ToString() == "") ? 0 : Convert.ToInt32(row.Cells["valDataDate"].Value);
                    int todaysDate = Convert.ToInt32(DateTime.Today.ToOADate());
                    int lapse = todaysDate - lastUpdateDateValue;
                    if (lapse > 1)
                    {
                        switch (lapse)
                        {
                            case 2:
                                row.Cells["dataDate"].Style.BackColor = Color.LightGoldenrodYellow;
                                break;
                            default:
                                row.Cells["dataDate"].Style.BackColor = Color.LightCoral;
                                break;
                        }
                        string timeUpdated = (lastUpdateDateValue > 0) ? "en los últimos " + lapse.ToString() + " días" : "nunca";
                        row.Cells["dataDate"].ToolTipText = String.Format("Esta máquina no ha sido actualizada " + timeUpdated + ". {0}Por favor valida la conectividad del equipo a la red o el {1}estado del agente SNMP.", "\n", "\n");
                    }

                    //This will put red colour on those cells
                    //that indicate a low (less than 20) toner level.
                    Int32 tonerLevel;
                    if (Int32.TryParse((String)row.Cells["valBlackLevel"].Value.ToString().Trim(), out tonerLevel))
                    {
                        String myCellColorString = "#000";

                        if (tonerLevel > 25)
                        {
                            myCellColorString = "#9dfc99";
                        }
                        else if (tonerLevel > 20 && tonerLevel <= 25)
                        {
                            myCellColorString = "#d4fc9c";
                        }
                        else if (tonerLevel > 15 && tonerLevel <= 20)
                        {
                            myCellColorString = "#f9f89a";
                        }
                        else if (tonerLevel > 10 && tonerLevel <= 15)
                        {
                            myCellColorString = "#f7c388";
                        }
                        else if (tonerLevel > 05 && tonerLevel <= 10)
                        {
                            myCellColorString = "#f48e5f";
                        }
                        else if (tonerLevel > -1 && tonerLevel <= 05)
                        {
                            myCellColorString = "#ef5743";
                        }

                        if (myCellColorString != "#000")
                        {
                            Color myCellColor = new Color();
                            myCellColor = (Color)myConverter.ConvertFromString(myCellColorString);
                            row.Cells["areaName"].Style.BackColor = myCellColor;
                        }
                    }
                    else
                    {
                        row.Cells["areaName"].Style.BackColor = (Color)myConverter.ConvertFromString("#ef5743"); ;
                    }

                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myICounterCyclesForm.SetActiveCounterCycleId();

            if(GlobalSetup.ActiveCounterCycleId == 0)
            {
                MessageBox.Show("No hay ningún ciclo de contador activo actualmente.", "No hay ciclos activos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myStartForm.cmdICounterCycles.PerformClick();
                return;
            }

            string selectedPrinterIds = "";

            StringBuilder commandString = new StringBuilder();

            commandString.Append("INSERT INTO icounterhistory(");
            commandString.Append("id, ");
            commandString.Append("iCounterCycleId, ");
            commandString.Append("printerSerialId, ");
            commandString.Append("printerSerial, ");
            commandString.Append("replacedSerial, ");
            commandString.Append("printerAreaId, ");
            commandString.Append("printerAreaName, ");
            commandString.Append("printerModelId, ");
            commandString.Append("printerModelName, ");
            commandString.Append("areaHostName, ");
            commandString.Append("areaIpAddress, ");
            commandString.Append("counterDate, ");
            commandString.Append("saveDate, ");
            commandString.Append("blackCounter");
            //commandString.Append("colorCounter, ");
            //commandString.Append("emailCounter, ");
            //commandString.Append("copyCounter, ");
            commandString.Append(") VALUES ");

            if (dgPrinters.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dgvRow in dgPrinters.SelectedRows)
                {

                    commandString.Append("(NULL,");
                    commandString.Append(GlobalSetup.ActiveCounterCycleId.ToString() + ", ");
                    commandString.Append(dgvRow.Cells["id"].Value.ToString() + ", '");
                    commandString.Append(dgvRow.Cells["printerSerial"].Value.ToString() + "', '");
                    commandString.Append(dgvRow.Cells["valSerialNumber"].Value.ToString() + "', ");
                    commandString.Append(dgvRow.Cells["printerAreaId"].Value.ToString() + ", '");
                    commandString.Append(dgvRow.Cells["areaName"].Value.ToString() + "', ");
                    commandString.Append(dgvRow.Cells["printerModelId"].Value.ToString() + ", '");
                    commandString.Append(dgvRow.Cells["printerModelName"].Value.ToString() + "', '");
                    commandString.Append(dgvRow.Cells["areaHostName"].Value.ToString() + "', '");
                    commandString.Append(dgvRow.Cells["areaIpAddress"].Value.ToString() + "', '");
                    commandString.Append(dgvRow.Cells["dataDate"].Value.ToString() + "', '");
                    commandString.Append(DateEngine.CurrentDateTimeShort + "', '");
                    commandString.Append(dgvRow.Cells["valBlackCounter"].Value.ToString() + "'");
                    //commandString.Append(dgvRow.Cells["colorCounter"].Value.ToString() + "),");
                    //commandString.Append("_emailCounter, ");
                    //commandString.Append("_copyCounter, ");
                    commandString.Append("),");

                    selectedPrinterIds += dgvRow.Cells["id"].Value.ToString() + ",";
                }

                string finalInsertQuery = commandString.ToString().Remove(commandString.Length - 1);

                parameters = new StoredProcedureParameters[1];
                parameters[0] = new StoredProcedureParameters("_commandText", finalInsertQuery);
                if(database.RunStoredProcedure("__RunCommand", parameters))
                {
                    if (selectedPrinterIds.Length > 0)
                    {
                        updateCounterStatus(selectedPrinterIds, "2");
                    }
                }


                //Screen capture
                foreach (DataGridViewRow dgvRow in dgPrinters.SelectedRows)
                {
                    string urlUsage = dgvRow.Cells["urlUsage"].Value.ToString().Trim();
                    if(urlUsage.Trim() == string.Empty) { continue; }

                    string ipAddress = dgvRow.Cells["areaIpAddress"].Value.ToString();

                    WebCapture myWebCapture = new WebCapture();
                    myWebCapture.UrlToLoad = urlUsage;

                }

            }



        }

        private void updateCounterStatus(string selectedPrinterIds, string newCounterStatus)
        {
            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_newStatus", newCounterStatus);
            parameters[1] = new StoredProcedureParameters("_ids", selectedPrinterIds);
            database.RunStoredProcedure("MonthlyCounterStatus_Update", parameters);

            myStartForm.cmdPrinterStatus.PerformClick();
        }

        //private void finalizarCicloDeTomaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    DialogResult resetConfirmation = MessageBox.Show("Esta operación restablecerá todas las impresoras al estado 'Pendiente'. Por favor confirme que desea proceder con esta acción.", "Restablecer estado de toma de contadores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //    if (resetConfirmation == DialogResult.OK)
        //    {
        //        parameters = new StoredProcedureParameters[0];
        //        database.RunStoredProcedure("MonthlyCounterStatus_ResetAll", parameters);
        //        myStartForm.cmdPrinterStatus.PerformClick();
        //    }

        //}

        private void dgPrinters_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgPrinters.Columns[e.ColumnIndex].ValueType.ToString() != "System.Drawing.Image")
            {
                return;
            }

            try
            {
                string clickedColumn = dgPrinters.Columns[e.ColumnIndex].Name;


                if (
                    clickedColumn.ToString() == "printerStatusImage"
                    && dgPrinters.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable
                    )
                {
                    // Check which column is selected, otherwise set NewColumn to null.
                    DataGridViewColumn newColumn = dgPrinters.Columns["printerStatus"];

                    DataGridViewColumn oldColumn = dgPrinters.SortedColumn;
                    ListSortDirection direction;

                    if (oldColumn == newColumn &&
                            dgPrinters.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }

                    // If no column has been selected, display an error dialog  box.
                    if (newColumn == null)
                    {
                        MessageBox.Show("Select a single column and try again.",
                            "Error: Invalid Selection", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgPrinters.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        dgPrinters.SortDirection = SortOrder.None;
                    }
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }
        }

        private void abrirRaízCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string printerIp = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;

            if (!pingIp(printerIp))
            {
                MessageBox.Show("El dispositivo no está disponible en la red en este momento", "Dispositivo desconectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int printerConnectionTypeId = Convert.ToInt32(dgPrinters.SelectedRows[0].Cells["printerConnectionTypeId"].Value);

            if(printerConnectionTypeId == Convert.ToInt32(PrinterConnectionType.USB))
            {
                using (NetworkShareAccesser.Access(printerIp, GlobalSetup.DefaultLocalDomainName, GlobalSetup.NetworkAdministrator, GlobalSetup.NetworkAdministratorPassword))
                {
                    try
                    {
                        Process.Start(@"\\" + printerIp + @"\C$\");
                    }
                    catch (Exception ee)
                    {
                        EventLogger.LogEvent(this, ee.Message.ToString(), ee);
                        MessageBox.Show(ee.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            else if(printerConnectionTypeId == 2)
            {
                DialogResult myDialogResult= MessageBox.Show("El tipo de Host (impresora de red) no soporta ingresar a la carpeta raíz.\n\n¿Desea abrir la dirección IP como carpeta?", "Error de conexión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (myDialogResult == DialogResult.OK)
                {
                    try
                    {
                        Process.Start(@"\\" + printerIp + @"\");
                    }
                        catch (Exception ee)
                    {
                        EventLogger.LogEvent(this, ee.Message.ToString(), ee);
                        MessageBox.Show(ee.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }

            }


        }

        private void otroEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShortcutHelper.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Vinculo.lnk", @"C:\Users\SONDA2\Desktop\USADOS\bat\Test.SNMP.bat");

            string targetComputerIp = "172.16.23.249";
            string printServerIp = "192.168.1.33";
            string printerQueueName = "AUDITORIA";

            FileManager myFileManager = new FileManager();

            StringBuilder installerBatText = new StringBuilder();
            installerBatText.Append("@echo ############ Ejecutable de proceso de Instalación de Impresoras ################" + Environment.NewLine);
            installerBatText.Append("@echo Bienvenido al asistente de instalacion de Impresoras by Wtamayom -Wilson Tamayo Morales-" + Environment.NewLine);
            installerBatText.Append(@":: Copiar en C:\Windows" + Environment.NewLine);
            installerBatText.Append(@":: Copiar acceso directo a ::C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup" + Environment.NewLine);
            installerBatText.Append("@echo Instalacion de impresoras en proceso..." + Environment.NewLine);
            installerBatText.Append("@echo Favor no cancelar." + Environment.NewLine);
            installerBatText.Append("@echo Si presenta algún inconveniente favor comunicarse a la mesa de ayuda." + Environment.NewLine);
            installerBatText.Append("@echo OFF" + Environment.NewLine);
            installerBatText.Append("@echo." + Environment.NewLine);
            installerBatText.Append(@"rundll32 printui.dll,PrintUIEntry /in /n \\" + printServerIp + @"\" + printerQueueName + @" /q" + Environment.NewLine);
            installerBatText.Append(@"rundll32 printui.dll,PrintUIEntry /y /n \\" + printServerIp + @"\" + printerQueueName + @" /" + Environment.NewLine);
            installerBatText.Append("@echo." + Environment.NewLine);

            FileManager.TextToAppend = installerBatText.ToString();

            //myFileManager.FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup).ToString();
            myFileManager.FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows).ToString();
            myFileManager.FileName = "PrinterInstaller.bat";
            myFileManager.Text = FileManager.TextToAppend;

            myFileManager.RemoveFile();
            myFileManager.CreateFile();
            myFileManager.WriteToFile();

            File.Copy(Application.StartupPath.ToString() + @"\PrinterInstaller\PrinterInstaller.bat.lnk", @"\\" + targetComputerIp + @"\C$\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\PrinterInstaller.bat.lnk");

            EventLogger.LogEvent(this, myFileManager.FolderPath + "\\" + myFileManager.FileName, null);
            EventLogger.LogEvent(this, FileManager.TextToAppend, null);
        }

        private void abrirIPEnElNavegadorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void despertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wakePrinterUP();
        }

        private void wakePrinterUP()
        {
            try
            {
                string areaIpAddress = (string)dgPrinters.SelectedRows[0].Cells["areaIpAddress"].Value;
                string areaQueueName = (string)dgPrinters.SelectedRows[0].Cells["areaQueueName"].Value;

                if (!pingIp(areaIpAddress))
                {
                    return;
                }

                    using (NetworkShareAccesser.Access(areaIpAddress, GlobalSetup.DefaultLocalDomainName, GlobalSetup.NetworkAdministrator, GlobalSetup.NetworkAdministratorPassword))
                {
                    File.Copy(@"C:\Sonda\SamsungPrinter\PrinterWakeUp.prn", @"\\" + areaIpAddress + @"\" + areaQueueName, true);
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);

            }
        }

        private void capturarImagenDeContadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgPrinters.SelectedRows.Count > 0)
            {
                FolderBrowserDialog myFolderBrowserDialog = new FolderBrowserDialog();
                myFolderBrowserDialog.Description = "Seleccione la carpeta donde se guardarán las capturas de pantalla";

                myFolderBrowserDialog.ShowDialog();

                string selectedFolder = myFolderBrowserDialog.SelectedPath;

                //Screen capture
                foreach (DataGridViewRow dgvRow in dgPrinters.SelectedRows)
                {
                    string urlUsage = dgvRow.Cells["urlUsage"].Value.ToString().Trim();
                    string printerSerial = dgvRow.Cells["valSerialNumber"].Value.ToString().Trim();
                    string areaName = dgvRow.Cells["areaName"].Value.ToString().Trim();
                    if (urlUsage.Trim() == string.Empty) { continue; }

                    string ipAddress = dgvRow.Cells["areaIpAddress"].Value.ToString();

                    WebCapture myWebCapture = new WebCapture();
                    myWebCapture.UrlToLoad = urlUsage;
                    myWebCapture.FileName = selectedFolder + "\\" + printerSerial + " - " + areaName;
                    myWebCapture.SaveCapture();
                }

            }
        }

        private void equiposAsociadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tónerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateEngine myDateEngine = new DateEngine();

            string readonlyHtmlChart = @".\webserver\root\amcharts_3.20.8.free\samples\tonerHistory.htm";
            string myHtml = File.ReadAllText(readonlyHtmlChart);

            myHtml = myHtml.Replace("{PAGE_TITLE}", "Hola mundo!");

            string randomString = Convert.ToString(DateTime.Now.Ticks);
            randomString = randomString.Substring(randomString.Length - 10, 10);

            FileManager myChartFileManager = new FileManager(Application.StartupPath + @"\webserver\root\amcharts_3.20.8.free\samples", DateEngine.CurrentDateInteger.ToString() + "_" + randomString + "_tonerHistory.html");


            myChartFileManager.RemoveFile();
            myChartFileManager.Text = myHtml;
            myChartFileManager.CreateFile();
            myChartFileManager.WriteToFile();
            string outPutUri = "file:///" + myChartFileManager.FullFilePath.Replace(@"\", "/");
            string outPutFile = "\"" +outPutUri + "\"";
            Console.WriteLine(outPutFile);
            //Process myProcess = Process.Start(Application.StartupPath + @"\Browser\CEF\CefBrowser.exe", outPutFile);

            //BrowserForm myForm = new BrowserForm();
            //myForm.ShowDialog();
            //myCefBrowser.LoadNewUrl(outPutFile);
            //myCefBrowser.Show();

            //myStartForm.AddBrowserTab("Sample", "Test", outPutUri);

        }
    }
}
