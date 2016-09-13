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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InkAlert
{
    public class GlobalSetup : Database
    {
        public static string LogFolderPath
        {
            get { return Application.StartupPath + @"\Service\Log"; }
        }
        public static string LogFileName
        {
            get { return "InkAlertLog.txt"; }
        }

        public static string SettingsFolderPath
        {
            get { return Application.StartupPath + @"\Service\StartUp"; }
        }

        public static string SettingsFileName
        {
            get { return "Setup.db"; }
        }

        public static bool IsServer = false;
        private static bool isServer
        {
            get { return GlobalSetup.isServer; }
            set { GlobalSetup.isServer = value; }
        }

        private static string dataBaseName = "inkalert";
        public static string DataBaseName
        {
            get { return GlobalSetup.dataBaseName; }
            set { GlobalSetup.dataBaseName = value; }
        }

        private static string dataBaseServerName = "localhost";
        public static string DataBaseServerName
        {
            get { return GlobalSetup.dataBaseServerName; }
            set { GlobalSetup.dataBaseServerName = value; }
        }

        private static string dataBaseServerPort = "3306";
        public static string DataBaseServerPort
        {
            get { return GlobalSetup.dataBaseServerPort; }
            set { GlobalSetup.dataBaseServerPort = value; }
        }

        private static string dataBaseUserName = "root";
        public static string DataBaseUserName
        {
            get { return GlobalSetup.dataBaseUserName; }
            set { GlobalSetup.dataBaseUserName = value; }
        }

        private static string dataBasePassword = "";
        public static string DataBasePassword
        {
            get { return GlobalSetup.dataBasePassword; }
            set { GlobalSetup.dataBasePassword = value; }
        }

        private static int trackingInterval = 60;
        public static int TrackingInterval
        {
            get { return GlobalSetup.trackingInterval; }
            set { GlobalSetup.trackingInterval = value; }
        }

        private static int snmpRequestRetry = 1;
        public static int SnmpRequestRetry
        {
            get { return GlobalSetup.snmpRequestRetry; }
            set { GlobalSetup.snmpRequestRetry = value; }
        }

        private static int snmpRequestTimeOut = 500;
        public static int SnmpRequestTimeOut
        {
            get { return GlobalSetup.snmpRequestTimeOut; }
            set { GlobalSetup.snmpRequestTimeOut = value; }
        }

        private static string defaultLocalDomainName;
        public static string DefaultLocalDomainName
        {
            get { return GlobalSetup.defaultLocalDomainName; }
            set { GlobalSetup.defaultLocalDomainName = value; }
        }

        private static int printerHistoryCleanUpInterval = 90;
        public static int PrinterHistoryCleanUpInterval
        {
            get { return GlobalSetup.printerHistoryCleanUpInterval; }
            set { GlobalSetup.printerHistoryCleanUpInterval = value; }
        }

        private static bool showRunTimeErrors = false;
        public static bool ShowRunTimeErrors
        {
            get { return GlobalSetup.showRunTimeErrors; }
            set { GlobalSetup.showRunTimeErrors = value; }
        }

        private static string workGroup;
        public static string WorkGroup
        {
            get { return GlobalSetup.workGroup; }
            set { GlobalSetup.workGroup = value; }
        }

        private static string networkAdministrator;
        public static string NetworkAdministrator
        {
            get { return GlobalSetup.networkAdministrator; }
            set { GlobalSetup.networkAdministrator = value; }
        }

        private static string networkAdministratorPassword;
        public static string NetworkAdministratorPassword
        {
            get { return GlobalSetup.networkAdministratorPassword; }
            set { GlobalSetup.networkAdministratorPassword = value; }
        }

        public static string PSExecPath
        {
            get { return Application.StartupPath.ToString() + "\\PSExec\\"; }
        }

        public static string[] Months
        {
            get
            {
                return new string[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            }
        }

        private static int activeCounterCycleId;
        public static int ActiveCounterCycleId
        {
            get { return activeCounterCycleId; }
            set { activeCounterCycleId = value; }
        }

        private static string logRunTimeErrors;
        public static string LogRunTimeErrors
        {
            get { return GlobalSetup.logRunTimeErrors; }
            set { GlobalSetup.logRunTimeErrors = value; }
        }

        internal bool SaveSettings()
        {
            try
            {
                FileManager myFileManager = new FileManager();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public static string UpdateRunningConfig()
        {
            //Update current program variables


            try
            {
                string[] lines = System.IO.File.ReadAllLines(GlobalSetup.SettingsFolderPath + "\\" + GlobalSetup.SettingsFileName);

                foreach (string line in lines)
                {
                    if (!line.Contains("=") || line.Trim().Length == 0)
                    {
                        continue;
                    }

                    string[] dataline;
                    dataline = line.Split('=');

                    object newLineValue = dataline[1].ToString();

                    switch (dataline[0].ToString())
                    {
                        case "DataBaseServerName":
                            GlobalSetup.DataBaseServerName = newLineValue.ToString();
                            break;
                        case "DataBaseServerPort":
                            GlobalSetup.DataBaseServerPort = newLineValue.ToString();
                            break;
                        case "DataBaseName":
                            GlobalSetup.DataBaseName = newLineValue.ToString();
                            break;
                        case "DataBaseUserName":
                            GlobalSetup.DataBaseUserName = newLineValue.ToString();
                            break;
                        case "DataBasePassword":
                            GlobalSetup.DataBasePassword = newLineValue.ToString();
                            break;
                        case "TrackingInterval":
                            GlobalSetup.TrackingInterval = Convert.ToInt32(newLineValue);
                            break;
                        case "SnmpRequestRetry":
                            GlobalSetup.SnmpRequestRetry = Convert.ToInt32(newLineValue);
                            break;
                        case "SnmpRequestTimeOut":
                            GlobalSetup.SnmpRequestTimeOut = Convert.ToInt32(newLineValue);
                            break;
                        case "DefaultLocalDomainName":
                            GlobalSetup.DefaultLocalDomainName = newLineValue.ToString();
                            break;
                        case "PrinterHistoryCleanUpInterval":
                            GlobalSetup.PrinterHistoryCleanUpInterval = Convert.ToInt32(newLineValue);
                            break;
                        case "WorkGroup":
                            GlobalSetup.WorkGroup = newLineValue.ToString();
                            break;
                        case "NetworkAdministrator":
                            GlobalSetup.NetworkAdministrator = newLineValue.ToString();
                            break;
                        case "NetworkAdministratorPassword":
                            GlobalSetup.NetworkAdministratorPassword = newLineValue.ToString();
                            break;
                        case "LogRunTimeErrors":
                            GlobalSetup.LogRunTimeErrors = newLineValue.ToString();
                            break;

                        default:
                            break;
                    }

                }

                string cmdString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};", GlobalSetup.DataBaseServerName, GlobalSetup.DataBaseServerPort, GlobalSetup.DataBaseUserName, GlobalSetup.DataBasePassword, GlobalSetup.DataBaseName);
                return cmdString;


            }
            catch (Exception ee)
            {
                return ee.Message.ToString();

                EventLogger.LogEvent(null, ee.Message.ToString(), ee);
                string cmdString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};", GlobalSetup.DataBaseServerName, GlobalSetup.DataBaseServerPort, GlobalSetup.DataBaseUserName, GlobalSetup.DataBasePassword, GlobalSetup.DataBaseName);
                return cmdString;
            }

            //end update variables
        }


        //User session

        private static User currentSessionUser = null;
        public static User CurrentSessionUser
        {
            get { return GlobalSetup.currentSessionUser; }
            set { GlobalSetup.currentSessionUser = value; }
        }


    }
}
