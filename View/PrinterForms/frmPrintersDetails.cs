
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
    public partial class frmPrinterDetails : InkAlert.Forms.BaseForms.frmGeneralBase 
    {


        #region "References"

            Database database = new Database(); 
            StoredProcedureParameters[] parameters;
            PrinterSnmpUpdate myPrinter = new PrinterSnmpUpdate();
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
        #endregion

        public frmPrinterDetails()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            MyBackgroundPrinterEditProcess.DoWork += new DoWorkEventHandler(myBackgroundPrinterEditProcess_HardWork);
            MyBackgroundPrinterEditProcess.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myBackgroundPrinterEditProcess_Completed);
            MyBackgroundPrinterEditProcess.WorkerReportsProgress = false;
            MyBackgroundPrinterEditProcess.WorkerSupportsCancellation = false;
        }

        private void frmPrinterEdit_Load(object sender, EventArgs e){
            CallBackgroundWorker();
        }

        #region "Functions"

        internal void FillForm()
        {
            

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

            try
            {
                //Capture the BackgroundWorker that fired the event
                BackgroundWorker sendingWorker = (BackgroundWorker)sender;

                parameters = new StoredProcedureParameters[1];
                parameters[0] = new StoredProcedureParameters("_id", CurrentPrinterId.ToString());
                database.ReadTable("Printer_Get_Details", "dtPrinterDetails_" + CurrentPrinterId.ToString(), null, parameters);



                e.Result = "OK";
                return;
            }
            catch (Exception eee)
            {
                e.Result = this.Error;
                EventLogger.LogEvent(this, eee.Message.ToString(),eee);
            }

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
                DataTable oldTable = database.DbDataset1.Tables["dtPrinterDetails_" + CurrentPrinterId.ToString()];
                DataTable newTable = new DataTable();

                newTable.Columns.Add("Propiedad");
                newTable.Columns.Add("Valor");
                for (int i = 0; i < oldTable.Rows.Count; i++)
                    newTable.Columns.Add();

                for (int i = 0; i < oldTable.Columns.Count; i++)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow[0] = oldTable.Columns[i].Caption;
                    for (int j = 0; j < oldTable.Rows.Count; j++)
                        newRow[j + 1] = oldTable.Rows[j][i];
                    newTable.Rows.Add(newRow);
                }

                lightDatagrid1.DataSource = newTable;
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
            
            //set dialog result
            this.DialogResult = DialogResult.OK;

            //this.Close();

        }

        #endregion

        

    }
}
