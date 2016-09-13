
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


namespace InkAlert
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.cmdPrinterStatus = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.cmdUsers = new System.Windows.Forms.RibbonButton();
            this.cmdLocations = new System.Windows.Forms.RibbonButton();
            this.cmdAreas = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.cmdPrinterMakes = new System.Windows.Forms.RibbonButton();
            this.cmdPrinterModels = new System.Windows.Forms.RibbonButton();
            this.cmdPrinterTypes = new System.Windows.Forms.RibbonButton();
            this.cmdPrinterSeries = new System.Windows.Forms.RibbonButton();
            this.cmdOids = new System.Windows.Forms.RibbonButton();
            this.cmdPrinterSerials = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.cmdConsumables = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.cmdICounterCycles = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.cmdInforme = new System.Windows.Forms.RibbonButton();
            this.cmdSettings = new System.Windows.Forms.RibbonOrbMenuItem();
            this.timerDatabaseUpdate = new System.Windows.Forms.Timer(this.components);
            this.cmdLogout = new System.Windows.Forms.RibbonOrbMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblSelectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUserLoginData = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCounterStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel6);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel4);
            this.ribbonTab1.Panels.Add(this.ribbonPanel5);
            this.ribbonTab1.Text = "Administración";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.cmdPrinterStatus);
            this.ribbonPanel6.Text = "Estado Actual";
            // 
            // cmdPrinterStatus
            // 
            this.cmdPrinterStatus.Image = global::InkAlert.Properties.Resources.printer_color1;
            this.cmdPrinterStatus.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdPrinterStatus.SmallImage")));
            this.cmdPrinterStatus.Text = "Estado";
            this.cmdPrinterStatus.Click += new System.EventHandler(this.cmdPrinters_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.cmdUsers);
            this.ribbonPanel3.Items.Add(this.cmdLocations);
            this.ribbonPanel3.Items.Add(this.cmdAreas);
            this.ribbonPanel3.Text = "Usuarios y Ubicaciones";
            // 
            // cmdUsers
            // 
            this.cmdUsers.Image = global::InkAlert.Properties.Resources.user;
            this.cmdUsers.MinimumSize = new System.Drawing.Size(60, 0);
            this.cmdUsers.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdUsers.SmallImage")));
            this.cmdUsers.Text = "Usuarios";
            this.cmdUsers.Click += new System.EventHandler(this.cmdAddUser_Click);
            // 
            // cmdLocations
            // 
            this.cmdLocations.Image = global::InkAlert.Properties.Resources.office_building;
            this.cmdLocations.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdLocations.SmallImage")));
            this.cmdLocations.Text = "Ubicaciones";
            this.cmdLocations.Click += new System.EventHandler(this.cmdLocations_Click);
            // 
            // cmdAreas
            // 
            this.cmdAreas.Image = global::InkAlert.Properties.Resources.computer;
            this.cmdAreas.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdAreas.SmallImage")));
            this.cmdAreas.Text = "Áreas";
            this.cmdAreas.Click += new System.EventHandler(this.cmdAreas_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.cmdPrinterMakes);
            this.ribbonPanel1.Items.Add(this.cmdPrinterModels);
            this.ribbonPanel1.Items.Add(this.cmdPrinterTypes);
            this.ribbonPanel1.Items.Add(this.cmdPrinterSeries);
            this.ribbonPanel1.Items.Add(this.cmdOids);
            this.ribbonPanel1.Items.Add(this.cmdPrinterSerials);
            this.ribbonPanel1.Text = "Impresoras";
            // 
            // cmdPrinterMakes
            // 
            this.cmdPrinterMakes.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrinterMakes.Image")));
            this.cmdPrinterMakes.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdPrinterMakes.SmallImage")));
            this.cmdPrinterMakes.Text = "Marcas";
            this.cmdPrinterMakes.Click += new System.EventHandler(this.cmdPrinterMakes_Click);
            // 
            // cmdPrinterModels
            // 
            this.cmdPrinterModels.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrinterModels.Image")));
            this.cmdPrinterModels.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdPrinterModels.SmallImage")));
            this.cmdPrinterModels.Text = "Modelos";
            this.cmdPrinterModels.Click += new System.EventHandler(this.cmdPrinterModels_Click);
            // 
            // cmdPrinterTypes
            // 
            this.cmdPrinterTypes.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrinterTypes.Image")));
            this.cmdPrinterTypes.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdPrinterTypes.SmallImage")));
            this.cmdPrinterTypes.Text = "Tipos";
            this.cmdPrinterTypes.Click += new System.EventHandler(this.cmdPrinterTypes_Click);
            // 
            // cmdPrinterSeries
            // 
            this.cmdPrinterSeries.Image = global::InkAlert.Properties.Resources.printer;
            this.cmdPrinterSeries.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdPrinterSeries.SmallImage")));
            this.cmdPrinterSeries.Text = "Series";
            this.cmdPrinterSeries.Click += new System.EventHandler(this.cmdPrinterSeries_Click);
            // 
            // cmdOids
            // 
            this.cmdOids.Image = global::InkAlert.Properties.Resources.script_key;
            this.cmdOids.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdOids.SmallImage")));
            this.cmdOids.Text = "Oids";
            this.cmdOids.Click += new System.EventHandler(this.cmdOids_Click);
            // 
            // cmdPrinterSerials
            // 
            this.cmdPrinterSerials.Image = global::InkAlert.Properties.Resources.source_code;
            this.cmdPrinterSerials.SmallImage = global::InkAlert.Properties.Resources.source_code1;
            this.cmdPrinterSerials.Text = "Seriales";
            this.cmdPrinterSerials.Click += new System.EventHandler(this.cmdPrinterSerials_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.cmdConsumables);
            this.ribbonPanel2.Text = "Suministros";
            // 
            // cmdConsumables
            // 
            this.cmdConsumables.Image = global::InkAlert.Properties.Resources.draw_ink;
            this.cmdConsumables.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdConsumables.SmallImage")));
            this.cmdConsumables.Text = "Suministros";
            this.cmdConsumables.Click += new System.EventHandler(this.cmdConsumables_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.cmdICounterCycles);
            this.ribbonPanel4.Text = "Contadores";
            // 
            // cmdICounterCycles
            // 
            this.cmdICounterCycles.Image = global::InkAlert.Properties.Resources.diagnostic_chart1;
            this.cmdICounterCycles.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdICounterCycles.SmallImage")));
            this.cmdICounterCycles.Text = "Ciclos";
            this.cmdICounterCycles.Click += new System.EventHandler(this.cmdCounterCycles_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.cmdInforme);
            this.ribbonPanel5.Text = "Cierre de mes";
            // 
            // cmdInforme
            // 
            this.cmdInforme.Image = global::InkAlert.Properties.Resources.data_table;
            this.cmdInforme.SmallImage = ((System.Drawing.Image)(resources.GetObject("cmdInforme.SmallImage")));
            this.cmdInforme.Text = "Cierre";
            this.cmdInforme.Click += new System.EventHandler(this.ribbonButton1_Click_1);
            // 
            // cmdSettings
            // 
            this.cmdSettings.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.cmdSettings.Image = global::InkAlert.Properties.Resources.setting_tools;
            this.cmdSettings.SmallImage = global::InkAlert.Properties.Resources.setting_tools;
            this.cmdSettings.Text = "Configurar";
            this.cmdSettings.Click += new System.EventHandler(this.cmdSettings_Click);
            // 
            // timerDatabaseUpdate
            // 
            this.timerDatabaseUpdate.Enabled = true;
            this.timerDatabaseUpdate.Interval = 1800000;
            this.timerDatabaseUpdate.Tick += new System.EventHandler(this.timerDatabaseUpdate_Tick);
            // 
            // cmdLogout
            // 
            this.cmdLogout.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.cmdLogout.Image = global::InkAlert.Properties.Resources.logoff;
            this.cmdLogout.SmallImage = global::InkAlert.Properties.Resources.logoff;
            this.cmdLogout.Text = "Cerrar sesión";
            this.cmdLogout.Click += new System.EventHandler(this.cmdLogout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar,
            this.lblSelectionStatus,
            this.txtUserLoginData,
            this.lblCounterStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 641);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1179, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(450, 17);
            this.lblStatus.Text = "Listo";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 16);
            this.progressBar.Visible = false;
            // 
            // lblSelectionStatus
            // 
            this.lblSelectionStatus.Name = "lblSelectionStatus";
            this.lblSelectionStatus.Size = new System.Drawing.Size(63, 17);
            this.lblSelectionStatus.Text = "Selección...";
            // 
            // txtUserLoginData
            // 
            this.txtUserLoginData.AutoSize = false;
            this.txtUserLoginData.Name = "txtUserLoginData";
            this.txtUserLoginData.Size = new System.Drawing.Size(250, 17);
            this.txtUserLoginData.Text = "Bienvenido ...";
            this.txtUserLoginData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCounterStatus
            // 
            this.lblCounterStatus.Name = "lblCounterStatus";
            this.lblCounterStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.tabContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 30);
            this.panel1.Size = new System.Drawing.Size(1179, 549);
            this.panel1.TabIndex = 2;
            // 
            // tabContainer
            // 
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabContainer.Location = new System.Drawing.Point(10, 10);
            this.tabContainer.Margin = new System.Windows.Forms.Padding(10);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1159, 509);
            this.tabContainer.TabIndex = 1;
            this.tabContainer.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabContainer_DrawItem);
            this.tabContainer.DoubleClick += new System.EventHandler(this.tabContainer_DoubleClick);
            this.tabContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabContainer_MouseDown);
            // 
            // ribbon1
            // 
            this.ribbon1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.cmdSettings);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.cmdLogout);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.OrbText = "Menú Principal";
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Enabled = false;
            this.ribbon1.QuickAcessToolbar.Tag = "";
            this.ribbon1.QuickAcessToolbar.Text = "";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1179, 114);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Green;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 663);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(630, 665);
            this.Name = "StartForm";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Text = "InkAlert - Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
            this.Load += new System.EventHandler(this.Start_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripStatusLabel lblStatus;
        public System.Windows.Forms.ToolStripProgressBar progressBar;
        public System.Windows.Forms.ToolStripStatusLabel lblCounterStatus;
        public System.Windows.Forms.ToolStripStatusLabel lblSelectionStatus;
        public System.Windows.Forms.StatusStrip statusStrip;
        internal System.Windows.Forms.RibbonButton cmdUsers;
        internal System.Windows.Forms.RibbonButton cmdLocations;
        internal System.Windows.Forms.RibbonButton cmdPrinterMakes;
        internal System.Windows.Forms.RibbonButton cmdPrinterModels;
        internal System.Windows.Forms.RibbonButton cmdPrinterTypes;
        internal System.Windows.Forms.RibbonButton cmdPrinterSeries;
        internal System.Windows.Forms.RibbonButton cmdOids;
        internal System.Windows.Forms.RibbonButton cmdAreas;
        internal System.Windows.Forms.RibbonButton cmdPrinterStatus;
        internal System.Windows.Forms.Timer timerDatabaseUpdate;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton cmdConsumables;
        internal System.Windows.Forms.RibbonOrbMenuItem cmdSettings;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        internal System.Windows.Forms.RibbonButton cmdICounterCycles;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton cmdInforme;
        internal System.Windows.Forms.RibbonButton cmdPrinterSerials;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.ToolStripStatusLabel txtUserLoginData;
        private System.Windows.Forms.RibbonOrbMenuItem cmdLogout;
    }
}