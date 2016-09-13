
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

namespace InkAlert.Forms
{
    public partial class frmOids : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        #region "References"

            Oid myOid;
            Database database = new Database();
            StoredProcedureParameters[] parameters;
            public BackgroundWorker MyBackgroundOidUpdater = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            frmOids myAreaForm = Application.OpenForms.OfType<frmOids>().FirstOrDefault();

        #endregion

        #region "Members"
        
        private int currentOidId = 0;
        public int CurrentOidId
        {
            get { return currentOidId; }
            set { currentOidId = value; }
        }

        private string oidOperation = "";
        public string OidOperation
        {
            get { return oidOperation; }
            set { oidOperation = value; }
        }

        #endregion

        public frmOids()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundOidUpdater
            MyBackgroundOidUpdater.DoWork += new DoWorkEventHandler(MyBackgroundOidUpdater_HardWork);
            MyBackgroundOidUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundOidUpdater_Completed);
            MyBackgroundOidUpdater.WorkerReportsProgress = false;
            MyBackgroundOidUpdater.WorkerSupportsCancellation = false;

            dgOids.AssignedContextMenuStrip = this.contextMenuOids;
            dgOids.ColumnsToBeFiltered = new string[]
            {
                "oidName",
                "oidReturnDataTypeName",
                "printerMakeName",
                "oidPerModelCount",
                "printerMakeId",
                "printerConnectionType"
            };
        }

        private void Oids_Load(object sender, EventArgs e){}


        #region "Functions"


        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes dgOids datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundOidUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgOids
                MyBackgroundOidUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundOidUpdater was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgOids datagrid in the background.
        /// </summary>
        private void MyBackgroundOidUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdLocations in parent form while this thread is 
            //running
            myStartForm.cmdOids.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de identificadores. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myOid = new Oid();

            if (!myOid.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myOid.Error;

                EventLogger.LogEvent(this, myOid.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";

            }

        }

        /// <summary>
        /// Runs when MyBackgroundOidUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundOidUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundOidUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                dgOids.SetDataSource(myOid.Table);
                //dgOids.DtDatagridSource = myOid.Table;
                //dgOids.DatasourceRefreshPending = true;

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} identificadores en la lista", myOid.Table.Rows.Count.ToString()));
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
            myStartForm.cmdOids.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, loadingImage);
        }


        #endregion

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgOids.SelectedRows.Count > 0)
            {
                handleNewOidForm("Actualizar");
            }            
        }

        private void listViewOids_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewOids_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (dgOids.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local CurrentPrinterModelId
                CurrentOidId  = (int)dgOids.SelectedRows[0].Cells["id"].Value;
            }  
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewOidForm("Añadir");
        }

        private bool handleNewOidForm(string action)
        {
            
            frmOidEdit myOidEditForm = new frmOidEdit();

            myOidEditForm.FillFormControls();
            if (action == "Asignar")
            {   

                TabPage assignationTab = myOidEditForm.tabControl1.TabPages["tabEditCreate"];
                myOidEditForm.tabControl1.TabPages.Remove(assignationTab);
            }
            else if (action == "Actualizar")
            {
                var selectedRow = dgOids.SelectedRows[0];

                myOidEditForm.CurrentOidId = (int)selectedRow.Cells["id"].Value;
                //MessageBox.Show(myOidEditForm.CurrentOidId.ToString());
                //return false;

                myOidEditForm.cmbPrinterMakeName.SelectedValue = (int)selectedRow.Cells["printerMakeId"].Value;

                myOidEditForm.txtUpdateMessage.Location = myOidEditForm.lstPrinterModels.Location;
                myOidEditForm.txtUpdateMessage.Size = myOidEditForm.lstPrinterModels.Size;
                myOidEditForm.txtUpdateMessage.TextAlign = HorizontalAlignment.Center;
                myOidEditForm.txtUpdateMessage.ReadOnly = true;
                myOidEditForm.txtUpdateMessage.Text = "Para editar las asignaciones de un identificador OID, por favor utilice la pestaña 'Asignar OID existente'";

                myOidEditForm.txtOidAddress.Text = selectedRow.Cells["oidAddress"].Value.ToString();
                myOidEditForm.cmbOidType.SelectedValue = (int)selectedRow.Cells["oidTypeId"].Value;
                myOidEditForm.cmbOidReturnType.SelectedValue = (int)selectedRow.Cells["oidReturnDataTypeId"].Value;
                myOidEditForm.cmbPrinterConnectionType.SelectedValue = (int)selectedRow.Cells["printerConnectionTypeId"].Value;
            }
            else
            {
                myOidEditForm.txtUpdateMessage.Visible = false;
            }

            myOidEditForm.Text = action + " identificador de objeto OID";
            OidOperation = action;
            myOidEditForm.cmdSave.Text = OidOperation;

            myOidEditForm.ShowDialog();

            if (myOidEditForm.DialogResult == DialogResult.OK)
            {
                this.CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgOids.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar OID?", "Eliminar OID", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", CurrentOidId.ToString());
                    if (database.RunStoredProcedure("Oid_Remove", parameters))
                    {
                        this.CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del tipo de impresora. " + database.Error);
                    }
                }
            }

        }

        private void dgOids_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentOidId();
        }

        private void dgOids_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void dgOids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentOidId();
        }

        private void dgOids_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentOidId();
        }

        private void setCurrentOidId()
        {
            if (dgOids.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local currentOidId
                CurrentOidId = (int)dgOids.SelectedRows[0].Cells["id"].Value;
            }
        }

        private void asignarOidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewOidForm("Asignar");
        }


    }
}
