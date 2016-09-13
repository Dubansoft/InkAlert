
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

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InkAlert;
using System.Text;
using System.Net.NetworkInformation;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp;
using System.IO;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmICounterCycles : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        ICounterCycle myICounterCycle;
        Database database = new Database();
        StoredProcedureParameters[] parameters;
        public BackgroundWorker MyBackgroundICounterCycleUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmICounterCycles myICounterCycleForm = Application.OpenForms.OfType<frmICounterCycles>().FirstOrDefault();



        #endregion

        #region "Members"

        private int currentICounterCycleId = 0;
        public int CurrentICounterCycleId
        {
            get { return currentICounterCycleId; }
            set { currentICounterCycleId = value; }
        }

        private string iCounterCycleOperation = "";
        public string ICounterCycleOperation
        {
            get { return iCounterCycleOperation; }
            set { iCounterCycleOperation = value; }
        }

        #endregion

        public frmICounterCycles()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundICounterCycleUpdater
            MyBackgroundICounterCycleUpdater.DoWork += new DoWorkEventHandler(MyBackgroundICounterCycleUpdater_HardWork);
            MyBackgroundICounterCycleUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundICounterCycleUpdater_Completed);
            MyBackgroundICounterCycleUpdater.WorkerReportsProgress = false;
            MyBackgroundICounterCycleUpdater.WorkerSupportsCancellation = false;

            dgICounterCycles.AssignedContextMenuStrip = this.contextMenuICounterCycles;
            dgICounterCycles.ColumnsToBeFiltered = new string[]
            {
                "iCounterCycleName",
                "iCounterCycleYear",
                "iCounterCycleMonth",
                "iCounterCycleStatus",
                "iCounterCycleMonthNumber"
            };

        }

        private void ICounterCycles_Load(object sender, EventArgs e) { }

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that
        /// refreshes dgICounterCycles datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundICounterCycleUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgICounterCycles
                MyBackgroundICounterCycleUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundICounterCycleUpdater was called while it was still busy.", null);
            }
        }

        /// <summary>
        /// Reloads the dgICounterCycles datagrid in the background.
        /// </summary>
        private void MyBackgroundICounterCycleUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdICounterCycles in parent form while this thread is
            //running
            myStartForm.cmdICounterCycles.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myICounterCycle = new ICounterCycle();
            if (!myICounterCycle.Read())
            {
                //If there is an error while reading the database,
                //send the results back to the main thread
                e.Result = myICounterCycle.Error;

                EventLogger.LogEvent(this, myICounterCycle.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }

        /// <summary>
        /// Runs when MyBackgroundICounterCycleUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundICounterCycleUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundICounterCycleUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                dgICounterCycles.SetDataSource(myICounterCycle.Table);
                //dgICounterCycles.DtDatagridSource = myICounterCycle.Table;
                //dgICounterCycles.DatasourceRefreshPending = true;

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} ciclos en la lista", myICounterCycle.Table.Rows.Count.ToString()));
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

            //Enable cmdICounterCycles
            myStartForm.cmdICounterCycles.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        /// <summary>
        /// Handles the creation or opening of the form myICounterCycleEditForm
        /// </summary>
        /// <param name="action">Actualizar or Añadir</param>
        /// <returns>Boolean true if the form is successfully opened,
        /// otherwise, false.</returns>
        private bool handleNewICounterCycleForm(string action)
        {

            //Creates a new instance of frmICounterCycleEdit
            frmICounterCycleEdit myICounterCycleEditForm = new frmICounterCycleEdit();

            //Pre-fills all controls in myICounterCycleEditForm

            if (action == "Actualizar")
            {
                //Create a var to store the data from the selected row
                var selectedRow = dgICounterCycles.SelectedRows[0];

                //Set the current id on myICounterCycleEditForm
                myICounterCycleEditForm.CurrentICounterCycleId = (int)selectedRow.Cells["id"].Value;
                myICounterCycleEditForm.txtICounterCycleName.Text = selectedRow.Cells["iCounterCycleName"].Value.ToString();

                try
                {
                    //Fill the controls on myICounterCycleEditForm with the data
                    //from the selected row in dgICounterCycles

                    int cycleYear = Convert.ToInt32(selectedRow.Cells["iCounterCycleYear"].Value);
                    int cycleMonth = Convert.ToInt32(selectedRow.Cells["iCounterCycleMonthNumber"].Value);

                    DateTime selectedDateTime = new DateTime(cycleYear, cycleMonth, 1);

                    myICounterCycleEditForm.dateICounterCycles.Value = selectedDateTime;

                }
                catch (Exception e)
                {
                    EventLogger.LogEvent(this, e.Message.ToString(), e);
                }

            }
            else if (action == "Añadir")
            {
                myICounterCycleEditForm.txtICounterCycleName.Text = "Contadores " + GlobalSetup.Months[DateTime.Now.Month - 1] + " de " + DateTime.Now.Year;
            }

            //Set title and action for myICounterCycleEditForm
            myICounterCycleEditForm.Text = action + " ciclo de contador mensual";
            ICounterCycleOperation = action;
            myICounterCycleEditForm.cmdSave.Text = ICounterCycleOperation;

            //Open myICounterCycleEditForm
            myICounterCycleEditForm.ShowDialog();

            if (myICounterCycleEditForm.DialogResult == DialogResult.OK)
            {
                //Refresh dgICounterCycles datagrid
                this.CallBackgroundWorker();
                return true;

            }
            return false;
        }

        /// <summary>
        /// Sets the current iCounterCycle id to be used in external form references.
        /// </summary>
        private void setCurrentICounterCycleId()
        {
            if (dgICounterCycles.SelectedRows.Count > 0)
            {
                CurrentICounterCycleId = (int)dgICounterCycles.SelectedRows[0].Cells["id"].Value;
            }
        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgICounterCycles.SelectedRows.Count > 0)
            {
                handleNewICounterCycleForm("Actualizar");
            }
        }

        private void listViewICounterCycles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewICounterCycleForm("Añadir");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgICounterCycles.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar el ciclo de contador seleccionado?", "Eliminar ciclo de contador", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", CurrentICounterCycleId.ToString());
                    if (database.RunStoredProcedure("ICounterCycle_Remove", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        EventLogger.LogEvent(this, "Falló la eliminación del ciclo de contador. " + database.Error, null);
                        MessageBox.Show("No se ha podido eliminar el ciclo de contador seleccionado. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        private void dgICounterCycles_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentICounterCycleId();
            if (dgICounterCycles.SelectedRows.Count == 1)
            {
                myStartForm.UpdateStatusSelection("1 ciclo seleccionada");
            }
            else
            {
                myStartForm.UpdateStatusSelection(string.Format("{0} ciclos de contador seleccionados", dgICounterCycles.SelectedRows.Count.ToString()));
            }
        }

        private void dgICounterCycles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentICounterCycleId();

        }

        private void dgICounterCycles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentICounterCycleId();

        }

        private void dgICounterCycles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void dgICounterCycles_KeyUp(object sender, KeyEventArgs e)
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

        private void dgICounterCycles_Enter(object sender, EventArgs e)
        {
            myStartForm.FullStatusUpdate(
                "Listo",
                0,
                string.Format("{0} iCounterCycles en la lista", dgICounterCycles.Rows.Count.ToString()),
                string.Format("{0} ciclo(s) de contador seleccionado(s)", dgICounterCycles.SelectedRows.Count.ToString()));
        }

        private void actualizarDireccionesIpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void iniciarCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SetActiveCounterCycleId();

            if (CurrentICounterCycleId == GlobalSetup.ActiveCounterCycleId)
            {
                MessageBox.Show("Este ciclo ya está en ejecución.", "Ciclo en ejecución", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (
                GlobalSetup.ActiveCounterCycleId > 0 &&
                CurrentICounterCycleId != GlobalSetup.ActiveCounterCycleId)
            {
                DialogResult myDialogResult = MessageBox.Show("Hay otro ciclo de contador activo todavía. Debe terminar el ciclo anterior antes de activar uno nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            updateCounterCycleStatus(1);
        }


        private void finalizarCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveCounterCycleId();

            if (GlobalSetup.ActiveCounterCycleId != CurrentICounterCycleId)
            {
                MessageBox.Show("No se puede finalizar este ciclo porque no está en ejecución.", "Cerrar ciclo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            updateCounterCycleStatus(2);
        }

        private void updateCounterCycleStatus(int newStatus = 2)
        {
            int newCounterCycleState = newStatus;
            string action = "FINALIZAR";

            if (newCounterCycleState == 1)
            {
                action = "INICIAR";

            }
            else
            {
                DialogResult myDialogResult = MessageBox.Show("¿Confirma que desea " + action + " este ciclo de contador?", "Confirme " + action + " ciclo de contador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (myDialogResult != DialogResult.Yes) { return; }
            }
            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_newStatus", newCounterCycleState.ToString());
            parameters[1] = new StoredProcedureParameters("_id", this.CurrentICounterCycleId.ToString());
            database.RunStoredProcedure("ICounterCycle_ChangeState", parameters);
            myStartForm.cmdICounterCycles.PerformClick();

            SetActiveCounterCycleId();
        }

        public void SetActiveCounterCycleId()
        {
            database.ReadTable("ICounterCycle_GetActiveCycleId", "dtCurrentCycleId", null, null);

            if (database.DbDataset1.Tables["dtCurrentCycleId"].Rows.Count > 0)
            {
                GlobalSetup.ActiveCounterCycleId = Convert.ToInt32(database.DbDataset1.Tables["dtCurrentCycleId"].Rows[0][0].ToString());
            }
            else
            {
                GlobalSetup.ActiveCounterCycleId = 0;
            }


        }

        private void verContadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgICounterCycles.SelectedRows.Count > 0)
            {
                string cycleName = (string)dgICounterCycles.SelectedRows[0].Cells["iCounterCycleName"].Value;
                frmCounterList formCounterList = new frmCounterList();

                formCounterList.CurrentCycleName = cycleName;
                formCounterList.CurrentCycleMonth = (string)dgICounterCycles.SelectedRows[0].Cells["iCounterCycleMonth"].Value;
                formCounterList.CurrentCycleYear = (string)dgICounterCycles.SelectedRows[0].Cells["iCounterCycleYear"].Value;

                formCounterList.Text = "Ciclo de contador " + cycleName;

                parameters = new StoredProcedureParameters[1];
                parameters[0] = new StoredProcedureParameters("_iCounterCycleId", CurrentICounterCycleId.ToString());

                string dataTableName = "dtCounterList_Id" + CurrentICounterCycleId.ToString();

                database.ReadTable("ICounterCycle_GetCountersByCycle", dataTableName,null, parameters);
                if (database.DbDataset1.Tables.Contains(dataTableName))
                {
                    if(database.DbDataset1.Tables[dataTableName].Rows.Count > 0)
                    {
                        formCounterList.dgCounterList.DataSource = database.DbDataset1.Tables[dataTableName];
                        formCounterList.Show();
                    }
                    else
                    {
                        MessageBox.Show("El ciclo seleccionado no tiene contadores registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }
    }
}