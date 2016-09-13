
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
    public partial class frmPrinterMakeEdit : InkAlert.Forms.BaseForms.frmGeneralBase 
    {
        public frmPrinterMakeEdit()
        {
            InitializeComponent();
            
        }
        
        //new database instance
        Database database = new Database(); 

        //instantiate parameters
        private StoredProcedureParameters[] parameters; 

        //the id of the selected printerMake in the listview
        private int currentPrinterMakeId = 0;
        public int CurrentPrinterMakeId
        {
            get { return currentPrinterMakeId; }
            set { currentPrinterMakeId = value; }
        }

        //current error message
        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        private void frmPrinterMakeEdit_Load(object sender, EventArgs e)
        {
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new printerMake class instance
            PrinterMake myPrinterMake = new PrinterMake(); 

            //text validation
            if(txtPrinterMakeName.Text.Trim() == ""){
                Error = "Debe escribir una marca de impresora";
                goto ErrorMessage;
            }
            else if (txtPrinterMakeDescription.Text.Trim() == "")
            {
                Error = "Debe escribir una descripción";
                goto ErrorMessage;
            }
            
            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered printerMake name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerMakes");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerMakes.printerMakeName='" + txtPrinterMakeName.Text + "' AND printerMakes.id<>" + CurrentPrinterMakeId.ToString());

                    database.Error = String.Empty;
                    int printerMakeUpdateCount = database.CountRows("__Counter", parameters);


                    if (printerMakeUpdateCount > 0)
                    {
                        //if the entered printerMake name user  already exists
                        Error = "El tipo de impresora '" + txtPrinterMakeName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerMake instance we created before the textbox check

                    myPrinterMake.Id =this.CurrentPrinterMakeId;
                    myPrinterMake.PrinterMakeName = txtPrinterMakeName.Text;
                    myPrinterMake.PrinterMakeDescription = txtPrinterMakeDescription.Text;
                
                    if (!myPrinterMake.Update())
                    {
                        //if there has been an error during printerMake update
                        Error = myPrinterMake.Error;
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //create parameters and query to ckeck if the entered printerMake name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "printerMakes");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE printerMakes.printerMakeName='" + txtPrinterMakeName.Text + "'");

                    database.Error = String.Empty;
                    int printerMakeAddCount = database.CountRows("__Counter", parameters);

                    if (printerMakeAddCount > 0)
                    {
                        //if the printerMake name user entered already exists
                        Error = "El tipo de impresora '" + txtPrinterMakeName.Text + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the printerMake instance we created

                    myPrinterMake.PrinterMakeName = txtPrinterMakeName.Text;
                    myPrinterMake.PrinterMakeDescription  = txtPrinterMakeDescription.Text;

                    try
                    {

                        if (myPrinterMake.AddNew() == 0)
                        {
                            //if there has been an error during user add
                            Error = myPrinterMake.Error;
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
