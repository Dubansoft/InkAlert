
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
    public partial class frmLocations : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

            Location myLocation;
            Database database = new Database();
            StoredProcedureParameters[] parameters;
            
            public BackgroundWorker MyBackgroundLocationUpdater = new BackgroundWorker();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            frmLocations myAreaForm = Application.OpenForms.OfType<frmLocations>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentLocationId = 0;
        public int CurrentLocationId
        {
            get { return currentLocationId; }
            set { currentLocationId = value; }
        }

        private string locationOperation = "";
        public string LocationOperation
        {
            get { return locationOperation; }
            set { locationOperation = value; }
        }

        #endregion

        public frmLocations()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundAreaUpdater
            MyBackgroundLocationUpdater.DoWork += new DoWorkEventHandler(MyBackgroundLocationUpdater_HardWork);
            MyBackgroundLocationUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundLocationUpdater_Completed);
            MyBackgroundLocationUpdater.WorkerReportsProgress = false;
            MyBackgroundLocationUpdater.WorkerSupportsCancellation = false;
        }

        private void Locations_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes dgLocations datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundLocationUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgAreas
                MyBackgroundLocationUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundLocationUpdater was called while it was still busy.",null);
            }

        }

        /// <summary>
        /// Reloads the dgLocations datagrid in the background.
        /// </summary>
        private void MyBackgroundLocationUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdLocations in parent form while this thread is 
            //running
            myStartForm.cmdLocations.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de ubicaciones. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;
            
            myLocation = new Location();
            if (!myLocation.Read()){
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myLocation.Error;
                
                EventLogger.LogEvent(this, myLocation.Error, null);
                return;
            }
            else
            {
                
                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";

            }
            
        }

        /// <summary>
        /// Runs when MyBackgroundLocationUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundLocationUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundLocationUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {

                if (listViewLocations.Items.Count > 0)
                {
                    listViewLocations.Items.Clear();
                }
                foreach (DataRow row in myLocation.Table.Rows)
                {

                    DateEngine myDate = new DateEngine();
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["locationName"].ToString());
                    item.SubItems.Add(row["locationDescription"].ToString());

                    listViewLocations.Items.Add(item);

                }

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} ubicaciones en la lista", myLocation.Table.Rows.Count.ToString()));
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
            myStartForm.cmdLocations.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLocations.SelectedItems.Count > 0)
            {
                handleNewLocationForm("Actualizar");
            }            
        }

        private void listViewLocations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewLocations_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewLocations.SelectedItems.Count > 0)
            {
                CurrentLocationId = Convert.ToInt16(listViewLocations.SelectedItems[0].SubItems[0].Text);
                
            }   
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewLocationForm("Añadir");
        }

        private bool handleNewLocationForm(string action)
        {
            
            frmLocationEdit myLocationEditForm = new frmLocationEdit();

            if (action == "Actualizar")
            {

                var selecteItem = listViewLocations.SelectedItems[0];

                myLocationEditForm.txtLocationName.Text = selecteItem.SubItems[1].Text;
                myLocationEditForm.txtLocationDescription.Text = selecteItem.SubItems[2].Text;
            }

            myLocationEditForm.Text = action + " ubicación";
            LocationOperation = action;
            myLocationEditForm.cmdSave.Text = LocationOperation;
            myLocationEditForm.CurrentLocationId = CurrentLocationId;

            myLocationEditForm.ShowDialog();

            if (myLocationEditForm.DialogResult == DialogResult.OK)
            {
                //Refresh dgLocations datagrid
                this.CallBackgroundWorker();

                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewLocations.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar ubicación?", "Eliminar ubicación", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_locationId", CurrentLocationId.ToString());
                    if (database.RunStoredProcedure("Location_Remove", parameters))
                    {
                        //Refresh dgLocations datagrid
                        this.CallBackgroundWorker();
                    }
                    else
                    {
                        EventLogger.LogEvent(this, "Falló la eliminación de la ubicación. " + database.Error, null);
                        MessageBox.Show("No se ha podido eliminar el área seleccionada. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        
        #endregion

        private void listViewLocations_KeyUp(object sender, KeyEventArgs e)
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
    }

        
}
