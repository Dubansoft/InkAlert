
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
using FormValidation;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmSettings : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        public Form WhoOpenedThis = null;

        public frmSettings()
        {
            InitializeComponent();
            FillControls();
        }
        private void FillControls()
        {
            try
            {
                //Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                string[] lines = System.IO.File.ReadAllLines(GlobalSetup.SettingsFolderPath + "\\" + GlobalSetup.SettingsFileName);

                DataTable dtSettings = new DataTable();
                dtSettings.Columns.Add(new DataColumn("ParamName", Type.GetType("System.String")));
                dtSettings.Columns.Add(new DataColumn("ParamValue", Type.GetType("System.String")));

                foreach (string line in lines)
                {
                    if (!line.Contains("=") || line.Trim().Length == 0)
                    {
                        continue;
                    }

                    string[] dataline;
                    dataline = line.Split('=');

                    DataRow row;
                    row = dtSettings.NewRow();
                    row["ParamName"] = dataline[0].ToString();
                    row["ParamValue"] = dataline[1].ToString();
                    dtSettings.Rows.Add(row);
                }

                // Display the file contents by using a foreach loop.
                foreach (Control control in this.Controls)
                {
                    if (control is GroupBox)
                    {
                        foreach (Control groupBoxControl in control.Controls)
                        {
                            DataRow selectedSettingParam = dtSettings.Select("ParamName = '" + groupBoxControl.Name.Substring(3) + "'").FirstOrDefault();

                            if (groupBoxControl is TextBox)
                            {

                                ((TextBox)groupBoxControl).Text = selectedSettingParam[1].ToString();
                            }
                            else if (groupBoxControl is NumericUpDown)
                            {
                                ((NumericUpDown)groupBoxControl).Value = Convert.ToDecimal(selectedSettingParam[1].ToString());
                            }
                            else if(groupBoxControl is CheckBox)
                            {
                                ((CheckBox)groupBoxControl).Checked = Convert.ToBoolean(selectedSettingParam[1].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

        }

        public bool checkDB_Conn()
        {
            var conn_info = "Server=" + txtDataBaseServerName.Text + ";Port=" + txtDataBaseServerPort.Text + ";Database=" + txtDataBaseName.Text + ";Uid=" + txtDataBaseUserName.Text + ";Pwd="+ txtDataBasePassword.Text;
            bool isConn = false;
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(conn_info);
                conn.Open();
                isConn = true;
                conn.Close();
            }
            catch (ArgumentException a_ex)
            {
                MessageBox.Show(a_ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(a_ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                isConn = false;
            }
            catch (MySqlException ex)
            {
                string sqlErrorMessage = "Error:\n\n" + ex.Message + "\n" +
                "Fuente del error: " + ex.Source + "\n" +
                "Código del error: " + ex.Number;

                isConn = false;
                switch (ex.Number)
                {
                    case 1042:
                        MessageBox.Show("Imposible conectarse al servidor especificado, compruebe el nombre del servidor o la dirección IPv4 especificada.\n\n" + sqlErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    case 0:
                        MessageBox.Show("Se ha denegado el acceso al servidor especificado, compruebe el nombre de la base de datos, el nombre de usuario y la contraseña.\n\n" + sqlErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            conn.Close();
            return isConn;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate.ValidateTextbox(
                new TextBox[] {
                    txtDataBaseServerName,
                    txtDataBaseServerPort,
                    txtDataBaseName,
                    txtDataBaseUserName,
                    txtDefaultLocalDomainName,
                    txtWorkGroup,
                    txtNetworkAdministrator,
                    txtNetworkAdministratorPassword
                }))
            {
                return;
            }

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(txtDataBaseServerName.Text.Trim(), Convert.ToInt32(txtDataBaseServerPort.Text.Trim()));
                }
                catch (SocketException ee)
                {
                    MessageBox.Show(String.Format("No es posible conectarse al servidor {0} en el  puerto {1}", txtDataBaseServerName.Text.Trim(), txtDataBaseServerPort.Text.Trim()) + "\n\n" + ee.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                client.Close();

            }

            try
            {
                int timeout = 120;
                Ping pingSender = new Ping();

                PingReply reply = pingSender.Send(txtDataBaseServerName.Text.Trim(), timeout);

                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.Show("El servidor " + txtDataBaseServerName.Text.Trim() + " no responde. Valide su conexión de red o la conexión de red del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }

            if (!checkDB_Conn())
            {
                return;
            }

            try
            {
                FileManager myFileManager = new FileManager();
                myFileManager.FolderPath = GlobalSetup.SettingsFolderPath;
                myFileManager.FileName = GlobalSetup.SettingsFileName;

                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("DataBaseServerName={0}\n", txtDataBaseServerName.Text.Trim()));
                sb.Append(String.Format("DataBaseServerPort={0}\n", txtDataBaseServerPort.Text.Trim()));
                sb.Append(String.Format("DataBaseName={0}\n", txtDataBaseName.Text.Trim()));
                sb.Append(String.Format("DataBaseUserName={0}\n", txtDataBaseUserName.Text.Trim()));
                sb.Append(String.Format("DataBasePassword={0}\n", txtDataBasePassword.Text.Trim()));
                sb.Append(String.Format("TrackingInterval={0}\n", nupTrackingInterval.Value.ToString()));
                sb.Append(String.Format("SnmpRequestRetry={0}\n",nupSnmpRequestRetry.Value.ToString()));
                sb.Append(String.Format("SnmpRequestTimeOut={0}\n",nupSnmpRequestTimeOut.Value.ToString()));
                sb.Append(String.Format("DefaultLocalDomainName={0}\n",txtDefaultLocalDomainName.Text.ToString()));
                sb.Append(String.Format("PrinterHistoryCleanUpInterval={0}\n", nupPrinterHistoryCleanUpInterval.Value.ToString()));
                sb.Append(String.Format("WorkGroup={0}\n", txtWorkGroup.Text.ToString()));
                sb.Append(String.Format("NetworkAdministrator={0}\n", txtNetworkAdministrator.Text.ToString()));
                sb.Append(String.Format("NetworkAdministratorPassword={0}\n", txtNetworkAdministratorPassword.Text.ToString()));
               sb.Append(String.Format("LogRunTimeErrors={0}\n", chkLogRunTimeErrors.Checked.ToString()));

                myFileManager.Text = sb.ToString();
                myFileManager.RemoveFile();
                myFileManager.WriteToFile();

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

        }


        private void txtDataBaseServerName_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El nombre o la dirección IPv4 del Servidor MySql donde se aloja la base de datos.";
        }

        private void txtDataBaseName_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El nombre de la base de datos a la cual se conectará el programa para almacenar la información";
        }

        private void txtDataBaseUserName_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El usuario de la base de datos.";
        }

        private void txtDataBasePassword_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "La contraseña de la base de datos.";
        }

        private void nupTrackingInterval_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "La frecuencia en minutos con la que se realizará la recolección de datos.";
        }

        private void nupSnmpRequestRetry_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El número de intentos que se realizarán para conectarse a los dispositivos, computadores o impresoras.";
        }

        private void nupSnmpRequestTimeOut_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El tiempo durante el cual se se esperará una respuesta del dispositivo o impresora.";
        }

        private void txtDefaultLocalDomainName_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El dominio por defecto de todos los dispositivos o impresoras. Por ejemplo 'miempresa.loc'";
        }

        private void nupPrinterHistoryCleanUpInterval_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "Número de meses durante los cuales se almacenará el historial de consumibles de las impresoras. El valor mínimo es 12.";
        }

        private void chkLogRunTimeErrors_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "InkAlert se puede actualizar automáticamente por medio de un proceso de Windows llamado Inkalert Database Updater Service. Esta opción habilita el registro de eventos del servicio en el registro de Eventos de Windows.";
        }

        private void txtWorkGroup_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El grupo de trabajo por defecto asociado todos los dispositivos o impresoras. Por ejemplo MI_EMPRESA\\";
        }

        private void txtNetworkAdministrator_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El nombre de usuario administrador de la red";
        }

        private void txtNetworkAdministratorPassword_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "La contraseña de la red";
        }

        private void cmbCounterCycles_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El ciclo de contador actual.";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            lblMessage.Text = "El puerto que se ha asignado en el servidor al MySql.";
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

    }
}
