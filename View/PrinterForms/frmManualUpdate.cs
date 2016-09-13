
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
    public partial class frmManualUpdate : Forms.BaseForms.frmGeneralBase
    {
        Database database = new Database();
        DateEngine myDateEngine = new DateEngine();
        StoredProcedureParameters[] parameters;
        StartForm myStartForm = Application.OpenForms.OfType<StartForm>().FirstOrDefault();

        private int currentCounter;    
        public int CurrentCounter
        {
            get{return currentCounter;}
            set{currentCounter = value;}
        }

        private int currentTonerKLevel;
        public int CurrentTonerKLevel
        {
            get { return currentTonerKLevel; }
            set { currentTonerKLevel = value; }
        }

        public frmManualUpdate()
        {
            InitializeComponent();
        }

        private void frmManualUpdate_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "Actualizar manualmente historial de " + cmbPrinters.Text;
            cmbPrinterSerial.SelectedValue = cmbPrinters.SelectedValue;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (nupTonerLevel.Value > CurrentTonerKLevel)
            {
                MessageBox.Show("El nivel de tóner negro no es válido porque es mayor al nivel actual (" + CurrentTonerKLevel.ToString() +"%)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(nupTonerLevel.Value) < 1)
            {

                DialogResult myDialogResult = MessageBox.Show("¿Seguro que desea ingresar el valor " + Convert.ToString(nupTonerLevel.Value) + " en el nivel de tóner?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (myDialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (nupBlackCounter.Value < CurrentCounter)
            {
                MessageBox.Show("El contador de impresión negro no es válido porque es menor al contador actual (" + CurrentCounter.ToString() +")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(nupBlackCounter.Value) == 0)
            {
                MessageBox.Show("El contador de impresión negro no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            parameters = new StoredProcedureParameters[5];
            parameters[0] = new StoredProcedureParameters("_id",cmbPrinters.SelectedValue.ToString());
            parameters[1] = new StoredProcedureParameters("_dataDate",DateEngine.CurrentDateTimeDouble);
            parameters[2] = new StoredProcedureParameters("_serialNumber",cmbPrinterSerial.Text.ToString());
            parameters[3] = new StoredProcedureParameters("_tonerLevel",nupTonerLevel.Value.ToString());
            parameters[4] = new StoredProcedureParameters("_blackCounter", nupBlackCounter.Value.ToString());

            if (database.RunStoredProcedure("PrinterHistory_ManualUpdate", parameters))
            {
                MessageBox.Show("El nivel de tóner ha sido establecido al " + (int)nupTonerLevel.Value  + "%", "Nivel de tóner actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                myStartForm.cmdPrinterStatus.PerformClick();
            }
        }
    }
}
