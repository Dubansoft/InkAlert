
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
    partial class frmPrinterEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterEdit));
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblAsterisq = new System.Windows.Forms.Label();
            this.lblSerialFilter = new System.Windows.Forms.Label();
            this.txtSerialFilter = new System.Windows.Forms.TextBox();
            this.cmbPrinterSerial = new System.Windows.Forms.ComboBox();
            this.cmbPrinterArea = new System.Windows.Forms.ComboBox();
            this.cmbPrinterConnectionType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPrinterLocation = new System.Windows.Forms.ComboBox();
            this.cmbPrinterMakeName = new System.Windows.Forms.ComboBox();
            this.cmbPrinterModel = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(453, 213);
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
            this.cmdCancel.Location = new System.Drawing.Point(372, 213);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblAsterisq
            // 
            this.lblAsterisq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisq.Location = new System.Drawing.Point(290, 14);
            this.lblAsterisq.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAsterisq.Name = "lblAsterisq";
            this.lblAsterisq.Size = new System.Drawing.Size(258, 26);
            this.lblAsterisq.TabIndex = 34;
            this.lblAsterisq.Text = "Escribe * en el filtro para ver todas las impresoras disponibles";
            this.lblAsterisq.Visible = false;
            // 
            // lblSerialFilter
            // 
            this.lblSerialFilter.AutoSize = true;
            this.lblSerialFilter.Location = new System.Drawing.Point(23, 51);
            this.lblSerialFilter.Name = "lblSerialFilter";
            this.lblSerialFilter.Size = new System.Drawing.Size(86, 17);
            this.lblSerialFilter.TabIndex = 33;
            this.lblSerialFilter.Text = "Filtrar serial:";
            // 
            // txtSerialFilter
            // 
            this.txtSerialFilter.Location = new System.Drawing.Point(151, 49);
            this.txtSerialFilter.Name = "txtSerialFilter";
            this.txtSerialFilter.Size = new System.Drawing.Size(129, 23);
            this.txtSerialFilter.TabIndex = 32;
            this.txtSerialFilter.TextChanged += new System.EventHandler(this.txtSerialFilter_TextChanged);
            // 
            // cmbPrinterSerial
            // 
            this.cmbPrinterSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterSerial.FormattingEnabled = true;
            this.cmbPrinterSerial.Location = new System.Drawing.Point(293, 47);
            this.cmbPrinterSerial.Name = "cmbPrinterSerial";
            this.cmbPrinterSerial.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterSerial.TabIndex = 31;
            this.cmbPrinterSerial.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterSerial_SelectedIndexChanged);
            // 
            // cmbPrinterArea
            // 
            this.cmbPrinterArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterArea.FormattingEnabled = true;
            this.cmbPrinterArea.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbPrinterArea.Location = new System.Drawing.Point(293, 106);
            this.cmbPrinterArea.Name = "cmbPrinterArea";
            this.cmbPrinterArea.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterArea.TabIndex = 30;
            this.cmbPrinterArea.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterArea_SelectedIndexChanged);
            // 
            // cmbPrinterConnectionType
            // 
            this.cmbPrinterConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterConnectionType.FormattingEnabled = true;
            this.cmbPrinterConnectionType.Location = new System.Drawing.Point(26, 220);
            this.cmbPrinterConnectionType.Name = "cmbPrinterConnectionType";
            this.cmbPrinterConnectionType.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterConnectionType.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 197);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tipo de conexión";
            // 
            // cmbPrinterLocation
            // 
            this.cmbPrinterLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterLocation.FormattingEnabled = true;
            this.cmbPrinterLocation.Location = new System.Drawing.Point(25, 106);
            this.cmbPrinterLocation.Name = "cmbPrinterLocation";
            this.cmbPrinterLocation.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterLocation.TabIndex = 26;
            this.cmbPrinterLocation.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterLocation_SelectedIndexChanged);
            // 
            // cmbPrinterMakeName
            // 
            this.cmbPrinterMakeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterMakeName.Enabled = false;
            this.cmbPrinterMakeName.FormattingEnabled = true;
            this.cmbPrinterMakeName.Location = new System.Drawing.Point(25, 164);
            this.cmbPrinterMakeName.Name = "cmbPrinterMakeName";
            this.cmbPrinterMakeName.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterMakeName.TabIndex = 26;
            this.cmbPrinterMakeName.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterMakeName_SelectedIndexChanged);
            // 
            // cmbPrinterModel
            // 
            this.cmbPrinterModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterModel.Enabled = false;
            this.cmbPrinterModel.FormattingEnabled = true;
            this.cmbPrinterModel.Location = new System.Drawing.Point(293, 164);
            this.cmbPrinterModel.Name = "cmbPrinterModel";
            this.cmbPrinterModel.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterModel.TabIndex = 26;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(21, 76);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(70, 17);
            this.lblLocation.TabIndex = 17;
            this.lblLocation.Text = "Ubicación";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(290, 76);
            this.lblArea.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(38, 17);
            this.lblArea.TabIndex = 17;
            this.lblArea.Text = "Área";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Serial de la impresora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Modelo";
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(293, 213);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(35, 32);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmPrinterEdit
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(575, 270);
            this.Controls.Add(this.lblAsterisq);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.lblSerialFilter);
            this.Controls.Add(this.txtSerialFilter);
            this.Controls.Add(this.cmbPrinterSerial);
            this.Controls.Add(this.cmbPrinterArea);
            this.Controls.Add(this.cmbPrinterConnectionType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPrinterLocation);
            this.Controls.Add(this.cmbPrinterMakeName);
            this.Controls.Add(this.cmbPrinterModel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmPrinterEdit";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Text = "frmPrinterEdit";
            this.Load += new System.EventHandler(this.frmPrinterEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbPrinterModel;
        internal System.Windows.Forms.ComboBox cmbPrinterLocation;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeName;
        private Controls.LoadingImage loadingImage;
        internal System.Windows.Forms.ComboBox cmbPrinterConnectionType;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cmbPrinterArea;
        internal System.Windows.Forms.ComboBox cmbPrinterSerial;
        internal System.Windows.Forms.TextBox txtSerialFilter;
        internal System.Windows.Forms.Label lblAsterisq;
        internal System.Windows.Forms.Label lblSerialFilter;
        internal System.Windows.Forms.Label lblArea;
        internal System.Windows.Forms.Label lblLocation;
    }
}