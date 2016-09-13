
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
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmLocationEdit : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        Database database = new Database(); 
        StoredProcedureParameters[] parameters;
        Location myLocation = new Location();
        BackgroundWorker myBackgroundLocationEditProcess = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();

        #endregion

        #region "Members"

        //the id of the selected location in the listview
        private int currentLocationId = 0;
        public int CurrentLocationId
        {
            get { return currentLocationId; }
            set { currentLocationId = value; }
        }

        //current error message
        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private string locationOperation = "";
        public string LocationOperation
        {
            get { return locationOperation; }
            set { locationOperation = value; }
        }

        #endregion

        public frmLocationEdit()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            myBackgroundLocationEditProcess.DoWork += new DoWorkEventHandler(myBackgroundLocationEditProcess_HardWork);
            myBackgroundLocationEditProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundLocationEditProcess_Completed);
            myBackgroundLocationEditProcess.WorkerReportsProgress = false;
            myBackgroundLocationEditProcess.WorkerSupportsCancellation = false;
        }


        #region "Functions"

        /// <summary>
        /// Calls the worker that 
        /// will perform a background operation for updating a location or 
        /// adding a new one
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!myBackgroundLocationEditProcess.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Disable cmdSave and cmdCancel
                this.cmdSave.Enabled = false;
                this.cmdCancel.Enabled = false;

                //Set parent form status
                myStartForm.UpdateStatus("Procesando información, por favor espere...", 0);

                //Run background worker to update or add a new location
                myBackgroundLocationEditProcess.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "myBackgroundLocationEditProcess was called while it was still busy.",null);
            }


        }


        /// <summary>
        /// Reloads the dgLocations datagrid in the background.
        /// </summary>
        private void myBackgroundLocationEditProcess_HardWork(object sender, DoWorkEventArgs e)
        {

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            switch (LocationOperation)
            {
                case "Añadir":
                    if (myLocation.AddNew() == 0)
                    {
                        //if there has been an error during location add
                        Error = myLocation.Error;
                        goto ErrorMessage;
                    }
                    break;

                case "Actualizar":
                    if (!myLocation.Update())
                    {
                        //if there has been an error during location update
                        Error = myLocation.Error;
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
            EventLogger.LogEvent(this, myLocation.Error, null);

        }


        /// <summary>
        /// Runs when myBackgroundLocationEditProcess has finished doing its job
        /// </summary>
        /// <param name="sender">myBackgroundLocationEditProcess</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void myBackgroundLocationEditProcess_Completed(object sender, RunWorkerCompletedEventArgs e)
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

            //Enable cmdSave and cmdCancel
            this.cmdSave.Enabled = true;
            this.cmdCancel.Enabled = true;

            //set dialog result
            this.DialogResult = DialogResult.OK;
            this.Close();

        }


        #endregion

        private void frmLocationEdit_Load(object sender, EventArgs e)
        {
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            this.LocationOperation = cmdSave.Text;

            //text validation
            if(txtLocationName.Text.Trim() == ""){
                Error = "Debe escribir un nombre de ubicación";
                goto ErrorMessage;
            }
            else if (txtLocationDescription.Text.Trim() == "")
            {
                Error = "Debe escribir una descripción";
                goto ErrorMessage;
            }
            
            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered location name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "locations");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE locations.locationName='" + txtLocationName.Text + "' AND locations.id<>" + CurrentLocationId.ToString());

                    database.Error = String.Empty;
                    int locationUpdateCount = database.CountRows("__Counter", parameters);


                    if (locationUpdateCount > 0)
                    {
                        //if the entered location name user  already exists
                        Error = "La ubicación '" + txtLocationName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the location instance we created before the textbox check

                    myLocation.Id =this.CurrentLocationId;
                    myLocation.LocationName = txtLocationName.Text;
                    myLocation.LocationDescription = txtLocationDescription.Text;

                    CallBackgroundWorker();

                        break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered location name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "locations");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE locations.locationName='" + txtLocationName.Text + "'");

                    database.Error = String.Empty;
                    int locationAddCount = database.CountRows("__Counter", parameters);

                    if (locationAddCount > 0)
                    {
                        //if the location name user entered already exists
                        Error = "La ubicación '" + txtLocationName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the location instance we created

                    myLocation.LocationName = txtLocationName.Text;
                    myLocation.LocationDescription  = txtLocationDescription.Text;

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

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
