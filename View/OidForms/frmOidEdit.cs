
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
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InkAlert.Forms
{
    public partial class frmOidEdit : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        #region "References"

        Database database = new Database();
        Trick trick = new Trick();
        StoredProcedureParameters[] parameters;
        Trick myTrick = new Trick();
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();

        #endregion

        public frmOidEdit()
        {
            InitializeComponent();
        }

        #region "Members"

        private int currentOidId = 0;
        public int CurrentOidId
        {
            get { return currentOidId; }
            set { currentOidId = value; }
        }

        private string error = "";
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        #endregion

        private void frmOidEdit_Load(object sender, EventArgs e)
        {}


        internal bool FillFormControls()
        {
            try
            {
                //Fill cmbPrinterMake
                trick.bindComboBox(cmbOidType, "oidName", "id", "OidType_Get", "dtOidTypes");

                //Fill cmbPrinterMake
                trick.bindComboBox(cmbPrinterMakeName, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

                //Fill cmbPrinterMakeNameAssignment
                trick.bindComboBox(cmbPrinterMakeNameAssignment, "printerMakeName", "id", "PrinterMake_Get", "dtPrinterMakes");

                trick.bindComboBox(cmbOidReturnType, "oidReturnDataTypeName", "id", "OidDataType_Get", "dtOidReturnTypes");

                ////Fill cmbConnectionType
                myTrick.bindComboBox(cmbPrinterConnectionType, "printerConnectionType", "id", "PrinterConnectionType_Get", "dtPrinterConnectionTypes");


                return true;
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);

                return false;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //new oid class instance
            Oid myOid = new Oid();

            try
            {
                //text validation
                if (txtOidAddress.Text.Trim() == "")
                {
                    Error = "Debe escribir un Identificador OID";
                    goto ErrorMessage;
                }
                else if (cmbOidType.Text.Trim() == "")
                {
                    Error = "Debe escribir o seleccionar el nombre del resultado";
                    goto ErrorMessage;
                }
                else if ((int)cmbOidType.SelectedIndex == -1)
                {
                    if (cmbOidType.SelectedText.Trim().Length > 0)
                    {
                        DialogResult = MessageBox.Show(String.Format("El tipo de resultado {0} no existe. ¿Desea crearlo?", cmbOidType.SelectedText));
                    }
                    else
                    {
                        Error = "Debe seleccionar el tipo de resultado";
                        goto ErrorMessage;
                    }
                }
                else if (lstPrinterModels.SelectedIndices.Count == 0)
                {
                    Error = "Debe seleccionar al menos un modelo de impresora";
                    goto ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }

            //select case Update or New

            switch (cmdSave.Text)
            {

                case "Actualizar":

                    //parameters and db query to check if the entered oid address already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "oids");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE oids.oidAddress='" + txtOidAddress.Text.Trim() + "' AND oids.id<>" + CurrentOidId.ToString() + " AND oids.oidTypeId=" + cmbOidType.SelectedValue.ToString() + " AND oidPrinterMakeId=" + cmbPrinterMakeName.SelectedValue.ToString());

                    database.Error = String.Empty;
                    int oidUpdateCount = database.CountRows("__Counter", parameters);


                    if (oidUpdateCount > 0)
                    {
                        //if the entered oid name user  already exists
                        Error = "El identificador OID '" + txtOidAddress.Text.Trim() + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }

                    try
                    {
                        //if it's ok, go ahead and fill the oid instance we created before the textbox check

                        myOid.Id = this.CurrentOidId;
                        myOid.OidTypeId = (int)cmbOidType.SelectedValue;
                        myOid.OidAddress = txtOidAddress.Text.Trim();
                        myOid.OidPrinterMakeId = (int)cmbPrinterMakeName.SelectedValue;
                        myOid.OidReturnDataTypeId = (int)cmbOidReturnType.SelectedValue;
                        myOid.PrinterConnectionTypeId = (int)cmbPrinterConnectionType.SelectedValue;

                    }
                    catch (Exception ex)
                    {
                        EventLogger.LogEvent(this, ex.Message.ToString(), ex);
                    }

                    if (!myOid.Update())
                    {
                        //if there has been an error during oid update
                        Error = myOid.Error;
                        goto ErrorMessage;
                    }

                    //send dialog result to main form
                    this.DialogResult = DialogResult.OK;
                        break;

                case "Añadir":

                    //parameters and db query to check if the entered oid name already exists
                    parameters = new StoredProcedureParameters[2];
                    parameters[0] = new StoredProcedureParameters("_tableName", "oids");
                    parameters[1] = new StoredProcedureParameters("_condition", "WHERE oids.oidAddress='" + txtOidAddress.Text.Trim() + "' AND oids.oidTypeId=" + cmbOidType.SelectedValue.ToString() + " AND oidPrinterMakeId=" + cmbPrinterMakeName.SelectedValue.ToString());

                    database.Error = String.Empty;

                    int oidAddCount = database.CountRows("__Counter", parameters);

                    if (oidAddCount > 0)
                    {
                        //if the entered oid name user  already exists
                        Error = "El identificador OID '" + txtOidAddress.Text.Trim() + "' ya existe.";
                        goto ErrorMessage;
                    }
                    else if (database.Error != "")
                    {
                        //if there has been an external error during query execution
                        this.Error = database.Error;
                        goto ErrorMessage;
                    }


                    //find oidTypeName of selected oidType

                    string selectedOidTypeName = "";
                    if (cmbOidType.SelectedIndex > -1)
                    {
                        database.ReadTable(null, "dtOidTypes", "SELECT * FROM oidtypes WHERE id=" + (int)cmbOidType.SelectedValue);

                        int selectedValue = (int)cmbOidType.SelectedValue;
                        DataRow row = database.DbDataset1.Tables["dtOidTypes"].Rows[0];
                        selectedOidTypeName = row["oidType"].ToString();
                        myOid.OidTypeName = selectedOidTypeName;
                    }

                    try
                    {
                        //if it's ok, go ahead and fill the oid instance we created before the textbox check

                        myOid.Id = this.CurrentOidId;
                        myOid.OidTypeId = (int)cmbOidType.SelectedValue;
                        myOid.OidAddress = txtOidAddress.Text.Trim();
                        myOid.OidPrinterMakeId = (int)cmbPrinterMakeName.SelectedValue;
                        myOid.OidReturnDataTypeId = (int)cmbOidReturnType.SelectedValue;
                        myOid.PrinterConnectionTypeId = (int)cmbPrinterConnectionType.SelectedValue;

                    }
                    catch (Exception ex)
                    {
                        EventLogger.LogEvent(this, ex.Message.ToString(), ex);
                    }

                    try
                    {

                        int myOidAddressId = myOid.AddNew();

                        if (myOidAddressId == 0)
                        {
                            //if there has been an error during user add
                            Error = myOid.Error;
                            goto ErrorMessage;
                        }

                        if (lstPrinterModels.SelectedIndices.Count > 0)
                        {
                            foreach (object element in lstPrinterModels.SelectedItems)
                            {
                                DataRowView row = (DataRowView)element;

                                if (!printerModelAddOid((int)row[0], myOid.OidTypeName.ToString(), myOidAddressId, row[1].ToString(), cmbOidType.Text)){
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

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel click event, send dialog result to main form
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbPrinterMakeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                fillModelNames(cmbPrinterMakeName, lstPrinterModels);
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

        private void cmbOidType_SelectedIndexChanged(object sender, EventArgs e)
        {}


        private void cmbPrinterMakeNameAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgOidsByModel.DataSource = null;

            if ((int)cmbPrinterMakeName.SelectedIndex > -1)
            {
                //if there is a selected index, fill printer models corresponding to the make
                fillModelNames(cmbPrinterMakeNameAssignment, lstPrinterModelAssignments);

                //create an instance of Oid
                Oid myOid = new Oid();

                //assign required properties
                myOid.OidPrinterMakeId = (int)cmbPrinterMakeNameAssignment.SelectedValue;


                //create parameters array to send the id of our printer make
                parameters = new StoredProcedureParameters[1];
                parameters[0] = new StoredProcedureParameters("_printerMakeId", myOid.OidPrinterMakeId.ToString());

                //run stored procedure with certain parameters

                bool queryResult = database.ReadTable("Oid_GetByMake", "dtOidsByMakeName", null, parameters);

                if (queryResult)
                {
                    //fill datagrid view with oids according to the selected make id
                    dgOidsByMake.DataSource = database.DbDataset1.Tables["dtOidsByMakeName"];
                }
                else
                {
                    MessageBox.Show(myOid.Error);

                }
            }
        }

        private void lstPrinterModelAssignments_SelectedIndexChanged(object sender, EventArgs e)
        {
            printerModelOidRefresh();
        }

        private void cmdAddOid_Click(object sender, EventArgs e)
        {
            if(!(lstPrinterModelAssignments.SelectedItems.Count > 0)){
                return;
            }

            foreach (object element in lstPrinterModelAssignments.SelectedItems)
            {
                DataRowView row = (DataRowView)element;

                //printerModelAddOid(, myOid.OidTypeName.ToString(), myOid.Id, row[1].ToString(), cmbOidType.Text);
                foreach (DataGridViewRow printerOidByMakeRow in dgOidsByMake.SelectedRows)
                {
                    printerModelAddOid((int)row[0], printerOidByMakeRow.Cells["oidType"].Value.ToString(), (int)printerOidByMakeRow.Cells["id"].Value, row[1].ToString(), printerOidByMakeRow.Cells["oidName"].Value.ToString());
                }
            }

            printerModelOidRefresh();
        }

        private bool printerModelAddOid(int printerModelId, string oidTypeName, int oidId, string printerModelName, string oidName)
        {
            //instantiate oid object and add printermodelid and oidtypename params

            Oid myOid = new Oid();
            myOid.PrinterModelId = printerModelId;
            myOid.OidTypeName = oidTypeName.ToString();
            myOid.Id = oidId;
            EventLogger.LogEvent(this, myOid.PrinterModelId.ToString() + ", " + myOid.OidTypeName, null);

            //create a parameters array
            parameters = new StoredProcedureParameters[2];
            parameters[0] = new StoredProcedureParameters("_tableName", "printermodelmeta");
            parameters[1] = new StoredProcedureParameters("_condition", "WHERE printermodelmeta.printerModelId=" + myOid.PrinterModelId.ToString() + " AND printermodelmeta.metaKey='" + myOid.OidTypeName + "'");

            //check if this model has already been assigned this type of oid
            int oidCount = database.CountRows("__Counter", parameters);

            if (oidCount == 0)
            {
                parameters = new StoredProcedureParameters[3];
                parameters[0] = new StoredProcedureParameters("_printerModelId", myOid.PrinterModelId.ToString());
                parameters[1] = new StoredProcedureParameters("_metaName", myOid.OidTypeName);
                parameters[2] = new StoredProcedureParameters("_metaValue", myOid.Id.ToString());

                if (!myOid.RunStoredProcedure("PrinterModel_AddOid", parameters))
                {
                    MessageBox.Show(myOid.Error);
                    return false;
                }
            }
            else if (oidCount > 0)
            {
                this.Error = "El identificador OID fue añadido a la lista, pero no se ha podido asignar al modelo " + printerModelName + " ya que este modelo ya tiene asignado un identificador para " + oidName;
                return false;
            }
            return true;
        }

        private void printerModelOidRefresh()
        {


            ////////////////

            //create an instance of Oid
            Oid myOid = new Oid();

            //assign required properties
            myOid.PrinterModelId = (int)lstPrinterModelAssignments.SelectedValue;


            //create parameters array to send the id of our printer make
            parameters = new StoredProcedureParameters[1];
            parameters[0] = new StoredProcedureParameters("_printerModelId", myOid.PrinterModelId.ToString());

            //run stored procedure with certain parameters

            bool queryResult = database.ReadTable("Oid_GetByModel", "dtOidsByModelName", null, parameters);

            if (queryResult)
            {
                //fill datagrid view with oids according to the selected make id
                dgOidsByModel.DataSource = database.DbDataset1.Tables["dtOidsByModelName"];
            }
            else
            {
                MessageBox.Show(myOid.Error);

            }

        }

        private void cmdRemoveOid_Click(object sender, EventArgs e)
        {
            if (!(dgOidsByModel.SelectedRows.Count > 0))
            {
                return;
            }

            DialogResult result = MessageBox.Show("¿Desasociar del modelo la(s) oid(s) seleccionada?", "Desasociar oids", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.OK)
            {

                foreach (DataGridViewRow row in dgOidsByModel.SelectedRows)
                {
                    int idToRemove = (int)row.Cells["modelMetaOidId"].Value;
                    parameters = new StoredProcedureParameters[1];
                    parameters[0] = new StoredProcedureParameters("_id", idToRemove.ToString());

                    if (!database.RunStoredProcedure("PrinterModelMeta_Remove", parameters))
                    {
                        MessageBox.Show("Falló la eliminación de la ubicación. " + database.Error);
                    }
                }


                printerModelOidRefresh();
            }
        }

        private void cmdNewOidType_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewOidType myFrmNewOidType = new frmNewOidType();
                myFrmNewOidType.FillControls();
                myFrmNewOidType.ShowDialog();
            }
            catch (Exception ex)
            {
                EventLogger.LogEvent(this, ex.Message.ToString(), ex);
            }
        }

    }
}
