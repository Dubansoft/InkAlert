
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
    partial class frmLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocations));
            this.contextMenuLocations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewLocations = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locationName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locationDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuLocations
            // 
            this.contextMenuLocations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirNuevoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuLocations.Name = "contextMenuLocations";
            this.contextMenuLocations.Size = new System.Drawing.Size(118, 70);
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
            this.editarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.page_edit;
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
            // listViewLocations
            // 
            this.listViewLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.locationName,
            this.locationDescription});
            this.listViewLocations.ContextMenuStrip = this.contextMenuLocations;
            this.listViewLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLocations.FullRowSelect = true;
            this.listViewLocations.Location = new System.Drawing.Point(10, 10);
            this.listViewLocations.MultiSelect = false;
            this.listViewLocations.Name = "listViewLocations";
            this.listViewLocations.ShowItemToolTips = true;
            this.listViewLocations.Size = new System.Drawing.Size(873, 425);
            this.listViewLocations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewLocations.TabIndex = 20;
            this.listViewLocations.UseCompatibleStateImageBehavior = false;
            this.listViewLocations.View = System.Windows.Forms.View.Details;
            this.listViewLocations.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewLocations_ItemSelectionChanged);
            this.listViewLocations.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewLocations_KeyUp);
            this.listViewLocations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewLocations_MouseDoubleClick);
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 0;
            // 
            // locationName
            // 
            this.locationName.Text = "Nombre de la ubicación";
            this.locationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.locationName.Width = 398;
            // 
            // locationDescription
            // 
            this.locationDescription.Text = "Descripción";
            this.locationDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.locationDescription.Width = 471;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(734, 304);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(146, 131);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // frmLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 445);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.listViewLocations);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmLocations";
            this.Text = "Ubicaciones";
            this.Load += new System.EventHandler(this.Locations_Load);
            this.contextMenuLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewLocations;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader locationName;
        private System.Windows.Forms.ColumnHeader locationDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuLocations;
        private System.Windows.Forms.ToolStripMenuItem añadirNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        public Controls.LoadingImage loadingImage;

    }
}