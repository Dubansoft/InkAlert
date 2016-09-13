
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
    partial class frmPrinterTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterTypes));
            this.contextMenuPrinterTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewPrinterTypes = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printerTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printerTypeDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuPrinterTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuPrinterTypes
            // 
            this.contextMenuPrinterTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuPrinterTypes.Name = "contextMenuPrinterTypes";
            this.contextMenuPrinterTypes.Size = new System.Drawing.Size(118, 70);
            // 
            // añadirNuevoToolStripMenuItem
            // 
            this.añadirNuevoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.add;
            this.añadirNuevoToolStripMenuItem.Name = "añadirNuevoToolStripMenuItem";
            this.añadirNuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.añadirNuevoToolStripMenuItem.Text = "Añadir";
            this.añadirNuevoToolStripMenuItem.Click += new System.EventHandler(this.añadirNuevoToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.bullet_edit;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // listViewPrinterTypes
            // 
            this.listViewPrinterTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.printerTypeName,
            this.printerTypeDescription});
            this.listViewPrinterTypes.ContextMenuStrip = this.contextMenuPrinterTypes;
            this.listViewPrinterTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPrinterTypes.FullRowSelect = true;
            this.listViewPrinterTypes.Location = new System.Drawing.Point(10, 10);
            this.listViewPrinterTypes.MultiSelect = false;
            this.listViewPrinterTypes.Name = "listViewPrinterTypes";
            this.listViewPrinterTypes.ShowItemToolTips = true;
            this.listViewPrinterTypes.Size = new System.Drawing.Size(873, 425);
            this.listViewPrinterTypes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewPrinterTypes.TabIndex = 20;
            this.listViewPrinterTypes.UseCompatibleStateImageBehavior = false;
            this.listViewPrinterTypes.View = System.Windows.Forms.View.Details;
            this.listViewPrinterTypes.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewPrinterTypes_ItemSelectionChanged);
            this.listViewPrinterTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPrinterTypes_MouseDoubleClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 0;
            // 
            // printerTypeName
            // 
            this.printerTypeName.Text = "Tipo de Impresora";
            this.printerTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.printerTypeName.Width = 300;
            // 
            // printerTypeDescription
            // 
            this.printerTypeDescription.Text = "Características";
            this.printerTypeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.printerTypeDescription.Width = 565;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(116, 185);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(100, 50);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmPrinterTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.listViewPrinterTypes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPrinterTypes";
            this.Text = "Tipos de impresora";
            this.Load += new System.EventHandler(this.PrinterTypes_Load);
            this.contextMenuPrinterTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPrinterTypes;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader printerTypeName;
        private System.Windows.Forms.ColumnHeader printerTypeDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuPrinterTypes;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private Controls.LoadingImage loadingImage;
        
    }
}