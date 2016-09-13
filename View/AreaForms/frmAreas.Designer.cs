
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
    partial class frmAreas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAreas));
            this.contextMenuAreas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clausurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reactivarAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgAreas = new InkAlert.Controls.LightDatagrid();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaQueueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printersPerArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuAreas
            // 
            this.contextMenuAreas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.clausurarToolStripMenuItem,
            this.reactivarAreaToolStripMenuItem});
            this.contextMenuAreas.Name = "contextMenuAreas";
            this.contextMenuAreas.Size = new System.Drawing.Size(148, 114);
            this.contextMenuAreas.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuAreas_Opening);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // clausurarToolStripMenuItem
            // 
            this.clausurarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.key_delete;
            this.clausurarToolStripMenuItem.Name = "clausurarToolStripMenuItem";
            this.clausurarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.clausurarToolStripMenuItem.Text = "Clausurar";
            this.clausurarToolStripMenuItem.Click += new System.EventHandler(this.clausurarToolStripMenuItem_Click);
            // 
            // reactivarAreaToolStripMenuItem
            // 
            this.reactivarAreaToolStripMenuItem.Image = global::InkAlert.Properties.Resources.key_add;
            this.reactivarAreaToolStripMenuItem.Name = "reactivarAreaToolStripMenuItem";
            this.reactivarAreaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.reactivarAreaToolStripMenuItem.Text = "Reactivar área";
            this.reactivarAreaToolStripMenuItem.Click += new System.EventHandler(this.reactivarAreaToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dgAreas
            // 
            this.dgAreas.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgAreas.AllowUserToAddRows = false;
            this.dgAreas.AllowUserToDeleteRows = false;
            this.dgAreas.AllowUserToOrderColumns = true;
            this.dgAreas.AssignedContextMenuStrip = null;
            this.dgAreas.AutoGenerateColumns = false;
            this.dgAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAreas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgAreas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAreas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAreas.ColumnHeadersHeight = 30;
            this.dgAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgAreas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.locationName,
            this.areaName,
            this.areaHostName,
            this.areaIpAddress,
            this.areaQueueName,
            this.printersPerArea,
            this.storyNumber,
            this.areaStatus,
            this.locationId,
            this.areaStatusId});
            this.dgAreas.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgAreas.CurrentFilterString = null;
            this.dgAreas.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAreas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgAreas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAreas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgAreas.FilterColumnList = ((System.Collections.ArrayList)(resources.GetObject("dgAreas.FilterColumnList")));
            this.dgAreas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgAreas.GridColor = System.Drawing.SystemColors.Control;
            this.dgAreas.Location = new System.Drawing.Point(10, 10);
            this.dgAreas.Name = "dgAreas";
            this.dgAreas.RowHeadersVisible = false;
            this.dgAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAreas.Size = new System.Drawing.Size(873, 425);
            this.dgAreas.SortColumn = -1;
            this.dgAreas.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgAreas.TabIndex = 0;
            this.dgAreas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAreas_CellClick);
            this.dgAreas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAreas_CellDoubleClick);
            this.dgAreas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAreas_CellEnter);
            this.dgAreas.SelectionChanged += new System.EventHandler(this.dgAreas_SelectionChanged);
            this.dgAreas.Enter += new System.EventHandler(this.dgAreas_Enter);
            this.dgAreas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgAreas_KeyUp);
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.Transparent;
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(739, 289);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(141, 128);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // locationName
            // 
            this.locationName.DataPropertyName = "locationName";
            this.locationName.HeaderText = "Nombre de la Ubicación";
            this.locationName.Name = "locationName";
            this.locationName.Width = 133;
            // 
            // areaName
            // 
            this.areaName.DataPropertyName = "areaName";
            this.areaName.HeaderText = "Nombre del Área";
            this.areaName.Name = "areaName";
            this.areaName.Width = 82;
            // 
            // areaHostName
            // 
            this.areaHostName.DataPropertyName = "areaHostName";
            this.areaHostName.HeaderText = "Nombre del Dispositivo";
            this.areaHostName.Name = "areaHostName";
            this.areaHostName.Width = 128;
            // 
            // areaIpAddress
            // 
            this.areaIpAddress.DataPropertyName = "areaIpAddress";
            this.areaIpAddress.HeaderText = "Dirección IPv4";
            this.areaIpAddress.Name = "areaIpAddress";
            this.areaIpAddress.Width = 94;
            // 
            // areaQueueName
            // 
            this.areaQueueName.DataPropertyName = "areaQueueName";
            this.areaQueueName.HeaderText = "Cola de Impresión";
            this.areaQueueName.Name = "areaQueueName";
            this.areaQueueName.Width = 106;
            // 
            // printersPerArea
            // 
            this.printersPerArea.DataPropertyName = "printersPerArea";
            this.printersPerArea.HeaderText = "Impresoras asignadas";
            this.printersPerArea.Name = "printersPerArea";
            this.printersPerArea.Width = 123;
            // 
            // storyNumber
            // 
            this.storyNumber.DataPropertyName = "storyNumber";
            this.storyNumber.HeaderText = "Piso";
            this.storyNumber.Name = "storyNumber";
            this.storyNumber.Width = 52;
            // 
            // areaStatus
            // 
            this.areaStatus.DataPropertyName = "areaStatus";
            this.areaStatus.HeaderText = "Estado";
            this.areaStatus.Name = "areaStatus";
            this.areaStatus.Width = 65;
            // 
            // locationId
            // 
            this.locationId.DataPropertyName = "locationId";
            this.locationId.HeaderText = "locationId";
            this.locationId.Name = "locationId";
            this.locationId.Visible = false;
            this.locationId.Width = 78;
            // 
            // areaStatusId
            // 
            this.areaStatusId.DataPropertyName = "areaStatusId";
            this.areaStatusId.HeaderText = "areaStatusId";
            this.areaStatusId.Name = "areaStatusId";
            this.areaStatusId.Visible = false;
            this.areaStatusId.Width = 92;
            // 
            // frmAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgAreas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAreas";
            this.Text = "Áreas";
            this.Load += new System.EventHandler(this.Areas_Load);
            this.contextMenuAreas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAreas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuAreas;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LightDatagrid dgAreas;
        public Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ToolStripMenuItem reactivarAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clausurarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaHostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaQueueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printersPerArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn storyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaStatusId;
    }
}