
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

namespace InkAlert
{
    partial class frmManualUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConsumableType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.nupTonerLevel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPrinterSerial = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nupBlackCounter = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupTonerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBlackCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de consumible";
            // 
            // cmbConsumableType
            // 
            this.cmbConsumableType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsumableType.FormattingEnabled = true;
            this.cmbConsumableType.Items.AddRange(new object[] {
            "Tóner"});
            this.cmbConsumableType.Location = new System.Drawing.Point(197, 10);
            this.cmbConsumableType.Name = "cmbConsumableType";
            this.cmbConsumableType.Size = new System.Drawing.Size(245, 25);
            this.cmbConsumableType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Impresora";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.FormattingEnabled = true;
            this.cmbPrinters.Location = new System.Drawing.Point(197, 47);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(245, 25);
            this.cmbPrinters.TabIndex = 2;
            this.cmbPrinters.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valor actual en porcentaje";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(347, 183);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(95, 32);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Aceptar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(266, 183);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // nupTonerLevel
            // 
            this.nupTonerLevel.Location = new System.Drawing.Point(197, 118);
            this.nupTonerLevel.Name = "nupTonerLevel";
            this.nupTonerLevel.Size = new System.Drawing.Size(245, 23);
            this.nupTonerLevel.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serial";
            // 
            // cmbPrinterSerial
            // 
            this.cmbPrinterSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterSerial.Enabled = false;
            this.cmbPrinterSerial.FormattingEnabled = true;
            this.cmbPrinterSerial.Location = new System.Drawing.Point(197, 82);
            this.cmbPrinterSerial.Name = "cmbPrinterSerial";
            this.cmbPrinterSerial.Size = new System.Drawing.Size(245, 25);
            this.cmbPrinterSerial.TabIndex = 1;
            this.cmbPrinterSerial.SelectedIndexChanged += new System.EventHandler(this.cmbPrinters_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Contador actual";
            // 
            // nupBlackCounter
            // 
            this.nupBlackCounter.Location = new System.Drawing.Point(197, 150);
            this.nupBlackCounter.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nupBlackCounter.Name = "nupBlackCounter";
            this.nupBlackCounter.Size = new System.Drawing.Size(245, 23);
            this.nupBlackCounter.TabIndex = 4;
            this.nupBlackCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmManualUpdate
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(459, 237);
            this.Controls.Add(this.nupBlackCounter);
            this.Controls.Add(this.nupTonerLevel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmbPrinterSerial);
            this.Controls.Add(this.cmbPrinters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbConsumableType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManualUpdate";
            this.Text = "Actualización manual";
            this.Load += new System.EventHandler(this.frmManualUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupTonerLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupBlackCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.NumericUpDown nupTonerLevel;
        internal System.Windows.Forms.ComboBox cmbPrinters;
        internal System.Windows.Forms.ComboBox cmbConsumableType;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbPrinterSerial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nupBlackCounter;
    }
}