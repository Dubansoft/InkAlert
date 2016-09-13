
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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmICounterCycleEdit : BaseForms.frmGeneralBase
    {

        #region "References"

            Database database = new Database(); 
            StoredProcedureParameters[] parameters;
            Trick myTrick = new Trick();
            BackgroundWorker myBackgroundICounterCycleEditProcess = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            ICounterCycle myICounterCycle = new ICounterCycle();
            
            
        #endregion

        #region "Members"
            //the id of the selected iCounterCycle in the listview
            private int currentICounterCycleId = 0;
            public int CurrentICounterCycleId
            {
                get { return currentICounterCycleId; }
                set { currentICounterCycleId = value; }
            }

            //current error message
            private string error = "";
            public string Error
            {
                get { return error; }
                set { error = value; }
            }

            private string iCounterCycleOperation = "";
            public string ICounterCycleOperation
            {
                get { return iCounterCycleOperation; }
                set { iCounterCycleOperation = value; }
            }

        #endregion

        public frmICounterCycleEdit()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundICounterCycleUpdater
            myBackgroundICounterCycleEditProcess.DoWork += new DoWorkEventHandler(myBackgroundICounterCycleEditProcess_HardWork);
            myBackgroundICounterCycleEditProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundICounterCycleEditProcess_Completed);
            myBackgroundICounterCycleEditProcess.WorkerReportsProgress = false;
            myBackgroundICounterCycleEditProcess.WorkerSupportsCancellation = false;
            
        }

        private void frmICounterCycleEdit_Load(object sender, EventArgs e)
        {
            
        }

        #region "Functions"
        
        /// <summary>
        /// Calls the worker that 
        /// will perform a background operation for updating an iCounterCycle or 
        /// adding a new one
        /// </summary>
        public void CallBackgroundWorker()
        {

            //Before calling the background worker, let's check it is NOT busy
            if (!myBackgroundICounterCycleEditProcess.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgICounterCycles
                myBackgroundICounterCycleEditProcess.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "myBackgroundICounterCycleEditProcess was called while it was still busy.",null);
            }

        }

        /// <summary>
        /// Reloads the dgICounterCycles datagrid in the background.
        /// </summary>
        private void myBackgroundICounterCycleEditProcess_HardWork(object sender, DoWorkEventArgs e)
        {

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            switch (ICounterCycleOperation)
            {
                case "Añadir":
                    if (myICounterCycle.AddNew() == 0)
                    {
                        //if there has been an error during user add
                        Error = myICounterCycle.Error;
                        goto ErrorMessage;
                    }
                    break;

                case "Actualizar":
                    if (!myICounterCycle.Update())
                    {
                        //if there has been an error during iCounterCycle update
                        Error = myICounterCycle.Error;
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
            EventLogger.LogEvent(this, myICounterCycle.Error, null);

        }

        /// <summary>
        /// Runs when myBackgroundICounterCycleEditProcess has finished doing its job
        /// </summary>
        /// <param name="sender">myBackgroundICounterCycleEditProcess</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void myBackgroundICounterCycleEditProcess_Completed(object sender, RunWorkerCompletedEventArgs e)
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
            this.ICounterCycleOperation = cmdSave.Text;

            //Disable cmdSave and cmdCancel
            this.cmdSave.Enabled = false;
            this.cmdCancel.Enabled = false;

            //text validation
            if (txtICounterCycleName.Text.Trim() == string.Empty)
            {
                Error = "Debe escribir un nombre para el ciclo de contador";
                goto ErrorMessage;
            }

            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered iCounterCycle name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "iCounterCycles");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE iCounterCycles.iCounterCycleName='" + txtICounterCycleName.Text + "' AND iCounterCycles.id<>" + CurrentICounterCycleId.ToString());

                    database.Error = String.Empty;

                    int iCounterCycleUpdateCount = database.CountRows("__Counter", parameters);

                    if (iCounterCycleUpdateCount > 0)
                    {
                        //if the entered iCounterCycle name user  already exists
                        Error = "El ciclo de contador '" + txtICounterCycleName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the iCounterCycle instance we created before the textbox check

                    myICounterCycle.Id = this.CurrentICounterCycleId;
                    myICounterCycle.ICounterCycleName = txtICounterCycleName.Text.Trim();
                    myICounterCycle.ICounterCycleYear = dateICounterCycles.Value.Year;
                    myICounterCycle.ICounterCycleMonth = dateICounterCycles.Value.Month;

                    CallBackgroundWorker();

                    break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered iCounterCycle name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "iCounterCycles");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE iCounterCycles.iCounterCycleName='" + txtICounterCycleName.Text + "'");

                    database.Error = String.Empty;
                    int iCounterCycleAddCount = database.CountRows("__Counter", parameters);

                    if (iCounterCycleAddCount > 0)
                    {
                        //if the iCounterCycle name user entered already exists
                        Error = "El ciclo de contador '" + txtICounterCycleName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the iCounterCycle instance we created

                    myICounterCycle.ICounterCycleName = txtICounterCycleName.Text.Trim();
                    myICounterCycle.ICounterCycleYear = dateICounterCycles.Value.Year;
                    myICounterCycle.ICounterCycleMonth = dateICounterCycles.Value.Month;

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

        #endregion

    }
}
