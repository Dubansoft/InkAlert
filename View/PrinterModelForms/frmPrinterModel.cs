
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
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmPrinterModels : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "References"

        PrinterModel myPrinterModel;
        Database database = new Database();
        private StoredProcedureParameters[] parameters;

        public BackgroundWorker MyBackgroundPrinterModelUpdater = new BackgroundWorker();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
        frmPrinterModels myPrinterModelForm = Application.OpenForms.OfType<frmPrinterModels>().FirstOrDefault();
        #endregion

        #region "Members"

        private int currentPrinterModelId = 0;
        public int CurrentPrinterModelId
        {
            get { return currentPrinterModelId; }
            set { currentPrinterModelId = value; }
        }
         
        private string printerModelOperation = "";
        public string PrinterModelOperation
        {
            get { return printerModelOperation; }
            set { printerModelOperation = value; }
        }

        #endregion

        public frmPrinterModels()
        {
            InitializeComponent();

            //Initialise event listeners for MyBackgroundPrinterModelUpdater
            MyBackgroundPrinterModelUpdater.DoWork += new DoWorkEventHandler(MyBackgroundPrinterModelUpdater_HardWork);
            MyBackgroundPrinterModelUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MyBackgroundPrinterModelUpdater_Completed);
            MyBackgroundPrinterModelUpdater.WorkerReportsProgress = false;
            MyBackgroundPrinterModelUpdater.WorkerSupportsCancellation = false;

            dgPrinterModels.AssignedContextMenuStrip = this.contextMenuPrinterModels;
            dgPrinterModels.ColumnsToBeFiltered = new string[]
            {
                "printerModelName",
                "printerMakeName",
                "printerTypeName",
                "printerColor",
                "printerCapacity",
                "printerDuplex",
                "monthlyDuty",
                "printerColorId",
                "ramMemory",
                "hddCapacity"
            };
        }

        private void PrinterModels_Load(object sender, EventArgs e){}

        #region "Functions"
        

        /// <summary>
        /// Shows the loading image and call the process that 
        /// refreshes dgPrinterModels datagrid in the background.
        /// </summary>
        public void CallBackgroundWorker()
        {
            //Before calling the background worker, let's check it is NOT busy
            if (!MyBackgroundPrinterModelUpdater.IsBusy)
            {
                //Show loading image
                myStartForm.ToggleLoadingImage(this, true, loadingImage);

                //Run background worker to fill dgPrinterModels
                MyBackgroundPrinterModelUpdater.RunWorkerAsync();
            }
            else
            {
                EventLogger.LogEvent(this, "MyBackgroundPrinterModelUpdater was called while it was still busy.",null);
            }
        }

        private void MyBackgroundPrinterModelUpdater_HardWork(object sender, DoWorkEventArgs e)
        {
            //Disable cmdAreas in parent form while this thread is 
            //running
            myStartForm.cmdPrinterModels.Enabled = false;

            //Set parent form status
            myStartForm.UpdateStatus("Cargando lista de modelos. Por favor espere...", 0);

            //Capture the BackgroundWorker that fired the event
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;

            myPrinterModel = new PrinterModel();
            if (!myPrinterModel.Read())
            {
                //if there is an error while reading the database, 
                //send the results back to the main thread
                e.Result = myPrinterModel.Error;

                EventLogger.LogEvent(this, myPrinterModel.Error, null);
                return;
            }
            else
            {

                //Once finished, if it's OK, send our result to the main thread
                e.Result = "OK";
            }
        }


        /// <summary>
        /// Runs when MyBackgroundPrinterModelUpdater has finished doing its job
        /// </summary>
        /// <param name="sender">MyBackgroundPrinterModelUpdater</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        public void MyBackgroundPrinterModelUpdater_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            //Check if the worker has NOT been cancelled or if an error occured
            if (!e.Cancelled && e.Error == null && (string)e.Result == "OK")
            {
                dgPrinterModels.SetDataSource(myPrinterModel.Table);
                //dgPrinterModels.DtDatagridSource = myPrinterModel.Table;
                //dgPrinterModels.DatasourceRefreshPending = true;

                string[] visibleColumns = { "printerModelName", "printerMakeName", "printerTypeName", "printerColor", "printerCapacity", "monthlyDuty", "ramMemory", "hddCapacity", "printerDuplex" };
                foreach (DataGridViewTextBoxColumn column in dgPrinterModels.Columns)
                {
                    if (!visibleColumns.Contains(column.Name.ToString()))
                    {
                        column.Visible = false;
                    }
                }

                //Set the datasource for dgAreas datagrid
                dgPrinterModels.SetDataSource(myPrinterModel.Table);
                //dgPrinterModels.DtDatagridSource = myPrinterModel.Table;
                //dgPrinterModels.DatasourceRefreshPending = true;

                //Set parent main status
                myStartForm.UpdateStatus("Listo", 0);

                //Set parent counters status
                myStartForm.UpdateStatusCounters(string.Format("{0} modelos en la lista", myPrinterModel.Table.Rows.Count.ToString()));
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
            myStartForm.cmdPrinterModels.Enabled = true;

            //Hide loading image
            myStartForm.ToggleLoadingImage(this, false, this.loadingImage);

        }

        #endregion

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgPrinterModels.SelectedRows.Count > 0)
            {
                handleNewPrinterModelForm("Actualizar");
            }
        }


        private void dgPrinterModels_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem_Click(sender, e);
        }

        private void añadirNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            handleNewPrinterModelForm("Añadir");
        }

        private bool handleNewPrinterModelForm(string action)
        {

            //Creates a new instance of frmPrinterModelEdit
            frmPrinterModelEdit myPrinterModelEditForm = new frmPrinterModelEdit();

            //Fill the controls in the new printerModelForm instance

            myPrinterModelEditForm.FillFormControls();

            

            if (action == "Actualizar")
            {

                //send the current printerModelId to the new form

                myPrinterModelEditForm.CurrentPrinterModelId = this.CurrentPrinterModelId;

                //set all values based on the model we want to edit, the one
                //that is selected in the datagridview

                var selectedRow = dgPrinterModels.SelectedRows[0];

                try
                {
                    myPrinterModelEditForm.txtPrinterModelName.Text = selectedRow.Cells["printerModelName"].Value.ToString();
                    myPrinterModelEditForm.cmbPrinterMakeName.SelectedValue = (int)selectedRow.Cells["printerMakeId"].Value;
                    myPrinterModelEditForm.cmbPrinterSerieName.SelectedValue = (int)selectedRow.Cells["printerSeriesId"].Value;
                    myPrinterModelEditForm.cmbPrinterTypeName.SelectedValue = (int)selectedRow.Cells["printerTypeId"].Value;
                    myPrinterModelEditForm.cmbPrinterColorName.SelectedValue = (int)selectedRow.Cells["printerColorId"].Value;
                    myPrinterModelEditForm.CurrentPrinterModelFunctions = selectedRow.Cells["standardFunctions"].Value.ToString();
                    myPrinterModelEditForm.cmbPrinterCapacity.SelectedValue = (int)selectedRow.Cells["printingCapacityId"].Value;
                    myPrinterModelEditForm.nupMonthlyDuty.Value = (int)selectedRow.Cells["monthlyDuty"].Value;
                    myPrinterModelEditForm.nupRamMemory.Value = (int)selectedRow.Cells["ramMemory"].Value;
                    myPrinterModelEditForm.nupHddCapacity.Value = (int)selectedRow.Cells["hddCapacity"].Value;
                    myPrinterModelEditForm.cmbDuplexUnit.SelectedValue = (int)selectedRow.Cells["duplexUnitId"].Value;
                    myPrinterModelEditForm.txtSettingsUrl.Text = selectedRow.Cells["urlSettings"].Value.ToString();
                    myPrinterModelEditForm.txtConsumablesUrl.Text = selectedRow.Cells["urlConsumables"].Value.ToString();
                    myPrinterModelEditForm.txtUsageUrl.Text = selectedRow.Cells["urlUsage"].Value.ToString();

                    //remove brackets from function string stored in db
                    string selectedFunctions = selectedRow.Cells["standardFunctions"].Value.ToString()
                        .Replace("{".ToString(),String.Empty)
                        .Replace("}".ToString(),String.Empty);

                    //unselect the default first value
                    myPrinterModelEditForm.lstPrinterFunctions.SetSelected(0, false);

                    //convert functions string in to array, splitting by comma separator
                    string[] selectedFunctionsArray = selectedFunctions.Split(new char[] {','});
                    foreach (string function in selectedFunctionsArray)
                    {
                        myPrinterModelEditForm.lstPrinterFunctions.SelectedValue = Convert.ToInt16(function);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString(), "Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //return false;
                }


            }
            else if (action == "Añadir") {
                try
                {

                    foreach (TabPage myTabPage in myPrinterModelEditForm.tabControl1.TabPages)
                    {
                        foreach (Control myControl in myTabPage.Controls)
                        {
                            if (myControl is System.Windows.Forms.TextBox)
                            {
                                myControl.Text = "";
                            }
                            else if (myControl is System.Windows.Forms.ComboBox)
                            {
                                ComboBox myCombo = (ComboBox)myControl;
                                myCombo.SelectedIndex = -1;
                            }
                            else if (myControl is System.Windows.Forms.NumericUpDown)
                            {
                                NumericUpDown myNup = (NumericUpDown)myControl;
                                myNup.Value = myNup.Minimum;
                                myNup.Text = myNup.Minimum.ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }

            myPrinterModelEditForm.Text = action + " modelo de impresora";
            PrinterModelOperation = action;
            myPrinterModelEditForm.cmdSave.Text = PrinterModelOperation;
            myPrinterModelEditForm.CurrentPrinterModelId = CurrentPrinterModelId;

            myPrinterModelEditForm.ShowDialog();

            if (myPrinterModelEditForm.DialogResult == DialogResult.OK)
            {
                CallBackgroundWorker();
                return true;
            }
            return false;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if there are selected rows
            if (dgPrinterModels.SelectedRows.Count > 0)
            {
                //ask users whether to delete or not the printer
                DialogResult result = MessageBox.Show("¿Eliminar tipo de impresora?", "Eliminar tipo de impresora", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_printerModelId", CurrentPrinterModelId.ToString());
                    if (database.RunStoredProcedure("PrinterModel_Remove", parameters))
                    {
                        CallBackgroundWorker();
                    }
                    else
                    {
                        MessageBox.Show("Falló la eliminación del modelo de impresora. " + database.Error);
                    }
                }
            }

        }

        private void dgPrinterModels_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterModelId();
        }

        private void setCurrentPrinterModelId()
        {
            if (dgPrinterModels.SelectedRows.Count > 0)
            {
                //if there's a selected row, assign the value of Id column to the local CurrentPrinterModelId
                CurrentPrinterModelId = (int)dgPrinterModels.SelectedRows[0].Cells["id"].Value;
            }
        }

        private void dgPrinterModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCurrentPrinterModelId();
        }

        private void dgPrinterModels_SelectionChanged(object sender, EventArgs e)
        {
            setCurrentPrinterModelId();
        }

    }
}
