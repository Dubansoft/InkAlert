
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
    partial class frmPrinterModels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterModels));
            this.contextMenuPrinterModels = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgPrinterModels = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ramMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hddCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerDuplex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyDuty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerColorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerSeriesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standardFunctions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printingCapacityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duplexUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlSettings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlConsumables = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuPrinterModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinterModels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuPrinterModels
            // 
            this.contextMenuPrinterModels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuPrinterModels.Name = "contextMenuPrinterModels";
            this.contextMenuPrinterModels.Size = new System.Drawing.Size(153, 92);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.bullet_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dgPrinterModels
            // 
            this.dgPrinterModels.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgPrinterModels.AllowUserToAddRows = false;
            this.dgPrinterModels.AllowUserToDeleteRows = false;
            this.dgPrinterModels.AllowUserToOrderColumns = true;
            this.dgPrinterModels.AssignedContextMenuStrip = null;
            this.dgPrinterModels.AutoGenerateColumns = false;
            this.dgPrinterModels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPrinterModels.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgPrinterModels.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrinterModels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPrinterModels.ColumnHeadersHeight = 30;
            this.dgPrinterModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPrinterModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.id2,
            this.printerModelName,
            this.printerMakeName,
            this.printerTypeName,
            this.printerColor,
            this.printerCapacity,
            this.ramMemory,
            this.hddCapacity,
            this.printerDuplex,
            this.monthlyDuty,
            this.printerColorId,
            this.printerMakeId,
            this.printerSeriesId,
            this.printerTypeId,
            this.standardFunctions,
            this.printingCapacityId,
            this.duplexUnitId,
            this.urlSettings,
            this.urlConsumables,
            this.urlUsage});
            this.dgPrinterModels.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgPrinterModels.CurrentFilterString = null;
            this.dgPrinterModels.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPrinterModels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPrinterModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPrinterModels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgPrinterModels.FilterColumnList = ((System.Collections.ArrayList)(resources.GetObject("dgPrinterModels.FilterColumnList")));
            this.dgPrinterModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgPrinterModels.GridColor = System.Drawing.SystemColors.Control;
            this.dgPrinterModels.Location = new System.Drawing.Point(10, 10);
            this.dgPrinterModels.MultiSelect = false;
            this.dgPrinterModels.Name = "dgPrinterModels";
            this.dgPrinterModels.RowHeadersVisible = false;
            this.dgPrinterModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPrinterModels.Size = new System.Drawing.Size(815, 425);
            this.dgPrinterModels.SortColumn = -1;
            this.dgPrinterModels.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgPrinterModels.TabIndex = 0;
            this.dgPrinterModels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterModels_CellClick);
            this.dgPrinterModels.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterModels_CellDoubleClick);
            this.dgPrinterModels.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinterModels_CellEnter);
            this.dgPrinterModels.SelectionChanged += new System.EventHandler(this.dgPrinterModels_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // id2
            // 
            this.id2.DataPropertyName = "id";
            this.id2.HeaderText = "id2";
            this.id2.Name = "id2";
            this.id2.Width = 46;
            // 
            // printerModelName
            // 
            this.printerModelName.DataPropertyName = "printerModelName";
            this.printerModelName.HeaderText = "Modelo";
            this.printerModelName.Name = "printerModelName";
            this.printerModelName.Width = 67;
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
            // printerColorId
            // 
            this.printerColorId.DataPropertyName = "printerColorId";
            this.printerColorId.HeaderText = "printerColorId";
            this.printerColorId.Name = "printerColorId";
            this.printerColorId.Visible = false;
            this.printerColorId.Width = 94;
            // 
            // printerMakeId
            // 
            this.printerMakeId.DataPropertyName = "printerMakeId";
            this.printerMakeId.HeaderText = "printerMakeId";
            this.printerMakeId.Name = "printerMakeId";
            this.printerMakeId.Visible = false;
            this.printerMakeId.Width = 97;
            // 
            // printerSeriesId
            // 
            this.printerSeriesId.DataPropertyName = "printerSeriesId";
            this.printerSeriesId.HeaderText = "printerSeriesId";
            this.printerSeriesId.Name = "printerSeriesId";
            this.printerSeriesId.Visible = false;
            this.printerSeriesId.Width = 99;
            // 
            // printerTypeId
            // 
            this.printerTypeId.DataPropertyName = "printerTypeId";
            this.printerTypeId.HeaderText = "printerTypeId";
            this.printerTypeId.Name = "printerTypeId";
            this.printerTypeId.Visible = false;
            this.printerTypeId.Width = 94;
            // 
            // standardFunctions
            // 
            this.standardFunctions.DataPropertyName = "standardFunctions";
            this.standardFunctions.HeaderText = "standardFunctions";
            this.standardFunctions.Name = "standardFunctions";
            this.standardFunctions.Width = 119;
            // 
            // printingCapacityId
            // 
            this.printingCapacityId.DataPropertyName = "printingCapacityId";
            this.printingCapacityId.HeaderText = "printingCapacityId";
            this.printingCapacityId.Name = "printingCapacityId";
            this.printingCapacityId.Width = 116;
            // 
            // duplexUnitId
            // 
            this.duplexUnitId.DataPropertyName = "duplexUnitId";
            this.duplexUnitId.HeaderText = "duplexUnitId";
            this.duplexUnitId.Name = "duplexUnitId";
            this.duplexUnitId.Width = 91;
            // 
            // urlSettings
            // 
            this.urlSettings.DataPropertyName = "urlSettings";
            this.urlSettings.HeaderText = "urlSettings";
            this.urlSettings.Name = "urlSettings";
            this.urlSettings.Visible = false;
            this.urlSettings.Width = 81;
            // 
            // urlConsumables
            // 
            this.urlConsumables.DataPropertyName = "urlConsumables";
            this.urlConsumables.HeaderText = "urlConsumables";
            this.urlConsumables.Name = "urlConsumables";
            this.urlConsumables.Visible = false;
            this.urlConsumables.Width = 106;
            // 
            // urlUsage
            // 
            this.urlUsage.DataPropertyName = "urlUsage";
            this.urlUsage.HeaderText = "urlUsage";
            this.urlUsage.Name = "urlUsage";
            this.urlUsage.Visible = false;
            this.urlUsage.Width = 74;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(173, 153);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(100, 50);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmPrinterModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgPrinterModels);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPrinterModels";
            this.Text = "Modelos de impresoras";
            this.Load += new System.EventHandler(this.PrinterModels_Load);
            this.contextMenuPrinterModels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinterModels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuPrinterModels;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LightDatagrid dgPrinterModels;
        private Controls.LoadingImage loadingImage;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn id2;
        private DataGridViewTextBoxColumn printerModelName;
        private DataGridViewTextBoxColumn printerMakeName;
        private DataGridViewTextBoxColumn printerTypeName;
        private DataGridViewTextBoxColumn printerColor;
        private DataGridViewTextBoxColumn printerCapacity;
        private DataGridViewTextBoxColumn ramMemory;
        private DataGridViewTextBoxColumn hddCapacity;
        private DataGridViewTextBoxColumn printerDuplex;
        private DataGridViewTextBoxColumn monthlyDuty;
        private DataGridViewTextBoxColumn printerColorId;
        private DataGridViewTextBoxColumn printerMakeId;
        private DataGridViewTextBoxColumn printerSeriesId;
        private DataGridViewTextBoxColumn printerTypeId;
        private DataGridViewTextBoxColumn standardFunctions;
        private DataGridViewTextBoxColumn printingCapacityId;
        private DataGridViewTextBoxColumn duplexUnitId;
        private DataGridViewTextBoxColumn urlSettings;
        private DataGridViewTextBoxColumn urlConsumables;
        private DataGridViewTextBoxColumn urlUsage;
    }
}