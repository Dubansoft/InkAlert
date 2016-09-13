
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
    public partial class frmPrinterTypes : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        PrinterType myPrinterType;
        Database database = new Database();
        StoredProcedureParameters[] parameters;

        public BackgroundWorker MyBackgroundPrinterTypeUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmPrinterTypes myUserForm = Application.OpenForms.OfType<frmPrinterTypes>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentPrinterTypeId = 0;
        public int CurrentPrinterTypeId
        {
            get { return currentPrinterTypeId; }
            set { currentPrinterTypeId = value; }
        }

        private string printerTypeOperation = "";
        public string PrinterTypeOperation
        {
            get { return printerTypeOperation; }
            set { printerTypeOperation = value; }
        }

        #endregion

        public frmPrinterTypes()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundPrinterTypeUpdater
            MyBackgroundPrinterTypeUpdater.DoWork += new DoWorkEventHandler(MyBackgroundPrinterTypeUpdater_HardWork);
            MyBackgroundPrinterTypeUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundPrinterTypeUpdater_Completed);
            MyBackgroundPrinterTypeUpdater.WorkerReportsProgress = false;
            MyBackgroundPrinterTypeUpdater.WorkerSupportsCancellation = false;
        }

        private void PrinterTypes_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes listViewPrinterTypes list iew in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundPrinterTypeUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgUsers
                MyBackgroundPrinterTypeUpdater.RunWorkerAsync();
            }
            else
            {
                FileHelper.EventLogger.LogEvent(this, "MyBackgroundPrinterTypeUpdater was called while it was still busy.",null);
            }
        }


        /// <summary>
        /// Reloads the listViewPrinterTypes datagrid in the background.
        /// </summary>
        private void MyBackgroundPrinterTypeUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdPrinterTypes in parent form while this thread is 
            //running
            myStartForm.cmdPrinterTypes.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de tipos de impresoras. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myPrinterType = new PrinterType();
            if (!myPrinterType.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myPrinterType.Error;

                FileHelper.EventLogger.LogEvent(this, myPrinterType.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }


        /// <summary>
        /// Runs when MyBackgroundPrinterTypeUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundPrinterTypeUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundPrinterTypeUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                //Bind listViewUsers
                if (listViewPrinterTypes.Items.Count > 0)
                {
                    listViewPrinterTypes.Items.Clear();
                }
                foreach (DataRow row in myPrinterType.Table.Rows)
                {

                    DateEngine myDate = new DateEngine();
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["printerTypeName"].ToString());
                    item.SubItems.Add(row["printerTypeDescription"].ToString());

                    listViewPrinterTypes.Items.Add(item);

                }

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} tipos de impresoras en la lista", myPrinterType.Table.Rows.Count.ToString()));
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
            myStartForm.cmdPrinterTypes.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterTypes.SelectedItems.Count > 0)
            {
                handleNewPrinterTypeForm("Actualizar");
            }            
        }

        private void listViewPrinterTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewPrinterTypes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPrinterTypes.SelectedItems.Count > 0)
            {
                CurrentPrinterTypeId = Convert.ToInt16(listViewPrinterTypes.SelectedItems[0].SubItems[0].Text);
                
            }   
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewPrinterTypeForm("Añadir");
        }

        private bool handleNewPrinterTypeForm(string action)
        {
            
            frmPrinterTypeEdit myPrinterTypeEditForm = new frmPrinterTypeEdit();

            if (action == "Actualizar")
            {

                var selecteItem = listViewPrinterTypes.SelectedItems[0];

                myPrinterTypeEditForm.txtPrinterTypeName.Text = selecteItem.SubItems[1].Text;
                myPrinterTypeEditForm.txtPrinterTypeDescription.Text = selecteItem.SubItems[2].Text;
            }

            myPrinterTypeEditForm.Text = action + " tipo de impresora";
            PrinterTypeOperation = action;
            myPrinterTypeEditForm.cmdSave.Text = PrinterTypeOperation;
            myPrinterTypeEditForm.CurrentPrinterTypeId = CurrentPrinterTypeId;

            myPrinterTypeEditForm.ShowDialog();

            if (myPrinterTypeEditForm.DialogResult == DialogResult.OK)
            {
                CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewPrinterTypes.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar tipo de impresora?", "Eliminar tipo de impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_printerTypeId", CurrentPrinterTypeId.ToString());
                    if (database.RunStoredProcedure("PrinterType_Remove", parameters))
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
