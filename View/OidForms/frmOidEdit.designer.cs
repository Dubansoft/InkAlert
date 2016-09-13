
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
    partial class frmOidEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOidEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEditCreate = new System.Windows.Forms.TabPage();
            this.cmbPrinterConnectionType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdNewOidType = new System.Windows.Forms.Button();
            this.txtUpdateMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOidAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lstPrinterModels = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPrinterMakeName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOidReturnType = new System.Windows.Forms.ComboBox();
            this.cmbOidType = new System.Windows.Forms.ComboBox();
            this.tabAssign = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgOidsByModel = new InkAlert.Controls.LightDatagrid();
            this.modelMetaOidId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgOidsByMake = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPrinterMakeNameAssignment = new System.Windows.Forms.ComboBox();
            this.cmdRemoveOid = new System.Windows.Forms.Button();
            this.cmdAddOid = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lstPrinterModelAssignments = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblModelSelected = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabEditCreate.SuspendLayout();
            this.tabAssign.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOidsByModel)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOidsByMake)).BeginInit();
            this.SuspendLayout();
            //
            // cmdSave
            //
            this.cmdSave.Location = new System.Drawing.Point(1104, 560);
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
            this.cmdCancel.Location = new System.Drawing.Point(1023, 560);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.button1_Click);
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabEditCreate);
            this.tabControl1.Controls.Add(this.tabAssign);
            this.tabControl1.Location = new System.Drawing.Point(10, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1221, 632);
            this.tabControl1.TabIndex = 30;
            //
            // tabEditCreate
            //
            this.tabEditCreate.Controls.Add(this.cmbPrinterConnectionType);
            this.tabEditCreate.Controls.Add(this.label9);
            this.tabEditCreate.Controls.Add(this.cmdNewOidType);
            this.tabEditCreate.Controls.Add(this.txtUpdateMessage);
            this.tabEditCreate.Controls.Add(this.label2);
            this.tabEditCreate.Controls.Add(this.txtOidAddress);
            this.tabEditCreate.Controls.Add(this.label4);
            this.tabEditCreate.Controls.Add(this.label5);
            this.tabEditCreate.Controls.Add(this.lstPrinterModels);
            this.tabEditCreate.Controls.Add(this.label3);
            this.tabEditCreate.Controls.Add(this.cmbPrinterMakeName);
            this.tabEditCreate.Controls.Add(this.label1);
            this.tabEditCreate.Controls.Add(this.cmbOidReturnType);
            this.tabEditCreate.Controls.Add(this.cmbOidType);
            this.tabEditCreate.Controls.Add(this.cmdCancel);
            this.tabEditCreate.Controls.Add(this.cmdSave);
            this.tabEditCreate.Location = new System.Drawing.Point(4, 26);
            this.tabEditCreate.Name = "tabEditCreate";
            this.tabEditCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditCreate.Size = new System.Drawing.Size(1213, 602);
            this.tabEditCreate.TabIndex = 0;
            this.tabEditCreate.Text = "Edición de OID";
            this.tabEditCreate.UseVisualStyleBackColor = true;
            //
            // cmbPrinterConnectionType
            //
            this.cmbPrinterConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterConnectionType.FormattingEnabled = true;
            this.cmbPrinterConnectionType.Location = new System.Drawing.Point(616, 39);
            this.cmbPrinterConnectionType.Name = "cmbPrinterConnectionType";
            this.cmbPrinterConnectionType.Size = new System.Drawing.Size(580, 25);
            this.cmbPrinterConnectionType.TabIndex = 32;
            //
            // label9
            //
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(613, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Tipo de conexión compatible";
            //
            // cmdNewOidType
            //
            this.cmdNewOidType.Location = new System.Drawing.Point(1104, 457);
            this.cmdNewOidType.Name = "cmdNewOidType";
            this.cmdNewOidType.Size = new System.Drawing.Size(92, 27);
            this.cmdNewOidType.TabIndex = 30;
            this.cmdNewOidType.Text = "Nuevo...";
            this.cmdNewOidType.UseVisualStyleBackColor = true;
            this.cmdNewOidType.Click += new System.EventHandler(this.cmdNewOidType_Click);
            //
            // txtUpdateMessage
            //
            this.txtUpdateMessage.Location = new System.Drawing.Point(986, 105);
            this.txtUpdateMessage.Multiline = true;
            this.txtUpdateMessage.Name = "txtUpdateMessage";
            this.txtUpdateMessage.Size = new System.Drawing.Size(213, 25);
            this.txtUpdateMessage.TabIndex = 29;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Marca de impresora";
            //
            // txtOidAddress
            //
            this.txtOidAddress.Location = new System.Drawing.Point(19, 399);
            this.txtOidAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txtOidAddress.Name = "txtOidAddress";
            this.txtOidAddress.Size = new System.Drawing.Size(1177, 23);
            this.txtOidAddress.TabIndex = 19;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 436);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Nombre del Resultado";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 501);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Valor devuelto";
            //
            // lstPrinterModels
            //
            this.lstPrinterModels.FormattingEnabled = true;
            this.lstPrinterModels.ItemHeight = 17;
            this.lstPrinterModels.Location = new System.Drawing.Point(19, 105);
            this.lstPrinterModels.Name = "lstPrinterModels";
            this.lstPrinterModels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPrinterModels.Size = new System.Drawing.Size(1180, 259);
            this.lstPrinterModels.TabIndex = 27;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 377);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Identificador OID";
            //
            // cmbPrinterMakeName
            //
            this.cmbPrinterMakeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterMakeName.FormattingEnabled = true;
            this.cmbPrinterMakeName.Location = new System.Drawing.Point(21, 39);
            this.cmbPrinterMakeName.Name = "cmbPrinterMakeName";
            this.cmbPrinterMakeName.Size = new System.Drawing.Size(580, 25);
            this.cmbPrinterMakeName.TabIndex = 26;
            this.cmbPrinterMakeName.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterMakeName_SelectedIndexChanged);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Modelos de impresoras a los cuales se aplicará el OID";
            //
            // cmbOidReturnType
            //
            this.cmbOidReturnType.FormattingEnabled = true;
            this.cmbOidReturnType.Location = new System.Drawing.Point(19, 523);
            this.cmbOidReturnType.Name = "cmbOidReturnType";
            this.cmbOidReturnType.Size = new System.Drawing.Size(1180, 25);
            this.cmbOidReturnType.TabIndex = 26;
            this.cmbOidReturnType.SelectedIndexChanged += new System.EventHandler(this.cmbOidType_SelectedIndexChanged);
            //
            // cmbOidType
            //
            this.cmbOidType.FormattingEnabled = true;
            this.cmbOidType.Location = new System.Drawing.Point(19, 458);
            this.cmbOidType.Name = "cmbOidType";
            this.cmbOidType.Size = new System.Drawing.Size(1079, 25);
            this.cmbOidType.TabIndex = 26;
            this.cmbOidType.SelectedIndexChanged += new System.EventHandler(this.cmbOidType_SelectedIndexChanged);
            //
            // tabAssign
            //
            this.tabAssign.Controls.Add(this.panel2);
            this.tabAssign.Controls.Add(this.panel1);
            this.tabAssign.Controls.Add(this.label8);
            this.tabAssign.Controls.Add(this.cmbPrinterMakeNameAssignment);
            this.tabAssign.Controls.Add(this.cmdRemoveOid);
            this.tabAssign.Controls.Add(this.cmdAddOid);
            this.tabAssign.Controls.Add(this.label7);
            this.tabAssign.Controls.Add(this.lstPrinterModelAssignments);
            this.tabAssign.Controls.Add(this.label6);
            this.tabAssign.Controls.Add(this.lblModelSelected);
            this.tabAssign.Location = new System.Drawing.Point(4, 26);
            this.tabAssign.Name = "tabAssign";
            this.tabAssign.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssign.Size = new System.Drawing.Size(1213, 602);
            this.tabAssign.TabIndex = 1;
            this.tabAssign.Text = "Asignar OID existente";
            this.tabAssign.UseVisualStyleBackColor = true;
            //
            // panel2
            //
            this.panel2.Controls.Add(this.dgOidsByModel);
            this.panel2.Location = new System.Drawing.Point(654, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 280);
            this.panel2.TabIndex = 38;
            //
            // dgOidsByModel
            //
            this.dgOidsByModel.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgOidsByModel.AllowUserToAddRows = false;
            this.dgOidsByModel.AllowUserToDeleteRows = false;
            this.dgOidsByModel.AllowUserToOrderColumns = true;
            this.dgOidsByModel.AssignedContextMenuStrip = null;
            this.dgOidsByModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOidsByModel.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgOidsByModel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOidsByModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOidsByModel.ColumnHeadersHeight = 30;
            this.dgOidsByModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgOidsByModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modelMetaOidId,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgOidsByModel.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgOidsByModel.CurrentFilterString = null;
            this.dgOidsByModel.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOidsByModel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgOidsByModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOidsByModel.FilterColumnList = null;
            this.dgOidsByModel.GridColor = System.Drawing.SystemColors.Control;
            this.dgOidsByModel.Location = new System.Drawing.Point(0, 0);
            this.dgOidsByModel.Name = "dgOidsByModel";
            this.dgOidsByModel.ReadOnly = true;
            this.dgOidsByModel.RowHeadersVisible = false;
            this.dgOidsByModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOidsByModel.Size = new System.Drawing.Size(537, 280);
            this.dgOidsByModel.SortColumn = -1;
            this.dgOidsByModel.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgOidsByModel.TabIndex = 0;
            //
            // modelMetaOidId
            //
            this.modelMetaOidId.DataPropertyName = "id";
            this.modelMetaOidId.HeaderText = "id";
            this.modelMetaOidId.Name = "modelMetaOidId";
            this.modelMetaOidId.ReadOnly = true;
            this.modelMetaOidId.Visible = false;
            this.modelMetaOidId.Width = 44;
            //
            // dataGridViewTextBoxColumn2
            //
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "oidName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 83;
            //
            // dataGridViewTextBoxColumn3
            //
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "oidAddress";
            this.dataGridViewTextBoxColumn3.HeaderText = "Dirección del Identificador";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 196;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.dgOidsByMake);
            this.panel1.Location = new System.Drawing.Point(23, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 280);
            this.panel1.TabIndex = 38;
            //
            // dgOidsByMake
            //
            this.dgOidsByMake.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgOidsByMake.AllowUserToAddRows = false;
            this.dgOidsByMake.AllowUserToDeleteRows = false;
            this.dgOidsByMake.AllowUserToOrderColumns = true;
            this.dgOidsByMake.AssignedContextMenuStrip = null;
            this.dgOidsByMake.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOidsByMake.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgOidsByMake.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOidsByMake.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgOidsByMake.ColumnHeadersHeight = 30;
            this.dgOidsByMake.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgOidsByMake.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.oidName,
            this.oidAddress,
            this.oidType});
            this.dgOidsByMake.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgOidsByMake.CurrentFilterString = null;
            this.dgOidsByMake.DataSourceView = null;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOidsByMake.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgOidsByMake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOidsByMake.FilterColumnList = null;
            this.dgOidsByMake.GridColor = System.Drawing.SystemColors.Control;
            this.dgOidsByMake.Location = new System.Drawing.Point(0, 0);
            this.dgOidsByMake.Name = "dgOidsByMake";
            this.dgOidsByMake.ReadOnly = true;
            this.dgOidsByMake.RowHeadersVisible = false;
            this.dgOidsByMake.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOidsByMake.Size = new System.Drawing.Size(540, 280);
            this.dgOidsByMake.SortColumn = -1;
            this.dgOidsByMake.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgOidsByMake.TabIndex = 0;
            //
            // id
            //
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 44;
            //
            // oidName
            //
            this.oidName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oidName.DataPropertyName = "oidName";
            this.oidName.HeaderText = "Nombre";
            this.oidName.Name = "oidName";
            this.oidName.ReadOnly = true;
            this.oidName.Width = 83;
            //
            // oidAddress
            //
            this.oidAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oidAddress.DataPropertyName = "oidAddress";
            this.oidAddress.HeaderText = "Dirección del Identificador";
            this.oidAddress.Name = "oidAddress";
            this.oidAddress.ReadOnly = true;
            this.oidAddress.Width = 196;
            //
            // oidType
            //
            this.oidType.DataPropertyName = "oidType";
            this.oidType.HeaderText = "Tipo";
            this.oidType.Name = "oidType";
            this.oidType.ReadOnly = true;
            this.oidType.Visible = false;
            this.oidType.Width = 61;
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 17);
            this.label8.TabIndex = 35;
            this.label8.Text = "Marca de impresora";
            //
            // cmbPrinterMakeNameAssignment
            //
            this.cmbPrinterMakeNameAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterMakeNameAssignment.FormattingEnabled = true;
            this.cmbPrinterMakeNameAssignment.Location = new System.Drawing.Point(21, 36);
            this.cmbPrinterMakeNameAssignment.Name = "cmbPrinterMakeNameAssignment";
            this.cmbPrinterMakeNameAssignment.Size = new System.Drawing.Size(1169, 25);
            this.cmbPrinterMakeNameAssignment.TabIndex = 36;
            this.cmbPrinterMakeNameAssignment.SelectedIndexChanged += new System.EventHandler(this.cmbPrinterMakeNameAssignment_SelectedIndexChanged);
            //
            // cmdRemoveOid
            //
            this.cmdRemoveOid.Image = global::InkAlert.Properties.Resources.key_delete;
            this.cmdRemoveOid.Location = new System.Drawing.Point(569, 458);
            this.cmdRemoveOid.Name = "cmdRemoveOid";
            this.cmdRemoveOid.Size = new System.Drawing.Size(79, 135);
            this.cmdRemoveOid.TabIndex = 34;
            this.cmdRemoveOid.UseVisualStyleBackColor = true;
            this.cmdRemoveOid.Click += new System.EventHandler(this.cmdRemoveOid_Click);
            //
            // cmdAddOid
            //
            this.cmdAddOid.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddOid.Image = global::InkAlert.Properties.Resources.key_add;
            this.cmdAddOid.Location = new System.Drawing.Point(569, 312);
            this.cmdAddOid.Name = "cmdAddOid";
            this.cmdAddOid.Size = new System.Drawing.Size(79, 135);
            this.cmdAddOid.TabIndex = 34;
            this.cmdAddOid.UseVisualStyleBackColor = true;
            this.cmdAddOid.Click += new System.EventHandler(this.cmdAddOid_Click);
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 287);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Oids de la marca seleccionada";
            //
            // lstPrinterModelAssignments
            //
            this.lstPrinterModelAssignments.FormattingEnabled = true;
            this.lstPrinterModelAssignments.ItemHeight = 17;
            this.lstPrinterModelAssignments.Location = new System.Drawing.Point(21, 94);
            this.lstPrinterModelAssignments.Name = "lstPrinterModelAssignments";
            this.lstPrinterModelAssignments.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPrinterModelAssignments.Size = new System.Drawing.Size(1170, 174);
            this.lstPrinterModelAssignments.TabIndex = 31;
            this.lstPrinterModelAssignments.SelectedIndexChanged += new System.EventHandler(this.lstPrinterModelAssignments_SelectedIndexChanged);
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Modelos de la marca";
            //
            // lblModelSelected
            //
            this.lblModelSelected.AutoSize = true;
            this.lblModelSelected.Location = new System.Drawing.Point(651, 287);
            this.lblModelSelected.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblModelSelected.Name = "lblModelSelected";
            this.lblModelSelected.Size = new System.Drawing.Size(258, 17);
            this.lblModelSelected.TabIndex = 28;
            this.lblModelSelected.Text = "Oids asignadas al modelo seleccionado";
            //
            // frmOidEdit
            //
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(1243, 651);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmOidEdit";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Text = "frmOidEdit";
            this.Load += new System.EventHandler(this.frmOidEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEditCreate.ResumeLayout(false);
            this.tabEditCreate.PerformLayout();
            this.tabAssign.ResumeLayout(false);
            this.tabAssign.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOidsByModel)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOidsByMake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox txtOidAddress;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbOidType;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeName;
        internal System.Windows.Forms.ListBox lstPrinterModels;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbOidReturnType;
        private System.Windows.Forms.TabPage tabEditCreate;
        private System.Windows.Forms.TabPage tabAssign;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ListBox lstPrinterModelAssignments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdRemoveOid;
        private System.Windows.Forms.Button cmdAddOid;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeNameAssignment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Controls.LightDatagrid dgOidsByMake;
        private System.Windows.Forms.Label lblModelSelected;
        private Controls.LightDatagrid dgOidsByModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidType;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelMetaOidId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        internal System.Windows.Forms.TextBox txtUpdateMessage;
        internal System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button cmdNewOidType;
        internal System.Windows.Forms.ComboBox cmbPrinterConnectionType;
        private System.Windows.Forms.Label label9;
    }
}