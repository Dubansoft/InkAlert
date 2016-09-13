
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
using System.Data;
using System.Collections.Generic;

namespace InkAlert.Forms
{
    public partial class frmPrinterSerialEdit : InkAlert.Forms.BaseForms.frmGeneralBase 
    {
        public frmPrinterSerialEdit()
        {
            InitializeComponent();
        }
        
        //new database instance
        Database database = new Database();

        //new trick intance
        Trick trick = new Trick();

        //instantiate parameters
        private StoredProcedureParameters[] parameters; 

        //the id of the selected printerSerial in the listview
        private int currentPrinterSerialId = 0;
        public int CurrentPrinterSerialId
        {
            get { return currentPrinterSerialId; }
            set { currentPrinterSerialId = value; }
        }

        private string currentPrinterSerialFunctions;
        public string CurrentPrinterSerialFunctions
        {
            get { return currentPrinterSerialFunctions; }
            set { currentPrinterSerialFunctions = value; }
        }

        //current error message
        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        
        private void frmPrinterSerialEdit_Load(object sender, EventArgs e)
        {
            
        }

        internal bool FillFormControls()
        {
            try
                    {
                //Fill cmbPrinterMake
                trick.bindComboBox(cmbPrinterMakeName, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

                //call function to bind cmbPrinterSerieName
                fillCmbPrinterSerieName();

                //Fill cmbPrinterTypeName
                trick.bindComboBox(cmbPrinterTypeName, "printerTypeName", "id", "PrinterType_Get", "dtPrinterTypes");

                //Fill cmbPrinterColorName
                trick.bindComboBox(cmbPrinterColorName, "printerColor", "id", "PrinterColor_Get", "dtPrinterColor");

                //Fill cmbPrintingTypeName
                trick.bindListBox(lstPrinterFunctions, "printerFunction", "id", "PrinterFunction_Get", "dtPrinterFunctions");

                for (int i = 0; i < lstPrinterFunctions.Items.Count -1; i++)
                {
                    lstPrinterFunctions.SetSelected(i, false);
                }
                lstPrinterFunctions.SetSelected(0, false);

                ////Fill cmbPrinterCapacity
                trick.bindComboBox(cmbPrinterCapacity, "printerCapacity", "id", "PrinterCapacity_Get", "dtPrinterCapacities");


                //Fill cmbDuplexUnit
                cmbDuplexUnit.DataSource = database.DbDataset1.Tables["dtDuplexUnit"];
                trick.bindComboBox(cmbDuplexUnit, "printerDuplex", "id", "PrinterDuplexUnit_Get", "dtDuplexUnit");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool fillCmbPrinterSerieName()
        {
            try
            {
                //Fill cmbPrinterSerieName
                if ((int)cmbPrinterMakeName.SelectedIndex > -1)
                {
                    database.ReadTable(null, "dtPrinterSeries", "SELECT * FROM printerSeries WHERE printerSerieMakeId=" + (int)cmbPrinterMakeName.SelectedValue);
                }
                else {
                    database.ReadTable("PrinterSerie_Get", "dtPrinterSeries");
                }

                cmbPrinterSerieName.DisplayMember = "printerSerieName";
                cmbPrinterSerieName.ValueMember = "id";
                cmbPrinterSerieName.DataSource = database.DbDataset1.Tables["dtPrinterSeries"];
                return true;
            }
            catch (Exception e)
            {
                this.Error = e.Message.ToString();
                return false;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new printerSerial class instance
            PrinterSerial myPrinterSerial = new PrinterSerial(); 

            //model name validation
            if(txtPrinterSerialName.Text.Trim() == ""){
                Error = "Debe escribir un modelo de impresora";
                goto ErrorMessage;
            }

            //make name validation
            if (cmbPrinterMakeName.SelectedIndex == -1)
            {
                Error = "Debe seleccionar una marca";
                goto ErrorMessage;
            }

            //series validation
            try
            {
                if (cmbPrinterSerieName.Text.Trim() == "")
                {
                    Error = "Debe escribir o seleccionar la serie del modelo";
                    goto ErrorMessage;
                }

                else {
                    if ((int)cmbPrinterSerieName.SelectedIndex == -1)
                    {
                        //check if the new series name already exists

                        //parameters and db query to check if the entered series name name already exists
                        parameters = new StoredProcedureParameters[2];
                        parameters[0] = new StoredProcedureParameters("_tableName", "printerSeries");
                        parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerSeries.printerSerieName='" + cmbPrinterSerieName.Text.Trim() + "'");

                        database.Error = String.Empty;
                        int newSerieNameCountCheck = database.CountRows("__Counter", parameters);

                        if (newSerieNameCountCheck > 0)
                        {
                            //if the series name already exists, lets select the corresponding item
                            cmbPrinterSerieName.SelectedIndex = cmbPrinterSerieName.FindStringExact(cmbPrinterSerieName.Text.Trim());
                            // and then lets check if the selected index really changed
                            if ((int)cmbPrinterSerieName.SelectedIndex == -1)
                            {
                                //if the entered serie name could not be resolved to a seriesId, lets tell users they have to select the option manually
                                Error = "La serie '" + cmbPrinterSerieName.Text + "' ya existe. Por favor selecciónelo de la lista en lugar de escribirlo";
                                goto ErrorMessage;
                            }
                        }
                        else
                        {
                            //if the series name was not found in db, lets create a new record in the series table
                            PrinterSerie myNewPrinterSerie = new PrinterSerie();
                            myNewPrinterSerie.PrinterSerieName = cmbPrinterSerieName.Text.Trim();
                            myNewPrinterSerie.PrinterSerieMakeId = (int)cmbPrinterMakeName.SelectedValue;

                            //now lets get the id
                            myNewPrinterSerie.Id = myNewPrinterSerie.AddNew();

                            //now, lets rebind the control
                            fillCmbPrinterSerieName();

                            //lets set the selected value
                            cmbPrinterSerieName.SelectedValue = myNewPrinterSerie.Id;

                        }
                    }
                }    
            }
            catch (Exception)
            {
                //if there has been an external error during query execution
                this.Error = database.Error;
                goto ErrorMessage;
            }

            //end series name check










            //printer type validation
            if (cmbPrinterTypeName.SelectedIndex == -1)
            {
                Error = "Debe seleccionar un sistema de impresión";
                goto ErrorMessage;
            }

            //color validation
            if (cmbPrinterColorName.SelectedIndex == -1)
            {
                Error = "Debe seleccionar un color de impresión";
                goto ErrorMessage;
            }

            //validate selected printer functions
            if (lstPrinterFunctions.SelectedIndices.Count > 0)
            {
                string selectedFunctions = "{";
                foreach (object element in lstPrinterFunctions.SelectedItems)
                {
                    DataRowView row = (DataRowView)element;
                    selectedFunctions += row[0].ToString() + ",";

                }
                selectedFunctions = selectedFunctions.Remove(selectedFunctions.Length - 1);

                selectedFunctions += "}";
                CurrentPrinterSerialFunctions = selectedFunctions;
            }
            else
            {
                Error = "Debe seleccionar al menos una de las funciones";
                goto ErrorMessage;
            }

            //function validation
            if (lstPrinterFunctions.SelectedIndices.Count == 0)
            {
                Error = "Debe seleccionar al menos una función de la lista";
                goto ErrorMessage;
            }

            //printer capacity validation
            if (cmbPrinterCapacity.SelectedIndex == -1)
            {
                Error = "Debe seleccionar una capacidad de impresión";
                goto ErrorMessage;
            }

            //printing volume validation
            if (nupMonthlyDuty.Value == 0)
            {
                Error = "Debe escribir un volumen máximo mensual de impresión";
                goto ErrorMessage;
            }

            //ram validation
            if (nupRamMemory.Value == 0)
            {
                Error = "Debe escribir la capacidad de memoria";
                goto ErrorMessage;
            }

            //hdd validation :: validation disabled because printers may have no hdd at all
            //if (nupHddCapacity.Value == 0)
            //{
            //    Error = "Debe escribir la capacidad de memoria";
            //    goto ErrorMessage;
            //}

            //duplex unit validation
            if (cmbDuplexUnit.SelectedIndex == -1)
            {
                Error = "Debe seleccionar el tipo de unidad dúplex";
                goto ErrorMessage;
            }


            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered printerSerial name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerSerials");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerSerials.printerSerialName='" + txtPrinterSerialName.Text + "' AND printerSerials.id<>" + CurrentPrinterSerialId.ToString());

                    database.Error = String.Empty;
                    int printerSerialUpdateCount = database.CountRows("__Counter", parameters);


                    if (printerSerialUpdateCount > 0)
                    {
                        //if the entered printerSerial name already exists
                        Error = "El modelo '" + txtPrinterSerialName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerSerial instance we created before the textbox check
                    fillPrinterSerial(myPrinterSerial);


                    if (!myPrinterSerial.Update())
                    {
                        //if there has been an error during printerSerial update
                        Error = myPrinterSerial.Error;
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered printerSerial name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerSerials");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerSerials.printerSerialName='" + txtPrinterSerialName.Text + "'");

                    database.Error = String.Empty;
                    int printerSerialAddCount = database.CountRows("__Counter", parameters);

                    if (printerSerialAddCount > 0)
                    {
                        //if the printerSerial name user entered already exists
                        Error = "El tipo de impresora '" + txtPrinterSerialName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerSerial instance we created

                    fillPrinterSerial(myPrinterSerial);


                    try
                    {

                        if (myPrinterSerial.AddNew() == 0)
                        {
                            //if there has been an error during user add
                            Error = myPrinterSerial.Error;
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

        private bool fillPrinterSerial(PrinterSerial myPrinterSerial)
        {
            myPrinterSerial.Id = this.CurrentPrinterSerialId; 
            myPrinterSerial.PrinterSerialName = txtPrinterSerialName.Text;
            myPrinterSerial.PrinterMakeId = (int)cmbPrinterMakeName.SelectedValue;
            myPrinterSerial.PrinterSeriesId = (int)cmbPrinterSerieName.SelectedValue;
            myPrinterSerial.PrinterTypeId = (int)cmbPrinterTypeName.SelectedValue;
            myPrinterSerial.PrinterColorId = (int)cmbPrinterColorName.SelectedValue;
            myPrinterSerial.StandardFunctions = CurrentPrinterSerialFunctions;
            myPrinterSerial.PrintingCapacityId = (int)cmbPrinterCapacity.SelectedValue;
            myPrinterSerial.MonthlyDuty = (int)nupMonthlyDuty.Value;
            myPrinterSerial.RamMemory = (int)nupRamMemory.Value;
            myPrinterSerial.HddCapacity = (int)nupHddCapacity.Value;
            myPrinterSerial.DuplexUnitId = (int)cmbDuplexUnit.SelectedValue;
            myPrinterSerial.UrlSettings = txtSettingsUrl.Text;
            myPrinterSerial.UrlConsumables = txtConsumablesUrl.Text;
            myPrinterSerial.UrlUsage = txtUsageUrl.Text;

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(lstPrinterFunctions.SelectedIndices.ToString());
        }


        private void cmb_oidValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox myComboBox = (ComboBox)sender;
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show(cmbPrinterSerieName.SelectedValue.ToString());
        }

        private void cmbPrinterMakeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                fillCmbPrinterSerieName();
            }
        }

    }
}
