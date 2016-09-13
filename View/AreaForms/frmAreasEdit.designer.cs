
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
    partial class frmAreaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAreaEdit));
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.txtIpAddress = new IPAddressControlLib.IPAddressControl();
            this.cmbStoryNumber = new System.Windows.Forms.ComboBox();
            this.cmbPrinterLocationName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQueueName = new System.Windows.Forms.TextBox();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.cmdGetIp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(442, 255);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(95, 32);
            this.cmdSave.TabIndex = 8;
            this.cmdSave.Text = "Aceptar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(351, 255);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(85, 32);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.Transparent;
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(23, 271);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(127, 29);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.AllowInternalTab = false;
            this.txtIpAddress.AutoHeight = true;
            this.txtIpAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIpAddress.Location = new System.Drawing.Point(282, 154);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.ReadOnly = false;
            this.txtIpAddress.Size = new System.Drawing.Size(255, 23);
            this.txtIpAddress.TabIndex = 5;
            this.txtIpAddress.Text = "...";
            this.txtIpAddress.Leave += new System.EventHandler(this.txtIpAddress_Leave);
            // 
            // cmbStoryNumber
            // 
            this.cmbStoryNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoryNumber.FormattingEnabled = true;
            this.cmbStoryNumber.Location = new System.Drawing.Point(282, 94);
            this.cmbStoryNumber.Name = "cmbStoryNumber";
            this.cmbStoryNumber.Size = new System.Drawing.Size(255, 25);
            this.cmbStoryNumber.TabIndex = 2;
            // 
            // cmbPrinterLocationName
            // 
            this.cmbPrinterLocationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterLocationName.FormattingEnabled = true;
            this.cmbPrinterLocationName.Location = new System.Drawing.Point(21, 94);
            this.cmbPrinterLocationName.Name = "cmbPrinterLocationName";
            this.cmbPrinterLocationName.Size = new System.Drawing.Size(255, 25);
            this.cmbPrinterLocationName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 192);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nombre de la cola de impresión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Direccion IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre del host o IPv4 estática";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Piso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nombre del área";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ubicación";
            // 
            // txtQueueName
            // 
            this.txtQueueName.Location = new System.Drawing.Point(21, 214);
            this.txtQueueName.Margin = new System.Windows.Forms.Padding(5);
            this.txtQueueName.Name = "txtQueueName";
            this.txtQueueName.Size = new System.Drawing.Size(516, 23);
            this.txtQueueName.TabIndex = 6;
            this.txtQueueName.Tag = "Nombre de la cola de impresión";
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(23, 154);
            this.txtHostName.Margin = new System.Windows.Forms.Padding(5);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(220, 23);
            this.txtHostName.TabIndex = 3;
            this.txtHostName.Tag = "Nombre del host o IPv4 estática";
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(21, 41);
            this.txtAreaName.Margin = new System.Windows.Forms.Padding(5);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(516, 23);
            this.txtAreaName.TabIndex = 0;
            this.txtAreaName.Tag = "Nombre del área";
            this.txtAreaName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAreaName_KeyUp);
            // 
            // cmdGetIp
            // 
            this.cmdGetIp.Location = new System.Drawing.Point(244, 153);
            this.cmdGetIp.Name = "cmdGetIp";
            this.cmdGetIp.Size = new System.Drawing.Size(32, 25);
            this.cmdGetIp.TabIndex = 4;
            this.cmdGetIp.Text = "...";
            this.cmdGetIp.UseVisualStyleBackColor = true;
            this.cmdGetIp.Click += new System.EventHandler(this.cmdGetIp_Click);
            // 
            // frmAreaEdit
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(559, 310);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.txtIpAddress);
            this.Controls.Add(this.cmbStoryNumber);
            this.Controls.Add(this.cmbPrinterLocationName);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQueueName);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.txtAreaName);
            this.Controls.Add(this.cmdGetIp);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmAreaEdit";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Text = "frmAreaEdit";
            this.Load += new System.EventHandler(this.frmAreaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtAreaName;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbPrinterLocationName;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbStoryNumber;
        internal System.Windows.Forms.TextBox txtQueueName;
        internal IPAddressControlLib.IPAddressControl txtIpAddress;
        private Controls.LoadingImage loadingImage;
        private System.Windows.Forms.Button cmdGetIp;
    }
}