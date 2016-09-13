
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
    partial class frmOids
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOids));
            this.contextMenuOids = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarOidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgOids = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidReturnDataTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidPerModelCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oidReturnDataTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerConnectionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerConnectionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuOids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuOids
            // 
            this.contextMenuOids.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.asignarOidToolStripMenuItem});
            this.contextMenuOids.Name = "contextMenuOids";
            this.contextMenuOids.Size = new System.Drawing.Size(135, 92);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // asignarOidToolStripMenuItem
            // 
            this.asignarOidToolStripMenuItem.Image = global::InkAlert.Properties.Resources.key_add1;
            this.asignarOidToolStripMenuItem.Name = "asignarOidToolStripMenuItem";
            this.asignarOidToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.asignarOidToolStripMenuItem.Text = "Asignar oid";
            this.asignarOidToolStripMenuItem.Click += new System.EventHandler(this.asignarOidToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dgOids
            // 
            this.dgOids.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgOids.AllowUserToAddRows = false;
            this.dgOids.AllowUserToDeleteRows = false;
            this.dgOids.AllowUserToOrderColumns = true;
            this.dgOids.AssignedContextMenuStrip = null;
            this.dgOids.AutoGenerateColumns = false;
            this.dgOids.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOids.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgOids.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOids.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgOids.ColumnHeadersHeight = 30;
            this.dgOids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgOids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.oidName,
            this.oidAddress,
            this.oidReturnDataTypeName,
            this.printerMakeName,
            this.oidPerModelCount,
            this.printerMakeId,
            this.oidTypeId,
            this.oidReturnDataTypeId,
            this.printerConnectionType,
            this.printerConnectionTypeId});
            this.dgOids.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgOids.CurrentFilterString = null;
            this.dgOids.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOids.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgOids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOids.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgOids.FilterColumnList = null;
            this.dgOids.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgOids.GridColor = System.Drawing.SystemColors.Control;
            this.dgOids.Location = new System.Drawing.Point(10, 10);
            this.dgOids.MultiSelect = false;
            this.dgOids.Name = "dgOids";
            this.dgOids.RowHeadersVisible = false;
            this.dgOids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOids.Size = new System.Drawing.Size(936, 401);
            this.dgOids.SortColumn = -1;
            this.dgOids.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgOids.TabIndex = 0;
            this.dgOids.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOids_CellClick);
            this.dgOids.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOids_CellDoubleClick);
            this.dgOids.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOids_CellEnter);
            this.dgOids.SelectionChanged += new System.EventHandler(this.dgOids_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 44;
            // 
            // oidName
            // 
            this.oidName.DataPropertyName = "oidName";
            this.oidName.HeaderText = "Nombre del Identificador";
            this.oidName.Name = "oidName";
            this.oidName.Width = 134;
            // 
            // oidAddress
            // 
            this.oidAddress.DataPropertyName = "oidAddress";
            this.oidAddress.HeaderText = "Dirección del identificador";
            this.oidAddress.Name = "oidAddress";
            this.oidAddress.Width = 141;
            // 
            // oidReturnDataTypeName
            // 
            this.oidReturnDataTypeName.DataPropertyName = "oidReturnDataTypeName";
            this.oidReturnDataTypeName.HeaderText = "Tipo de dato";
            this.oidReturnDataTypeName.Name = "oidReturnDataTypeName";
            this.oidReturnDataTypeName.Width = 85;
            // 
            // printerMakeName
            // 
            this.printerMakeName.DataPropertyName = "printerMakeName";
            this.printerMakeName.HeaderText = "Marca de impresora";
            this.printerMakeName.Name = "printerMakeName";
            this.printerMakeName.Width = 114;
            // 
            // oidPerModelCount
            // 
            this.oidPerModelCount.DataPropertyName = "oidPerModelCount";
            this.oidPerModelCount.HeaderText = "Cantidad de modelos asignados";
            this.oidPerModelCount.Name = "oidPerModelCount";
            this.oidPerModelCount.Width = 123;
            // 
            // printerMakeId
            // 
            this.printerMakeId.DataPropertyName = "printerMakeId";
            this.printerMakeId.HeaderText = "printerMakeId";
            this.printerMakeId.Name = "printerMakeId";
            this.printerMakeId.Visible = false;
            this.printerMakeId.Width = 115;
            // 
            // oidTypeId
            // 
            this.oidTypeId.DataPropertyName = "oidTypeId";
            this.oidTypeId.HeaderText = "oidTypeId";
            this.oidTypeId.Name = "oidTypeId";
            this.oidTypeId.Visible = false;
            this.oidTypeId.Width = 95;
            // 
            // oidReturnDataTypeId
            // 
            this.oidReturnDataTypeId.DataPropertyName = "oidReturnDataTypeId";
            this.oidReturnDataTypeId.HeaderText = "oidReturnDataTypeId";
            this.oidReturnDataTypeId.Name = "oidReturnDataTypeId";
            this.oidReturnDataTypeId.Visible = false;
            this.oidReturnDataTypeId.Width = 163;
            // 
            // printerConnectionType
            // 
            this.printerConnectionType.DataPropertyName = "printerConnectionType";
            this.printerConnectionType.HeaderText = "Tipo de conexión";
            this.printerConnectionType.Name = "printerConnectionType";
            this.printerConnectionType.Width = 105;
            // 
            // printerConnectionTypeId
            // 
            this.printerConnectionTypeId.DataPropertyName = "printerConnectionTypeId";
            this.printerConnectionTypeId.HeaderText = "printerConnectionTypeId";
            this.printerConnectionTypeId.Name = "printerConnectionTypeId";
            this.printerConnectionTypeId.Visible = false;
            this.printerConnectionTypeId.Width = 180;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(842, 326);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(101, 82);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmOids
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 421);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgOids);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOids";
            this.Text = "Identificadores de Objeto OIDS";
            this.Load += new System.EventHandler(this.Oids_Load);
            this.contextMenuOids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuOids;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LightDatagrid dgOids;
        private Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ToolStripMenuItem asignarOidToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidReturnDataTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerMakeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidPerModelCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerMakeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidReturnDataTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerConnectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerConnectionTypeId;

    }
}