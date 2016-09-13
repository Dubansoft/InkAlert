
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
using FormValidation;
using SnmpSharpNet;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmAreaEdit : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        #region "References"

            Database database = new Database();
            StoredProcedureParameters[] parameters;
            PrinterSnmpUpdate myPrinter = new PrinterSnmpUpdate();
            IpAddress myIpAddress = new IpAddress();
            Trick myTrick = new Trick();
            BackgroundWorker myBackgroundAreaEditProcess = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            Area myArea = new Area();


        #endregion

        #region "Members"
            //the id of the selected area in the listview
            private int currentAreaId = 0;
            public int CurrentAreaId
            {
                get { return currentAreaId; }
                set { currentAreaId = value; }
            }

            //current error message
            private string error = "";
            public string Error
            {
                get { return error; }
                set { error = value; }
            }

            private string areaOperation = "";
            public string AreaOperation
            {
                get { return areaOperation; }
                set { areaOperation = value; }
            }

        #endregion

        public frmAreaEdit()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            myBackgroundAreaEditProcess.DoWork += new DoWorkEventHandler(myBackgroundAreaEditProcess_HardWork);
            myBackgroundAreaEditProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundAreaEditProcess_Completed);
            myBackgroundAreaEditProcess.WorkerReportsProgress = false;
            myBackgroundAreaEditProcess.WorkerSupportsCancellation = false;

        }

        private void frmAreaEdit_Load(object sender, EventArgs e)
        {

        }

        #region "Functions"

        internal void FillForm()
        {
            //Fill cmbStoryNumber items

            //Create dataTable StoriesTable that
            //will bind the cmbStoryNumber combo box

            DataTable myTable = new DataTable();
            myTable.TableName = "StoriesTable";

            DataRow row;
            myTable.Columns.Add(new DataColumn("Value", Type.GetType("System.String")));

            try
            {
                //Create row for Sótano

                row = myTable.NewRow();
                row["Value"] = "Sótano";
                myTable.Rows.Add(row);

                //Create and add rows for all stories from 1 to 100
                for (int i = 1; i < 101; i++)
                {
                    row = myTable.NewRow();
                    row["Value"] = "Piso ";
                    row["Value"] += i < 10 ? ("0" + i.ToString()) : i.ToString();
                    myTable.Rows.Add(row);
                }

                //Bind the cmbStoryNumber combo box
                cmbStoryNumber.DataSource = myTable;
                cmbStoryNumber.DisplayMember = "Value";
                cmbStoryNumber.ValueMember = "Value";

            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message.ToString(),e);
            }


            //Fill cmbPrinterLocationName
            myTrick.bindComboBox(cmbPrinterLocationName, "locationName", "id", "Location_Get", "dtLocations", null);


        }

        private bool getIpAddress(string address)
        {
            myIpAddress = new IpAddress(myPrinter.DefaultIpAddress);

            try
            {
                myIpAddress = new IpAddress(address.Trim());
                txtIpAddress.Text = myIpAddress.ToString();
                return true;
            }
            catch (Exception)
            {
                DialogResult dgResult = MessageBox.Show(string.Format("No se ha podido convertir el nombre de host {0} en una IPv4 válida. ¿Desea reemplazar la dirección actual por la dirección 0.0.0.0 por defecto?",txtHostName.Text.Trim()),"Conversión nombre de Host en IPv4",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (dgResult == DialogResult.Yes)
                {
                    txtIpAddress.Text = "0.0.0.0";
                }

                return false;
            }
        }

        /// <summary>
        /// Calls the worker that
        /// will perform a background operation for updating an area or
        /// adding a new one
        /// </summary>
        public void CallBackgroundWorker()
        {

            //Before calling the background worker, let's check it is NOT busy
            if (!myBackgroundAreaEditProcess.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgAreas
                myBackgroundAreaEditProcess.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "myBackgroundAreaEditProcess was called while it was still busy.",null);
            }

        }

        /// <summary>
        /// Reloads the dgAreas datagrid in the background.
        /// </summary>
        private void myBackgroundAreaEditProcess_HardWork(object sender, DoWorkEventArgs e)
        {

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            switch (AreaOperation)
            {
                case "Añadir":
                    if (myArea.AddNew() == 0)
                    {
                        //if there has been an error during user add
                        Error = myArea.Error;
                        goto ErrorMessage;
                    }
                    break;

                case "Actualizar":
                    if (!myArea.Update())
                    {
                        //if there has been an error during area update
                        Error = myArea.Error;
                        goto ErrorMessage;
                    }
                    break;

                default:
                    break;
            }


            e.Result = "OK";
            return;

        ErrorMessage:
            e.Result = this.Error;
            EventLogger.LogEvent(this, myArea.Error, null);

        }

        /// <summary>
        /// Runs when myBackgroundAreaEditProcess has finished doing its job
        /// </summary>
        /// <param name="sender">myBackgroundAreaEditProcess</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void myBackgroundAreaEditProcess_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);
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

            //Show loading image
            myStartForm.ToggleLoadingImage(this, false, loadingImage);

            //Disable cmdSave and cmdCancel
            this.cmdSave.Enabled = true;
            this.cmdCancel.Enabled = true;

            //set dialog result
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        #endregion

        #region "Interface Events"

        private void cmdSave_Click(object sender, EventArgs e)
        {
            this.AreaOperation = cmdSave.Text;

            //Disable cmdSave and cmdCancel
            this.cmdSave.Enabled = false;
            this.cmdCancel.Enabled = false;

            Match ipMatch = Regex.Match(txtIpAddress.Text.Trim(), @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");

            if(!FormValidate.ValidateTextbox(
                new TextBox[]
                {
                    txtAreaName,
                    txtHostName,
                    txtQueueName
                }
                ))
            {
                //Reenable cmdSave and cmdCancel
                this.cmdSave.Enabled = true;
                this.cmdCancel.Enabled = true;
                return;
            }


            if (cmbPrinterLocationName.SelectedIndex == -1)
            {
                Error = "Debe seleccionar una ubicación";
                goto ErrorMessage;
            }
            else if (cmbStoryNumber.SelectedIndex == -1)
            {
                Error = "Debe seleccionar un piso en el cual está ubicada el área";
                goto ErrorMessage;
            }
            else if (
                txtIpAddress.Text.Trim() == "..." || txtIpAddress.Text.Trim() == "0.0.0.0")
            {
                Error = "Debe escribir una dirección IP";
                goto ErrorMessage;
            }
            else if (!getIpAddress(txtIpAddress.Text) || !ipMatch.Success)
            {
                Error = "La dirección IP escrita no es válida";
                goto ErrorMessage;
            }


            //select case Update or New

            switch (cmdSave.Text)
            {

                case "Actualizar":

                    //parameters and db query to check if the entered area name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "areas");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE areas.areaName='" + txtAreaName.Text + "' AND areas.id<>" + CurrentAreaId.ToString());

                    database.Error = String.Empty;

                    int areaUpdateCount = database.CountRows("__Counter", parameters);

                    if (areaUpdateCount > 0)
                    {
                        //if the entered area name user  already exists
                        Error = "El área '" + txtAreaName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the area instance we created before the textbox check

                    myArea.Id = this.CurrentAreaId;
                    myArea.AreaName = txtAreaName.Text.Trim();
                    myArea.LocationId = (int)cmbPrinterLocationName.SelectedValue;
                    myArea.HostName = txtHostName.Text.Trim();
                    myArea.IpAddress = myIpAddress;
                    myArea.PrinterQueueName = txtQueueName.Text.Trim();
                    myArea.StoryNumber = cmbStoryNumber.SelectedValue.ToString();

                    CallBackgroundWorker();

                    break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered area name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "areas");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE areas.areaName='" + txtAreaName.Text + "'");

                    database.Error = String.Empty;
                    int areaAddCount = database.CountRows("__Counter", parameters);

                    if (areaAddCount > 0)
                    {
                        //if the area name user entered already exists
                        Error = "El área '" + txtAreaName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the area instance we created

                    myArea.AreaName = txtAreaName.Text.Trim();
                    myArea.LocationId = (int)cmbPrinterLocationName.SelectedValue;
                    myArea.HostName = txtHostName.Text.Trim();
                    myArea.IpAddress = myIpAddress;
                    myArea.PrinterQueueName = txtQueueName.Text.Trim();
                    myArea.StoryNumber = cmbStoryNumber.SelectedValue.ToString();

                    CallBackgroundWorker();

                    break;

                default:
                    break;
            }

            //exit form and prevent empty message from showing
            return;

        ErrorMessage:
            MessageBox.Show(this.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //Disable cmdSave and cmdCancel
            this.cmdSave.Enabled = true;
            this.cmdCancel.Enabled = true;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdGetIp_Click(object sender, EventArgs e)
        {
            getIpAddress(txtHostName.Text);
        }

        private void txtIpAddress_Leave(object sender, EventArgs e)
        {
            getIpAddress(txtIpAddress.Text);
        }
        #endregion

        private void txtAreaName_KeyUp(object sender, KeyEventArgs e)
        {
            txtQueueName.Text = txtAreaName.Text.Replace(" ", "_");
        }
    }
}
