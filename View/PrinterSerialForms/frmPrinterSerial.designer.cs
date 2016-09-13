
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

using System.Windows.Forms;

namespace InkAlert.Forms
{
    partial class frmPrinterSerial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterSerial));
            this.contextMenuPrinterSerials = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgPrinterSerials = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCommercialStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ramMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hddCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerDuplex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyDuty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerConnectionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCommercialStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuPrinterSerials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinterSerials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuPrinterSerials
            // 
            this.contextMenuPrinterSerials.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.cambiarEstadoToolStripMenuItem});
            this.contextMenuPrinterSerials.Name = "contextMenuPrinterSerials";
            this.contextMenuPrinterSerials.Size = new System.Drawing.Size(167, 92);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.bullet_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cambiarEstadoToolStripMenuItem
            // 
            this.cambiarEstadoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
            this.cambiarEstadoToolStripMenuItem.Name = "cambiarEstadoToolStripMenuItem";
            this.cambiarEstadoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cambiarEstadoToolStripMenuItem.Text = "Cambiar estado...";
            this.cambiarEstadoToolStripMenuItem.Click += new System.EventHandler(this.cambiarEstadoToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dgPrinterSerials
            // 
            this.dgPrinterSerials.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgPrinterSerials.AllowUserToAddRows = false;
            this.dgPrinterSerials.AllowUserToDeleteRows = false;
            this.dgPrinterSerials.AllowUserToOrderColumns = true;
            this.dgPrinterSerials.AssignedContextMenuStrip = null;
            this.dgPrinterSerials.AutoGenerateColumns = false;
            this.dgPrinterSerials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPrinterSerials.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgPrinterSerials.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrinterSerials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPrinterSerials.ColumnHeadersHeight = 30;
            this.dgPrinterSerials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPrinterSerials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.printerModelName,
            this.printerSerial,
            this.areaName,
            this.printerCommercialStatus,
            this.printerMakeName,
            this.printerTypeName,
            this.printerColor,
            this.printerCapacity,
            this.ramMemory,
            this.hddCapacity,
            this.printerDuplex,
            this.monthlyDuty,
            this.printerMakeId,
            this.printerModelId,
            this.printerAreaId,
            this.printerConnectionTypeId,
            this.printerCommercialStatusId});
            this.dgPrinterSerials.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgPrinterSerials.CurrentFilterString = null;
            this.dgPrinterSerials.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPrinterSerials.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPrinterSerials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPrinterSerials.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgPrinterSerials.FilterColumnList = ((System.Collections.ArrayList)(resources.GetObject("dgPrinterSerials.FilterColumnList")));
            this.dgPrinterSerials.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgPrinterSerials.GridColor = System.Drawing.SystemColors.Control;
            this.dgPrinterSerials.Location = new System.Drawing.Point(10, 10);
            this.dgPrinterSerials.MultiSelect = false;
            this.dgPrinterSerials.Name = "dgPrinterSerials";
            this.dgPrinterSerials.RowHeadersVisible = false;
            this.dgPrinterSerials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPrinterSerials.Size = new System.Drawing.Size(815, 425);
            this.dgPrinterSerials.SortColumn = -1;
            this.dgPrinterSerials.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgPrinterSerials.TabIndex = 0;
            this.dgPrinterSerials.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterSerials_CellClick);
            this.dgPrinterSerials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterSerials_CellDoubleClick);
            this.dgPrinterSerials.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterSerials_CellEnter);
            this.dgPrinterSerials.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgPrinterSerials_DataBindingComplete);
            this.dgPrinterSerials.SelectionChanged += new System.EventHandler(this.dgPrinterSerials_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // printerModelName
            // 
            this.printerModelName.DataPropertyName = "printerModelName";
            this.printerModelName.HeaderText = "Modelo";
            this.printerModelName.Name = "printerModelName";
            this.printerModelName.Width = 67;
            // 
            // printerSerial
            // 
            this.printerSerial.DataPropertyName = "printerSerial";
            this.printerSerial.HeaderText = "Serial";
            this.printerSerial.Name = "printerSerial";
            this.printerSerial.Width = 58;
            // 
            // areaName
            // 
            this.areaName.DataPropertyName = "areaName";
            this.areaName.HeaderText = "Área";
            this.areaName.Name = "areaName";
            this.areaName.Width = 54;
            // 
            // printerCommercialStatus
            // 
            this.printerCommercialStatus.DataPropertyName = "printerCommercialStatus";
            this.printerCommercialStatus.HeaderText = "Estado comercial";
            this.printerCommercialStatus.Name = "printerCommercialStatus";
            this.printerCommercialStatus.Width = 104;
            // 
            // printerMakeName
            // 
            this.printerMakeName.DataPropertyName = "printerMakeName";
            this.printerMakeName.HeaderText = "Fabricante";
            this.printerMakeName.Name = "printerMakeName";
            this.printerMakeName.Width = 82;
            // 
            // printerTypeName
            // 
            this.printerTypeName.DataPropertyName = "printerTypeName";
            this.printerTypeName.HeaderText = "Sistema de impresión";
            this.printerTypeName.Name = "printerTypeName";
            this.printerTypeName.Width = 120;
            // 
            // printerColor
            // 
            this.printerColor.DataPropertyName = "printerColor";
            this.printerColor.HeaderText = "Mono-Color";
            this.printerColor.Name = "printerColor";
            this.printerColor.Width = 86;
            // 
            // printerCapacity
            // 
            this.printerCapacity.DataPropertyName = "printerCapacity";
            this.printerCapacity.HeaderText = "Volumen de impresión";
            this.printerCapacity.Name = "printerCapacity";
            this.printerCapacity.Width = 123;
            // 
            // ramMemory
            // 
            this.ramMemory.DataPropertyName = "ramMemory";
            this.ramMemory.HeaderText = "Memoria Ram (MB)";
            this.ramMemory.Name = "ramMemory";
            this.ramMemory.Width = 92;
            // 
            // hddCapacity
            // 
            this.hddCapacity.DataPropertyName = "hddCapacity";
            this.hddCapacity.HeaderText = "Disco Duro (GB)";
            this.hddCapacity.Name = "hddCapacity";
            this.hddCapacity.Width = 81;
            // 
            // printerDuplex
            // 
            this.printerDuplex.DataPropertyName = "printerDuplex";
            this.printerDuplex.HeaderText = "Unidad dúplex";
            this.printerDuplex.Name = "printerDuplex";
            this.printerDuplex.Width = 92;
            // 
            // monthlyDuty
            // 
            this.monthlyDuty.DataPropertyName = "monthlyDuty";
            this.monthlyDuty.HeaderText = "Capacidad mensual";
            this.monthlyDuty.Name = "monthlyDuty";
            this.monthlyDuty.Width = 114;
            // 
            // printerMakeId
            // 
            this.printerMakeId.DataPropertyName = "printerMakeId";
            this.printerMakeId.HeaderText = "printerMakeId";
            this.printerMakeId.Name = "printerMakeId";
            this.printerMakeId.Visible = false;
            this.printerMakeId.Width = 97;
            // 
            // printerModelId
            // 
            this.printerModelId.DataPropertyName = "printerModelId";
            this.printerModelId.HeaderText = "printerModelId";
            this.printerModelId.Name = "printerModelId";
            this.printerModelId.Visible = false;
            this.printerModelId.Width = 99;
            // 
            // printerAreaId
            // 
            this.printerAreaId.DataPropertyName = "printerAreaId";
            this.printerAreaId.HeaderText = "printerAreaId";
            this.printerAreaId.Name = "printerAreaId";
            this.printerAreaId.Width = 92;
            // 
            // printerConnectionTypeId
            // 
            this.printerConnectionTypeId.DataPropertyName = "printerConnectionTypeId";
            this.printerConnectionTypeId.HeaderText = "printerConnectionTypeId";
            this.printerConnectionTypeId.Name = "printerConnectionTypeId";
            this.printerConnectionTypeId.Visible = false;
            this.printerConnectionTypeId.Width = 148;
            // 
            // printerCommercialStatusId
            // 
            this.printerCommercialStatusId.DataPropertyName = "printerCommercialStatusId";
            this.printerCommercialStatusId.HeaderText = "printerCommercialStatusId";
            this.printerCommercialStatusId.Name = "printerCommercialStatusId";
            this.printerCommercialStatusId.Visible = false;
            this.printerCommercialStatusId.Width = 154;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(45, 67);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(134, 137);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmPrinterSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgPrinterSerials);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPrinterSerial";
            this.Text = "Todas las impresoras";
            this.Load += new System.EventHandler(this.PrinterSerials_Load);
            this.contextMenuPrinterSerials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinterSerials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuPrinterSerials;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LightDatagrid dgPrinterSerials;
        private Controls.LoadingImage loadingImage;
        private ToolStripMenuItem cambiarEstadoToolStripMenuItem;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn printerModelName;
        private DataGridViewTextBoxColumn printerSerial;
        private DataGridViewTextBoxColumn areaName;
        private DataGridViewTextBoxColumn printerCommercialStatus;
        private DataGridViewTextBoxColumn printerMakeName;
        private DataGridViewTextBoxColumn printerTypeName;
        private DataGridViewTextBoxColumn printerColor;
        private DataGridViewTextBoxColumn printerCapacity;
        private DataGridViewTextBoxColumn ramMemory;
        private DataGridViewTextBoxColumn hddCapacity;
        private DataGridViewTextBoxColumn printerDuplex;
        private DataGridViewTextBoxColumn monthlyDuty;
        private DataGridViewTextBoxColumn printerMakeId;
        private DataGridViewTextBoxColumn printerModelId;
        private DataGridViewTextBoxColumn printerAreaId;
        private DataGridViewTextBoxColumn printerConnectionTypeId;
        private DataGridViewTextBoxColumn printerCommercialStatusId;
    }
}