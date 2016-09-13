
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

namespace InkAlert.Forms
{
    public partial class frmPrinterSerieEdit : InkAlert.Forms.BaseForms.frmGeneralBase 
    {
        public frmPrinterSerieEdit()
        {
            InitializeComponent();
            
        }
        
        //new database instance
        Database database = new Database(); 

        //instantiate parameters
        private StoredProcedureParameters[] parameters; 

        //the id of the selected printerSerie in the listview
        private int currentPrinterSerieId = 0;
        public int CurrentPrinterSerieId
        {
            get { return currentPrinterSerieId; }
            set { currentPrinterSerieId = value; }
        }

        //current error message
        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private void frmPrinterSerieEdit_Load(object sender, EventArgs e)
        {
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new printerSerie class instance
            PrinterSerie myPrinterSerie = new PrinterSerie(); 

            //text validation
            if(txtPrinterSerieName.Text.Trim() == ""){
                Error = "Debe escribir una serie de impresora";
                goto ErrorMessage;
            }
            else if (cmbPrinterMakeName.SelectedIndex == -1)
            {
                Error = "Debe seleccionar una marca de impresora";
                goto ErrorMessage;
            }
            
            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered printerSerie name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerSeries");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerSeries.printerSerieName='" + txtPrinterSerieName.Text + "' AND printerSeries.id<>" + CurrentPrinterSerieId.ToString());

                    database.Error = String.Empty;
                    int printerSerieUpdateCount = database.CountRows("__Counter", parameters);


                    if (printerSerieUpdateCount > 0)
                    {
                        //if the entered printerSerie name user  already exists
                        Error = "El tipo de impresora '" + txtPrinterSerieName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerSerie instance we created before the textbox check

                    myPrinterSerie.Id =this.CurrentPrinterSerieId;
                    myPrinterSerie.PrinterSerieName = txtPrinterSerieName.Text;
                    myPrinterSerie.PrinterSerieMakeId = (int)cmbPrinterMakeName.SelectedValue;
                
                    if (!myPrinterSerie.Update())
                    {
                        //if there has been an error during printerSerie update
                        Error = myPrinterSerie.Error;
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered printerSerie name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerSeries");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerSeries.printerSerieName='" + txtPrinterSerieName.Text + "'");

                    database.Error = String.Empty;
                    int printerSerieAddCount = database.CountRows("__Counter", parameters);

                    if (printerSerieAddCount > 0)
                    {
                        //if the printerSerie name user entered already exists
                        Error = "La serie de impresoras '" + txtPrinterSerieName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerSerie instance we created

                    myPrinterSerie.PrinterSerieName = txtPrinterSerieName.Text;
                    myPrinterSerie.PrinterSerieMakeId  = (int)cmbPrinterMakeName.SelectedValue;

                    try
                    {
                        if (myPrinterSerie.AddNew() == 0)
                        {
                            //if there has been an error during user add
                            Error = myPrinterSerie.Error;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
