
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
    partial class frmICounterCycles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmICounterCycles));
            this.contextMenuICounterCycles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verContadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgICounterCycles = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCycleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCycleYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCycleMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCycleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCycleMonthNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCounterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuICounterCycles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgICounterCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuICounterCycles
            // 
            this.contextMenuICounterCycles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.iniciarCicloToolStripMenuItem,
            this.finalizarCicloToolStripMenuItem,
            this.verContadoresToolStripMenuItem});
            this.contextMenuICounterCycles.Name = "contextMenuICounterCycles";
            this.contextMenuICounterCycles.Size = new System.Drawing.Size(154, 136);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // iniciarCicloToolStripMenuItem
            // 
            this.iniciarCicloToolStripMenuItem.Image = global::InkAlert.Properties.Resources.stopwatch_start;
            this.iniciarCicloToolStripMenuItem.Name = "iniciarCicloToolStripMenuItem";
            this.iniciarCicloToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.iniciarCicloToolStripMenuItem.Text = "Iniciar ciclo";
            this.iniciarCicloToolStripMenuItem.Click += new System.EventHandler(this.iniciarCicloToolStripMenuItem_Click);
            // 
            // finalizarCicloToolStripMenuItem
            // 
            this.finalizarCicloToolStripMenuItem.Image = global::InkAlert.Properties.Resources.stopwatch_finish;
            this.finalizarCicloToolStripMenuItem.Name = "finalizarCicloToolStripMenuItem";
            this.finalizarCicloToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.finalizarCicloToolStripMenuItem.Text = "Finalizar ciclo";
            this.finalizarCicloToolStripMenuItem.Click += new System.EventHandler(this.finalizarCicloToolStripMenuItem_Click);
            // 
            // verContadoresToolStripMenuItem
            // 
            this.verContadoresToolStripMenuItem.Image = global::InkAlert.Properties.Resources.winrar_view;
            this.verContadoresToolStripMenuItem.Name = "verContadoresToolStripMenuItem";
            this.verContadoresToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.verContadoresToolStripMenuItem.Text = "Ver contadores";
            this.verContadoresToolStripMenuItem.Click += new System.EventHandler(this.verContadoresToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dgICounterCycles
            // 
            this.dgICounterCycles.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgICounterCycles.AllowUserToAddRows = false;
            this.dgICounterCycles.AllowUserToDeleteRows = false;
            this.dgICounterCycles.AllowUserToOrderColumns = true;
            this.dgICounterCycles.AssignedContextMenuStrip = null;
            this.dgICounterCycles.AutoGenerateColumns = false;
            this.dgICounterCycles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgICounterCycles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgICounterCycles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgICounterCycles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgICounterCycles.ColumnHeadersHeight = 30;
            this.dgICounterCycles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgICounterCycles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.iCounterCycleName,
            this.iCounterCycleYear,
            this.iCounterCycleMonth,
            this.iCounterCycleStatus,
            this.iCounterCycleMonthNumber,
            this.iCounterCount});
            this.dgICounterCycles.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgICounterCycles.CurrentFilterString = null;
            this.dgICounterCycles.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgICounterCycles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgICounterCycles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgICounterCycles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgICounterCycles.FilterColumnList = null;
            this.dgICounterCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgICounterCycles.GridColor = System.Drawing.SystemColors.Control;
            this.dgICounterCycles.Location = new System.Drawing.Point(10, 10);
            this.dgICounterCycles.Name = "dgICounterCycles";
            this.dgICounterCycles.RowHeadersVisible = false;
            this.dgICounterCycles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgICounterCycles.Size = new System.Drawing.Size(873, 425);
            this.dgICounterCycles.SortColumn = -1;
            this.dgICounterCycles.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgICounterCycles.TabIndex = 0;
            this.dgICounterCycles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgICounterCycles_CellClick);
            this.dgICounterCycles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgICounterCycles_CellDoubleClick);
            this.dgICounterCycles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgICounterCycles_CellEnter);
            this.dgICounterCycles.SelectionChanged += new System.EventHandler(this.dgICounterCycles_SelectionChanged);
            this.dgICounterCycles.Enter += new System.EventHandler(this.dgICounterCycles_Enter);
            this.dgICounterCycles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgICounterCycles_KeyUp);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // iCounterCycleName
            // 
            this.iCounterCycleName.DataPropertyName = "iCounterCycleName";
            this.iCounterCycleName.HeaderText = "Nombre del ciclo";
            this.iCounterCycleName.Name = "iCounterCycleName";
            this.iCounterCycleName.Width = 82;
            // 
            // iCounterCycleYear
            // 
            this.iCounterCycleYear.DataPropertyName = "iCounterCycleYear";
            this.iCounterCycleYear.HeaderText = "Año";
            this.iCounterCycleYear.Name = "iCounterCycleYear";
            this.iCounterCycleYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iCounterCycleYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.iCounterCycleYear.Width = 51;
            // 
            // iCounterCycleMonth
            // 
            this.iCounterCycleMonth.DataPropertyName = "iCounterCycleMonth";
            this.iCounterCycleMonth.HeaderText = "Mes";
            this.iCounterCycleMonth.Name = "iCounterCycleMonth";
            this.iCounterCycleMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iCounterCycleMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.iCounterCycleMonth.Width = 52;
            // 
            // iCounterCycleStatus
            // 
            this.iCounterCycleStatus.DataPropertyName = "iCounterCycleStatus";
            this.iCounterCycleStatus.HeaderText = "Estado";
            this.iCounterCycleStatus.Name = "iCounterCycleStatus";
            this.iCounterCycleStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iCounterCycleStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.iCounterCycleStatus.Width = 65;
            // 
            // iCounterCycleMonthNumber
            // 
            this.iCounterCycleMonthNumber.DataPropertyName = "iCounterCycleMonthNumber";
            this.iCounterCycleMonthNumber.HeaderText = "counterCycleMonthNumber";
            this.iCounterCycleMonthNumber.Name = "iCounterCycleMonthNumber";
            this.iCounterCycleMonthNumber.Visible = false;
            this.iCounterCycleMonthNumber.Width = 161;
            // 
            // iCounterCount
            // 
            this.iCounterCount.DataPropertyName = "iCounterCount";
            this.iCounterCount.HeaderText = "Contadores generados";
            this.iCounterCount.Name = "iCounterCount";
            this.iCounterCount.Width = 127;
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
            // frmICounterCycles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgICounterCycles);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmICounterCycles";
            this.Text = "Ciclos de contador";
            this.Load += new System.EventHandler(this.ICounterCycles_Load);
            this.contextMenuICounterCycles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgICounterCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuICounterCycles;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LightDatagrid dgICounterCycles;
        public Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ToolStripMenuItem iniciarCicloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalizarCicloToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCycleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCycleYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCycleMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCycleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCycleMonthNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCounterCount;
        internal System.Windows.Forms.ToolStripMenuItem verContadoresToolStripMenuItem;
    }
}