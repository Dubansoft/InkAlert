
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmMonthlyReport : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        Database database = new Database();
        StoredProcedureParameters[] parameters;
        public BackgroundWorker MyBackgroundMonthlyReportUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmMonthlyReport myMonthlyReportForm = Application.OpenForms.OfType<frmMonthlyReport>().FirstOrDefault();

        private bool categoriseOnly = false;
        private bool showTableseOnly = false;

        private double TotalRows = 0;
        private object[,] filters = new object[,]
        {
            { "Microsoft Word", new string[] { ".doc%", "word", "libreoffice writer","documento%1", "documento%2", "documento%3" } },
            { "Microsoft Excel", new string[] {"spread", ".xls%", "excel", "libreoffice calc", "libro%1", "libro%2", "libro%3", "libro%4", "libro%5", "libro%6", "libro%7", "libro%8", "libro%9" } },
            { "Tarjetas de trazab. de disp. méd.", new string[] { "trazabilidad%dispositivo%m%dico"} },
            { "PDF", new string[] { "pdf", "acrobat"} },
            { "Microsoft Power Point", new string[] { "ppt", "pptx", "power%point"} },
            { "CrgV4.0", new string[] { "crgv4.0"} },
            { "Print Report", new string[] { "print report"} },
            { "Vlf", new string[] { "vlf"} },
            { "EspV4", new string[] { "espv4"} },
            { "MSDataReport", new string[] { "msdatareport"} },
            { "AtnV4.0", new string[] { "atnv4.0"} },
            { "Printing from PrintComponent", new string[] { "printing from printcomponent"} },
            { "CSV", new string[] { "csv"} },
            { "Imagenologia", new string[] { "imagenolog%a"} },
            { "ECG", new string[] { "ecg"} },
            { "Laboratorio", new string[] { "laboratorio"} },
            { "Crystal Reports", new string[] { "crystal"} },
            { "Anexo", new string[] { "anexo"} },
            { "Cuadros de turno", new string[] { "turno"} },
            { "Anatomía Patológica", new string[] { "anatom%a patol%gica"} },
            { "CTC", new string[] { "ctc"} },
            { "IPS", new string[] { "ips" } },
            { "Correo Electrónico", new string[] { "outlook", "fwd:", "re:", "gmail", "https://bay%.ms" } },
            { "Recomendaciones para cirugia", new string[] { "recomendaciones para cirug%a"} },
            { "Bloc de notas", new string[] { "notepad", "bloc de notas", "sin t%tulo", ".txt"} },
            { "Internet", new string[] { ".net", ".org", ".com", ".edu", ".es", "http://%.co", "http://%.tv", "https://", ".gov.co" } },
            { "Intranet", new string[] { "http://cessrv", "http://hera/" } },
            { "Document, documento, Documento ", new string[] { "level document", "remoto%nivel", "document", "documento"} },
            { "Imágenes", new string[] { "fotograf%a%p%gina%completa",".png",".jpg",".gif", "image"} },
            { "Estándares de Procedimientos", new string[] { "estandares%procedimientos" } },
            { "Fórmulas con logo", new string[] { "f%rmulas%logo" } },
            { "Adobe Illustrator", new string[] { ".ai" } },
            { "Registro de entrega y recepcion de pacientes trasladados en ambulancia", new string[] { "registro%entrega%recepcion%pacientes%trasladados%ambulancia" } },
            { "Sucursal Virtual Empresas", new string[] { "sucursal%virtual%empresas" } },
            { "Validador de usuarios Sanitas", new string[] { "validador%usuarios%sanitas" } },
        };

        #endregion

        public frmMonthlyReport()
        {
            InitializeComponent();

            MyBackgroundMonthlyReportUpdater.DoWork += new DoWorkEventHandler(MyBackgroundMonthlyReportUpdater_HardWork);
            MyBackgroundMonthlyReportUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundMonthlyReportUpdater_Completed);
            MyBackgroundMonthlyReportUpdater.ProgressChanged += new ProgressChangedEventHandler(myWorker_PrinterUpdateProgressChanged);
            MyBackgroundMonthlyReportUpdater.WorkerReportsProgress = true;
            MyBackgroundMonthlyReportUpdater.WorkerSupportsCancellation = false;

            dgCategories.AssignedContextMenuStrip = contextMenuCategories;
        }


        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes dgAreas datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundMonthlyReportUpdater.IsBusy)
            {
                //Run background worker to fill dgAreas
                MyBackgroundMonthlyReportUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundMonthlyReportUpdater was called while it was still busy.", null);
            }
        }

        /// <summary>
        /// Reloads the dgAreas datagrid in the background.
        /// </summary>
        private void MyBackgroundMonthlyReportUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Set parent form status
            myStartForm.UpdateStatus("Procesando información...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            try
            {
                
                //Read each line of the file into a string array. Each element
                // of the array is one line of the file.
                

                parameters = new StoredProcedureParameters[1];
                
                if (this.categoriseOnly) { goto Criteria; }
                if (this.showTableseOnly) { goto ShowTablesOnly;  }
                
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Database.sql";
                string[] lines = System.IO.File.ReadAllLines(filePath);
                string updateCommand = string.Empty;

                //Truncate table Impresiones
                updateCommand = "DELETE FROM impresiones;";

                parameters[0] = new StoredProcedureParameters("_commandText", updateCommand.ToString());
                database.RunStoredProcedure("__RunCommand", parameters);

                this.TotalRows = lines.Length;
                double i = 0;

                foreach (string line in lines)
                {
                    updateCommand = string.Empty;

                    if(!(line.Trim().Length > 0)){ continue; }

                    updateCommand = updateCommand + "INSERT INTO impresiones VALUES " + line.ToString();
                    updateCommand = updateCommand.Remove(updateCommand.Length - 1);

                    parameters[0] = new StoredProcedureParameters("_commandText", updateCommand.ToString());
                    database.RunStoredProcedure("__RunCommand", parameters);

                    i = i + 1;
                    sendingWorker.ReportProgress(Convert.ToInt32(i));
                }

                Criteria:


                //Set otros for all entries
                updateCommand = "UPDATE impresiones SET Category='Otros' WHERE id>0";
                parameters[0] = new StoredProcedureParameters("_commandText", updateCommand.ToString());
                database.RunStoredProcedure("__RunCommand", parameters);

                for (int ii = 0; ii < this.filters.Length / 2; ii++)
                {
                    updateCommand = string.Empty;
                    string likeCommand = string.Empty;
                    string currentCriteriaCategory = Convert.ToString(this.filters[ii,0]);

                    updateCommand = "UPDATE impresiones SET Category='" + currentCriteriaCategory + "' WHERE Category='Otros' AND (";

                    string[] filterOptions = (String[])this.filters[ii, 1];

                    for (int cc = 0; cc < filterOptions.Length; cc++)
                    {
                        likeCommand = likeCommand + "LCASE(JobName) LIKE '%" + filterOptions[cc].ToString().ToLower() + "%' ";

                        if (filterOptions.Length - 1 > cc) { likeCommand = likeCommand + " OR ";}
                        EventLogger.LogEvent(this, filterOptions[cc].ToString(), null);
                    }

                    updateCommand = updateCommand + likeCommand + ");";
                    parameters[0] = new StoredProcedureParameters("_commandText", updateCommand.ToString());
                    database.RunStoredProcedure("__RunCommand", parameters);
                    
                }

            ShowTablesOnly:

                database.ReadTable("PrintoutCategoryCounts_Get", "dtCategories", null, null);
                database.ReadTable("PrintoutCategoryOtherCounts_Get", "dtOthers", null, null);


            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }

            e.Result = "OK";

        }

        /// <summary>
        /// Runs when MyBackgroundAreaUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundAreaUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundMonthlyReportUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {

                //Set the datasource for dgAreas datagrid

                dgCategories.AutoGenerateColumns = true;
                dgOthers.AutoGenerateColumns = true;

                if (database.DbDataset1.Tables.Contains("dtCategories"))
                {
                    dgCategories.DataSource = database.DbDataset1.Tables["dtCategories"];
                }

                if (database.DbDataset1.Tables.Contains("dtOthers"))
                {
                    dgOthers.DataSource = database.DbDataset1.Tables["dtOthers"];
                }
                

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                //myStartForm.UpdateStatusCounters(string.Format("{0} áreas en la lista", myArea.Table.Rows.Count.ToString()));
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

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        protected void myWorker_PrinterUpdateProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //Show the progress to the user based on the input we got from the background worker
                int totalRows = Convert.ToInt32(this.TotalRows);
                int reportedProgress = e.ProgressPercentage;
                double progressValueDbl = ((double)reportedProgress / totalRows) * 100;
                int progressValue = (int)progressValueDbl;

                myStartForm.UpdateStatus(string.Format("Insertando registro número {0} de {1} seleccionadas. Cancelar está deshabilitado.", reportedProgress, totalRows.ToString()), progressValue);
            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }
        }

        private void llenarTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asegúrese de que el archivo Database.sql ha sido ubicado en el escritorio.", "Preparar archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString() + @"\Database.sql"))
            {
                MessageBox.Show("El archivo " + Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString() + @"\Database.sql no fue encontrado","Archivo no encontrado",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            llenarTablaToolStripMenuItem.Enabled = false;
            this.categoriseOnly = false;
            CallBackgroundWorker();
            llenarTablaToolStripMenuItem.Enabled = true;
        }

        private void categorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categorizarToolStripMenuItem.Enabled = false;
            this.categoriseOnly = true;
            CallBackgroundWorker();
            categorizarToolStripMenuItem.Enabled = true;


        }

        private void verTablaDeResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verTablaDeResultadosToolStripMenuItem.Enabled = false;
            this.showTableseOnly = true;
            CallBackgroundWorker();
            verTablaDeResultadosToolStripMenuItem.Enabled = true;
        }
    }
}
