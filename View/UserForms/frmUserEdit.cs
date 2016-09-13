
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
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmUserEdit : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        public frmUserEdit()
        {
            InitializeComponent();
        }


        //new database instance
        Database database = new Database();

        //instantiate parameters
        private StoredProcedureParameters[] parameters;

        //the id of the selected user in the listview
        private int currentUserId = 0;
        public int CurrentUserId
        {
            get { return currentUserId; }
            set { currentUserId = value; }
        }

        //current error message
        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new User class instance
            User myUser = new User();

            Match usernameMatch = Regex.Match(txtUserName.Text.Trim(), @"^[a-zA-Z0-9]+$");


            //text validation
            if (txtUserName.Text.Trim() == "")
            {
                Error = "Debe escribir un nombre de usuario";
                goto ErrorMessage;
            }
            else if (!usernameMatch.Success)
            {
                Error = "El nombre de usuario escrito no es válido";
                goto ErrorMessage;
            }
            else if (txtFirstName.Text.Trim() == "")
            {
                Error = "Debe escribir un nombre";
                goto ErrorMessage;
            }
            else if (txtLastName.Text.Trim() == "")
            {
                Error = "Debe escribir un apellido";
                goto ErrorMessage;
            }

            //select case Update or New

            switch (cmdSave.Text)
            {

                case "Actualizar":

                    //parameters and db query to check if the entered user name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "users");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE users.userName='" + txtUserName.Text + "' AND users.id<>" + CurrentUserId.ToString());

                    database.Error = String.Empty;
                    int userUpdateCount = database.CountRows("__Counter", parameters);


                    if (userUpdateCount > 0)
                    {
                        //if the entered user name user  already exists
                        Error = "El nombre de usuario '" + txtUserName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the user instance we created before the textbox check


                    myUser.Id =this.CurrentUserId;
                    myUser.Username = txtUserName.Text;
                    myUser.FirstName = txtFirstName.Text;
                    myUser.LastName = txtLastName.Text;
                    myUser.DateModified = DateEngine.CurrentDateTimeDouble;

                    if (!myUser.Update())
                    {
                        //if there has been an error during user update
                        Error = myUser.Error;
                        goto ErrorMessage;
                    }

                    //Update password
                    //check if user entered a new password

                    if (txtNewPassword.Text.Trim().Length > 0)
                    {
                           if (txtNewPassword.Text.Length > 5 || txtNewPassword2.Text.Length > 5)
                        {
                            if (txtNewPassword.Text == txtNewPassword2.Text){

                                myUser.Password = txtNewPassword2.Text;

                                if (!myUser.UpdatePassword())
                                {
                                    //if there has been an error during password update
                                    Error = myUser.Error;
                                    goto ErrorMessage;
                                }
                            }
                            else
                            {
                                Error = "Las contraseñas no coinciden";
                                goto ErrorMessage;
                            }
                        }
                           else
                           {
                               Error = "La contraseña es muy corta";
                               goto ErrorMessage;
                           }
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered user name already exists

                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "users");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE users.userName='" + txtUserName.Text + "'");

                    database.Error = String.Empty;
                    int userAddCount = database.CountRows("__Counter", parameters);

                    if (userAddCount > 0)
                    {
                        //if the user name user entered already exists
                        Error = "El nombre de usuario '" + txtUserName.Text + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the user instance we created

                    myUser.Username = txtUserName.Text;
                    myUser.FirstName = txtFirstName.Text;
                    myUser.LastName = txtLastName.Text;

                    //check if empty password
                    if (txtNewPassword.Text.Trim().Length > 5)
                    {
                        //check if different passwords were entered
                        if (txtNewPassword.Text == txtNewPassword2.Text)
                        {
                            myUser.Password = txtNewPassword.Text;
                        }
                        else
                        {
                            Error = "Las contraseñas no coinciden";
                            goto ErrorMessage;
                        }
                    }
                    else
                    {
                        Error = "La contraseña no puede estar vacía";
                        goto ErrorMessage;
                    }
                    myUser.DateCreated = DateEngine.CurrentDateTimeDouble;
                    myUser.DateModified = DateEngine.CurrentDateTimeDouble;

                    try
                    {
                        if (myUser.AddNew()== 0)
                        {
                            //if there has been an error during user add
                            Error = myUser.Error;
                            goto ErrorMessage;
                        }
                    }
                    catch (Exception ee)
                    {

                        Error = ee.Message.ToString();
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                    break;

                default:
                    break;
            }

            //exit form and prevent empty message from showing

            this.Close();
            return;

        ErrorMessage:
            MessageBox.Show(this.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //enable or disable sencond password field according to first password length
                if (txtNewPassword.Text.Trim() != "" && txtNewPassword.Text.Length > 5)
                {
                    txtNewPassword2.Enabled = true;
                }
                else
                {
                    txtNewPassword2.Enabled = false;
                    txtNewPassword2.Text = "";
                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //cancel click event, send dialog result to main form
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }
        }

    }
}
