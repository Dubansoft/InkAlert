
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

using FileHelper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmPrinterSerial : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        PrinterSerial myPrinterSerial;
        Database database = new Database();
        private StoredProcedureParameters[] parameters;

        public BackgroundWorker MyBackgroundPrinterSerialUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmPrinterSerial myPrinterSerialForm = Application.OpenForms.OfType<frmPrinterSerial>().FirstOrDefault();
        ColorConverter myConverter = new ColorConverter();


        #endregion

        #region "Members"

        private int currentPrinterSerialId = 0;
        public int CurrentPrinterSerialId
        {
            get { return currentPrinterSerialId; }
            set { currentPrinterSerialId = value; }
        }

        private int currentAreaId = 0;
        public int CurrentAreaId
        {
            get { return currentAreaId; }
            set { currentAreaId = value; }
        }
        private string printerSerialOperation = "";
        public string PrinterSerialOperation
        {
            get { return printerSerialOperation; }
            set { printerSerialOperation = value; }
        }

        #endregion

        public frmPrinterSerial()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundPrinterSerialUpdater
            MyBackgroundPrinterSerialUpdater.DoWork += new DoWorkEventHandler(MyBackgroundPrinterSerialUpdater_HardWork);
            MyBackgroundPrinterSerialUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundPrinterSerialUpdater_Completed);
            MyBackgroundPrinterSerialUpdater.WorkerReportsProgress = false;
            MyBackgroundPrinterSerialUpdater.WorkerSupportsCancellation = false;

            dgPrinterSerials.AssignedContextMenuStrip = this.contextMenuPrinterSerials;
            dgPrinterSerials.ColumnsToBeFiltered = new string[]
            {
                "printerCommercialStatus",
                "printerSerialName",
                "printerMakeName",
                "areaName",
                "printerTypeName",
                "printerColor",
                "printerCapacity",
                "printerDuplex",
                "monthlyDuty",
                "printerColorId",
                "ramMemory",
                "hddCapacity"
            };
            dgPrinterSerials.CurrentFilterString = "(printerCommercialStatusId < 5)";
        }

        private void PrinterSerials_Load(object sender, EventArgs e){}

        #region "Functions"


        /// <summary>
        /// Shows the loading image and call the process that
        /// refreshes dgPrinterSerials datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundPrinterSerialUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgPrinterSerials
                MyBackgroundPrinterSerialUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundPrinterSerialUpdater was called while it was still busy.",null);
            }
        }

        private void MyBackgroundPrinterSerialUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdAreas in parent form while this thread is
            //running
            myStartForm.cmdPrinterSerials.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de modelos. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myPrinterSerial = new PrinterSerial();
            if (!myPrinterSerial.Read())
            {
                //if there is an error while reading the database,
                //send the results back to the main thread
                e.Result = myPrinterSerial.Error;

                EventLogger.LogEvent(this, myPrinterSerial.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }


        /// <summary>
        /// Runs when MyBackgroundPrinterSerialUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundPrinterSerialUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundPrinterSerialUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                dgPrinterSerials.SetDataSource(myPrinterSerial.Table);
                //dgPrinterSerials.DtDatagridSource = myPrinterSerial.Table;
                //dgPrinterSerials.DatasourceRefreshPending = true;

                //string[] visibleColumns = { "printerSerialName", "printerMakeName", "printerTypeName", "printerColor", "printerCapacity", "monthlyDuty", "ramMemory", "hddCapacity", "printerDuplex" };
                //foreach (DataGridViewTextBoxColumn column in dgPrinterSerials.Columns)
                //{
                //    if (!visibleColumns.Contains(column.Name.ToString()))
                //    {
                //        column.Visible = false;
                //    }
                //}

                //Set the datasource for dgAreas datagrid
                dgPrinterSerials.SetDataSource(myPrinterSerial.Table);
                //dgPrinterSerials.DtDatagridSource = myPrinterSerial.Table;
                //dgPrinterSerials.DatasourceRefreshPending = true;

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} modelos en la lista", myPrinterSerial.Table.Rows.Count.ToString()));
            }
            else if (e.Cancelled)
            {
                //Set parent main status if worker job was cancelled
                myStartForm.UpdateStatus("Operación cancelada", 0);
            }
            else if ((string)e.Result != "OK")
            {
                //Set parent main status if an error ocurred
                myStartForm.UpdateStatus("Ha ocurrido un error", 0);
                //Set parent counters status
                myStartForm.UpdateStatusCounters("No se ha podido completar la operación solicitada.");
            }

            //Enable cmdAreas
            myStartForm.cmdPrinterSerials.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgPrinterSerials.SelectedRows.Count > 0)
            {
                handleNewPrinterSerialForm("Actualizar");
            }
        }


        private void dgPrinterSerials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewPrinterSerialForm("Añadir");
        }

        private bool handleNewPrinterSerialForm(string action)
        {



            //Creates a new instance of frmPrinterSerialEdit
            frmPrinterEdit myPrinterSerialEditForm = new frmPrinterEdit();

            //Fill the controls in the new printerSerialForm instance
            myPrinterSerialEditForm.FillForm();

            myPrinterSerialEditForm.CurrentPrinterId = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["id"].Value);

            if (action == "Añadir")
            {

                try
                {
                    myPrinterSerialEditForm.cmbPrinterArea.Enabled = false;
                    myPrinterSerialEditForm.cmbPrinterArea.SelectedIndex = -1;
                    myPrinterSerialEditForm.cmbPrinterLocation.Enabled = false;
                    myPrinterSerialEditForm.cmbPrinterLocation.SelectedIndex = -1;
                    myPrinterSerialEditForm.cmbPrinterMakeName.Enabled = true;
                    myPrinterSerialEditForm.cmbPrinterModel.Enabled = true;
                    myPrinterSerialEditForm.cmbPrinterSerial.DropDownStyle = ComboBoxStyle.DropDown;
                    myPrinterSerialEditForm.txtSerialFilter.Enabled = false;
                    myPrinterSerialEditForm.txtSerialFilter.Visible = false;
                    myPrinterSerialEditForm.cmbPrinterSerial.Location = new System.Drawing.Point(24, 42);
                    myPrinterSerialEditForm.cmbPrinterSerial.Width = 522;
                    myPrinterSerialEditForm.lblAsterisq.Visible = false;
                    myPrinterSerialEditForm.lblSerialFilter.Visible = false;
                    myPrinterSerialEditForm.lblLocation.Enabled = false;
                    myPrinterSerialEditForm.lblArea.Enabled = false;
                    myPrinterSerialEditForm.cmbPrinterConnectionType.SelectedValue = (int)PrinterConnectionType.SinDefinir;
                    myPrinterSerialEditForm.cmbPrinterConnectionType.Enabled = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }else if(action == "Actualizar")
            {
                myPrinterSerialEditForm.cmbPrinterArea.Enabled = false;
                myPrinterSerialEditForm.cmbPrinterArea.SelectedIndex = -1;
                myPrinterSerialEditForm.cmbPrinterLocation.Enabled = false;
                myPrinterSerialEditForm.cmbPrinterLocation.SelectedIndex = -1;
                myPrinterSerialEditForm.cmbPrinterMakeName.Enabled = true;
                myPrinterSerialEditForm.cmbPrinterModel.Enabled = true;
                myPrinterSerialEditForm.cmbPrinterSerial.DropDownStyle = ComboBoxStyle.DropDown;
                myPrinterSerialEditForm.txtSerialFilter.Enabled = false;
                myPrinterSerialEditForm.txtSerialFilter.Visible = false;
                myPrinterSerialEditForm.cmbPrinterSerial.Location = new System.Drawing.Point(24, 42);
                myPrinterSerialEditForm.cmbPrinterSerial.Width = 522;
                myPrinterSerialEditForm.lblAsterisq.Visible = false;
                myPrinterSerialEditForm.lblSerialFilter.Visible = false;
                myPrinterSerialEditForm.lblLocation.Enabled = false;
                myPrinterSerialEditForm.lblArea.Enabled = false;

                if(Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerCommercialStatusId"].Value) != (int)PrinterCommercialStatus.Produccion)
                {
                    myPrinterSerialEditForm.cmbPrinterConnectionType.Enabled = false;
                }

                myPrinterSerialEditForm.cmbPrinterConnectionType.SelectedValue = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerConnectionTypeId"].Value);
                myPrinterSerialEditForm.cmbPrinterSerial.Text = dgPrinterSerials.SelectedRows[0].Cells["printerSerial"].Value.ToString();
                myPrinterSerialEditForm.cmbPrinterMakeName.SelectedValue = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerMakeId"].Value);
                myPrinterSerialEditForm.cmbPrinterModel.SelectedValue = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerModelId"].Value);
            }

            myPrinterSerialEditForm.Text = action + " serial de impresora";
            PrinterSerialOperation = action;
            myPrinterSerialEditForm.cmdSave.Text = PrinterSerialOperation;

            myPrinterSerialEditForm.ShowDialog();

            if (myPrinterSerialEditForm.DialogResult == DialogResult.OK)
            {
                CallBackgroundWorker();

                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if there are selected rows
            if (dgPrinterSerials.SelectedRows.Count > 0)
            {
                //ask users whether to delete or not the printer
                DialogResult result = MessageBox.Show("¿Eliminar tipo de impresora?", "Eliminar tipo de impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", CurrentPrinterSerialId.ToString());
                    if (database.RunStoredProcedure("PrinterSerial_Remove", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del modelo de impresora. " + database.Error);
                    }
                }
            }
        }

        private void setCurrentPrinterSerialId()
        {
            if (dgPrinterSerials.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local CurrentPrinterSerialId
                CurrentPrinterSerialId = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["id"].Value);

                try
                {
                    CurrentAreaId = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerAreaId"].Value);
                }
                catch (Exception ee)
                {
                    CurrentAreaId = 0;
                    EventLogger.LogEvent(this, ee.Message.ToString(), null);
                }

            }
        }

        private void dgPrinterSerials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterSerialId();
        }

        private void dgPrinterSerials_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentPrinterSerialId();
        }

        private void dgPrinterSerials_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterSerialId();
        }

        private void cambiarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgPrinterSerials.SelectedRows.Count > 0)
            {
                frmChangePrinterCommercialStatus myChangePrinterCommercialStatusForm = new frmChangePrinterCommercialStatus();

                myChangePrinterCommercialStatusForm.WhoOpenedThis = this;
                myChangePrinterCommercialStatusForm.CurrentPrinterId = (int)dgPrinterSerials.SelectedRows[0].Cells["id"].Value;
                myChangePrinterCommercialStatusForm.CurrentAreaId = Convert.ToInt32(dgPrinterSerials.SelectedRows[0].Cells["printerAreaId"].Value);
                myChangePrinterCommercialStatusForm.SelectedPrinterSerialDataRow = dgPrinterSerials.SelectedRows[0];

                DialogResult result = myChangePrinterCommercialStatusForm.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    myStartForm.cmdPrinterSerials.PerformClick();
                }
            }
        }

        private void dgPrinterSerials_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //This will loop all of the rows every time they're sorted or
                //reloaded
                foreach (DataGridViewRow row in dgPrinterSerials.Rows)
                {
                    PrinterCommercialStatus printerCommercialStatus = (PrinterCommercialStatus)row.Cells["printerCommercialStatusId"].Value;

                    Color myCellColor = Color.White;

                    switch (printerCommercialStatus)
                    {
                        case PrinterCommercialStatus.Produccion:
                            myCellColor = Color.LightGreen;
                            break;
                        case PrinterCommercialStatus.Contingencia:
                            myCellColor = Color.LightSkyBlue;
                            break;
                        case PrinterCommercialStatus.Reparacion:
                            myCellColor = Color.IndianRed;
                            break;
                        case PrinterCommercialStatus.Sin_definir:
                            myCellColor = Color.Silver;
                            break;
                        case PrinterCommercialStatus.Eliminada:
                            myCellColor = Color.LightSalmon;
                            break;
                        default:
                            myCellColor = Color.White;
                            break;
                    }

                    row.Cells["printerCommercialStatus"].Style.BackColor = myCellColor;

                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }
        }
    }
}
