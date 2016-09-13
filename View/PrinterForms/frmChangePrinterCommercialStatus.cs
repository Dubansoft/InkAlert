using FileHelper;
using InkAlert.Forms;
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
    public partial class frmChangePrinterCommercialStatus : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        #region "Class References"
            Database database = new Database();
            StoredProcedureParameters[] parameters;
            Trick myTrick = new Trick();
        #endregion

        #region "Members"

        private int currentPrinterId = 0;
        public int CurrentPrinterId
        {
            get { return currentPrinterId; }
            set { currentPrinterId = value; }
        }

        private int currentAreaId = 0;
        public int CurrentAreaId
        {
            get { return currentAreaId; }
            set { currentAreaId = value; }
        }

        private int newAreaId = 0;
        public int NewAreaId
        {
            get { return newAreaId; }
            set { newAreaId = value; }
        }

        private Form whoOpenedThis = null;
        public Form WhoOpenedThis
        {
            get { return whoOpenedThis; }
            set { whoOpenedThis = value; }
        }

        private DataGridViewRow selectedPrinterSerialDataRow = null;
        public DataGridViewRow SelectedPrinterSerialDataRow
        {
            get{return selectedPrinterSerialDataRow;}
            set{selectedPrinterSerialDataRow = value;}
        }
        #endregion

        public frmChangePrinterCommercialStatus()
        {
            InitializeComponent();


        }


        private void frmChangePrinterCommercialStatus_Load(object sender, EventArgs e)
        {
            myTrick.bindComboBox(cmbPrinterCommercialStatus, "printerCommercialStatus", "id", "PrinterCommercialStatus_Get", "dtCommercialStatus", null);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            int newPrinterCommercialStatusId = (int)this.cmbPrinterCommercialStatus.SelectedValue;
            string nameOfWhoOpenedThis = ((Form)WhoOpenedThis).Name;
            
            if ((int)cmbPrinterCommercialStatus.SelectedValue == (int)PrinterCommercialStatus.Produccion)
            {
                if (nameOfWhoOpenedThis == "frmPrinterSerial")
                {
                    var selectedRow = SelectedPrinterSerialDataRow;

                    if (Convert.ToInt32(selectedRow.Cells["printerCommercialStatusId"].Value) == (int)PrinterCommercialStatus.Produccion)
                    {
                        MessageBox.Show("La impresora seleccionada ya está en producción","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (handleNewPrinterForm("Actualizar"))
                    {
                        updateCommercialStatus(newPrinterCommercialStatusId, NewAreaId);

                    }
                }
                else if (nameOfWhoOpenedThis == "frmPrinterStatus")
                {
                    MessageBox.Show("El nuevo estado no es válido. Esta impresora ya está en producción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                updateCommercialStatus(newPrinterCommercialStatusId, 0);
            }
            
        }

        private void updateCommercialStatus(int printerCommercialStatusId, int newAreaId)
        {
            parameters = new StoredProcedureParameters[4];
            parameters[0] = new StoredProcedureParameters("_printerSerialId", CurrentPrinterId.ToString());
            parameters[1] = new StoredProcedureParameters("_newPrinterCommercialStatusId", printerCommercialStatusId.ToString());
            parameters[2] = new StoredProcedureParameters("_currentAreaId", CurrentAreaId.ToString());
            parameters[3] = new StoredProcedureParameters("_newAreaId", newAreaId.ToString());

            if (database.RunStoredProcedure("PrinterSerial_ChangeCommercialStatus", parameters))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se ha podido actualizar el estado comercial de la impresora", "Error al cambiar el estado de la impresora", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EventLogger.LogEvent(this, database.Error, null);
            }
        }


        /// <summary>
        /// Handles the creation and opening of myPrinterEditForm
        /// which is used to update or create new printers
        /// </summary>
        /// <param name="action">"Actualizar" or "Añadir"</param>
        /// <returns>Boolean true or false. True if the form could be created/
        /// opened or false if not.</returns>
        private bool handleNewPrinterForm(string action)
        {
            //Creates a new instance of myPrinterEditForm
            frmPrinterEdit myPrinterEditForm = new frmPrinterEdit();

            myPrinterEditForm.cmdSave.Text = action;

            //Prefills the controls in myPrinterEditForm
            myPrinterEditForm.FillForm();

            if (action == "Actualizar")
            {
                //Creates a variable to store the data from the currently
                //selected row
                var selectedRow = SelectedPrinterSerialDataRow;

                //Sends the current printer id to the new myPrinterEditForm
                myPrinterEditForm.CurrentPrinterId = (int)selectedRow.Cells["id"].Value;

                try
                {
                    //Fills the controls in myPrinterEditForm, based on
                    //the data from selectedRow
                    myPrinterEditForm.cmbPrinterSerial.Text = selectedRow.Cells["printerSerial"].Value.ToString();
                    myPrinterEditForm.cmbPrinterMakeName.SelectedValue = (int)selectedRow.Cells["printerMakeId"].Value;
                    myPrinterEditForm.cmbPrinterModel.SelectedValue = (int)selectedRow.Cells["printerModelId"].Value;
                    myPrinterEditForm.cmbPrinterLocation.SelectedIndex = -1;
                    myPrinterEditForm.cmbPrinterArea.SelectedIndex = -1;
                    myPrinterEditForm.cmbPrinterConnectionType.SelectedIndex = -1;
                    myPrinterEditForm.PrinterSerialBeingEdited = (string)selectedRow.Cells["printerSerial"].Value;
            }
                catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message.ToString(), e);
            }

        }

            //Sets titles and text in myPrinterEditForm
            myPrinterEditForm.Text = action + " impresora";
            myPrinterEditForm.cmdSave.Text = action;

            myPrinterEditForm.ShowDialog();

            if (myPrinterEditForm.DialogResult == DialogResult.OK)
            {
                return true;
            }

            return false;
            
        }



    }
}
