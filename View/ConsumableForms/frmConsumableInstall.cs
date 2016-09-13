
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkAlert  
{
    public partial class frmConsumableInstall : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        
        Database database = new Database();
        StoredProcedureParameters[] parameters;

        //Create a datatable to store
        //the start counters for the selected printer ID 
        DataTable dtStartCountersAndConsumableIdsByPrinter = new DataTable();

                    
        #region "Members"

        private int printerSerialId;
        public int PrinterSerialId
        {
            get { return printerSerialId; }
            set { printerSerialId = value; }
        }

        private int printerModelId;
        public int PrinterModelId
        {
            get { return printerModelId; }
            set { printerModelId = value; }
        }

        #endregion



        public frmConsumableInstall()
        {
            InitializeComponent();
            
        }

        public void fillControls()
        {
            //Stored procedure params to get the consumable types that 
            //are compatible with this printer model
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_printerModelId", this.PrinterModelId.ToString());

            //This datatable will store a list of consumable types
            //that are currently compatible with the model of
            //the selected printer 
            DataTable dtConsumableTypesByPrinterModel = new DataTable();

            //The unique name for the datatable that will store 
            //the list of consumable types
            //that are currently compatible with the model of
            //the selected printer the list
            string dtIName = "dtConsumablesPerPrinterId_" + this.PrinterSerialId.ToString();

            //If the ReadTable succeeds and the datatable 
            //dtConsumablesPerPrinterId_xx is created
            if (database.ReadTable("Consumable_GetTypesByPrinterModel", dtIName, null, parameters))
            {
                //Cast the datatabe created and stored in DataSet1
                dtConsumableTypesByPrinterModel = (DataTable)database.DbDataset1.Tables[dtIName];

                //Check if the datatable has rows
                if (dtConsumableTypesByPrinterModel.Rows.Count > 0)
                {
                    //String builder that will create a string for
                    //selecting the start counters and consuable ids (from the printers table) 
                    //that match the compatible consumable types 
                    //currently assigned to the printer model
                    StringBuilder startCountersAndConsumableIdsByPrinterQueryBuilder = new StringBuilder();
                    startCountersAndConsumableIdsByPrinterQueryBuilder.Append("SELECT printerDataConnectionTypeTable.printerConnectionType, ");

                    foreach (DataRow row in dtConsumableTypesByPrinterModel.Rows)
                    {
                        //Add every consumable type followed 
                        //by 'StartCounter' so we can select it from the 
                        //printers table
                        startCountersAndConsumableIdsByPrinterQueryBuilder.Append(row["consumableType"].ToString() + "StartCounter, ");
                        startCountersAndConsumableIdsByPrinterQueryBuilder.Append(row["consumableType"].ToString() + "Id, ");

                    }

                    //Remove last ", " from the string builder
                    //create a final query string
                    string finalStartCountersByPrinterQueryString = startCountersAndConsumableIdsByPrinterQueryBuilder.ToString().Remove(startCountersAndConsumableIdsByPrinterQueryBuilder.Length - 2);

                    //Add table name and conditions to the query
                    //in order to get the start counters only from the 
                    //selected printer ID.
                    finalStartCountersByPrinterQueryString += " FROM printerserials";
                    finalStartCountersByPrinterQueryString += " LEFT OUTER JOIN printerData AS printerDataConnectionTypeTable ON printerserials.printerConnectionTypeId = printerDataConnectionTypeTable.id";
                    finalStartCountersByPrinterQueryString +=  " WHERE printerserials.id=" + printerSerialId.ToString();

                    EventLogger.LogEvent(this,finalStartCountersByPrinterQueryString,null);

                    //Read the database using finalStartCountersByPrinterQueryString
                    //and create a datatable to store
                    //the start counters for the selected printer ID
                    if (database.ReadTable(null,"dtStartCountersAndConsumableIdsByPrinter_" + printerSerialId.ToString(), finalStartCountersByPrinterQueryString))
                    {
                        //Cast the datatable created and stored in DataSet1
                        dtStartCountersAndConsumableIdsByPrinter = (DataTable)database.DbDataset1.Tables["dtStartCountersAndConsumableIdsByPrinter_" + printerSerialId.ToString()];
                    }
                    
                    //Since dtConsumableTypesByPrinterModel stores 
                    //the consumable types that are compatible the
                    //model of the current printer, we loop through 
                    //collection to create labels and a drop down
                    //for every consumable type
                    foreach (DataRow row in dtConsumableTypesByPrinterModel.Rows)
                    {
                        //This label will display the name of the
                        //consumable type. We need a new label for every
                        //consumable type, so we create a new instance at
                        //each iteration of the loop
                        this.label1 = new System.Windows.Forms.Label();

                        //This combobox will display a list of the
                        //available references availabla for the corres-
                        //pinding consumable type. 
                        //We need a new combobox for every
                        //consumable type, so we create a new instance at
                        //each iteration of the loop
                        this.comboBox1 = new System.Windows.Forms.ComboBox();

                        //This label will display a text indicating
                        //that it contains the current assigned 
                        //start counter for the corresponding
                        //consumable type. We need a new label 
                        //for every consumable type, so we create 
                        //a new instance at each iteration of the loop
                        this.label2 = new System.Windows.Forms.Label();
            
                        //This numeric field will display the current
                        //assigned start counter for the corresponding
                        //consumable type. We need a new numeric field
                        //for every consumable type, so we create 
                        //a new instance at each iteration of the loop
                        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
                        
                        // 
                        // label1
                        //
                        //Here we give the label1 all the properties
                        //such as size and name.
                        //the name is based on the consumable type, 
                        //and the consumable types are taken from the 
                        //current row being read in this foreach loop
                        //that loops the datatable 
                        //dtConsumableTypesByPrinterModel
                        //The text displayed by the label corresponds to the 
                        //consumable type name (name of a specific type)
                        //for example, 
                        //if type is 'tonerK', typeName is 'Tóner Negro'
                        this.label1.Name = "lbl_" + row["consumableType"].ToString();
                        this.label1.Size = new System.Drawing.Size(303, 28);
                        this.label1.Text = row["consumableTypeName"].ToString();
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                        // 
                        // comboBox1
                        //
                        //Here we give the comboBox1 all the properties
                        //such as size and name.
                        //the name is based on the consumable type, 
                        //and the consumable types are taken from the 
                        //current row being read in this foreach loop
                        //that loops the datatable 
                        //dtConsumableTypesByPrinterModel

                        this.comboBox1.FormattingEnabled = true;
                        this.comboBox1.Name = "cmb_" + row["consumableType"].ToString();
                        this.comboBox1.Tag = row["consumableType"].ToString() + "Id";
                        this.comboBox1.Size = new System.Drawing.Size(150, 25);
                        this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                        //Since we need to bind data to this combobox
                        //we need to create a datatable to store the
                        //available consumables that are compatible with the 
                        //model of the selected printer
                        //and that are of the type being handeld
                        //For example, if the current consumable type is 
                        //'tonerK', the combobox will display
                        //only the items of type 'tonerK' that are compatible
                        //with the current printer model
                        parameters = new StoredProcedureParameters[2];
                        parameters[0] = new StoredProcedureParameters("_printerModelId", this.PrinterModelId.ToString());
                        parameters[1] = new StoredProcedureParameters("_consumableType", row["consumableType"].ToString());

                        //Create a datatable to store the supplies of 
                        //the current type that are compatible with the
                        //current printer model
                        DataTable dtConsumablesByTypeAndModel = new DataTable();
                        //This stringw will be the name for the 
                        //datatable dtConsumablesByTypeAndModel
                        //this name will contain the consumable type
                        //and the id of the currenty printer model
                        string dtIIName = "dtConsumablesByType_" + row["consumableType"].ToString() + "_AndModelId_" + this.PrinterModelId.ToString();
                            if (database.ReadTable("Consumables_GetByTypeAndModel", dtIIName, null, parameters))
                            {
                                //Cast the datatable created and stored
                                //in DataSet1
                                dtConsumablesByTypeAndModel = (DataTable)database.DbDataset1.Tables[dtIIName];

                                //Check if dtConsumablesByTypeAndModel has rows 
                                if (dtConsumablesByTypeAndModel.Rows.Count > 0)
                                {
                                    //Bind the data to the combobox
                                    this.comboBox1.DataSource = database.DbDataset1.Tables[dtIIName];
                                    this.comboBox1.DisplayMember = "consumableModelName";
                                    this.comboBox1.ValueMember = "id";

                                    //Datatable dtStartCountersAndConsumableIdsByPrinter
                                    //contains the consumable ids
                                    //and the start counters
                                    //currently assigned to this printer id
                                    //'row' is the current row that describes
                                    //the current consumable type 
                                    //being handled

                                    if (dtStartCountersAndConsumableIdsByPrinter.Rows.Count > 0)
                                    {
                                        string valueColumn = row["consumableType"].ToString() + "Id";
                                        int selectedValue = (int)dtStartCountersAndConsumableIdsByPrinter.Rows[0][valueColumn];
                                        this.comboBox1.SelectedValue = selectedValue;
                                    }
                                }
                            }
                        // 
                        // label2
                        // 
                        this.label2.Name = "lbl_" + row["consumableType"].ToString() + "_StartCounter";
                        this.label2.Size = new System.Drawing.Size(188, 26);
                        this.label2.Text = "Contador del último cambio";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // numericUpDown1
                        // 
                        this.numericUpDown1.Location = new System.Drawing.Point(227, 13);
                        this.numericUpDown1.Name = "nup_" + row["consumableType"].ToString();
                        this.numericUpDown1.Tag = row["consumableType"].ToString() + "StartCounter";
                        this.numericUpDown1.Size = new System.Drawing.Size(133, 23);
                        this.numericUpDown1.TabIndex = 0;
                        this.numericUpDown1.Maximum = new decimal(new int[] {
                            1000000000,
                            0,
                            0,
                            0});

                        //This gets the type of connection of the printer
                        string printerConnectionType = dtStartCountersAndConsumableIdsByPrinter.Rows[0]["printerConnectionType"].ToString();
                       
                        if (this.numericUpDown1.Tag.ToString().Contains("toner") || printerConnectionType == "Red")
                        {
                            this.numericUpDown1.Enabled = false;
                        }

                        this.flowLayoutPanel1.Controls.Add(this.label1);
                        this.flowLayoutPanel1.Controls.Add(this.comboBox1);
                        
                        this.flowLayoutPanel1.Controls.Add(this.label2);
                        this.flowLayoutPanel1.Controls.Add(this.numericUpDown1);

                    }


                }

            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            
            StringBuilder updateCommand = new StringBuilder();

            //Set a static start (last changed) supply counter

            foreach (Control control in this.flowLayoutPanel1.Controls)
            {
                updateCommand.Clear();

                updateCommand.Append("UPDATE printerhistory SET ");

                if (control is System.Windows.Forms.NumericUpDown)
                {
                    NumericUpDown numericUpDown = (NumericUpDown)control;

                    //Get the old value for StartCounter (which is the same as LastChangeCounter"

                    //MessageBox.Show(finalUpdateCommand);
                    string tempStartCounterDatatableName = "tempStartCounterDatatable_" + PrinterSerialId;
                    database.ReadTable(null, tempStartCounterDatatableName, "SELECT " + numericUpDown.Tag.ToString() + " FROM printerserials WHERE id=" + PrinterSerialId, null);

                    string oldValue = database.DbDataset1.Tables[tempStartCounterDatatableName].Rows[0][0].ToString();
                    string newValue = numericUpDown.Value.ToString();

                    if (oldValue != newValue)
                    {
                        string lastChangeCounterColumn = numericUpDown.Tag.ToString().Replace("StartCounter", "LastChangeCounter");
                        updateCommand.Append(lastChangeCounterColumn);
                        updateCommand.Append("=" + newValue + " WHERE printerSerialId=" + PrinterSerialId + " AND " + lastChangeCounterColumn + "=0");

                        parameters = new StoredProcedureParameters[1];
                        parameters[0] = new StoredProcedureParameters("_commandText", updateCommand.ToString());

                        //MessageBox.Show(updateCommand.ToString());
                        //EventLogger.LogEvent(this, updateCommand.ToString(), null);
                        database.RunStoredProcedure("__RunCommand", parameters);

                    }
                }
            }

            updateCommand.Clear();

            //update data entered by user
            updateCommand.Append("UPDATE printerserials SET ");

            foreach (Control control in this.flowLayoutPanel1.Controls)
            {
                
                if (control is System.Windows.Forms.ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    updateCommand.Append(comboBox.Tag + "=" + comboBox.SelectedValue.ToString() + ", ");
                }
                else if (control is System.Windows.Forms.NumericUpDown)
                {
                    NumericUpDown numericUpDown = (NumericUpDown)control;
                    updateCommand.Append(numericUpDown.Tag + "=" + numericUpDown.Value.ToString() + ", ");
                }
            }
            string finalUpdateCommand = updateCommand.ToString().Remove(updateCommand.Length - 2);
            finalUpdateCommand += " WHERE id=" + printerSerialId.ToString();

            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_commandText", finalUpdateCommand);

            //MessageBox.Show(finalUpdateCommand);
            //EventLogger.LogEvent(this, finalUpdateCommand, null);
            database.RunStoredProcedure("__RunCommand", parameters);


            this.Close();
            StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();
            myStartForm.cmdPrinterStatus.PerformClick();

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsumableInstall_Load(object sender, EventArgs e)
        {
            fillControlValues();
        }

        private void fillControlValues()
        {
            foreach (Control control in this.flowLayoutPanel1.Controls)
            {

                if (control is System.Windows.Forms.ComboBox)
                {
                    ComboBox myComboBox = (ComboBox)control;
                    myComboBox.SelectedValue = dtStartCountersAndConsumableIdsByPrinter.Rows[0][myComboBox.Tag.ToString()];
                }
                else if (control is System.Windows.Forms.NumericUpDown)
                {
                    NumericUpDown myNumericUpDown = (NumericUpDown)control;
                    myNumericUpDown.Value = (int)dtStartCountersAndConsumableIdsByPrinter.Rows[0][myNumericUpDown.Tag.ToString()];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dtStartCountersAndConsumableIdsByPrinter;
        }

    }
}
