
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
    partial class frmConsumables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumables));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuConsumables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarConsumableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.dgConsumables = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableMakeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumableTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuConsumables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumables)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuConsumables
            // 
            this.contextMenuConsumables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.asignarConsumableToolStripMenuItem});
            this.contextMenuConsumables.Name = "contextMenuConsumables";
            this.contextMenuConsumables.Size = new System.Drawing.Size(174, 92);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // asignarConsumableToolStripMenuItem
            // 
            this.asignarConsumableToolStripMenuItem.Image = global::InkAlert.Properties.Resources.key_add1;
            this.asignarConsumableToolStripMenuItem.Name = "asignarConsumableToolStripMenuItem";
            this.asignarConsumableToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.asignarConsumableToolStripMenuItem.Text = "Asignar suministro";
            this.asignarConsumableToolStripMenuItem.Click += new System.EventHandler(this.asignarConsumableToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
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
            // dgConsumables
            // 
            this.dgConsumables.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgConsumables.AllowUserToAddRows = false;
            this.dgConsumables.AllowUserToDeleteRows = false;
            this.dgConsumables.AllowUserToOrderColumns = true;
            this.dgConsumables.AssignedContextMenuStrip = null;
            this.dgConsumables.AutoGenerateColumns = false;
            this.dgConsumables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgConsumables.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgConsumables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsumables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConsumables.ColumnHeadersHeight = 30;
            this.dgConsumables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgConsumables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.printerMakeName,
            this.printerModelName,
            this.consumableTypeName,
            this.consumableModelName,
            this.maxLife,
            this.consumableMakeId,
            this.consumableTypeId});
            this.dgConsumables.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgConsumables.CurrentFilterString = null;
            this.dgConsumables.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsumables.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgConsumables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgConsumables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgConsumables.FilterColumnList = null;
            this.dgConsumables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgConsumables.GridColor = System.Drawing.SystemColors.Control;
            this.dgConsumables.Location = new System.Drawing.Point(10, 10);
            this.dgConsumables.Name = "dgConsumables";
            this.dgConsumables.RowHeadersVisible = false;
            this.dgConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConsumables.Size = new System.Drawing.Size(936, 401);
            this.dgConsumables.SortColumn = -1;
            this.dgConsumables.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgConsumables.TabIndex = 0;
            this.dgConsumables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsumables_CellClick);
            this.dgConsumables.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsumables_CellContentClick);
            this.dgConsumables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsumables_CellDoubleClick);
            this.dgConsumables.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsumables_CellEnter);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 40;
            // 
            // printerMakeName
            // 
            this.printerMakeName.DataPropertyName = "printerMakeName";
            this.printerMakeName.HeaderText = "Marca de impresora";
            this.printerMakeName.Name = "printerMakeName";
            this.printerMakeName.Width = 114;
            // 
            // printerModelName
            // 
            this.printerModelName.DataPropertyName = "printerModelName";
            this.printerModelName.HeaderText = "Modelo de impresora";
            this.printerModelName.Name = "printerModelName";
            this.printerModelName.Width = 119;
            // 
            // consumableTypeName
            // 
            this.consumableTypeName.DataPropertyName = "consumableTypeName";
            this.consumableTypeName.HeaderText = "Tipo de suministro";
            this.consumableTypeName.Name = "consumableTypeName";
            this.consumableTypeName.Width = 107;
            // 
            // consumableModelName
            // 
            this.consumableModelName.DataPropertyName = "consumableModelName";
            this.consumableModelName.HeaderText = "Referencia";
            this.consumableModelName.Name = "consumableModelName";
            this.consumableModelName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.consumableModelName.Width = 84;
            // 
            // maxLife
            // 
            this.maxLife.DataPropertyName = "maxLife";
            this.maxLife.HeaderText = "Duración";
            this.maxLife.Name = "maxLife";
            this.maxLife.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maxLife.Width = 75;
            // 
            // consumableMakeId
            // 
            this.consumableMakeId.DataPropertyName = "consumableMakeId";
            this.consumableMakeId.HeaderText = "consumableMakeId";
            this.consumableMakeId.Name = "consumableMakeId";
            this.consumableMakeId.Visible = false;
            this.consumableMakeId.Width = 125;
            // 
            // consumableTypeId
            // 
            this.consumableTypeId.DataPropertyName = "consumableTypeId";
            this.consumableTypeId.HeaderText = "consumableTypeId";
            this.consumableTypeId.Name = "consumableTypeId";
            this.consumableTypeId.Visible = false;
            this.consumableTypeId.Width = 122;
            // 
            // frmConsumables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 421);
            this.Controls.Add(this.dgConsumables);
            this.Controls.Add(this.loadingImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmConsumables";
            this.Text = "Suministros";
            this.Load += new System.EventHandler(this.Consumables_Load);
            this.contextMenuConsumables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgConsumables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuConsumables;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ToolStripMenuItem asignarConsumableToolStripMenuItem;
        private Controls.LightDatagrid dgConsumables;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerMakeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableMakeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumableTypeId;

    }
}