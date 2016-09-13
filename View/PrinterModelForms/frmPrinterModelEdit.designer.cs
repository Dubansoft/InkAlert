
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

namespace InkAlert.Forms
{
    partial class frmPrinterModelEdit
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nupHddCapacity = new System.Windows.Forms.NumericUpDown();
            this.nupRamMemory = new System.Windows.Forms.NumericUpDown();
            this.nupMonthlyDuty = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPrinterFunctions = new System.Windows.Forms.ListBox();
            this.cmbDuplexUnit = new System.Windows.Forms.ComboBox();
            this.txtPrinterModelName = new System.Windows.Forms.TextBox();
            this.cmbPrinterColorName = new System.Windows.Forms.ComboBox();
            this.cmbPrinterTypeName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrinterSerieName = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPrinterCapacity = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPrinterMakeName = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsageUrl = new System.Windows.Forms.TextBox();
            this.txtConsumablesUrl = new System.Windows.Forms.TextBox();
            this.txtSettingsUrl = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHddCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRamMemory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMonthlyDuty)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(701, 293);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(95, 32);
            this.cmdSave.TabIndex = 25;
            this.cmdSave.Text = "Aceptar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(620, 293);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 273);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nupHddCapacity);
            this.tabPage1.Controls.Add(this.nupRamMemory);
            this.tabPage1.Controls.Add(this.nupMonthlyDuty);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lstPrinterFunctions);
            this.tabPage1.Controls.Add(this.cmbDuplexUnit);
            this.tabPage1.Controls.Add(this.txtPrinterModelName);
            this.tabPage1.Controls.Add(this.cmbPrinterColorName);
            this.tabPage1.Controls.Add(this.cmbPrinterTypeName);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbPrinterSerieName);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbPrinterCapacity);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbPrinterMakeName);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label38);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos generales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nupHddCapacity
            // 
            this.nupHddCapacity.Location = new System.Drawing.Point(559, 102);
            this.nupHddCapacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupHddCapacity.Name = "nupHddCapacity";
            this.nupHddCapacity.Size = new System.Drawing.Size(121, 23);
            this.nupHddCapacity.TabIndex = 28;
            // 
            // nupRamMemory
            // 
            this.nupRamMemory.Location = new System.Drawing.Point(559, 71);
            this.nupRamMemory.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupRamMemory.Name = "nupRamMemory";
            this.nupRamMemory.Size = new System.Drawing.Size(121, 23);
            this.nupRamMemory.TabIndex = 28;
            // 
            // nupMonthlyDuty
            // 
            this.nupMonthlyDuty.Location = new System.Drawing.Point(559, 40);
            this.nupMonthlyDuty.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nupMonthlyDuty.Name = "nupMonthlyDuty";
            this.nupMonthlyDuty.Size = new System.Drawing.Size(121, 23);
            this.nupMonthlyDuty.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Modelo";
            // 
            // lstPrinterFunctions
            // 
            this.lstPrinterFunctions.FormattingEnabled = true;
            this.lstPrinterFunctions.ItemHeight = 17;
            this.lstPrinterFunctions.Location = new System.Drawing.Point(182, 164);
            this.lstPrinterFunctions.Name = "lstPrinterFunctions";
            this.lstPrinterFunctions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPrinterFunctions.Size = new System.Drawing.Size(211, 72);
            this.lstPrinterFunctions.TabIndex = 27;
            // 
            // cmbDuplexUnit
            // 
            this.cmbDuplexUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuplexUnit.FormattingEnabled = true;
            this.cmbDuplexUnit.Location = new System.Drawing.Point(559, 133);
            this.cmbDuplexUnit.Name = "cmbDuplexUnit";
            this.cmbDuplexUnit.Size = new System.Drawing.Size(211, 25);
            this.cmbDuplexUnit.TabIndex = 26;
            // 
            // txtPrinterModelName
            // 
            this.txtPrinterModelName.Location = new System.Drawing.Point(182, 9);
            this.txtPrinterModelName.Margin = new System.Windows.Forms.Padding(5);
            this.txtPrinterModelName.Name = "txtPrinterModelName";
            this.txtPrinterModelName.Size = new System.Drawing.Size(211, 23);
            this.txtPrinterModelName.TabIndex = 19;
            // 
            // cmbPrinterColorName
            // 
            this.cmbPrinterColorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterColorName.FormattingEnabled = true;
            this.cmbPrinterColorName.Location = new System.Drawing.Point(182, 133);
            this.cmbPrinterColorName.Name = "cmbPrinterColorName";
            this.cmbPrinterColorName.Size = new System.Drawing.Size(211, 25);
            this.cmbPrinterColorName.TabIndex = 26;
            // 
            // cmbPrinterTypeName
            // 
            this.cmbPrinterTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterTypeName.FormattingEnabled = true;
            this.cmbPrinterTypeName.Location = new System.Drawing.Point(182, 102);
            this.cmbPrinterTypeName.Name = "cmbPrinterTypeName";
            this.cmbPrinterTypeName.Size = new System.Drawing.Size(211, 25);
            this.cmbPrinterTypeName.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Capacidad de impresión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Marca";
            // 
            // cmbPrinterSerieName
            // 
            this.cmbPrinterSerieName.FormattingEnabled = true;
            this.cmbPrinterSerieName.Location = new System.Drawing.Point(182, 71);
            this.cmbPrinterSerieName.Name = "cmbPrinterSerieName";
            this.cmbPrinterSerieName.Size = new System.Drawing.Size(211, 25);
            this.cmbPrinterSerieName.TabIndex = 26;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(688, 46);
            this.label37.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 17);
            this.label37.TabIndex = 18;
            this.label37.Text = "(Clics)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Volumen mensual máx.";
            // 
            // cmbPrinterCapacity
            // 
            this.cmbPrinterCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterCapacity.FormattingEnabled = true;
            this.cmbPrinterCapacity.Location = new System.Drawing.Point(560, 7);
            this.cmbPrinterCapacity.Name = "cmbPrinterCapacity";
            this.cmbPrinterCapacity.Size = new System.Drawing.Size(211, 25);
            this.cmbPrinterCapacity.TabIndex = 26;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(688, 108);
            this.label36.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(82, 17);
            this.label36.TabIndex = 18;
            this.label36.Text = "(Gigabytes)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sistema de impresión";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 108);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 17);
            this.label10.TabIndex = 18;
            // 
            // cmbPrinterMakeName
            // 
            this.cmbPrinterMakeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterMakeName.FormattingEnabled = true;
            this.cmbPrinterMakeName.Location = new System.Drawing.Point(182, 40);
            this.cmbPrinterMakeName.Name = "cmbPrinterMakeName";
            this.cmbPrinterMakeName.Size = new System.Drawing.Size(211, 25);
            this.cmbPrinterMakeName.TabIndex = 26;
            this.cmbPrinterMakeName.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterMakeName_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(688, 77);
            this.label35.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(87, 17);
            this.label35.TabIndex = 18;
            this.label35.Text = "(Megabytes)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Serie";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(398, 108);
            this.label38.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(76, 17);
            this.label38.TabIndex = 18;
            this.label38.Text = "Disco duro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Memoria Ram";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 139);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mono/Color";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(397, 139);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "Unidad dúplex";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 189);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Funciones";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtUsageUrl);
            this.tabPage2.Controls.Add(this.txtConsumablesUrl);
            this.tabPage2.Controls.Add(this.txtSettingsUrl);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Interfaz web";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 78);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 17);
            this.label16.TabIndex = 21;
            this.label16.Text = "URL de Contadores";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 46);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 17);
            this.label15.TabIndex = 21;
            this.label15.Text = "URL de Suministros";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "URL de Configuración";
            // 
            // txtUsageUrl
            // 
            this.txtUsageUrl.Location = new System.Drawing.Point(182, 71);
            this.txtUsageUrl.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsageUrl.Name = "txtUsageUrl";
            this.txtUsageUrl.Size = new System.Drawing.Size(589, 23);
            this.txtUsageUrl.TabIndex = 20;
            // 
            // txtConsumablesUrl
            // 
            this.txtConsumablesUrl.Location = new System.Drawing.Point(182, 40);
            this.txtConsumablesUrl.Margin = new System.Windows.Forms.Padding(5);
            this.txtConsumablesUrl.Name = "txtConsumablesUrl";
            this.txtConsumablesUrl.Size = new System.Drawing.Size(589, 23);
            this.txtConsumablesUrl.TabIndex = 20;
            // 
            // txtSettingsUrl
            // 
            this.txtSettingsUrl.Location = new System.Drawing.Point(182, 9);
            this.txtSettingsUrl.Margin = new System.Windows.Forms.Padding(5);
            this.txtSettingsUrl.Name = "txtSettingsUrl";
            this.txtSettingsUrl.Size = new System.Drawing.Size(589, 23);
            this.txtSettingsUrl.TabIndex = 20;
            // 
            // frmPrinterModelEdit
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(808, 334);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmPrinterModelEdit";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Text = "frmPrinterModelEdit";
            this.Load += new System.EventHandler(this.frmPrinterModelEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupHddCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupRamMemory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMonthlyDuty)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtPrinterModelName;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtSettingsUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtUsageUrl;
        internal System.Windows.Forms.TextBox txtConsumablesUrl;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeName;
        internal System.Windows.Forms.ComboBox cmbPrinterTypeName;
        internal System.Windows.Forms.ComboBox cmbPrinterSerieName;
        internal System.Windows.Forms.ComboBox cmbPrinterColorName;
        internal System.Windows.Forms.ListBox lstPrinterFunctions;
        internal System.Windows.Forms.ComboBox cmbDuplexUnit;
        internal System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.NumericUpDown nupMonthlyDuty;
        internal System.Windows.Forms.ComboBox cmbPrinterCapacity;
        internal System.Windows.Forms.NumericUpDown nupHddCapacity;
        internal System.Windows.Forms.NumericUpDown nupRamMemory;
        private System.Windows.Forms.Label label38;
        internal System.Windows.Forms.TabControl tabControl1;
    }
}