
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
    partial class frmNewOidType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgOidTypes = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualizarDireccionesIpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResultName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOidCategory = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOidTypes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgOidTypes);
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 388);
            this.panel1.TabIndex = 0;
            // 
            // dgOidTypes
            // 
            this.dgOidTypes.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgOidTypes.AllowUserToAddRows = false;
            this.dgOidTypes.AllowUserToDeleteRows = false;
            this.dgOidTypes.AllowUserToOrderColumns = true;
            this.dgOidTypes.AutoGenerateColumns = false;
            this.dgOidTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOidTypes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgOidTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOidTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgOidTypes.ColumnHeadersHeight = 30;
            this.dgOidTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgOidTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.oidType,
            this.oidName});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOidTypes.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgOidTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOidTypes.GridColor = System.Drawing.SystemColors.Control;
            this.dgOidTypes.Location = new System.Drawing.Point(0, 0);
            this.dgOidTypes.Margin = new System.Windows.Forms.Padding(4);
            this.dgOidTypes.Name = "dgOidTypes";
            this.dgOidTypes.ReadOnly = true;
            this.dgOidTypes.RowHeadersVisible = false;
            this.dgOidTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOidTypes.Size = new System.Drawing.Size(396, 388);
            this.dgOidTypes.TabIndex = 0;
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
            // oidType
            // 
            this.oidType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oidType.DataPropertyName = "oidType";
            this.oidType.HeaderText = "Tipo de Oid";
            this.oidType.Name = "oidType";
            this.oidType.ReadOnly = true;
            this.oidType.Width = 107;
            // 
            // oidName
            // 
            this.oidName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oidName.DataPropertyName = "oidName";
            this.oidName.HeaderText = "Nombre del Oid";
            this.oidName.Name = "oidName";
            this.oidName.ReadOnly = true;
            this.oidName.Width = 132;
            // 
            // actualizarDireccionesIpToolStripMenuItem
            // 
            this.actualizarDireccionesIpToolStripMenuItem.Image = global::InkAlert.Properties.Resources.globe_network;
            this.actualizarDireccionesIpToolStripMenuItem.Name = "actualizarDireccionesIpToolStripMenuItem";
            this.actualizarDireccionesIpToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.actualizarDireccionesIpToolStripMenuItem.Text = "Actualizar direcciones IPv4";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(424, 373);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(102, 32);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "Eliminar";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(549, 373);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(110, 32);
            this.cmdSave.TabIndex = 27;
            this.cmdSave.Text = "Añadir";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nombre del Resultado";
            // 
            // txtResultName
            // 
            this.txtResultName.Location = new System.Drawing.Point(424, 37);
            this.txtResultName.Name = "txtResultName";
            this.txtResultName.Size = new System.Drawing.Size(235, 23);
            this.txtResultName.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Categoría";
            // 
            // cmbOidCategory
            // 
            this.cmbOidCategory.FormattingEnabled = true;
            this.cmbOidCategory.Location = new System.Drawing.Point(424, 100);
            this.cmbOidCategory.Name = "cmbOidCategory";
            this.cmbOidCategory.Size = new System.Drawing.Size(235, 25);
            this.cmbOidCategory.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(424, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 224);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vista preliminar";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre del Oid";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "label3";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tipo de Oid";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "label3";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "label3";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(20, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(209, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "label3";
            // 
            // frmNewOidType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 422);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbOidCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResultName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmNewOidType";
            this.Padding = new System.Windows.Forms.Padding(13);
            this.Text = "frmNewOidType";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOidTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.LightDatagrid dgOidTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidType;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidName;
        private System.Windows.Forms.ToolStripMenuItem actualizarDireccionesIpToolStripMenuItem;
        private System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResultName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOidCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}