
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
using SnmpSharpNet;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmPrinterEdit : InkAlert.Forms.BaseForms.frmGeneralBase 
    {


        #region "References"

            Database database = new Database(); 
            StoredProcedureParameters[] parameters;
            PrinterSnmpUpdate myPrinter = new PrinterSnmpUpdate();
            PrinterSerial myPrinterSerial = new PrinterSerial();
            IpAddress myIpAddress = new IpAddress();
            Trick myTrick = new Trick();
            BackgroundWorker MyBackgroundPrinterEditProcess = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentPrinterId = 0;
        public int CurrentPrinterId
        {
            get { return currentPrinterId; }
            set { currentPrinterId = value; }
        }

        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private string printerOperation = "";
        public string PrinterOperation
        {
            get { return printerOperation; }
            set { printerOperation = value; }
        }

        private string printerSerialBeingEdited = "**EMPTY-STRING**";
        public string PrinterSerialBeingEdited
        {
            get { return printerSerialBeingEdited; }
            set { printerSerialBeingEdited = value; }
        }
        #endregion

        public frmPrinterEdit()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            MyBackgroundPrinterEditProcess.DoWork += new DoWorkEventHandler(myBackgroundPrinterEditProcess_HardWork);
            MyBackgroundPrinterEditProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundPrinterEditProcess_Completed);
            MyBackgroundPrinterEditProcess.WorkerReportsProgress = false;
            MyBackgroundPrinterEditProcess.WorkerSupportsCancellation = false;
        }

        private void frmPrinterEdit_Load(object sender, EventArgs e){}

        #region "Functions"

        internal void FillForm()
        {

            try
            {
                //read from database and create the datatable
                if (cmdSave.Text == "Actualizar")
                {
                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_serialNumberBeingEdited", PrinterSerialBeingEdited);
                    database.ReadTable("PrinterSerial_GetAvailable", "dtPrinterSerials", null, parameters);
                }
                else if (cmdSave.Text == "Añadir")
                {
                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_serialNumberBeingEdited", PrinterSerialBeingEdited);
                    database.ReadTable("PrinterSerial_GetAvailable", "dtPrinterSerials", null, parameters);
                }


                //Fill the comboBox with display member and value member
                cmbPrinterSerial.DisplayMember = "printerSerial";
                cmbPrinterSerial.ValueMember = "id";
                cmbPrinterSerial.DataSource = database.DbDataset1.Tables["dtPrinterSerials"];

            }
            catch (Exception)
            {

                throw;
            }

            //Fill cmbPrinterLocationName

            myTrick.bindComboBox(cmbPrinterLocation, "locationName", "id", "Location_Get", "dtLocations", null);

            //Fill cmbPrinterMake
            myTrick.bindComboBox(cmbPrinterMakeName, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

            ////Fill cmbConnectionType
            myTrick.bindComboBox(cmbPrinterConnectionType, "printerConnectionType", "id", "PrinterConnectionType_Get", "dtPrinterConnectionTypes");


        }

        /// <summary>
        /// Calls the worker that 
        /// will perform a background operation for updating an area or 
        /// adding a new one
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundPrinterEditProcess.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Disable cmdSave and cmdCancel
                this.cmdSave.Enabled = false;
                this.cmdCancel.Enabled = false;

                //Set parent form status
                myStartForm.UpdateStatus("Procesando información, por favor espere...", 0);

                //Run background worker to update or add a new area
                MyBackgroundPrinterEditProcess.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundPrinterEditProcess was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgPrinters datagrid in the background.
        /// </summary>
        private void myBackgroundPrinterEditProcess_HardWork(object sender, DoWorkEventArgs e)
        {

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            switch (PrinterOperation)
            {
                case "Añadir":
                    if (myPrinterSerial.AddNew() == 0)
                    {
                        //if there has been an error during user add
                        Error = myPrinterSerial.Error;
                        goto ErrorMessage;
                    }
                    break;

                case "Actualizar":
                    if (!myPrinterSerial.Update())
                    {
                        //if there has been an error during area update
                        Error = myPrinter.Error;
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
            
            EventLogger.LogEvent(this, myPrinter.Error, null);

        }
        
        /// <summary>
        /// Runs when myBackgroundAreaEditProcess has finished doing its job
        /// </summary>
        /// <param name="sender">myBackgroundAreaEditProcess</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void myBackgroundPrinterEditProcess_Completed(object sender, RunWorkerCompletedEventArgs e)
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
            this.PrinterOperation = cmdSave.Text;

            // clear printer class instance
            //myPrinter = new PrinterSnmpUpdate();
            

            //text validation
            if (cmbPrinterSerial.Text.Trim() == string.Empty && cmbPrinterSerial.Enabled)
            {
                Error = "Debe seleccionar el serial de la impresora";
                goto ErrorMessage;
            }
            else if (cmbPrinterMakeName.SelectedIndex == -1 && cmbPrinterMakeName.Enabled)
            {
                Error = "Debe seleccionar una marca";
                goto ErrorMessage;
            }
            else if (cmbPrinterModel.SelectedIndex == -1 && cmbPrinterModel.Enabled)
            {
                Error = "Debe seleccionar un modelo";
                goto ErrorMessage;
            }

            if (cmdSave.Text != "Añadir")
            {

                if (cmbPrinterLocation.SelectedIndex == -1 && cmbPrinterLocation.Enabled)
                {
                    Error = "Debe seleccionar una ubicación";
                    goto ErrorMessage;
                }
                else if (cmbPrinterArea.SelectedIndex == -1 && cmbPrinterArea.Enabled)
                {
                    Error = "Debe seleccionar un área";
                    goto ErrorMessage;
                }
                else if (cmbPrinterConnectionType.SelectedIndex == -1 && cmbPrinterConnectionType.Enabled)
                {
                    Error = "Debe seleccionar un tipo de conexión";
                    goto ErrorMessage;
                }
            }

            if (Convert.ToInt32(cmbPrinterConnectionType.SelectedValue) == (int)PrinterConnectionType.UsbyRed || Convert.ToInt32(cmbPrinterConnectionType.SelectedValue) == (int)PrinterConnectionType.SinDefinir)
            {
                Error = "No se puede asignar el valor seleccionado para el tipo de conexión. Los valores válidos son USB o Red";
                goto ErrorMessage;
            }
            //select case Update or New

            switch (cmdSave.Text)
            {

                case "Actualizar":

                    //parameters and db query to check if the entered printer name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerserials");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerserials.printerSerial='" + cmbPrinterSerial.Text.ToString() + "' AND printerserials.id<>" + CurrentPrinterId.ToString());

                    database.Error = String.Empty;
                    int printerUpdateCount = database.CountRows("__Counter", parameters);


                    if (printerUpdateCount > 0)
                    {
                        //if the entered printer name user  already exists
                        Error = "El serial '" + cmbPrinterSerial.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printer instance we created before the textbox check

                    myPrinterSerial.Id =this.CurrentPrinterId;
                    myPrinterSerial.PrinterSerialNumber = cmbPrinterSerial.Text.Trim();
                    myPrinterSerial.PrinterModelId = (int)cmbPrinterModel.SelectedValue;
                    myPrinterSerial.PrinterConnectionTypeId = (int)cmbPrinterConnectionType.SelectedValue;

                    frmChangePrinterCommercialStatus myFrmChangePrinterCommercialStatus = Application.OpenForms.OfType<frmChangePrinterCommercialStatus>().FirstOrDefault();
                    if (myFrmChangePrinterCommercialStatus != null)
                    {
                        myFrmChangePrinterCommercialStatus.NewAreaId = Convert.ToInt32(cmbPrinterArea.SelectedValue);
                    }

                    CallBackgroundWorker();

                    break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered printer serial already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerserials");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerserials.printerSerial='" + cmbPrinterSerial.Text.ToString() + "'");

                    database.Error = String.Empty;
                    int printerAddCount = database.CountRows("__Counter", parameters);

                    if (printerAddCount > 0)
                    {
                        //if the printer serial user entered already exists
                        Error = "Ya hay una impresora registrada con el serial especificado.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printer instance we created

                    myPrinterSerial.PrinterSerialNumber = cmbPrinterSerial.Text.Trim();
                    myPrinterSerial.PrinterModelId = Convert.ToInt32(cmbPrinterModel.SelectedValue);


                    CallBackgroundWorker();

                    break;

                default:
                    break;
            }

            //exit form and prevent empty message from showing
            return;
            
        ErrorMessage:
            MessageBox.Show(this.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void cmbPrinterMakeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                myTrick.fillLocalCmb_Custom(cmbPrinterMakeName, cmbPrinterModel, "dtPrinterModels", "SELECT * FROM printerModels WHERE printerMakeId=" + (int)cmbPrinterMakeName.SelectedValue, "PrinterModel_Get", "printerModelName", "id");
            }
        }

        private void cmbPrinterLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbPrinterLocation.SelectedIndex > -1)
            {
                string customQuery = @"SELECT
                                    areas.id,
                                    areas.areaName
                                    FROM areas
                                    WHERE areas.locationId = " + (int)cmbPrinterLocation.SelectedValue + @"
                                    AND
                                    (SELECT COUNT(*) FROM printerserials WHERE printerserials.printerAreaId = areas.id) = 0
                                    ;";

                myTrick.fillLocalCmb_Custom(cmbPrinterLocation, cmbPrinterArea, "dtAreas", customQuery, "Area_Get", "areaName", "id");
            }
        }

        #endregion

        private void txtSerialFilter_TextChanged(object sender, EventArgs e)
        {
            lblAsterisq.Visible = false;

            if(txtSerialFilter.Text.Trim() == "")
            {
                lblAsterisq.Visible = true;
                return;
            }

            if (txtSerialFilter.Text.Contains("'") ||
                txtSerialFilter.Text.Contains("<") ||
                txtSerialFilter.Text.Contains(">") ||
                txtSerialFilter.Text.Contains("=") )
            {
                MessageBox.Show("Se han detectado caracteres no válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DataView dvFilteredSerials = new DataView(database.DbDataset1.Tables["dtPrinterSerials"]);
            dvFilteredSerials.RowFilter = "printerSerial like '%" + txtSerialFilter.Text.Trim() + "%'";
            cmbPrinterSerial.DisplayMember = "printerSerial";
            cmbPrinterSerial.ValueMember = "id";
            cmbPrinterSerial.DataSource = dvFilteredSerials;
        }

        private void cmbPrinterSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPrinterSerial.SelectedIndex > -1)
            {
                DataRow result = database.DbDataset1.Tables["dtPrinterSerials"].Select("printerSerial = '" + cmbPrinterSerial.Text + "'").First();
                cmbPrinterModel.SelectedValue = result["printerModelId"];
                cmbPrinterMakeName.SelectedValue = result["printerMakeId"];

            }
            
        }

        private void cmbPrinterArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedValue = 0;
            try{
                selectedValue = (int)cmbPrinterArea.SelectedValue;
            }
            catch{}
            
            if (selectedValue == 0)
            {cmbPrinterArea.SelectedIndex = -1;}
        }
        
    }
}
