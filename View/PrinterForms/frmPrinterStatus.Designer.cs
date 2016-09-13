
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

using System.Collections;

namespace InkAlert.Forms
{
    partial class frmPrinterStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinterStatus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuPrinters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizaciónManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contactarHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactarIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirIPComoSitioWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirIpComoCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirRaízCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.detenerServicioSNMPEnHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.verEvoluciónDeTónerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evoluciónDeContadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suministrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesDeImpresoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarImagenDeContadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.elegirColumnasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.diagnósticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablaDeOidsEnVivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.dgPrinters = new InkAlert.Controls.LightDatagrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerStatusImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.areaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valBlackLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonerKModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonerKMaxLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valMagentaLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valYellowLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valCianLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valFuserLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valImagingUnitKLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valTransferRollerLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valRollersPickupForwardTray1Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerConnectionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaQueueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valBlackCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultPrinter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyCounterStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCommercialStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerMakeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerConnectionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerCommercialStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyCounterStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valDataDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuPrinters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinters)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuPrinters
            // 
            this.contextMenuPrinters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarToolStripMenuItem,
            this.actualizarTodoToolStripMenuItem,
            this.actualizaciónManualToolStripMenuItem,
            this.toolStripSeparator7,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.contactarHostToolStripMenuItem,
            this.contactarIPToolStripMenuItem,
            this.abrirIPComoSitioWebToolStripMenuItem,
            this.abrirIpComoCarpetaToolStripMenuItem,
            this.abrirRaízCToolStripMenuItem,
            this.toolStripSeparator2,
            this.detenerServicioSNMPEnHostToolStripMenuItem,
            this.iniciarServicioToolStripMenuItem,
            this.toolStripSeparator3,
            this.verEvoluciónDeTónerToolStripMenuItem,
            this.evoluciónDeContadoresToolStripMenuItem,
            this.suministrosToolStripMenuItem,
            this.detallesDeImpresoraToolStripMenuItem,
            this.contadoresToolStripMenuItem,
            this.toolStripSeparator5,
            this.elegirColumnasToolStripMenuItem,
            this.toolStripSeparator4,
            this.diagnósticosToolStripMenuItem,
            this.toolStripSeparator6});
            this.contextMenuPrinters.Name = "contextMenuPrinters";
            this.contextMenuPrinters.Size = new System.Drawing.Size(192, 442);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.update;
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar seleccionado";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // actualizarTodoToolStripMenuItem
            // 
            this.actualizarTodoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.arrow_refresh;
            this.actualizarTodoToolStripMenuItem.Name = "actualizarTodoToolStripMenuItem";
            this.actualizarTodoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.actualizarTodoToolStripMenuItem.Text = "Actualizar todo";
            this.actualizarTodoToolStripMenuItem.Click += new System.EventHandler(this.actualizarTodoToolStripMenuItem_Click);
            // 
            // actualizaciónManualToolStripMenuItem
            // 
            this.actualizaciónManualToolStripMenuItem.Image = global::InkAlert.Properties.Resources.edit_path;
            this.actualizaciónManualToolStripMenuItem.Name = "actualizaciónManualToolStripMenuItem";
            this.actualizaciónManualToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.actualizaciónManualToolStripMenuItem.Text = "Actualización manual";
            this.actualizaciónManualToolStripMenuItem.Click += new System.EventHandler(this.actualizaciónManualToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(188, 6);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.eliminarToolStripMenuItem.Text = "Retirar de producción";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // contactarHostToolStripMenuItem
            // 
            this.contactarHostToolStripMenuItem.Image = global::InkAlert.Properties.Resources.hostname;
            this.contactarHostToolStripMenuItem.Name = "contactarHostToolStripMenuItem";
            this.contactarHostToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.contactarHostToolStripMenuItem.Text = "Contactar host";
            this.contactarHostToolStripMenuItem.Click += new System.EventHandler(this.contactarHostToolStripMenuItem_Click);
            // 
            // contactarIPToolStripMenuItem
            // 
            this.contactarIPToolStripMenuItem.Image = global::InkAlert.Properties.Resources.ssh_shell_access;
            this.contactarIPToolStripMenuItem.Name = "contactarIPToolStripMenuItem";
            this.contactarIPToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.contactarIPToolStripMenuItem.Text = "Contactar IP";
            this.contactarIPToolStripMenuItem.Click += new System.EventHandler(this.contactarIPToolStripMenuItem_Click);
            // 
            // abrirIPComoSitioWebToolStripMenuItem
            // 
            this.abrirIPComoSitioWebToolStripMenuItem.Image = global::InkAlert.Properties.Resources.globe_network;
            this.abrirIPComoSitioWebToolStripMenuItem.Name = "abrirIPComoSitioWebToolStripMenuItem";
            this.abrirIPComoSitioWebToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.abrirIPComoSitioWebToolStripMenuItem.Text = "Abrir IP como sitio web";
            this.abrirIPComoSitioWebToolStripMenuItem.Click += new System.EventHandler(this.abrirIPComoSitioWebToolStripMenuItem_Click);
            // 
            // abrirIpComoCarpetaToolStripMenuItem
            // 
            this.abrirIpComoCarpetaToolStripMenuItem.Image = global::InkAlert.Properties.Resources.network_folder;
            this.abrirIpComoCarpetaToolStripMenuItem.Name = "abrirIpComoCarpetaToolStripMenuItem";
            this.abrirIpComoCarpetaToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.abrirIpComoCarpetaToolStripMenuItem.Text = "Abrir IP como carpeta";
            this.abrirIpComoCarpetaToolStripMenuItem.Click += new System.EventHandler(this.abrirIpComoCarpetaToolStripMenuItem_Click);
            // 
            // abrirRaízCToolStripMenuItem
            // 
            this.abrirRaízCToolStripMenuItem.Image = global::InkAlert.Properties.Resources.network_folder;
            this.abrirRaízCToolStripMenuItem.Name = "abrirRaízCToolStripMenuItem";
            this.abrirRaízCToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.abrirRaízCToolStripMenuItem.Text = "Abrir raíz C:\\\\";
            this.abrirRaízCToolStripMenuItem.Click += new System.EventHandler(this.abrirRaízCToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // detenerServicioSNMPEnHostToolStripMenuItem
            // 
            this.detenerServicioSNMPEnHostToolStripMenuItem.Image = global::InkAlert.Properties.Resources.stopwatch_finish;
            this.detenerServicioSNMPEnHostToolStripMenuItem.Name = "detenerServicioSNMPEnHostToolStripMenuItem";
            this.detenerServicioSNMPEnHostToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.detenerServicioSNMPEnHostToolStripMenuItem.Text = "Detener servicio....";
            this.detenerServicioSNMPEnHostToolStripMenuItem.Click += new System.EventHandler(this.detenerServicioToolStripMenuItem_Click);
            // 
            // iniciarServicioToolStripMenuItem
            // 
            this.iniciarServicioToolStripMenuItem.Image = global::InkAlert.Properties.Resources.stopwatch_start;
            this.iniciarServicioToolStripMenuItem.Name = "iniciarServicioToolStripMenuItem";
            this.iniciarServicioToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.iniciarServicioToolStripMenuItem.Text = "Iniciar servicio...";
            this.iniciarServicioToolStripMenuItem.Click += new System.EventHandler(this.iniciarServicioToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // verEvoluciónDeTónerToolStripMenuItem
            // 
            this.verEvoluciónDeTónerToolStripMenuItem.Image = global::InkAlert.Properties.Resources.chart_line;
            this.verEvoluciónDeTónerToolStripMenuItem.Name = "verEvoluciónDeTónerToolStripMenuItem";
            this.verEvoluciónDeTónerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.verEvoluciónDeTónerToolStripMenuItem.Text = "Evolución de suministros";
            this.verEvoluciónDeTónerToolStripMenuItem.Click += new System.EventHandler(this.verEvoluciónDeTónerToolStripMenuItem_Click);
            // 
            // evoluciónDeContadoresToolStripMenuItem
            // 
            this.evoluciónDeContadoresToolStripMenuItem.Name = "evoluciónDeContadoresToolStripMenuItem";
            this.evoluciónDeContadoresToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.evoluciónDeContadoresToolStripMenuItem.Text = "Evolución de contadores";
            // 
            // suministrosToolStripMenuItem
            // 
            this.suministrosToolStripMenuItem.Image = global::InkAlert.Properties.Resources.oil;
            this.suministrosToolStripMenuItem.Name = "suministrosToolStripMenuItem";
            this.suministrosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.suministrosToolStripMenuItem.Text = "Suministros";
            this.suministrosToolStripMenuItem.Click += new System.EventHandler(this.suministrosToolStripMenuItem_Click);
            // 
            // detallesDeImpresoraToolStripMenuItem
            // 
            this.detallesDeImpresoraToolStripMenuItem.Image = global::InkAlert.Properties.Resources.printer_color;
            this.detallesDeImpresoraToolStripMenuItem.Name = "detallesDeImpresoraToolStripMenuItem";
            this.detallesDeImpresoraToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.detallesDeImpresoraToolStripMenuItem.Text = "Detalles de impresora";
            this.detallesDeImpresoraToolStripMenuItem.Click += new System.EventHandler(this.detallesDeImpresoraToolStripMenuItem_Click);
            // 
            // contadoresToolStripMenuItem
            // 
            this.contadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarToolStripMenuItem,
            this.capturarImagenDeContadoresToolStripMenuItem});
            this.contadoresToolStripMenuItem.Name = "contadoresToolStripMenuItem";
            this.contadoresToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.contadoresToolStripMenuItem.Text = "Contadores";
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.generarToolStripMenuItem.Text = "Generar contadores ";
            this.generarToolStripMenuItem.Click += new System.EventHandler(this.generarToolStripMenuItem_Click);
            // 
            // capturarImagenDeContadoresToolStripMenuItem
            // 
            this.capturarImagenDeContadoresToolStripMenuItem.Name = "capturarImagenDeContadoresToolStripMenuItem";
            this.capturarImagenDeContadoresToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.capturarImagenDeContadoresToolStripMenuItem.Text = "Capturar imagen de contadores";
            this.capturarImagenDeContadoresToolStripMenuItem.Click += new System.EventHandler(this.capturarImagenDeContadoresToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(188, 6);
            // 
            // elegirColumnasToolStripMenuItem
            // 
            this.elegirColumnasToolStripMenuItem.Image = global::InkAlert.Properties.Resources.table_select_column;
            this.elegirColumnasToolStripMenuItem.Name = "elegirColumnasToolStripMenuItem";
            this.elegirColumnasToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.elegirColumnasToolStripMenuItem.Text = "Elegir columnas";
            this.elegirColumnasToolStripMenuItem.Click += new System.EventHandler(this.elegirColumnasToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // diagnósticosToolStripMenuItem
            // 
            this.diagnósticosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTablaDeOidsEnVivoToolStripMenuItem});
            this.diagnósticosToolStripMenuItem.Image = global::InkAlert.Properties.Resources.diagnostic_chart;
            this.diagnósticosToolStripMenuItem.Name = "diagnósticosToolStripMenuItem";
            this.diagnósticosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.diagnósticosToolStripMenuItem.Text = "Beta";
            // 
            // verTablaDeOidsEnVivoToolStripMenuItem
            // 
            this.verTablaDeOidsEnVivoToolStripMenuItem.Image = global::InkAlert.Properties.Resources.application_view_icons;
            this.verTablaDeOidsEnVivoToolStripMenuItem.Name = "verTablaDeOidsEnVivoToolStripMenuItem";
            this.verTablaDeOidsEnVivoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.verTablaDeOidsEnVivoToolStripMenuItem.Text = "Ver tabla de Oids en vivo";
            this.verTablaDeOidsEnVivoToolStripMenuItem.Click += new System.EventHandler(this.verTablaDeOidsEnVivoToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(188, 6);
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar contraseña";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(314, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(852, 287);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.Transparent;
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(1013, 360);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(141, 133);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // dgPrinters
            // 
            this.dgPrinters.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgPrinters.AllowUserToAddRows = false;
            this.dgPrinters.AllowUserToDeleteRows = false;
            this.dgPrinters.AllowUserToOrderColumns = true;
            this.dgPrinters.AssignedContextMenuStrip = null;
            this.dgPrinters.AutoGenerateColumns = false;
            this.dgPrinters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPrinters.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgPrinters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrinters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPrinters.ColumnHeadersHeight = 30;
            this.dgPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPrinters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.printerStatusImage,
            this.areaName,
            this.valBlackLevel,
            this.tonerKModel,
            this.tonerKMaxLife,
            this.valMagentaLevel,
            this.valYellowLevel,
            this.valCianLevel,
            this.valFuserLevel,
            this.valImagingUnitKLevel,
            this.valTransferRollerLevel,
            this.valRollersPickupForwardTray1Level,
            this.areaIpAddress,
            this.dataDate,
            this.areaHostName,
            this.printerConnectionType,
            this.printerModelName,
            this.printerMakeName,
            this.printerSerial,
            this.printerTypeName,
            this.areaQueueName,
            this.valBlackCounter,
            this.defaultPrinter,
            this.monthlyCounterStatus,
            this.locationName,
            this.printerCommercialStatus,
            this.printerModelId,
            this.printerMakeId,
            this.printerLocationId,
            this.printerAreaId,
            this.printerStatus,
            this.printerConnectionTypeId,
            this.printerCommercialStatusId,
            this.monthlyCounterStatusId,
            this.storyNumber,
            this.valSerialNumber,
            this.valDataDate,
            this.urlUsage});
            this.dgPrinters.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgPrinters.CurrentFilterString = null;
            this.dgPrinters.DataSourceView = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPrinters.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgPrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPrinters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgPrinters.FilterColumnList = ((System.Collections.ArrayList)(resources.GetObject("dgPrinters.FilterColumnList")));
            this.dgPrinters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgPrinters.GridColor = System.Drawing.SystemColors.Control;
            this.dgPrinters.Location = new System.Drawing.Point(10, 10);
            this.dgPrinters.Name = "dgPrinters";
            this.dgPrinters.RowHeadersVisible = false;
            this.dgPrinters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPrinters.Size = new System.Drawing.Size(1156, 503);
            this.dgPrinters.SortColumn = -1;
            this.dgPrinters.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgPrinters.TabIndex = 0;
            this.dgPrinters.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinters_CellClick);
            this.dgPrinters.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrinters_CellEnter);
            this.dgPrinters.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPrinters_ColumnHeaderMouseClick);
            this.dgPrinters.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgPrinters_DataBindingComplete);
            this.dgPrinters.SelectionChanged += new System.EventHandler(this.dgPrinters_SelectionChanged);
            this.dgPrinters.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgPrinters_KeyUp);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 38;
            // 
            // printerStatusImage
            // 
            this.printerStatusImage.DataPropertyName = "printerStatusImage";
            this.printerStatusImage.Frozen = true;
            this.printerStatusImage.HeaderText = "Estado";
            this.printerStatusImage.Name = "printerStatusImage";
            this.printerStatusImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.printerStatusImage.Width = 44;
            // 
            // areaName
            // 
            this.areaName.DataPropertyName = "areaName";
            this.areaName.Frozen = true;
            this.areaName.HeaderText = "Área";
            this.areaName.Name = "areaName";
            this.areaName.Width = 52;
            // 
            // valBlackLevel
            // 
            this.valBlackLevel.DataPropertyName = "valBlackLevel";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.valBlackLevel.DefaultCellStyle = dataGridViewCellStyle2;
            this.valBlackLevel.HeaderText = "K";
            this.valBlackLevel.Name = "valBlackLevel";
            this.valBlackLevel.ToolTipText = "Nivel de tóner negro";
            this.valBlackLevel.Width = 37;
            // 
            // tonerKModel
            // 
            this.tonerKModel.DataPropertyName = "tonerKModel";
            this.tonerKModel.HeaderText = "Ref. K";
            this.tonerKModel.Name = "tonerKModel";
            this.tonerKModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tonerKModel.ToolTipText = "Referencia de tóner Negro";
            this.tonerKModel.Width = 56;
            // 
            // tonerKMaxLife
            // 
            this.tonerKMaxLife.DataPropertyName = "tonerKMaxLife";
            this.tonerKMaxLife.HeaderText = "Vida K";
            this.tonerKMaxLife.Name = "tonerKMaxLife";
            this.tonerKMaxLife.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tonerKMaxLife.ToolTipText = "Duración del tóner Negro";
            this.tonerKMaxLife.Width = 57;
            // 
            // valMagentaLevel
            // 
            this.valMagentaLevel.DataPropertyName = "valMagentaLevel";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Violet;
            this.valMagentaLevel.DefaultCellStyle = dataGridViewCellStyle3;
            this.valMagentaLevel.HeaderText = "M";
            this.valMagentaLevel.Name = "valMagentaLevel";
            this.valMagentaLevel.ToolTipText = "Nivel de tóner magenta";
            this.valMagentaLevel.Width = 39;
            // 
            // valYellowLevel
            // 
            this.valYellowLevel.DataPropertyName = "valYellowLevel";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.valYellowLevel.DefaultCellStyle = dataGridViewCellStyle4;
            this.valYellowLevel.HeaderText = "Y";
            this.valYellowLevel.Name = "valYellowLevel";
            this.valYellowLevel.ToolTipText = "Nivel de tóner amarillo";
            this.valYellowLevel.Width = 37;
            // 
            // valCianLevel
            // 
            this.valCianLevel.DataPropertyName = "valCianLevel";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.valCianLevel.DefaultCellStyle = dataGridViewCellStyle5;
            this.valCianLevel.HeaderText = "C";
            this.valCianLevel.Name = "valCianLevel";
            this.valCianLevel.ToolTipText = "Nivel de tóner cian";
            this.valCianLevel.Width = 37;
            // 
            // valFuserLevel
            // 
            this.valFuserLevel.DataPropertyName = "valFuserLevel";
            this.valFuserLevel.HeaderText = "Fusor";
            this.valFuserLevel.Name = "valFuserLevel";
            this.valFuserLevel.Width = 56;
            // 
            // valImagingUnitKLevel
            // 
            this.valImagingUnitKLevel.DataPropertyName = "valImagingUnitKLevel";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.valImagingUnitKLevel.DefaultCellStyle = dataGridViewCellStyle6;
            this.valImagingUnitKLevel.HeaderText = "iK";
            this.valImagingUnitKLevel.Name = "valImagingUnitKLevel";
            this.valImagingUnitKLevel.ToolTipText = "Nivel de unidad de imagen negra";
            this.valImagingUnitKLevel.Width = 39;
            // 
            // valTransferRollerLevel
            // 
            this.valTransferRollerLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.valTransferRollerLevel.DataPropertyName = "valTransferRollerLevel";
            this.valTransferRollerLevel.HeaderText = "T";
            this.valTransferRollerLevel.Name = "valTransferRollerLevel";
            this.valTransferRollerLevel.ToolTipText = "Nivel de rodillo de transferencia";
            this.valTransferRollerLevel.Width = 37;
            // 
            // valRollersPickupForwardTray1Level
            // 
            this.valRollersPickupForwardTray1Level.DataPropertyName = "valRollersPickupForwardTray1Level";
            this.valRollersPickupForwardTray1Level.HeaderText = "Bndj 1 Abs & Ree";
            this.valRollersPickupForwardTray1Level.Name = "valRollersPickupForwardTray1Level";
            this.valRollersPickupForwardTray1Level.ToolTipText = "Rodillos de absorción y reenvío de la bandeja 1";
            this.valRollersPickupForwardTray1Level.Width = 85;
            // 
            // areaIpAddress
            // 
            this.areaIpAddress.DataPropertyName = "areaIpAddress";
            this.areaIpAddress.HeaderText = "Dirección IPv4";
            this.areaIpAddress.Name = "areaIpAddress";
            this.areaIpAddress.Width = 92;
            // 
            // dataDate
            // 
            this.dataDate.DataPropertyName = "dataDate";
            dataGridViewCellStyle7.NullValue = null;
            this.dataDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataDate.HeaderText = "Última Actualización";
            this.dataDate.Name = "dataDate";
            this.dataDate.Width = 114;
            // 
            // areaHostName
            // 
            this.areaHostName.DataPropertyName = "areaHostName";
            this.areaHostName.HeaderText = "Nombre del Dispositivo";
            this.areaHostName.Name = "areaHostName";
            this.areaHostName.Width = 126;
            // 
            // printerConnectionType
            // 
            this.printerConnectionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.printerConnectionType.DataPropertyName = "printerConnectionType";
            this.printerConnectionType.HeaderText = "Tipo de conexión";
            this.printerConnectionType.MinimumWidth = 137;
            this.printerConnectionType.Name = "printerConnectionType";
            this.printerConnectionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.printerConnectionType.Width = 137;
            // 
            // printerModelName
            // 
            this.printerModelName.DataPropertyName = "printerModelName";
            this.printerModelName.HeaderText = "Modelo";
            this.printerModelName.MinimumWidth = 79;
            this.printerModelName.Name = "printerModelName";
            this.printerModelName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.printerModelName.Width = 79;
            // 
            // printerMakeName
            // 
            this.printerMakeName.DataPropertyName = "printerMakeName";
            this.printerMakeName.HeaderText = "Marca";
            this.printerMakeName.Name = "printerMakeName";
            this.printerMakeName.Width = 60;
            // 
            // printerSerial
            // 
            this.printerSerial.DataPropertyName = "printerSerial";
            this.printerSerial.HeaderText = "Serial Asignado";
            this.printerSerial.Name = "printerSerial";
            this.printerSerial.Width = 94;
            // 
            // printerTypeName
            // 
            this.printerTypeName.DataPropertyName = "printerTypeName";
            this.printerTypeName.HeaderText = "Tipo";
            this.printerTypeName.Name = "printerTypeName";
            this.printerTypeName.Width = 51;
            // 
            // areaQueueName
            // 
            this.areaQueueName.DataPropertyName = "areaQueueName";
            this.areaQueueName.HeaderText = "Cola de impresión";
            this.areaQueueName.Name = "areaQueueName";
            this.areaQueueName.Width = 103;
            // 
            // valBlackCounter
            // 
            this.valBlackCounter.DataPropertyName = "valBlackCounter";
            this.valBlackCounter.HeaderText = "Contador Negro";
            this.valBlackCounter.Name = "valBlackCounter";
            this.valBlackCounter.Width = 96;
            // 
            // defaultPrinter
            // 
            this.defaultPrinter.DataPropertyName = "defaultPrinter";
            this.defaultPrinter.HeaderText = "Impresora Predet.";
            this.defaultPrinter.Name = "defaultPrinter";
            this.defaultPrinter.Width = 103;
            // 
            // monthlyCounterStatus
            // 
            this.monthlyCounterStatus.DataPropertyName = "monthlyCounterStatus";
            this.monthlyCounterStatus.HeaderText = "Toma de contadores";
            this.monthlyCounterStatus.Name = "monthlyCounterStatus";
            this.monthlyCounterStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.monthlyCounterStatus.ToolTipText = "Estado de la toma de contadores para el mes actual";
            this.monthlyCounterStatus.Width = 117;
            // 
            // locationName
            // 
            this.locationName.DataPropertyName = "locationName";
            this.locationName.HeaderText = "Ubicación";
            this.locationName.MinimumWidth = 94;
            this.locationName.Name = "locationName";
            this.locationName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.locationName.Width = 94;
            // 
            // printerCommercialStatus
            // 
            this.printerCommercialStatus.DataPropertyName = "printerCommercialStatus";
            this.printerCommercialStatus.HeaderText = "Estado comercial";
            this.printerCommercialStatus.Name = "printerCommercialStatus";
            this.printerCommercialStatus.Width = 102;
            // 
            // printerModelId
            // 
            this.printerModelId.DataPropertyName = "printerModelId";
            this.printerModelId.HeaderText = "printerModelId";
            this.printerModelId.Name = "printerModelId";
            this.printerModelId.Visible = false;
            this.printerModelId.Width = 97;
            // 
            // printerMakeId
            // 
            this.printerMakeId.DataPropertyName = "printerMakeId";
            this.printerMakeId.HeaderText = "printerMakeId";
            this.printerMakeId.Name = "printerMakeId";
            this.printerMakeId.Visible = false;
            this.printerMakeId.Width = 95;
            // 
            // printerLocationId
            // 
            this.printerLocationId.DataPropertyName = "printerLocationId";
            this.printerLocationId.HeaderText = "printerLocationId";
            this.printerLocationId.Name = "printerLocationId";
            this.printerLocationId.Visible = false;
            this.printerLocationId.Width = 109;
            // 
            // printerAreaId
            // 
            this.printerAreaId.DataPropertyName = "printerAreaId";
            this.printerAreaId.HeaderText = "printerAreaId";
            this.printerAreaId.Name = "printerAreaId";
            this.printerAreaId.Visible = false;
            this.printerAreaId.Width = 90;
            // 
            // printerStatus
            // 
            this.printerStatus.DataPropertyName = "printerStatus";
            this.printerStatus.HeaderText = "printerStatus";
            this.printerStatus.Name = "printerStatus";
            this.printerStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.printerStatus.Visible = false;
            this.printerStatus.Width = 89;
            // 
            // printerConnectionTypeId
            // 
            this.printerConnectionTypeId.DataPropertyName = "printerConnectionTypeId";
            this.printerConnectionTypeId.HeaderText = "printerConnectionTypeId";
            this.printerConnectionTypeId.Name = "printerConnectionTypeId";
            this.printerConnectionTypeId.Visible = false;
            this.printerConnectionTypeId.Width = 146;
            // 
            // printerCommercialStatusId
            // 
            this.printerCommercialStatusId.DataPropertyName = "printerCommercialStatusId";
            this.printerCommercialStatusId.HeaderText = "printerCommercialStatusId";
            this.printerCommercialStatusId.Name = "printerCommercialStatusId";
            this.printerCommercialStatusId.Visible = false;
            this.printerCommercialStatusId.Width = 152;
            // 
            // monthlyCounterStatusId
            // 
            this.monthlyCounterStatusId.DataPropertyName = "monthlyCounterStatusId";
            this.monthlyCounterStatusId.HeaderText = "monthlyCounterStatusId";
            this.monthlyCounterStatusId.Name = "monthlyCounterStatusId";
            this.monthlyCounterStatusId.Visible = false;
            this.monthlyCounterStatusId.Width = 142;
            // 
            // storyNumber
            // 
            this.storyNumber.DataPropertyName = "storyNumber";
            this.storyNumber.HeaderText = "Piso";
            this.storyNumber.Name = "storyNumber";
            this.storyNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.storyNumber.Width = 50;
            // 
            // valSerialNumber
            // 
            this.valSerialNumber.DataPropertyName = "valSerialNumber";
            this.valSerialNumber.HeaderText = "Serial Reportado";
            this.valSerialNumber.Name = "valSerialNumber";
            // 
            // valDataDate
            // 
            this.valDataDate.DataPropertyName = "valDataDate";
            this.valDataDate.HeaderText = "valDataDate";
            this.valDataDate.Name = "valDataDate";
            this.valDataDate.Width = 90;
            // 
            // urlUsage
            // 
            this.urlUsage.DataPropertyName = "urlUsage";
            this.urlUsage.HeaderText = "Url de Config.";
            this.urlUsage.Name = "urlUsage";
            this.urlUsage.Width = 86;
            // 
            // frmPrinterStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 523);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loadingImage);
            this.Controls.Add(this.dgPrinters);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPrinterStatus";
            this.Text = "Estado actual";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrinters_FormClosing);
            this.Load += new System.EventHandler(this.Printers_Load);
            this.contextMenuPrinters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrinters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuPrinters;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarTodoToolStripMenuItem;
        public Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ToolStripMenuItem detallesDeImpresoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactarHostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactarIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirIPComoSitioWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirIpComoCarpetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem detenerServicioSNMPEnHostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem verEvoluciónDeTónerToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem diagnósticosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablaDeOidsEnVivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem actualizaciónManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem elegirColumnasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suministrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        internal Controls.LightDatagrid dgPrinters;
        private System.Windows.Forms.ToolStripMenuItem abrirRaízCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem capturarImagenDeContadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evoluciónDeContadoresToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewImageColumn printerStatusImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn valBlackLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tonerKModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tonerKMaxLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn valMagentaLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valYellowLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valCianLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valFuserLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valImagingUnitKLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valTransferRollerLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valRollersPickupForwardTray1Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaHostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerConnectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerMakeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaQueueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn valBlackCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultPrinter;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyCounterStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerCommercialStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerModelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerMakeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerAreaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerConnectionTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerCommercialStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyCounterStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn storyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn valSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn valDataDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlUsage;
    }
}