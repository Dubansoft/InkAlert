
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
using SnmpSharpNet;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmPrinterStatus
    {
        BackgroundWorker myBackgroundPrinterUpdater = new BackgroundWorker();

        //Let's create a tempDataTable to put the information corresponding
        //to the printers that we will update in the background process
        DataTable tempPrinterDataTable = new DataTable();
        DataTable tempOidDataTable = new DataTable();

        protected void myWorker_DoPrinterUpdate(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Capture the BackgroundWorker that fired the event
                BackgroundWorker sendingWorker = (BackgroundWorker)sender;

                //Collect the array of objects the we recived from the main thread
                object[] arrObjects = (object[])e.Argument;

                //Set updateMode value to the first parameter of arrObjects
                string updateMode = arrObjects[0].ToString();

                //At each iteration of the loop, check if there is a cancellation request pending 
                if (!sendingWorker.CancellationPending)
                {

                    #region "UpdateProcess"

                    string returnString = "";

                    //Let's first check if there are rows selected
                    if (dgPrinters.SelectedRows.Count > 0)
                    {
                        //Lets switch the updateMode
                        switch (updateMode)
                        {
                            //If updateMode is OnlySelected
                            case "OnlySelected":
                                tempPrinterDataTable = dataTableFromDataGrid(dgPrinters, updateMode);
                                break;

                            //If updateMode is All or not defined
                            default:
                                tempPrinterDataTable = dataTableFromDataGrid(dgPrinters, "All");
                                break;
                        }
                    }

                    //Lets create a counter to report progress
                    int processStatus = 0;
                    //Now, lets loop tempDataTable to get data for every printer
                    foreach (DataRow row in tempPrinterDataTable.Rows)
                    {
                        //Let's create a variable to store the current printer model Id
                        int currentPrinterModelId = Convert.ToInt32(row["printerModelId"]);
                        int currentPrinterConnectionTypeId = Convert.ToInt32(row["printerConnectionTypeId"]);
                        //Now, lets create a dataTable to put the Oids of the
                        //model of the current selected printer... to do that,...

                        //First, let's create the procedure parameters,
                        parameters = new StoredProcedureParameters[2];
                        parameters[0] = new StoredProcedureParameters("_printerModelId", currentPrinterModelId.ToString());
                        parameters[1] = new StoredProcedureParameters("_printerConnectionTypeId", currentPrinterConnectionTypeId.ToString());

                        //Second, let's create a datatable for the model of the printer.
                        //This datatable will be stored in database.DbDataset1
                        database.ReadTable("Printer_GetOidInfo", "dtPrinterModelOids_" + CurrentPrinterModelId, null, parameters);

                        //Third, let's create a pdu to handle the OID data request
                        Pdu myPdu = new Pdu(PduType.Get);

                        //Then, lets create a new datatable to the oid addresses
                        //of this model in it
                        DataTable oidDataTable = new DataTable();

                        //Lets give the datatable a particular name, 
                        //containing the printer model id
                        oidDataTable = database.DbDataset1.Tables["dtPrinterModelOids_" + CurrentPrinterModelId];

                        //Now that we have a datatable containing the model
                        //oid data, lets loop through it to get some data..
                        foreach (DataRow oidTableRow in oidDataTable.Rows)
                        {
                            //Let's create a string to store the oidAddress
                            string newOidAddress = oidTableRow["oidAddress"].ToString();

                            //And then, let's add it to myPdu list
                            myPdu.VbList.Add(newOidAddress);

                        }
                        //With all above done, lets create an instance of PrinterSnmpUpdate();
                        PrinterSnmpUpdate myOidUpdatePrinter = new PrinterSnmpUpdate();

                        //Lets add the new printer its parameters
                        //based on the current dataTable row being processed
                        myOidUpdatePrinter.Id = Convert.ToInt32(row["id"]);
                        myOidUpdatePrinter.PrinterAreaId = Convert.ToInt32(row["printerAreaId"]);
                        myOidUpdatePrinter.PrinterModelId = Convert.ToInt32(row["printerModelId"]);
                        myOidUpdatePrinter.HostName = row["areaIpAddress"].ToString();
                        myOidUpdatePrinter.PduOidList = myPdu;

                        //Now, lets create a vbcollection
                        //to store the data we will receive from the printer
                        VbCollection resultList = myOidUpdatePrinter.GetPrinterInfo();

                        //And now, lets create myOidResultsColumn 
                        //We will add this datacolumn to oidDataTable
                        //which contains so far only the oidType and the
                        //oidAddress collection for every printer model. 
                        DataColumn myOidResultsColumn = new DataColumn();
                        myOidResultsColumn.ColumnName = "oidResult";
                        myOidResultsColumn.DataType = Type.GetType("System.String");

                        //Now, since this is going to loop over and over again, let's
                        //check if the column oidResult has been already added to
                        //oidDataTable, and if that is true, let's remove it

                        if (oidDataTable.Columns.Contains("oidResult"))
                        {
                            oidDataTable.Columns.Remove("oidResult");
                        }

                        //And let's finally add the new column to oidDataTable
                        oidDataTable.Columns.Add(myOidResultsColumn);

                        //Let's create a variable to store the printer status,
                        //up to now, 0 = offline and 1 = online, default is 0
                        //in the future we could set 2 = warning and 3 = error
                        int newPrinterStatus = 0;

                        //While generating the resultList, 
                        //if there has been an error, the first list value is "Null",
                        //so, lets check if there has been any errors
                        //if there is any, we'll omit this part
                        if (resultList[0].Value.ToString() != "Null")
                        {
                            //We got in here because there has been no error

                            //Lets create an empty string to store the query
                            string historyUpdateQuery = string.Empty;

                            //If there are records in the resultList VbCollection
                            //then there has been a reply and the printer is online
                            int printerStatus = resultList.Count > 1 ? 1 : 0;


                            //foreach (DataRow oidRow in oidDataTable.Rows)
                            //{
                            //    //EventLogger.LogEvent(this, ,null);

                            //    foreach (DataColumn oidColumn in oidDataTable.Columns){
                            //        EventLogger.LogEvent(this, oidColumn.ColumnName.ToString() ,null);
                            //    }

                            //}
                            //Now, lets build the query that will insert the new row
                            //MessageBox.Show(oidDataTable.Rows.Count.ToString());
                            //in the table 'printerHistory', containing all new printer data retrieved 
                            //during this request

                            //Lets add the head
                            historyUpdateQuery = "INSERT INTO printerhistory ";

                            //Let's add the default fields
                            historyUpdateQuery += "(id,printerSerialId,printerAreaId,dataDate,";

                            //Let's append the oidTypes corresponding to
                            //the ones in the oidDataTable
                            foreach (DataRow dataRow in oidDataTable.Rows)
                            {
                                if (!(dataRow["oidType"].ToString().Contains("Max"))){

                                    historyUpdateQuery += dataRow["oidType"].ToString() + ",";

                                }
                                else
                                {
                                    //EventLogger.LogEvent(this, "Found " + dataRow["oidType"].ToString() + " in query string", null);
                                }
                            }

                            //Once all oidTypes appended, 
                            //let's remove the last comma
                            historyUpdateQuery = historyUpdateQuery.Remove(historyUpdateQuery.Length - 1);

                            //And then let's add some requiere stuff to the query
                            historyUpdateQuery += ") VALUES (";

                            //Next, lets add the default values

                            historyUpdateQuery += "NULL,";//the first field corresponds to the id, it must be null
                            historyUpdateQuery += myOidUpdatePrinter.Id.ToString() + ",";//the id of the current printer
                            historyUpdateQuery += myOidUpdatePrinter.PrinterAreaId.ToString() + ",";//the id of the current serial id
                            historyUpdateQuery += "'" + DateEngine.CurrentDateTimeDouble + "',";//current date, in numeric format
                            //Previouly we created a datatable to store oids
                            //and then we added a dataColumn to store the results.
                            //So far this dataColumn is empty, so, lets fill it
                            //Here, we will loop both oidDataTable.Rows and resultList
                            //in order to move the data from the
                            //resultList onto the oidDataTable column and then use it 
                            //while building the query

                            //EventLogger.LogEvent(this, oidDataTable.Rows.Count.ToString(),null);
                            //EventLogger.LogEvent(this, resultList.Count.ToString(), null);
                            //Lets create i
                            int i = 0;

                            //Lets create an empty delimiter to wrap string values
                            string delimiter = string.Empty;
                            foreach (DataRow dataRow in oidDataTable.Rows)
                            {
                                //Now, when there has been no error but the reply was empty
                                //the resultList hosts an empty string as the result
                                //so, if that is NOT case, lets move the data from the
                                //result list onto the oidDataTable column
                                if (resultList[i].Value.ToString().Length > 0)
                                {

                                    //Lets find the type of returned value: These are the valid types:
                                    //Integer.Used
                                    //Integer.Left
                                    //Integer
                                    //String

                                    //Now, lets take into account that in the db stored
                                    //procedure, we do some math to get the values based
                                    //on the current status of oids
                                    //Some oids return a value representing the left amount
                                    //of clics or tonner. 
                                    //However, some other oids return the used amount
                                    //or clics or tonner, for example
                                    //if a tonner prints 15k pages, depending on 
                                    //the printer model, tonner leves may be reported
                                    //as the amount already used, or the amount that is left
                                    //in this case, if your printer has printed 3k pages, 
                                    //you may find a value of 12k or a value of 3k.
                                    //3k is of type Integer.Used
                                    //and 12k is of type Integer.Left
                                    //Here we will base all calculations on Integer.Left,
                                    //if the printer reports Integer.Used instead, 
                                    //we'll try to convert that value into Integer.Left

                                    //Let's first define a variable for maxValue
                                    int maxValue = 0;

                                    //Another one for usedValue
                                    int usedValue = 0;

                                    //Another for oidType
                                    //this will store the current type of oid
                                    //remember that types refer to the types of information
                                    //that we can get by means of oids, for example
                                    //tonner levels, serial numbers, etc.
                                    string oidType = string.Empty;

                                    //And another one for storing the type name of the current level type.
                                    string maxValueType = string.Empty;

                                    //EventLogger.LogEvent(this, "Started switch",null);
                                    //EventLogger.LogEvent(this, dataRow["oidReturnDataType"].ToString(),null);
                                    switch (dataRow["oidReturnDataType"].ToString())
                                    {
                                        
                                        case "Integer.Left":

                                            //Let's get the current oid type
                                            oidType = dataRow["oidType"].ToString();
                                            //EventLogger.LogEvent(this, oidType, null);
                                            //Let's now check if it contains the word Level
                                            //Every oidType labeled as **Level
                                            //Must have a matchig oidType labeled as **Max
                                            //For example, oidBlackLevel must have a peer oidType
                                            //called oidBlackMax
                                            if (oidType.Contains("Level"))
                                            {
                                                //Lets translate oidType into maxValueType
                                                maxValueType = oidType.Replace("Level", "Max");
                                                //EventLogger.LogEvent(this, maxValueType, null);
                                                //To find the corresponding oidMax
                                                //we will query oidDatTable with its Select method
                                                DataRow[] dataRowMaxValue = oidDataTable.Select("oidType='" + maxValueType + "'");

                                                //This doesn't work if the query isn't ordering the oidTypes 
                                                //alphabetically from the stored procedure query itself,
                                                //so that the MaxValue has already 
                                                //been retrieved when we ask for the Left or Used values
                                                maxValue = Convert.ToInt32(dataRowMaxValue[0][4].ToString());

                                                //Now that we have the max value, lets get the Used value.
                                                usedValue = Convert.ToInt32(resultList[i].Value.ToString());

                                                //And using both of them, lets get the left value.
                                                double leftValueD = maxValue - usedValue;

                                                int percentResult = Convert.ToInt32((1-(leftValueD / maxValue))*100);

                                                //EventLogger.LogEvent(this, "Tóner actual en porcentaje: " + (percentResult.ToString() + "%"), null);

                                                //And add it to the datatable 
                                                dataRow["oidResult"] = percentResult.ToString();//resultList[i].Value.ToString();

                                            }

                                            break;

                                        default:

                                            dataRow["oidResult"] = resultList[i].Value.ToString();
                                            //EventLogger.LogEvent(this, resultList[i].Value.ToString(), null);

                                            break;
                                    }
                                    
                                }
                                else //if (dataRow["oidResult"].ToString() == string.Empty || dataRow["oidResult"].ToString().Length == 0)
                                {
                                    //If the result is an empty string, 
                                    //lets add 0 instead of "".
                                    dataRow["oidResult"] = "0";
                                    //EventLogger.LogEvent(this, "0", null);
                                }


                                //Now, in order to know if the data will
                                //be processed as numbers or strings, lets check
                                //the oid return datatype
                                switch (dataRow["oidReturnDataType"].ToString())
                                {
                                    //if oidReturnDataType is string, lets add "'"
                                    case "String":
                                        delimiter = "'";
                                        break;

                                    default:
                                        delimiter = "";
                                        break;
                                }
                                //Now, lets add the values, adding a deliminter 
                                //when requiered

                                if(!(dataRow["oidType"].ToString().Contains("Max")))
                                {
                                    historyUpdateQuery += delimiter + dataRow["oidResult"] + delimiter + ",";
                                }

                                i += 1;
                            }
                            //Once finish adding all values to the query, lets remove
                            //the last comma.
                            historyUpdateQuery = historyUpdateQuery.Remove(historyUpdateQuery.Length - 1);
                            //And let's close the query.
                            historyUpdateQuery += "); ";
                            //EventLogger.LogEvent(this, historyUpdateQuery, null);
                            //Lets see it in the console.
                            //EventLogger.LogEvent(this, historyUpdateQuery);


                            //Now, lets send the query to the database
                            //So lets build the stored procedure parameters:
                            parameters = new StoredProcedureParameters[1];
                            parameters[0] = new StoredProcedureParameters("_commandText", historyUpdateQuery);

                            //And call the __RunCommand function and pass the query
                            //as a parameter
                            database.RunStoredProcedure("__RunCommand", parameters);

                            //Every time the program can connect to the printer
                            //a new row is inserted in the printerHistory table
                            //so, if there's a reply, the printer is online
                            //and newPrinterStatus must be set to 1, because so far
                            //its value is its default, 0
                            newPrinterStatus = 1;
                        }//end if

                        //Now, lets build a query to update printerStatus field
                        //in the printers table

                        //lets create a string to store the query
                        string printerStatusUpdateQuery;

                        //lets add the data
                        printerStatusUpdateQuery = "UPDATE printerserials SET printerStatus=";
                        printerStatusUpdateQuery += newPrinterStatus;
                        printerStatusUpdateQuery += " WHERE id=";
                        printerStatusUpdateQuery += myOidUpdatePrinter.Id.ToString() + ";";

                        //lets write the query to the output
                        //EventLogger.LogEvent(this, printerStatusUpdateQuery);

                        //Lets create another StoredProcedureParameter 
                        parameters = new StoredProcedureParameters[1];
                        parameters[0] = new StoredProcedureParameters("_commandText", printerStatusUpdateQuery);

                        //And lets run __RunCommand
                        database.RunStoredProcedure("__RunCommand", parameters);

                        returnString = row["printerModelId"].ToString();

                        processStatus += 1;
                        //EventLogger.LogEvent(this, "Test", null);
                        this.tempOidDataTable = oidDataTable;
                        //EventLogger.LogEvent(this, tempOidDataTable.Rows.Count.ToString(), null);

                        //Report our progress to the main thread
                        sendingWorker.ReportProgress(processStatus);
                    }

                    #endregion "//UpdateProcess"

                    //Set the result
                    e.Result = true;


                    //Set refresh pending to true

                }
                else
                {
                    //If a cancellation request is pending, assign this flag a value of true
                    e.Cancel = true;
                }

                e.Result = "Operación finalizada";// Send our result to the main thread!
        }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }


}

        protected void myWorker_PrinterUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!e.Cancelled && e.Error == null)//Check if the worker has been cancelled or if an error occured
            {
                string result = (string)e.Result;//Get the result from the background thread
                myStartForm.UpdateStatus("Actualización completada", 100);
            }
            else if (e.Cancelled)
            {
                myStartForm.UpdateStatus("Actualización cancelada", 0);
            }
            else
            {
                myStartForm.UpdateStatus("Ha ocurrido un error", 0);
            }

            actualizarTodoToolStripMenuItem.Text = "Actualizar todo";
            actualizarTodoToolStripMenuItem.Enabled = true;//Reneable the start button
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }

            gridRefresh();
        }

        protected void myWorker_PrinterUpdateProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //Show the progress to the user based on the input we got from the background worker
            int totalRows = tempPrinterDataTable.Rows.Count;
            int reportedProgress = e.ProgressPercentage;
            double progressValueDbl = ((double)reportedProgress / totalRows) * 100;
            int progressValue = (int)progressValueDbl;

            myStartForm.UpdateStatus(string.Format("Actualizando impresora número {0} de {1} seleccionadas. Presione esc para cancelar.", reportedProgress, totalRows.ToString()), progressValue);

            actualizarTodoToolStripMenuItem.Text = string.Format("Actualizando impresora: {0}...", e.ProgressPercentage);

            this.dataGridView1.DataSource = tempOidDataTable;
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(),ee);
            }
        }
    }
}
