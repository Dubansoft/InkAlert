
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
using System.Linq;
using System.Windows.Forms;
using FormValidation;
using InkAlert;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmLogin : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "Class References"

        User myUser;
        Database database = new Database();
        public BackgroundWorker MyBackgroundUserLogin = new BackgroundWorker();
        StartForm myStartForm = (Application.OpenForms.OfType<StartForm>().FirstOrDefault()) ?? new StartForm();
        frmLogin myUserForm = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();


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

        public frmLogin()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundUserLogin
            MyBackgroundUserLogin.DoWork += new DoWorkEventHandler(MyBackgroundUserLogin_HardWork);
            MyBackgroundUserLogin.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundUserLogin_Completed);
            MyBackgroundUserLogin.WorkerReportsProgress = false;
            MyBackgroundUserLogin.WorkerSupportsCancellation = false;
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
            if (!MyBackgroundUserLogin.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgUsers
                MyBackgroundUserLogin.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundUserLogin was called while it was still busy.",null);
            }
        }

        /// <summary>
        /// Reloads the dgUsers datagrid in the background.
        /// </summary>
        private void MyBackgroundUserLogin_HardWork(object sender, DoWorkEventArgs e)
        {

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;



            if (!myUser.Login())
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
        public void MyBackgroundUserLogin_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                
                this.Visible = false;

                StartForm frmStart = new StartForm();

                frmStart.Show();

            }
            else if ((string)e.Result != "OK")
            {
                if (!database.TryConnect())
                {
                    MessageBox.Show("No se ha podido conectar al servidor MySql: " + database.Error, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }else if (myUser.Error != null)
                {
                    MessageBox.Show("No se ha podido iniciar sesión: "  + myUser.Error, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else {
                    MessageBox.Show("El nombre de usuario o contraseña ingresados son incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


            }

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        #region "Interface Events"

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if(!FormValidate.ValidateTextbox(
                new TextBox[] {
                    txtUserName,
                    txtPassword
                }))
            {
                return;
            }

            database = new Database();
            if (Validation.ValidateDbConnection(database))
            {
                try
                {
                    myUser = new User(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    myStartForm.ToggleLoadingImage(this, true, loadingImage);
                }
                catch (Exception ex)
                {
                    EventLogger.LogEvent(this, ex.Message.ToString(), ex);
                }

                MyBackgroundUserLogin.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Se perdió la conexión con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
