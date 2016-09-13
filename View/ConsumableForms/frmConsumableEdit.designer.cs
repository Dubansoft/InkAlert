
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
    partial class frmConsumableEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEditCreate = new System.Windows.Forms.TabPage();
            this.nupMaxLife = new System.Windows.Forms.NumericUpDown();
            this.txtConsumableModelName = new System.Windows.Forms.TextBox();
            this.cmbConsumableType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUpdateMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstPrinterModels = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPrinterMakeName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAssign = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgConsumablesByModel = new InkAlert.Controls.LightDatagrid();
            this.compatibilityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedConsumableTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedConsumableModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignedConsumableMaxLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgConsumablesByMake = new InkAlert.Controls.LightDatagrid();
            this.consumable_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPrinterMakeNameAssignment = new System.Windows.Forms.ComboBox();
            this.cmdRemoveConsumable = new System.Windows.Forms.Button();
            this.cmdAddConsumable = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lstPrinterModelAssignments = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblModelSelected = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabEditCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxLife)).BeginInit();
            this.tabAssign.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumablesByModel)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumablesByMake)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(1104, 562);
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
            this.cmdCancel.Location = new System.Drawing.Point(1023, 562);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 32);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "Cancelar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
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
            this.tabEditCreate.Controls.Add(this.nupMaxLife);
            this.tabEditCreate.Controls.Add(this.txtConsumableModelName);
            this.tabEditCreate.Controls.Add(this.cmbConsumableType);
            this.tabEditCreate.Controls.Add(this.label9);
            this.tabEditCreate.Controls.Add(this.txtUpdateMessage);
            this.tabEditCreate.Controls.Add(this.label2);
            this.tabEditCreate.Controls.Add(this.label4);
            this.tabEditCreate.Controls.Add(this.lstPrinterModels);
            this.tabEditCreate.Controls.Add(this.label3);
            this.tabEditCreate.Controls.Add(this.cmbPrinterMakeName);
            this.tabEditCreate.Controls.Add(this.label1);
            this.tabEditCreate.Controls.Add(this.cmdCancel);
            this.tabEditCreate.Controls.Add(this.cmdSave);
            this.tabEditCreate.Location = new System.Drawing.Point(4, 26);
            this.tabEditCreate.Name = "tabEditCreate";
            this.tabEditCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditCreate.Size = new System.Drawing.Size(1213, 602);
            this.tabEditCreate.TabIndex = 0;
            this.tabEditCreate.Text = "Edición de suministro";
            this.tabEditCreate.UseVisualStyleBackColor = true;
            // 
            // nupMaxLife
            // 
            this.nupMaxLife.Location = new System.Drawing.Point(618, 515);
            this.nupMaxLife.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nupMaxLife.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupMaxLife.Name = "nupMaxLife";
            this.nupMaxLife.Size = new System.Drawing.Size(578, 23);
            this.nupMaxLife.TabIndex = 34;
            this.nupMaxLife.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // txtConsumableModelName
            // 
            this.txtConsumableModelName.Location = new System.Drawing.Point(19, 516);
            this.txtConsumableModelName.Margin = new System.Windows.Forms.Padding(5);
            this.txtConsumableModelName.Name = "txtConsumableModelName";
            this.txtConsumableModelName.Size = new System.Drawing.Size(582, 23);
            this.txtConsumableModelName.TabIndex = 33;
            // 
            // cmbConsumableType
            // 
            this.cmbConsumableType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConsumableType.FormattingEnabled = true;
            this.cmbConsumableType.Location = new System.Drawing.Point(616, 39);
            this.cmbConsumableType.Name = "cmbConsumableType";
            this.cmbConsumableType.Size = new System.Drawing.Size(580, 25);
            this.cmbConsumableType.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(613, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Tipo de suministro";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 494);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Duración";
            // 
            // lstPrinterModels
            // 
            this.lstPrinterModels.FormattingEnabled = true;
            this.lstPrinterModels.ItemHeight = 17;
            this.lstPrinterModels.Location = new System.Drawing.Point(19, 105);
            this.lstPrinterModels.Name = "lstPrinterModels";
            this.lstPrinterModels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPrinterModels.Size = new System.Drawing.Size(1180, 378);
            this.lstPrinterModels.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 488);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Referencia del suministro";
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
            this.label1.Size = new System.Drawing.Size(423, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Modelos de impresoras con los cuales es compatible el suministro";
            // 
            // tabAssign
            // 
            this.tabAssign.Controls.Add(this.panel2);
            this.tabAssign.Controls.Add(this.panel1);
            this.tabAssign.Controls.Add(this.label8);
            this.tabAssign.Controls.Add(this.cmbPrinterMakeNameAssignment);
            this.tabAssign.Controls.Add(this.cmdRemoveConsumable);
            this.tabAssign.Controls.Add(this.cmdAddConsumable);
            this.tabAssign.Controls.Add(this.label7);
            this.tabAssign.Controls.Add(this.lstPrinterModelAssignments);
            this.tabAssign.Controls.Add(this.label6);
            this.tabAssign.Controls.Add(this.lblModelSelected);
            this.tabAssign.Location = new System.Drawing.Point(4, 26);
            this.tabAssign.Name = "tabAssign";
            this.tabAssign.Padding = new System.Windows.Forms.Padding(3);
            this.tabAssign.Size = new System.Drawing.Size(1213, 602);
            this.tabAssign.TabIndex = 1;
            this.tabAssign.Text = "Asignar suministro existente";
            this.tabAssign.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgConsumablesByModel);
            this.panel2.Location = new System.Drawing.Point(654, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 280);
            this.panel2.TabIndex = 38;
            // 
            // dgConsumablesByModel
            // 
            this.dgConsumablesByModel.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgConsumablesByModel.AllowUserToAddRows = false;
            this.dgConsumablesByModel.AllowUserToDeleteRows = false;
            this.dgConsumablesByModel.AllowUserToOrderColumns = true;
            this.dgConsumablesByModel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgConsumablesByModel.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgConsumablesByModel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsumablesByModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConsumablesByModel.ColumnHeadersHeight = 30;
            this.dgConsumablesByModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgConsumablesByModel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compatibilityId,
            this.assignedConsumableTypeName,
            this.assignedConsumableModelName,
            this.assignedConsumableMaxLife});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsumablesByModel.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgConsumablesByModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConsumablesByModel.GridColor = System.Drawing.SystemColors.Control;
            this.dgConsumablesByModel.Location = new System.Drawing.Point(0, 0);
            this.dgConsumablesByModel.Name = "dgConsumablesByModel";
            this.dgConsumablesByModel.ReadOnly = true;
            this.dgConsumablesByModel.RowHeadersVisible = false;
            this.dgConsumablesByModel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsumablesByModel.Size = new System.Drawing.Size(537, 280);
            this.dgConsumablesByModel.TabIndex = 0;
            this.dgConsumablesByModel.AutoGenerateColumns = false;
            // 
            // compatibilityId
            // 
            this.compatibilityId.DataPropertyName = "compatibilityId";
            this.compatibilityId.HeaderText = "id";
            this.compatibilityId.Name = "compatibilityId";
            this.compatibilityId.ReadOnly = true;
            this.compatibilityId.Visible = false;
            this.compatibilityId.Width = 44;
            // 
            // assignedConsumableTypeName
            // 
            this.assignedConsumableTypeName.DataPropertyName = "consumableTypeName";
            this.assignedConsumableTypeName.HeaderText = "Tipo de suministro";
            this.assignedConsumableTypeName.Name = "assignedConsumableTypeName";
            this.assignedConsumableTypeName.ReadOnly = true;
            this.assignedConsumableTypeName.Width = 149;
            // 
            // assignedConsumableModelName
            // 
            this.assignedConsumableModelName.DataPropertyName = "consumableModelName";
            this.assignedConsumableModelName.HeaderText = "Referencia";
            this.assignedConsumableModelName.Name = "assignedConsumableModelName";
            this.assignedConsumableModelName.ReadOnly = true;
            this.assignedConsumableModelName.Width = 102;
            // 
            // assignedConsumableMaxLife
            // 
            this.assignedConsumableMaxLife.DataPropertyName = "maxLife";
            this.assignedConsumableMaxLife.HeaderText = "Duración";
            this.assignedConsumableMaxLife.Name = "assignedConsumableMaxLife";
            this.assignedConsumableMaxLife.ReadOnly = true;
            this.assignedConsumableMaxLife.Width = 90;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgConsumablesByMake);
            this.panel1.Location = new System.Drawing.Point(23, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 280);
            this.panel1.TabIndex = 38;
            // 
            // dgConsumablesByMake
            // 
            this.dgConsumablesByMake.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgConsumablesByMake.AllowUserToAddRows = false;
            this.dgConsumablesByMake.AllowUserToDeleteRows = false;
            this.dgConsumablesByMake.AllowUserToOrderColumns = true;
            this.dgConsumablesByMake.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgConsumablesByMake.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgConsumablesByMake.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsumablesByMake.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgConsumablesByMake.ColumnHeadersHeight = 30;
            this.dgConsumablesByMake.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgConsumablesByMake.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consumable_id,
            this.consumableTypeName,
            this.consumableModelName,
            this.maxLife,
            this.consumableType});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsumablesByMake.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgConsumablesByMake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConsumablesByMake.GridColor = System.Drawing.SystemColors.Control;
            this.dgConsumablesByMake.Location = new System.Drawing.Point(0, 0);
            this.dgConsumablesByMake.Name = "dgConsumablesByMake";
            this.dgConsumablesByMake.ReadOnly = true;
            this.dgConsumablesByMake.RowHeadersVisible = false;
            this.dgConsumablesByMake.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsumablesByMake.Size = new System.Drawing.Size(540, 280);
            this.dgConsumablesByMake.TabIndex = 0;
            // 
            // consumable_id
            // 
            this.consumable_id.DataPropertyName = "id";
            this.consumable_id.HeaderText = "id";
            this.consumable_id.Name = "consumable_id";
            this.consumable_id.ReadOnly = true;
            this.consumable_id.Visible = false;
            this.consumable_id.Width = 44;
            // 
            // consumableTypeName
            // 
            this.consumableTypeName.DataPropertyName = "consumableTypeName";
            this.consumableTypeName.HeaderText = "Tipo de suministro";
            this.consumableTypeName.Name = "consumableTypeName";
            this.consumableTypeName.ReadOnly = true;
            this.consumableTypeName.Width = 149;
            // 
            // consumableModelName
            // 
            this.consumableModelName.DataPropertyName = "consumableModelName";
            this.consumableModelName.HeaderText = "Referencia";
            this.consumableModelName.Name = "consumableModelName";
            this.consumableModelName.ReadOnly = true;
            this.consumableModelName.Width = 102;
            // 
            // maxLife
            // 
            this.maxLife.DataPropertyName = "maxLife";
            this.maxLife.HeaderText = "Duración";
            this.maxLife.Name = "maxLife";
            this.maxLife.ReadOnly = true;
            this.maxLife.Width = 90;
            // 
            // consumableType
            // 
            this.consumableType.DataPropertyName = "consumableType";
            this.consumableType.HeaderText = "consumableType";
            this.consumableType.Name = "consumableType";
            this.consumableType.ReadOnly = true;
            this.consumableType.Visible = false;
            this.consumableType.Width = 141;
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
            // cmdRemoveConsumable
            // 
            this.cmdRemoveConsumable.Image = global::InkAlert.Properties.Resources.key_delete;
            this.cmdRemoveConsumable.Location = new System.Drawing.Point(569, 458);
            this.cmdRemoveConsumable.Name = "cmdRemoveConsumable";
            this.cmdRemoveConsumable.Size = new System.Drawing.Size(79, 135);
            this.cmdRemoveConsumable.TabIndex = 34;
            this.cmdRemoveConsumable.UseVisualStyleBackColor = true;
            this.cmdRemoveConsumable.Click += new System.EventHandler(this.cmdRemoveConsumable_Click);
            // 
            // cmdAddConsumable
            // 
            this.cmdAddConsumable.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddConsumable.Image = global::InkAlert.Properties.Resources.key_add;
            this.cmdAddConsumable.Location = new System.Drawing.Point(569, 312);
            this.cmdAddConsumable.Name = "cmdAddConsumable";
            this.cmdAddConsumable.Size = new System.Drawing.Size(79, 135);
            this.cmdAddConsumable.TabIndex = 34;
            this.cmdAddConsumable.UseVisualStyleBackColor = true;
            this.cmdAddConsumable.Click += new System.EventHandler(this.cmdAddConsumable_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 287);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 17);
            this.label7.TabIndex = 32;
            this.label7.Text = "Suministros de la marca seleccionada";
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
            this.lblModelSelected.Size = new System.Drawing.Size(302, 17);
            this.lblModelSelected.TabIndex = 28;
            this.lblModelSelected.Text = "Suministros asignados al modelo seleccionado";
            // 
            // frmConsumableEdit
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(1243, 651);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "frmConsumableEdit";
            this.Padding = new System.Windows.Forms.Padding(17);
            this.Text = "frmConsumableEdit";
            this.Load += new System.EventHandler(this.frmConsumableEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabEditCreate.ResumeLayout(false);
            this.tabEditCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxLife)).EndInit();
            this.tabAssign.ResumeLayout(false);
            this.tabAssign.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumablesByModel)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumablesByMake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeName;
        internal System.Windows.Forms.ListBox lstPrinterModels;
        private System.Windows.Forms.TabPage tabEditCreate;
        private System.Windows.Forms.TabPage tabAssign;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ListBox lstPrinterModelAssignments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdRemoveConsumable;
        private System.Windows.Forms.Button cmdAddConsumable;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cmbPrinterMakeNameAssignment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Controls.LightDatagrid dgConsumablesByMake;
        private System.Windows.Forms.Label lblModelSelected;
        private Controls.LightDatagrid dgConsumablesByModel;
        internal System.Windows.Forms.TextBox txtUpdateMessage;
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.ComboBox cmbConsumableType;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtConsumableModelName;
        internal System.Windows.Forms.NumericUpDown nupMaxLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn compatibilityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedConsumableTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedConsumableModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedConsumableMaxLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumable_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableType;
    }
}