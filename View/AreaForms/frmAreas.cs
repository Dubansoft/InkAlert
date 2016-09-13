
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
    public partial class frmAreas : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

            Area myArea;
            Database database = new Database();
            StoredProcedureParameters[] parameters;
            public BackgroundWorker MyBackgroundAreaUpdater = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            frmAreas myAreaForm = Application.OpenForms.OfType<frmAreas>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentAreaId = 0;
        public int CurrentAreaId
        {
            get { return currentAreaId; }
            set { currentAreaId = value; }
        }

        private string areaOperation = "";
        public string AreaOperation
        {
            get { return areaOperation; }
            set { areaOperation = value; }
        }

        #endregion

        public frmAreas()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            MyBackgroundAreaUpdater.DoWork += new DoWorkEventHandler(MyBackgroundAreaUpdater_HardWork);
            MyBackgroundAreaUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundAreaUpdater_Completed);
            MyBackgroundAreaUpdater.WorkerReportsProgress = false;
            MyBackgroundAreaUpdater.WorkerSupportsCancellation = false;

            dgAreas.AssignedContextMenuStrip = this.contextMenuAreas;
            dgAreas.ColumnsToBeFiltered = new string[]
            {
                "locationName",
                "printersPerArea",
                "storyNumber"
            };
        }

        private void Areas_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that
        /// refreshes dgAreas datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundAreaUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgAreas
                MyBackgroundAreaUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundAreaUpdater was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgAreas datagrid in the background.
        /// </summary>
        private void MyBackgroundAreaUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdAreas in parent form while this thread is
            //running
            myStartForm.cmdAreas.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de áreas. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myArea = new Area();
            if (!myArea.Read())
            {
                //If there is an error while reading the database,
                //send the results back to the main thread
                e.Result = myArea.Error;

                EventLogger.LogEvent(this, myArea.Error,null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
	    }

        /// <summary>
        /// Runs when MyBackgroundAreaUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundAreaUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundAreaUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {

                //Set the datasource for dgAreas datagrid
                dgAreas.SetDataSource(myArea.Table);

                //dgAreas.DtDatagridSource = myArea.Table;
                //dgAreas.DatasourceRefreshPending = true;

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} áreas en la lista", myArea.Table.Rows.Count.ToString()));
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
            myStartForm.cmdAreas.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        /// <summary>
        /// Handles the creation or opening of the form myAreaEditForm
        /// </summary>
        /// <param name="action">Actualizar or Añadir</param>
        /// <returns>Boolean true if the form is successfully opened,
        /// otherwise, false.</returns>
        private bool handleNewAreaForm(string action)
        {

            //Creates a new instance of frmAreaEdit
            frmAreaEdit myAreaEditForm = new frmAreaEdit();

            //Pre-fills all controls in myAreaEditForm
            myAreaEditForm.FillForm();

            if (action == "Actualizar")
            {
                //Create a var to store the data from the selected row
                var selectedRow = dgAreas.SelectedRows[0];

                //Set the current id on myAreaEditForm
                myAreaEditForm.CurrentAreaId = (int)selectedRow.Cells["id"].Value;

                try
                {
                    //Fill the controls on myAreaEditForm with the data
                    //from the selected row in dgAreas
                    myAreaEditForm.txtAreaName.Text = selectedRow.Cells["areaName"].Value.ToString();
                    myAreaEditForm.cmbPrinterLocationName.SelectedValue = (int)selectedRow.Cells["locationId"].Value;
                    myAreaEditForm.txtHostName.Text = selectedRow.Cells["areaHostName"].Value.ToString();
                    myAreaEditForm.txtIpAddress.Text = selectedRow.Cells["areaIpAddress"].Value.ToString();
                    myAreaEditForm.txtQueueName.Text = selectedRow.Cells["areaQueueName"].Value.ToString();
                    myAreaEditForm.cmbStoryNumber.SelectedValue = selectedRow.Cells["iCounterCycleMonth"].Value.ToString();
                }
                catch (Exception e)
                {
                    EventLogger.LogEvent(this, e.Message.ToString(),e);
                }

            }

            //Set title and action for myAreaEditForm
            myAreaEditForm.Text = action + " área";
            AreaOperation = action;
            myAreaEditForm.cmdSave.Text = AreaOperation;

            //Open myAreaEditForm
            myAreaEditForm.ShowDialog();

            if (myAreaEditForm.DialogResult == DialogResult.OK)
            {
                //Refresh dgAreas datagrid
                this.CallBackgroundWorker();
                return true;

            }
            return false;
        }

        /// <summary>
        /// Sets the current area id to be used in external form references.
        /// </summary>
        private void setCurrentAreaId()
        {
            if (dgAreas.SelectedRows.Count > 0)
            {
                CurrentAreaId = (int)dgAreas.SelectedRows[0].Cells["id"].Value;
            }
        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgAreas.SelectedRows.Count > 0)
            {
                handleNewAreaForm("Actualizar");
            }
        }

        private void listViewAreas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewAreaForm("Añadir");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgAreas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar él área seleccionada?", "Eliminar área", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_areaId", CurrentAreaId.ToString());
                    if (database.RunStoredProcedure("Area_Remove", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        EventLogger.LogEvent(this, "Falló la eliminación del área. " + database.Error, null);
                        MessageBox.Show("No se ha podido eliminar el área seleccionada. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        private void dgAreas_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentAreaId();

            try
            {
                if (dgAreas.SelectedRows.Count == 1)
                {
                    myStartForm.UpdateStatusSelection("1 área seleccionada");
                }
                else
                {
                    myStartForm.UpdateStatusSelection(string.Format("{0} áreas seleccionadas", dgAreas.SelectedRows.Count.ToString()));
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }
        }

        private void dgAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentAreaId();

        }

        private void dgAreas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentAreaId();

        }

        private void dgAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void dgAreas_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F5":
                    CallBackgroundWorker();
                    break;
                case "Delete":
                    eliminarToolStripMenuItem_Click(eliminarToolStripMenuItem, e);
                    break;
                case "F2":
                    editarToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void dgAreas_Enter(object sender, EventArgs e)
        {
            myStartForm.FullStatusUpdate(
                "Listo",
                0,
                string.Format("{0} áreas en la lista", dgAreas.Rows.Count.ToString()),
                string.Format("{0} área(s) seleccionada(s)", dgAreas.SelectedRows.Count.ToString()));
        }

        private void clausurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgAreas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Clausurar el área seleccionada?", "Clausurar área", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_areaId", CurrentAreaId.ToString());
                    if (database.RunStoredProcedure("Area_CloseDown", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        EventLogger.LogEvent(this, "Falló la clausura del área. " + database.Error, null);
                        MessageBox.Show("No se ha podido clausurar el área seleccionada. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void reactivarAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgAreas.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Reactivar él área seleccionada?", "Reactivar área", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_areaId", CurrentAreaId.ToString());
                    if (database.RunStoredProcedure("Area_Reopen", parameters))
                    {
                        string areaIdToUpdate = CurrentAreaId.ToString();

                        CallBackgroundWorker();

                        DialogResult myDialogResult = MessageBox.Show("¿Desea actualizar ahora los datos del área reactivada?", "Actualizar datos del área", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (myDialogResult == DialogResult.Yes)
                        {
                            dgAreas.MultiSelect = false;

                            //Find and select row

                            int rowIndex = -1;

                            DataGridViewRow row = dgAreas.Rows
                                .Cast<DataGridViewRow>()
                                .Where(r => r.Cells["id"].Value.ToString().Equals(areaIdToUpdate))
                                .First();

                            rowIndex = row.Index;
                            dgAreas.Rows[rowIndex].Selected = true;

                            editarToolStripMenuItem_Click(dgAreas, null);

                        }
                    }
                    else
                    {
                        EventLogger.LogEvent(this, "Falló la reapertura del área. " + database.Error, null);
                        MessageBox.Show("No se ha podido reagrir el área seleccionada. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void contextMenuAreas_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (dgAreas.Rows.Count == 0)
                {
                    editarToolStripMenuItem.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = false;
                    clausurarToolStripMenuItem.Enabled = false;
                    reactivarAreaToolStripMenuItem.Enabled = false;

                    return;
                }
                else
                {
                    editarToolStripMenuItem.Enabled = true;
                    eliminarToolStripMenuItem.Enabled = true;
                    clausurarToolStripMenuItem.Enabled = true;
                    reactivarAreaToolStripMenuItem.Enabled = true;
                }


                if (dgAreas.SelectedRows.Count > 0)
                {
                    if((AreaStatus)dgAreas.SelectedRows[0].Cells["areaStatusId"].Value == AreaStatus.Activa)
                    {
                        reactivarAreaToolStripMenuItem.Enabled = false;
                    }
                    else if ((AreaStatus)dgAreas.SelectedRows[0].Cells["areaStatusId"].Value == AreaStatus.Clausurada)
                    {
                        clausurarToolStripMenuItem.Enabled = false;
                    }
                }

            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }

        }

        #endregion

    }
}