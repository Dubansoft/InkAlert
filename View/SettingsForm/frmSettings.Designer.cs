
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
    partial class frmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataBasePassword = new System.Windows.Forms.TextBox();
            this.txtDataBaseUserName = new System.Windows.Forms.TextBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtDataBaseServerPort = new System.Windows.Forms.TextBox();
            this.txtDataBaseServerName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nupSnmpRequestTimeOut = new System.Windows.Forms.NumericUpDown();
            this.nupSnmpRequestRetry = new System.Windows.Forms.NumericUpDown();
            this.nupTrackingInterval = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNetworkAdministratorPassword = new System.Windows.Forms.TextBox();
            this.txtNetworkAdministrator = new System.Windows.Forms.TextBox();
            this.txtWorkGroup = new System.Windows.Forms.TextBox();
            this.txtDefaultLocalDomainName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkLogRunTimeErrors = new System.Windows.Forms.CheckBox();
            this.nupPrinterHistoryCleanUpInterval = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSnmpRequestTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSnmpRequestRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTrackingInterval)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrinterHistoryCleanUpInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDataBasePassword);
            this.groupBox1.Controls.Add(this.txtDataBaseUserName);
            this.groupBox1.Controls.Add(this.txtDataBaseName);
            this.groupBox1.Controls.Add(this.txtDataBaseServerPort);
            this.groupBox1.Controls.Add(this.txtDataBaseServerName);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conexión al servidor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario de base de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Base de datos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(282, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Puerto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor MySql";
            // 
            // txtDataBasePassword
            // 
            this.txtDataBasePassword.Location = new System.Drawing.Point(198, 109);
            this.txtDataBasePassword.Name = "txtDataBasePassword";
            this.txtDataBasePassword.PasswordChar = '●';
            this.txtDataBasePassword.Size = new System.Drawing.Size(212, 23);
            this.txtDataBasePassword.TabIndex = 4;
            this.txtDataBasePassword.Tag = "Contraseña";
            this.txtDataBasePassword.Enter += new System.EventHandler(this.txtDataBasePassword_Enter);
            // 
            // txtDataBaseUserName
            // 
            this.txtDataBaseUserName.Location = new System.Drawing.Point(198, 80);
            this.txtDataBaseUserName.Name = "txtDataBaseUserName";
            this.txtDataBaseUserName.Size = new System.Drawing.Size(212, 23);
            this.txtDataBaseUserName.TabIndex = 3;
            this.txtDataBaseUserName.Tag = "Usuario de base de datos";
            this.txtDataBaseUserName.Enter += new System.EventHandler(this.txtDataBaseUserName_Enter);
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(198, 51);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(212, 23);
            this.txtDataBaseName.TabIndex = 2;
            this.txtDataBaseName.Tag = "Base de datos";
            this.txtDataBaseName.Enter += new System.EventHandler(this.txtDataBaseName_Enter);
            // 
            // txtDataBaseServerPort
            // 
            this.txtDataBaseServerPort.Location = new System.Drawing.Point(338, 22);
            this.txtDataBaseServerPort.Name = "txtDataBaseServerPort";
            this.txtDataBaseServerPort.Size = new System.Drawing.Size(72, 23);
            this.txtDataBaseServerPort.TabIndex = 1;
            this.txtDataBaseServerPort.Tag = "Puerto";
            this.txtDataBaseServerPort.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // txtDataBaseServerName
            // 
            this.txtDataBaseServerName.Location = new System.Drawing.Point(135, 22);
            this.txtDataBaseServerName.Name = "txtDataBaseServerName";
            this.txtDataBaseServerName.Size = new System.Drawing.Size(141, 23);
            this.txtDataBaseServerName.TabIndex = 0;
            this.txtDataBaseServerName.Tag = "Servidor MySql";
            this.txtDataBaseServerName.Enter += new System.EventHandler(this.txtDataBaseServerName_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nupSnmpRequestTimeOut);
            this.groupBox2.Controls.Add(this.nupSnmpRequestRetry);
            this.groupBox2.Controls.Add(this.nupTrackingInterval);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNetworkAdministratorPassword);
            this.groupBox2.Controls.Add(this.txtNetworkAdministrator);
            this.groupBox2.Controls.Add(this.txtWorkGroup);
            this.groupBox2.Controls.Add(this.txtDefaultLocalDomainName);
            this.groupBox2.Location = new System.Drawing.Point(445, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 268);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexión a hosts";
            // 
            // nupSnmpRequestTimeOut
            // 
            this.nupSnmpRequestTimeOut.Location = new System.Drawing.Point(267, 80);
            this.nupSnmpRequestTimeOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupSnmpRequestTimeOut.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupSnmpRequestTimeOut.Name = "nupSnmpRequestTimeOut";
            this.nupSnmpRequestTimeOut.Size = new System.Drawing.Size(121, 23);
            this.nupSnmpRequestTimeOut.TabIndex = 9;
            this.nupSnmpRequestTimeOut.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupSnmpRequestTimeOut.Enter += new System.EventHandler(this.nupSnmpRequestTimeOut_Enter);
            // 
            // nupSnmpRequestRetry
            // 
            this.nupSnmpRequestRetry.Location = new System.Drawing.Point(267, 51);
            this.nupSnmpRequestRetry.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupSnmpRequestRetry.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupSnmpRequestRetry.Name = "nupSnmpRequestRetry";
            this.nupSnmpRequestRetry.Size = new System.Drawing.Size(121, 23);
            this.nupSnmpRequestRetry.TabIndex = 8;
            this.nupSnmpRequestRetry.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupSnmpRequestRetry.Enter += new System.EventHandler(this.nupSnmpRequestRetry_Enter);
            // 
            // nupTrackingInterval
            // 
            this.nupTrackingInterval.Location = new System.Drawing.Point(267, 22);
            this.nupTrackingInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.nupTrackingInterval.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupTrackingInterval.Name = "nupTrackingInterval";
            this.nupTrackingInterval.Size = new System.Drawing.Size(121, 23);
            this.nupTrackingInterval.TabIndex = 7;
            this.nupTrackingInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nupTrackingInterval.Enter += new System.EventHandler(this.nupTrackingInterval_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(236, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Contraseña de administrador de red";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Administrador de red";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Grupo de trabajo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Dominio de red local";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tiempo de espera (milisegundos)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Reintentos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Frecuencia de rastreo (minutos)";
            // 
            // txtNetworkAdministratorPassword
            // 
            this.txtNetworkAdministratorPassword.Location = new System.Drawing.Point(267, 199);
            this.txtNetworkAdministratorPassword.Name = "txtNetworkAdministratorPassword";
            this.txtNetworkAdministratorPassword.PasswordChar = '●';
            this.txtNetworkAdministratorPassword.Size = new System.Drawing.Size(121, 23);
            this.txtNetworkAdministratorPassword.TabIndex = 13;
            this.txtNetworkAdministratorPassword.Tag = "Contraseña de administrador de red";
            this.txtNetworkAdministratorPassword.Enter += new System.EventHandler(this.txtNetworkAdministratorPassword_Enter);
            // 
            // txtNetworkAdministrator
            // 
            this.txtNetworkAdministrator.Location = new System.Drawing.Point(267, 167);
            this.txtNetworkAdministrator.Name = "txtNetworkAdministrator";
            this.txtNetworkAdministrator.Size = new System.Drawing.Size(121, 23);
            this.txtNetworkAdministrator.TabIndex = 12;
            this.txtNetworkAdministrator.Tag = "Administrador de red";
            this.txtNetworkAdministrator.Enter += new System.EventHandler(this.txtNetworkAdministrator_Enter);
            // 
            // txtWorkGroup
            // 
            this.txtWorkGroup.Location = new System.Drawing.Point(267, 138);
            this.txtWorkGroup.Name = "txtWorkGroup";
            this.txtWorkGroup.Size = new System.Drawing.Size(121, 23);
            this.txtWorkGroup.TabIndex = 11;
            this.txtWorkGroup.Tag = "Grupo de trabajo";
            this.txtWorkGroup.Enter += new System.EventHandler(this.txtWorkGroup_Enter);
            // 
            // txtDefaultLocalDomainName
            // 
            this.txtDefaultLocalDomainName.Location = new System.Drawing.Point(267, 109);
            this.txtDefaultLocalDomainName.Name = "txtDefaultLocalDomainName";
            this.txtDefaultLocalDomainName.Size = new System.Drawing.Size(121, 23);
            this.txtDefaultLocalDomainName.TabIndex = 10;
            this.txtDefaultLocalDomainName.Tag = "Dominio de red local";
            this.txtDefaultLocalDomainName.Enter += new System.EventHandler(this.txtDefaultLocalDomainName_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkLogRunTimeErrors);
            this.groupBox4.Controls.Add(this.nupPrinterHistoryCleanUpInterval);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(11, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(428, 104);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mantenimiento";
            // 
            // chkLogRunTimeErrors
            // 
            this.chkLogRunTimeErrors.AutoSize = true;
            this.chkLogRunTimeErrors.Location = new System.Drawing.Point(20, 69);
            this.chkLogRunTimeErrors.Name = "chkLogRunTimeErrors";
            this.chkLogRunTimeErrors.Size = new System.Drawing.Size(389, 21);
            this.chkLogRunTimeErrors.TabIndex = 6;
            this.chkLogRunTimeErrors.Text = "Habilitar registro de eventos del Servicio de Actualización";
            this.chkLogRunTimeErrors.UseVisualStyleBackColor = true;
            this.chkLogRunTimeErrors.Enter += new System.EventHandler(this.chkLogRunTimeErrors_Enter);
            // 
            // nupPrinterHistoryCleanUpInterval
            // 
            this.nupPrinterHistoryCleanUpInterval.Location = new System.Drawing.Point(267, 26);
            this.nupPrinterHistoryCleanUpInterval.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nupPrinterHistoryCleanUpInterval.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nupPrinterHistoryCleanUpInterval.Name = "nupPrinterHistoryCleanUpInterval";
            this.nupPrinterHistoryCleanUpInterval.Size = new System.Drawing.Size(142, 23);
            this.nupPrinterHistoryCleanUpInterval.TabIndex = 5;
            this.nupPrinterHistoryCleanUpInterval.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nupPrinterHistoryCleanUpInterval.Enter += new System.EventHandler(this.nupPrinterHistoryCleanUpInterval_Enter);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(17, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 36);
            this.label12.TabIndex = 1;
            this.label12.Text = "Mantener historial de consumibles (meses)";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(755, 305);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(95, 32);
            this.cmdSave.TabIndex = 15;
            this.cmdSave.Text = "Aceptar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(674, 305);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(11, 282);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(661, 55);
            this.lblMessage.TabIndex = 28;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSettings
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(866, 350);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmSettings";
            this.Padding = new System.Windows.Forms.Padding(13);
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSnmpRequestTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupSnmpRequestRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupTrackingInterval)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrinterHistoryCleanUpInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataBasePassword;
        private System.Windows.Forms.TextBox txtDataBaseUserName;
        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.TextBox txtDataBaseServerName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nupSnmpRequestTimeOut;
        private System.Windows.Forms.NumericUpDown nupSnmpRequestRetry;
        private System.Windows.Forms.NumericUpDown nupTrackingInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDefaultLocalDomainName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nupPrinterHistoryCleanUpInterval;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNetworkAdministratorPassword;
        private System.Windows.Forms.TextBox txtNetworkAdministrator;
        private System.Windows.Forms.TextBox txtWorkGroup;
        private System.Windows.Forms.CheckBox chkLogRunTimeErrors;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDataBaseServerPort;
    }
}