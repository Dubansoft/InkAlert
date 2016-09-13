
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
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace InkAlert.Forms
{
    public partial class frmPrinterSeries : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        PrinterSerie myPrinterSerie;
        Database database = new Database();
        StoredProcedureParameters[] parameters;

        public BackgroundWorker MyBackgroundPrinterSeriesUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmPrinterSeries myUserForm = Application.OpenForms.OfType<frmPrinterSeries>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentPrinterSerieId = 0;
        public int CurrentPrinterSerieId
        {
            get { return currentPrinterSerieId; }
            set { currentPrinterSerieId = value; }
        }

        private string printerSerieOperation = "";
        public string PrinterSerieOperation
        {
            get { return printerSerieOperation; }
            set { printerSerieOperation = value; }
        }

        #endregion

        public frmPrinterSeries()
        {
            InitializeComponent();


            //Initialise event listeners for MyBackgroundPrinterTypeUpdater
            MyBackgroundPrinterSeriesUpdater.DoWork += new DoWorkEventHandler(MyBackgroundPrinterSeriesUpdater_HardWork);
            MyBackgroundPrinterSeriesUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundPrinterSeriesUpdater_Completed);
            MyBackgroundPrinterSeriesUpdater.WorkerReportsProgress = false;
            MyBackgroundPrinterSeriesUpdater.WorkerSupportsCancellation = false;
        }

        private void PrinterSeries_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes listViewPrinterSeries list iew in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundPrinterSeriesUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgUsers
                MyBackgroundPrinterSeriesUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundPrinterSeriesUpdater was called while it was still busy.",null);
            }
        }


        /// <summary>
        /// Reloads the listViewPrinterSeries datagrid in the background.
        /// </summary>
        private void MyBackgroundPrinterSeriesUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdPrinterSeries in parent form while this thread is 
            //running
            myStartForm.cmdPrinterSeries.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de series de impresoras. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myPrinterSerie = new PrinterSerie();
            if (!myPrinterSerie.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myPrinterSerie.Error;

                EventLogger.LogEvent(this, myPrinterSerie.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }


        /// <summary>
        /// Runs when MyBackgroundPrinterSeriesUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundPrinterSeriesUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundPrinterSeriesUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                //Bind listViewPrinterSeries
                if (listViewPrinterSeries.Items.Count > 0)
                {
                    listViewPrinterSeries.Items.Clear();
                }
                foreach (DataRow row in myPrinterSerie.Table.Rows)
                {

                    DateEngine myDate = new DateEngine();
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["printerMakeId"].ToString());
                    item.SubItems.Add(row["printerSerieName"].ToString());
                    item.SubItems.Add(row["printerMakeName"].ToString());
                    
                    listViewPrinterSeries.Items.Add(item); 


                }

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} series de impresoras en la lista", myPrinterSerie.Table.Rows.Count.ToString()));
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

            //Enable cmdUsers
            myStartForm.cmdPrinterSeries.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterSeries.SelectedItems.Count > 0)
            {
                handleNewPrinterSerieForm("Actualizar");
            }            
        }

        private void listViewPrinterSeries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewPrinterSeries_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPrinterSeries.SelectedItems.Count > 0)
            {
                CurrentPrinterSerieId = Convert.ToInt16(listViewPrinterSeries.SelectedItems[0].SubItems[0].Text);
                
            }   
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewPrinterSerieForm("Añadir");
        }

        private bool handleNewPrinterSerieForm(string action)
        {
            
            frmPrinterSerieEdit myPrinterSerieEditForm = new frmPrinterSerieEdit();

            //Fill cmbPrinterMakeName
            database.ReadTable("PrinterMake_Get", "dtPrinterMakes");
            myPrinterSerieEditForm.cmbPrinterMakeName.DisplayMember = "printerMakeName";
            myPrinterSerieEditForm.cmbPrinterMakeName.ValueMember = "Id";
            myPrinterSerieEditForm.cmbPrinterMakeName.DataSource = database.DbDataset1.Tables["dtPrinterMakes"];
        

            if (action == "Actualizar")
            {

                var selectedItem = listViewPrinterSeries.SelectedItems[0];
                try
                {
                myPrinterSerieEditForm.txtPrinterSerieName.Text = selectedItem.SubItems[2].Text;
                myPrinterSerieEditForm.cmbPrinterMakeName.SelectedValue = Convert.ToInt32(selectedItem.SubItems[1].Text);
                }
                catch (Exception)
                {
                    
                }
                
            }

            myPrinterSerieEditForm.Text = action + " marca de impresora";
            PrinterSerieOperation = action;
            myPrinterSerieEditForm.cmdSave.Text = PrinterSerieOperation;
            myPrinterSerieEditForm.CurrentPrinterSerieId = CurrentPrinterSerieId;

            myPrinterSerieEditForm.ShowDialog();

            if (myPrinterSerieEditForm.DialogResult == DialogResult.OK)
            {
                CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterSeries.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar tipo de impresora?", "Eliminar tipo de impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_printerSerieId", CurrentPrinterSerieId.ToString());
                    if (database.RunStoredProcedure("PrinterSerie_Remove", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del tipo de impresora. " + database.Error);
                    }
                }
            }

        }

        #endregion


    }
}
