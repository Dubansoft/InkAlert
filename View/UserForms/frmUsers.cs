
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
    public partial class frmUsers : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "Class References"

        User myUser;
        Database database = new Database();
        StoredProcedureParameters[] parameters;
        public BackgroundWorker MyBackgroundUserUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmUsers myUserForm = Application.OpenForms.OfType<frmUsers>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentUserId = 0;
        public int CurrentUserId
        {
            get { return currentUserId; }
            set { currentUserId = value; }
        }

        private string userOperation = "";
        public string UserOperation
        {
            get { return userOperation; }
            set { userOperation = value; }
        }

        #endregion

        public frmUsers()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundUserLogin
            MyBackgroundUserUpdater.DoWork += new DoWorkEventHandler(MyBackgroundUserUpdater_HardWork);
            MyBackgroundUserUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundUserUpdater_Completed);
            MyBackgroundUserUpdater.WorkerReportsProgress = false;
            MyBackgroundUserUpdater.WorkerSupportsCancellation = false;
        }

        private void Users_Load(object sender, EventArgs e){}

        #region "Functions"

        /// <summary>
        /// Shows the loading image and call the process that
        /// refreshes listViewUsers list view in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundUserUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgUsers
                MyBackgroundUserUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundUserLogin was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgUsers datagrid in the background.
        /// </summary>
        private void MyBackgroundUserUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdUsers in parent form while this thread is
            //running
            myStartForm.cmdUsers.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de usuarios. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myUser = new User();
            if (!myUser.Read())
            {
                //if there is an error while reading the database,
                //send the results back to the main thread
                e.Result = myUser.Error;

                EventLogger.LogEvent(this, myUser.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }

        /// <summary>
        /// Runs when MyBackgroundUserLogin has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundUserLogin</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundUserUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                //Bind listViewUsers
                if (listViewUsers.Items.Count > 0)
                {
                    listViewUsers.Items.Clear();
                }
                foreach (DataRow row in myUser.Table.Rows)
                {
                    DateEngine myDate = new DateEngine();
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["userName"].ToString());
                    item.SubItems.Add(row["firstName"].ToString());
                    item.SubItems.Add(row["lastName"].ToString());

                    myDate.Date = row["dateCreated"].ToString();
                    item.SubItems.Add(myDate.FromDoubleToStringDate());

                    myDate.Date = row["dateModified"].ToString();
                    item.SubItems.Add(myDate.FromDoubleToStringDate());

                    listViewUsers.Items.Add(item);

                }

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} usuarios en la lista", myUser.Table.Rows.Count.ToString()));
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
            myStartForm.cmdUsers.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface Events"

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                handleNewUserForm("Actualizar");
            }
        }

        private void listViewUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void listViewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                CurrentUserId = Convert.ToInt16(listViewUsers.SelectedItems[0].SubItems[0].Text);

            }
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewUserForm("Añadir");
        }
        /// <summary>
        /// Handles the creation or opening of the form myUserEditForm
        /// </summary>
        /// <param name="action">Actualizar or Añadir</param>
        /// <returns>Boolean true if the form is successfully opened,
        /// otherwise, false.</returns>
        private bool handleNewUserForm(string action)
        {

            frmUserEdit myUserEditForm = new frmUserEdit();

            if (action == "Actualizar")
            {

                var selecteItem = listViewUsers.SelectedItems[0];

                myUserEditForm.txtUserName.Text = selecteItem.SubItems[1].Text;
                myUserEditForm.txtFirstName.Text = selecteItem.SubItems[2].Text;
                myUserEditForm.txtLastName.Text = selecteItem.SubItems[3].Text;
            }

            myUserEditForm.Text = action + " usuario";
            UserOperation = action;
            myUserEditForm.cmdSave.Text = UserOperation;
            myUserEditForm.CurrentUserId = CurrentUserId;

            myUserEditForm.ShowDialog();

            if (myUserEditForm.DialogResult == DialogResult.OK)
            {
                this.CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selecteItem = listViewUsers.SelectedItems[0];

            if (GlobalSetup.CurrentSessionUser.Username == selecteItem.SubItems[1].Text.Trim())
            {
                MessageBox.Show("No puede autoeliminarse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (listViewUsers.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar usuario?", "Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_userId", CurrentUserId.ToString());
                    if (database.RunStoredProcedure("User_Remove", parameters))
                    {
                        this.CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del usuario. " + database.Error,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }

        }


        private void listViewUsers_KeyUp(object sender, KeyEventArgs e)
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

        #endregion
    }
}
