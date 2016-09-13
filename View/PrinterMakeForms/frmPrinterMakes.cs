
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
    public partial class frmPrinterMakes : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        PrinterMake myPrinterMake;
        Database database = new Database();
        StoredProcedureParameters[] parameters;

        public BackgroundWorker MyBackgroundMakeUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmPrinterMakes myAreaForm = Application.OpenForms.OfType<frmPrinterMakes>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentPrinterMakeId = 0;
        public int CurrentPrinterMakeId
        {
            get { return currentPrinterMakeId; }
            set { currentPrinterMakeId = value; }
        }

        private string printerMakeOperation = "";
        public string PrinterMakeOperation
        {
            get { return printerMakeOperation; }
            set { printerMakeOperation = value; }
        }

        #endregion

        public frmPrinterMakes()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            MyBackgroundMakeUpdater.DoWork += new DoWorkEventHandler(MyBackgroundMakeUpdater_HardWork);
            MyBackgroundMakeUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundMakeUpdater_Completed);
            MyBackgroundMakeUpdater.WorkerReportsProgress = false;
            MyBackgroundMakeUpdater.WorkerSupportsCancellation = false;
        }

        private void PrinterMakes_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes listViewPrinterMakes datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundMakeUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill listViewPrinterMakes
                MyBackgroundMakeUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundMakeUpdater was called while it was still busy.",null);
            }
        }
        
        /// <summary>
        /// Reloads the listViewPrinterMakes datagrid in the background.
        /// </summary>
        private void MyBackgroundMakeUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdPrinterMakes in parent form while this thread is 
            //running
            myStartForm.cmdPrinterMakes.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de marcas de impresoras. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myPrinterMake = new PrinterMake();
            if (!myPrinterMake.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myPrinterMake.Error;

                EventLogger.LogEvent(this, myPrinterMake.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";

            }

        }

        /// <summary>
        /// Runs when MyBackgroundMakeUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundMakeUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        /// 
        public void MyBackgroundMakeUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {

                if (listViewPrinterMakes.Items.Count > 0)
                {
                    listViewPrinterMakes.Items.Clear();
                }
                foreach (DataRow row in myPrinterMake.Table.Rows)
                {

                    DateEngine myDate = new DateEngine();
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["printerMakeName"].ToString());
                    item.SubItems.Add(row["printerMakeDescription"].ToString());

                    listViewPrinterMakes.Items.Add(item);

                } 

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} marcas de impresoras en la lista", myPrinterMake.Table.Rows.Count.ToString()));
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
            myStartForm.cmdPrinterMakes.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterMakes.SelectedItems.Count > 0)
            {
                handleNewPrinterMakeForm("Actualizar");
            }            
        }

        private void listViewPrinterMakes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewPrinterMakes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPrinterMakes.SelectedItems.Count > 0)
            {
                CurrentPrinterMakeId = Convert.ToInt16(listViewPrinterMakes.SelectedItems[0].SubItems[0].Text);
                
            }   
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewPrinterMakeForm("Añadir");
        }

        private bool handleNewPrinterMakeForm(string action)
        {
            
            frmPrinterMakeEdit myPrinterMakeEditForm = new frmPrinterMakeEdit();

            if (action == "Actualizar")
            {

                var selecteItem = listViewPrinterMakes.SelectedItems[0];

                myPrinterMakeEditForm.txtPrinterMakeName.Text = selecteItem.SubItems[1].Text;
                myPrinterMakeEditForm.txtPrinterMakeDescription.Text = selecteItem.SubItems[2].Text;
            }

            myPrinterMakeEditForm.Text = action + " marca de impresora";
            PrinterMakeOperation = action;
            myPrinterMakeEditForm.cmdSave.Text = PrinterMakeOperation;
            myPrinterMakeEditForm.CurrentPrinterMakeId = CurrentPrinterMakeId;

            myPrinterMakeEditForm.ShowDialog();

            if (myPrinterMakeEditForm.DialogResult == DialogResult.OK)
            {
                CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterMakes.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar tipo de impresora?", "Eliminar tipo de impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_printerMakeId", CurrentPrinterMakeId.ToString());
                    if (database.RunStoredProcedure("PrinterMake_Remove", parameters))
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
