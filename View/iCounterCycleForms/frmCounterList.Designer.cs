namespace InkAlert.Forms
{
    partial class frmCounterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCounterList));
            this.dgCounterList = new InkAlert.Controls.LightDatagrid();
            this.contextMenuICounterCycles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarTodosComoPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarComoCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blackCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.copyCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replacedSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCounterList)).BeginInit();
            this.contextMenuICounterCycles.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCounterList
            // 
            this.dgCounterList.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgCounterList.AllowUserToAddRows = false;
            this.dgCounterList.AllowUserToDeleteRows = false;
            this.dgCounterList.AllowUserToOrderColumns = true;
            this.dgCounterList.AssignedContextMenuStrip = null;
            this.dgCounterList.AutoGenerateColumns = false;
            this.dgCounterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCounterList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgCounterList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCounterList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCounterList.ColumnHeadersHeight = 30;
            this.dgCounterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgCounterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.printerSerial,
            this.blackCounter,
            this.areaName,
            this.printerModelName,
            this.colorCounter,
            this.emailCounter,
            this.copyCounter,
            this.replacedSerial,
            this.areaHostName,
            this.areaIpAddress,
            this.counterDate,
            this.saveDate});
            this.dgCounterList.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgCounterList.ContextMenuStrip = this.contextMenuICounterCycles;
            this.dgCounterList.CurrentFilterString = null;
            this.dgCounterList.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCounterList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCounterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCounterList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgCounterList.FilterColumnList = null;
            this.dgCounterList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgCounterList.GridColor = System.Drawing.SystemColors.Control;
            this.dgCounterList.Location = new System.Drawing.Point(10, 10);
            this.dgCounterList.Name = "dgCounterList";
            this.dgCounterList.RowHeadersVisible = false;
            this.dgCounterList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCounterList.Size = new System.Drawing.Size(883, 495);
            this.dgCounterList.SortColumn = -1;
            this.dgCounterList.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgCounterList.TabIndex = 0;
            // 
            // contextMenuICounterCycles
            // 
            this.contextMenuICounterCycles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem,
            this.exportarTodosComoPDFToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.exportarComoCSVToolStripMenuItem});
            this.contextMenuICounterCycles.Name = "contextMenuICounterCycles";
            this.contextMenuICounterCycles.Size = new System.Drawing.Size(231, 92);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar seleccionado";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // exportarTodosComoPDFToolStripMenuItem
            // 
            this.exportarTodosComoPDFToolStripMenuItem.Image = global::InkAlert.Properties.Resources.file_extension_pdf;
            this.exportarTodosComoPDFToolStripMenuItem.Name = "exportarTodosComoPDFToolStripMenuItem";
            this.exportarTodosComoPDFToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exportarTodosComoPDFToolStripMenuItem.Text = "Exportar todos como PDF";
            this.exportarTodosComoPDFToolStripMenuItem.Click += new System.EventHandler(this.exportarTodosComoPDFToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Image = global::InkAlert.Properties.Resources.file_extension_pdf;
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exportarToolStripMenuItem.Text = "Exportar seleccionado como PDF";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // exportarComoCSVToolStripMenuItem
            // 
            this.exportarComoCSVToolStripMenuItem.Image = global::InkAlert.Properties.Resources.file_extension_txt;
            this.exportarComoCSVToolStripMenuItem.Name = "exportarComoCSVToolStripMenuItem";
            this.exportarComoCSVToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exportarComoCSVToolStripMenuItem.Text = "Exportar al portapapeles";
            this.exportarComoCSVToolStripMenuItem.Click += new System.EventHandler(this.exportarComoCSVToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 38;
            // 
            // printerSerial
            // 
            this.printerSerial.DataPropertyName = "printerSerial";
            this.printerSerial.HeaderText = "Serial";
            this.printerSerial.Name = "printerSerial";
            this.printerSerial.Width = 56;
            // 
            // blackCounter
            // 
            this.blackCounter.DataPropertyName = "blackCounter";
            this.blackCounter.HeaderText = "Contador Negro";
            this.blackCounter.Name = "blackCounter";
            this.blackCounter.Width = 96;
            // 
            // areaName
            // 
            this.areaName.DataPropertyName = "areaName";
            this.areaName.HeaderText = "Área";
            this.areaName.Name = "areaName";
            this.areaName.Width = 52;
            // 
            // printerModelName
            // 
            this.printerModelName.DataPropertyName = "printerModelName";
            this.printerModelName.HeaderText = "Modelo";
            this.printerModelName.Name = "printerModelName";
            this.printerModelName.Width = 65;
            // 
            // colorCounter
            // 
            this.colorCounter.DataPropertyName = "colorCounter";
            this.colorCounter.HeaderText = "Contador Color";
            this.colorCounter.Name = "colorCounter";
            this.colorCounter.Width = 92;
            // 
            // emailCounter
            // 
            this.emailCounter.DataPropertyName = "emailCounter";
            this.emailCounter.HeaderText = "Contador Email";
            this.emailCounter.Name = "emailCounter";
            this.emailCounter.Width = 93;
            // 
            // copyCounter
            // 
            this.copyCounter.DataPropertyName = "copyCounter";
            this.copyCounter.HeaderText = "Contador de Copias";
            this.copyCounter.Name = "copyCounter";
            this.copyCounter.Width = 84;
            // 
            // replacedSerial
            // 
            this.replacedSerial.DataPropertyName = "replacedSerial";
            this.replacedSerial.HeaderText = "Es contingencia de";
            this.replacedSerial.Name = "replacedSerial";
            this.replacedSerial.Width = 111;
            // 
            // areaHostName
            // 
            this.areaHostName.DataPropertyName = "areaHostName";
            this.areaHostName.HeaderText = "Nombre del dispositivo";
            this.areaHostName.Name = "areaHostName";
            this.areaHostName.Width = 124;
            // 
            // areaIpAddress
            // 
            this.areaIpAddress.DataPropertyName = "areaIpAddress";
            this.areaIpAddress.HeaderText = "Dirección Ip";
            this.areaIpAddress.Name = "areaIpAddress";
            this.areaIpAddress.Width = 80;
            // 
            // counterDate
            // 
            this.counterDate.DataPropertyName = "counterDate";
            this.counterDate.HeaderText = "Fecha del contador";
            this.counterDate.Name = "counterDate";
            this.counterDate.Width = 112;
            // 
            // saveDate
            // 
            this.saveDate.DataPropertyName = "saveDate";
            this.saveDate.HeaderText = "Fecha de generación del informe";
            this.saveDate.Name = "saveDate";
            this.saveDate.Width = 138;
            // 
            // frmCounterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 515);
            this.Controls.Add(this.dgCounterList);
            this.Name = "frmCounterList";
            this.Text = "Visualizador de contadores";
            this.Load += new System.EventHandler(this.frmCounterList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCounterList)).EndInit();
            this.contextMenuICounterCycles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal Controls.LightDatagrid dgCounterList;
        private System.Windows.Forms.ContextMenuStrip contextMenuICounterCycles;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarComoCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarTodosComoPDFToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn blackCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn copyCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn replacedSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaHostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaIpAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn counterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn saveDate;
    }
}