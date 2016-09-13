
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
using InkAlert.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace InkAlert
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]

        

        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            if (args.Contains("-server"))
            {
                GlobalSetup.IsServer = true;

                try
                {
                    string serverPath = Application.StartupPath.ToString() + @"\webserver\InkalertWebserver.exe";

                    if (File.Exists(serverPath)) {
                        Process[] pname = Process.GetProcessesByName("InkalertWebserver");
                        if (pname.Length == 0)
                        {
                            Process.Start(serverPath);
                        }
                        else
                        {
                            foreach (Process proc in Process.GetProcessesByName("InkalertWebserver"))
                            {
                                proc.Kill();
                                Thread.Sleep(2000);
                                Process.Start(serverPath);
                            }
                        }

                        Thread.Sleep(5000);
                    }
                    else
                    {
                        MessageBox.Show("Servidor local de InkAlert no se puede iniciar porque el archivo " + serverPath + " no fue encontrado.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Environment.Exit(Environment.ExitCode);
                    }
                }
                catch (Exception e){
                    MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(Environment.ExitCode);
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Startup ckecks

            try
            {
                if (!File.Exists(GlobalSetup.SettingsFolderPath + "\\" + GlobalSetup.SettingsFileName))
                {
                    MessageBox.Show("No se encontró el archivo de configuración. Complete el siguiente diálogo para crear un archivo de configuración", "Archivo de configuración no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    showConfigForm();
                }

                GlobalSetup.UpdateRunningConfig();

                Database database = new Database();

                if (Validation.ValidateDbConnection(database))
                {
                    if (!thereAreRegisteredUsers())
                    {
                        frmUserEdit formUserEdit = new frmUserEdit();
                        formUserEdit.txtUserName.Text = "Administrator";
                        formUserEdit.txtFirstName.Text = "The";
                        formUserEdit.txtLastName.Text = "Administrator";
                        formUserEdit.Text = "Registrar usuario administrador";
                        formUserEdit.cmdSave.Text = "Añadir";
                        formUserEdit.ShowDialog();

                        if (formUserEdit.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Por favor utilice su nombre de usuario y contraseña seleccionados para iniciar sesión", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No podrá iniciar sesión sin un usuario. Para volver a abrir el cuadro de registro, reinicie la aplicación.", "No hay usuarios registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Environment.Exit(Environment.ExitCode);
                        }
                    }
                }
                else
                {
                    string message = string.Empty;

                    if (GlobalSetup.IsServer)
                    {
                        Process[] pname = Process.GetProcessesByName("InkalertWebserver");
                        if (pname.Length == 0)
                        {
                            message = "El servidor local no se está ejecutando. ";
                        }
                    }

                    message += "No se ha podido conectar a la base de datos. Compruebe los datos de configuración.";
                    MessageBox.Show(message, "Datos de conexión inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showConfigForm();
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(null, ee.Message.ToString(), ee);
            }

            //end startup checks

            Application.Run(new frmLogin());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }

        private static void showConfigForm()
        {
            frmSettings formSettings = new frmSettings();

            DialogResult diagres = formSettings.ShowDialog();
            if (diagres == System.Windows.Forms.DialogResult.OK)
            {
                GlobalSetup.UpdateRunningConfig();
                Thread.Sleep(2000);
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }


        /// <summary>
        /// Checks if there are users in the database. If there are no users registered,
        /// frmUserEdit.cs will be display for the user to register as administrator
        /// </summary>
        /// <returns></returns>
        private static bool thereAreRegisteredUsers()
        {
            //Check if there are users in the database
            //instantiate parameters
            StoredProcedureParameters[] parameters;
            Database database = new Database();

            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_tableName", "users");
            parameters[1] = new StoredProcedureParameters("_condition", "WHERE users.userName<>''");

            int userCount = database.CountRows("__Counter", parameters);

            if (userCount == 0)
            {
                //MessageBox.Show("No se encontraron usuarios registrados en la base de datos. Por favor completa el siguiente formulario para crear el usuario Administrador de la aplicación.","No hay usuarios registrados",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
