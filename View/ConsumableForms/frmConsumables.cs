
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

using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using FileHelper;
//using DataGridViewAutoFilter;

namespace InkAlert.Forms
{
    public partial class frmConsumables : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        #region "References"

            Consumable myConsumable;
            Database database = new Database();
            StoredProcedureParameters[] parameters;
            public BackgroundWorker MyBackgroundConsumableUpdater = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            frmConsumables myAreaForm = Application.OpenForms.OfType<frmConsumables>().FirstOrDefault();
        
        

        #endregion

        #region "Members"
        
        private int currentConsumableId = 0;
        public int CurrentConsumableId
        {
            get { return currentConsumableId; }
            set { currentConsumableId = value; }
        }

        private string consumableOperation = "";
        public string ConsumableOperation
        {
            get { return consumableOperation; }
            set { consumableOperation = value; }
        }

        #endregion

        public frmConsumables()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundConsumableUpdater
            MyBackgroundConsumableUpdater.DoWork += new DoWorkEventHandler(MyBackgroundConsumableUpdater_HardWork);
            MyBackgroundConsumableUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundConsumableUpdater_Completed);
            MyBackgroundConsumableUpdater.WorkerReportsProgress = false;
            MyBackgroundConsumableUpdater.WorkerSupportsCancellation = false;

            dgConsumables.AssignedContextMenuStrip = this.contextMenuConsumables;
            dgConsumables.ColumnsToBeFiltered = new string[]
            {
                "printerMakeName",
                "printerModelName",
                "consumableTypeName",
                "consumableModelName",
                "maxLife"
            };
        }

        private void Consumables_Load(object sender, EventArgs e){}


        #region "Functions"


        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes dgConsumables datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundConsumableUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgConsumables
                MyBackgroundConsumableUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundConsumableUpdater was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgConsumables datagrid in the background.
        /// </summary>
        private void MyBackgroundConsumableUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdLocations in parent form while this thread is 
            //running
            //myStartForm.cmdConsumables.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de identificadores. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myConsumable = new Consumable();

            if (!myConsumable.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myConsumable.Error;

                EventLogger.LogEvent(this, myConsumable.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";

            }

        }

        /// <summary>
        /// Runs when MyBackgroundConsumableUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundConsumableUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundConsumableUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                dgConsumables.SetDataSource(myConsumable.Table);
                //dgConsumables.DtDatagridSource = myConsumable.Table;
                //dgConsumables.DatasourceRefreshPending = true;
                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} identificadores en la lista", myConsumable.Table.Rows.Count.ToString()));
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
            //myStartForm.cmdConsumables.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, loadingImage);
        }


        #endregion

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgConsumables.SelectedRows.Count > 0)
            {
                handleNewConsumableForm("Actualizar");
            }            
        }

        private void listViewConsumables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewConsumables_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (dgConsumables.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local CurrentPrinterModelId
                CurrentConsumableId  = (int)dgConsumables.SelectedRows[0].Cells["id"].Value;
            }  
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewConsumableForm("Añadir");
        }

        private bool handleNewConsumableForm(string action)
        {
            
            frmConsumableEdit myConsumableEditForm = new frmConsumableEdit();

            myConsumableEditForm.FillFormControls();
            if (action == "Asignar")
            {   

                TabPage assignationTab = myConsumableEditForm.tabControl1.TabPages["tabEditCreate"];
                myConsumableEditForm.tabControl1.TabPages.Remove(assignationTab);
            }
            else if (action == "Actualizar")
            {
                var selectedRow = dgConsumables.SelectedRows[0];

                myConsumableEditForm.CurrentConsumableId = (int)selectedRow.Cells["id"].Value;
                
                myConsumableEditForm.cmbPrinterMakeName.SelectedValue = (int)selectedRow.Cells["consumableMakeId"].Value;

                myConsumableEditForm.txtUpdateMessage.Location = myConsumableEditForm.lstPrinterModels.Location;
                myConsumableEditForm.txtUpdateMessage.Size = myConsumableEditForm.lstPrinterModels.Size;
                myConsumableEditForm.txtUpdateMessage.TextAlign = HorizontalAlignment.Center;
                myConsumableEditForm.txtUpdateMessage.ReadOnly = true;
                myConsumableEditForm.txtUpdateMessage.Text = "Para editar las asignaciones de un suministro, por favor utilice la pestaña 'Asignar suministro existente'";

                myConsumableEditForm.txtConsumableModelName.Text = selectedRow.Cells["consumableModelName"].Value.ToString();
                myConsumableEditForm.cmbConsumableType.SelectedValue = (int)selectedRow.Cells["consumableTypeId"].Value;
                myConsumableEditForm.nupMaxLife.Value = (int)selectedRow.Cells["maxLife"].Value;
                
            }
            else
            {
                myConsumableEditForm.txtUpdateMessage.Visible = false;
            }

            myConsumableEditForm.Text = action + " suministro";
            ConsumableOperation = action;
            myConsumableEditForm.cmdSave.Text = ConsumableOperation;

            myConsumableEditForm.ShowDialog();

            if (myConsumableEditForm.DialogResult == DialogResult.OK)
            {
                this.CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgConsumables.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar suministro?", "Eliminar suministro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", CurrentConsumableId.ToString());
                    if (database.RunStoredProcedure("Consumable_Remove", parameters))
                    {
                        this.CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del suministro. " + database.Error);
                    }
                }
            }

        }

        private void dgConsumables_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentConsumableId();
        }

        private void dgConsumables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void dgConsumables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentConsumableId();
        }

        private void dgConsumables_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentConsumableId();
        }

        private void setCurrentConsumableId()
        {
            if (dgConsumables.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local currentConsumableId
                CurrentConsumableId = (int)dgConsumables.SelectedRows[0].Cells["id"].Value;
            }
        }

        private void asignarConsumableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewConsumableForm("Asignar");
        }

        private void dgConsumables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
