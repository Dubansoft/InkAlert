
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
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmConsumableEdit : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        #region "References"

        Database database = new Database();
        Trick trick = new Trick();
        StoredProcedureParameters[] parameters;
        Trick myTrick = new Trick();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();

        #endregion

        #region "Members"

        private int currentConsumableId = 0;
        public int CurrentConsumableId
        {
            get { return currentConsumableId; }
            set { currentConsumableId = value; }
        }

        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        #endregion

        public frmConsumableEdit()
        {
            InitializeComponent();
        }

        private void frmConsumableEdit_Load(object sender, EventArgs e)
        {}

        #region "Functions"

        internal bool FillFormControls()
        {
            try
            {
                //Fill cmbPrinterMake
                trick.bindComboBox(cmbConsumableType, "consumableName", "id", "ConsumableType_Get", "dtConsumableTypes");
                //Fill cmbPrinterMake
                trick.bindComboBox(cmbPrinterMakeName, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

                //Fill cmbPrinterMakeNameAssignment
                trick.bindComboBox(cmbPrinterMakeNameAssignment, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private bool fillModelNames(ComboBox senderComboBox, ListBox targetListBox, Boolean fillAssignmentsMakeNameListBox = false)
        {

            try
            {
                //Fill cmbPrinterSerieName
                if ((int)senderComboBox.SelectedIndex > -1)
                {
                    database.ReadTable(null, "dtPrinterModels", "SELECT * FROM printerModels WHERE printerMakeId=" + (int)senderComboBox.SelectedValue);
                }
                else
                {
                    database.ReadTable("PrinterModels_Get", "dtPrinterModels");
                }

                targetListBox.DisplayMember = "printerModelName";
                targetListBox.ValueMember = "id";
                targetListBox.DataSource = database.DbDataset1.Tables["dtPrinterModels"];



                if (fillAssignmentsMakeNameListBox)
                {
                    database.ReadTable(null, "dtPrinterModelsById");

                    targetListBox.DisplayMember = "printerModelName";
                    targetListBox.ValueMember = "id";
                    targetListBox.DataSource = database.DbDataset1.Tables["dtPrinterModelsById"];
                }
                return true;
            }
            catch (Exception e)
            {
                this.Error = e.Message.ToString();
                return false;
            }
        }

        private bool printerModelConsumableRefresh()
        {


            //create an instance of Consumable
            Consumable myConsumable = new Consumable();

            //assign required properties
            myConsumable.Id = (int)lstPrinterModelAssignments.SelectedValue;


            //create parameters array to send the id of our printer make
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_printerModelId", myConsumable.Id.ToString());

            //run stored procedure with certain parameters

            bool queryResult = database.ReadTable("Consumable_GetByModel", "dtConsumablesByModelName", null, parameters);

            if (queryResult)
            {
                //fill datagrid view with consumables according to the selected make id
                dgConsumablesByModel.DataSource = database.DbDataset1.Tables["dtConsumablesByModelName"];
            }


            return true;
        }

        private bool printerModelAddConsumable(int printerModelId, string consumableType, int consumableId, string printerModelName, string consumableName)
        {
            //instantiate consumable object and add printermodelid and consumabletypename params

            Consumable myConsumable = new Consumable();
            myConsumable.Id = consumableId;
            myConsumable.ConsumableType = consumableType;
            //create a parameters array
            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_tableName", "consumablecompatibility");
            parameters[1] = new StoredProcedureParameters("_condition", "WHERE consumablecompatibility.printerModelId=" + printerModelId.ToString() + " AND consumablecompatibility.consumableId=" + myConsumable.Id.ToString());

            //check if this model has already been assigned this type of consumable
            int consumableCount = database.CountRows("__Counter", parameters);

            if (consumableCount == 0)
            {
                parameters = new StoredProcedureParameters[3];
                parameters[0] = new StoredProcedureParameters("_printerModelId", printerModelId.ToString());
                parameters[1] = new StoredProcedureParameters("_consumableType", myConsumable.ConsumableType.ToString());
                parameters[2] = new StoredProcedureParameters("_consumableId", myConsumable.Id.ToString());

                if (!myConsumable.RunStoredProcedure("PrinterModel_AddConsumable", parameters))
                {
                    MessageBox.Show(myConsumable.Error + "\n" + database.Error);
                    return false;
                }
            }
            else if (consumableCount > 0)
            {
                this.Error = "El suministro se ha añadido a la lista, pero no se ha podido asignar al modelo " + printerModelName + " ya que este modelo ya tiene asignado un suministro del tipo " + consumableName;
                return false;
            }
            return true;
        }

        #endregion

        #region "Interface Events"

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new consumable class instance
            Consumable myConsumable = new Consumable();

            //text validation
            if(txtConsumableModelName.Text.Trim() == ""){
                Error = "Debe escribir una referencia de suministro";
                goto ErrorMessage;
            }
            else if (cmbConsumableType.Text.Trim() == "")
            {
                Error = "Debe seleccionar el tipo de suministro";
                goto ErrorMessage;
            }
            else if (cmbPrinterMakeName.Text.Trim() == "")
            {
                Error = "Debe seleccionar la marca del suministro";
                goto ErrorMessage;
            }
            else if (lstPrinterModels.SelectedIndices.Count == 0)
            {
                Error = "Debe seleccionar al menos un modelo de impresora con el cual el suministro sea compatible";
                goto ErrorMessage;
            }
            else if (nupMaxLife.Value == 0)
            {
                Error = "Debe asignar una vida útil al suministro";
                goto ErrorMessage;
            }
            
            //select case Update or New

            switch (cmdSave.Text)
            {
                
                case "Actualizar":
                    
                    //parameters and db query to check if the entered consumable address already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "consumables");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE consumables.consumableModelName='" + txtConsumableModelName.Text.Trim() + "' AND consumables.id<>" + CurrentConsumableId.ToString() + " AND consumables.consumableTypeId=" + cmbConsumableType.SelectedValue.ToString());

                    database.Error = String.Empty;
                    int consumableUpdateCount = database.CountRows("__Counter", parameters);


                    if (consumableUpdateCount > 0)
                    {
                        //if the entered consumable name user  already exists
                        Error = "El suministro '" + txtConsumableModelName.Text.Trim() + "' de tipo  '" + cmbConsumableType.Text.Trim() + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //if it's ok, go ahead and fill the consumable instance we created before the textbox check

                    myConsumable.Id =this.CurrentConsumableId;
                    myConsumable.ConsumableTypeId = (int)cmbConsumableType.SelectedValue;
                    myConsumable.ConsumableModelName = txtConsumableModelName.Text;
                    myConsumable.ConsumableTypeId = (int)cmbConsumableType.SelectedValue;
                    myConsumable.ConsumableMakeId = (int)cmbPrinterMakeName.SelectedValue;
                    myConsumable.MaxLife = (int)nupMaxLife.Value;

                    if (!myConsumable.Update())
                    {
                        //if there has been an error during consumable update
                        Error = myConsumable.Error;
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //parameters and db query to check if the entered consumable name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "consumables");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE consumables.consumableModelName='" + txtConsumableModelName.Text.Trim().ToString() + "' AND consumables.consumableTypeId=" + cmbConsumableType.SelectedValue.ToString());

                    database.Error = String.Empty;

                    int consumableAddCount = database.CountRows("__Counter", parameters);

                    if (consumableAddCount > 0)
                    {
                        //if the entered consumable name user  already exists
                        Error = "El consumible '" + txtConsumableModelName.Text.Trim() + "' de tipo  '" + cmbConsumableType.Text.Trim() + "' ya existe.";
                        goto ErrorMessage;
                    } 
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    //find oidTypeName of selected oidType

                    string selectedConsumableType = "";
                    if (cmbConsumableType.SelectedIndex > -1)
                    {
                        database.ReadTable(null, "dtConsumableTypes", "SELECT * FROM consumableTypes WHERE id=" + (int)cmbConsumableType.SelectedValue);

                        int selectedValue = (int)cmbConsumableType.SelectedValue;
                        DataRow row = database.DbDataset1.Tables["dtConsumableTypes"].Rows[0];
                        selectedConsumableType = row["consumableType"].ToString();
                        myConsumable.ConsumableType = selectedConsumableType;
                    }

                    //if it's ok, go ahead and fill the consumable instance we created before the textbox check

                    myConsumable.Id =this.CurrentConsumableId;
                    myConsumable.ConsumableMakeId = (int)cmbPrinterMakeName.SelectedValue;
                    myConsumable.ConsumableModelName = txtConsumableModelName.Text.Trim();
                    myConsumable.ConsumableTypeId = (int)cmbConsumableType.SelectedValue;
                    myConsumable.MaxLife = (int)nupMaxLife.Value;
                    
                    try
                    {

                        int myConsumableId = myConsumable.AddNew();

                        if (myConsumableId == 0)
                        {
                            //if there has been an error during user add
                            Error = myConsumable.Error;
                            goto ErrorMessage;
                        }

                        if (lstPrinterModels.SelectedIndices.Count > 0)
                        {
                            foreach (object element in lstPrinterModels.SelectedItems)
                            {
                                DataRowView row = (DataRowView)element;

                                if (!printerModelAddConsumable((int)row[0], myConsumable.ConsumableType.ToString(), myConsumableId, row[1].ToString(), txtConsumableModelName.Text))
                                {
                                    goto ErrorMessage;
                                }

                            }
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

        private void cmbPrinterMakeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                fillModelNames(cmbPrinterMakeName, lstPrinterModels);
            }
        }

        private void cmbPrinterMakeNameAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgConsumablesByModel.DataSource = null;
            

            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                //if there is a selected index, fill printer models corresponding to the make
                fillModelNames(cmbPrinterMakeNameAssignment, lstPrinterModelAssignments);

                //create an instance of Consumable
                Consumable myConsumable = new Consumable();

                //assign required properties
                myConsumable.ConsumableMakeId = (int)cmbPrinterMakeNameAssignment.SelectedValue;


                //create parameters array to send the id of our printer make
                parameters = new StoredProcedureParameters[1];
                parameters[0] = new StoredProcedureParameters("_printerMakeId", myConsumable.ConsumableMakeId.ToString());

                //run stored procedure with certain parameters

                bool queryResult = database.ReadTable("Consumable_GetByMake", "dtConsumablesByMakeName", null, parameters);

                if (queryResult)
                {
                    //fill datagrid view with consumables according to the selected make id
                    dgConsumablesByMake.DataSource = database.DbDataset1.Tables["dtConsumablesByMakeName"];
                }
                else
                {
                    MessageBox.Show(myConsumable.Error + "\n" + database.Error);

                }
            }
        }

        private void lstPrinterModelAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            printerModelConsumableRefresh();

        }

        private void cmdAddConsumable_Click(object sender, EventArgs e)
        {
            if(lstPrinterModelAssignments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un suministro del panel izquierdo.","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            foreach (object element in lstPrinterModelAssignments.SelectedItems)
            {
                DataRowView row = (DataRowView)element;

                foreach (DataGridViewRow printerConsumableByMakeRow in dgConsumablesByMake.SelectedRows)
                {
                    printerModelAddConsumable((int)row[0], printerConsumableByMakeRow.Cells["consumableType"].Value.ToString(), (int)printerConsumableByMakeRow.Cells["consumable_id"].Value, row[1].ToString(), printerConsumableByMakeRow.Cells["consumableModelName"].Value.ToString());               
                }
            }

                //(int)lstPrinterModelAssignments.SelectedValue
            
            
            printerModelConsumableRefresh();
        }

        private void cmdRemoveConsumable_Click(object sender, EventArgs e)
        {
            if (lstPrinterModelAssignments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un modelo del panel superior.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desasociar del modelo los suministros seleccionados?", "Desasociar suministros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.OK)
            {

                foreach (DataGridViewRow row in dgConsumablesByModel.SelectedRows)
                {
                    int idToRemove = (int)row.Cells["compatibilityId"].Value;
                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", idToRemove.ToString());

                    if (!database.RunStoredProcedure("PrinterModel_RemoveConsumable", parameters))
                    {
                        MessageBox.Show("Falló la eliminación del suministro. " + database.Error);
                    }
                }


                printerModelConsumableRefresh();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        #endregion

    }
}
