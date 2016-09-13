namespace InkAlert.Forms
{
    partial class frmMonthlyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonthlyReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.loadingImage = new InkAlert.Controls.LoadingImage();
            this.contextMenuCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.llenarTablaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categorizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTablaDeResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgCategories = new InkAlert.Controls.LightDatagrid();
            this.dgOthers = new InkAlert.Controls.LightDatagrid();
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).BeginInit();
            this.contextMenuCategories.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOthers)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingImage
            // 
            this.loadingImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loadingImage.Image = ((System.Drawing.Image)(resources.GetObject("loadingImage.Image")));
            this.loadingImage.Location = new System.Drawing.Point(554, 261);
            this.loadingImage.Name = "loadingImage";
            this.loadingImage.Size = new System.Drawing.Size(100, 50);
            this.loadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingImage.TabIndex = 0;
            this.loadingImage.TabStop = false;
            this.loadingImage.Visible = false;
            // 
            // contextMenuCategories
            // 
            this.contextMenuCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.llenarTablaToolStripMenuItem,
            this.categorizarToolStripMenuItem,
            this.verTablaDeResultadosToolStripMenuItem});
            this.contextMenuCategories.Name = "contextMenuCategories";
            this.contextMenuCategories.Size = new System.Drawing.Size(183, 70);
            // 
            // llenarTablaToolStripMenuItem
            // 
            this.llenarTablaToolStripMenuItem.Name = "llenarTablaToolStripMenuItem";
            this.llenarTablaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.llenarTablaToolStripMenuItem.Text = "Llenar tabla";
            this.llenarTablaToolStripMenuItem.Click += new System.EventHandler(this.llenarTablaToolStripMenuItem_Click);
            // 
            // categorizarToolStripMenuItem
            // 
            this.categorizarToolStripMenuItem.Name = "categorizarToolStripMenuItem";
            this.categorizarToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.categorizarToolStripMenuItem.Text = "Categorizar";
            this.categorizarToolStripMenuItem.Click += new System.EventHandler(this.categorizarToolStripMenuItem_Click);
            // 
            // verTablaDeResultadosToolStripMenuItem
            // 
            this.verTablaDeResultadosToolStripMenuItem.Name = "verTablaDeResultadosToolStripMenuItem";
            this.verTablaDeResultadosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.verTablaDeResultadosToolStripMenuItem.Text = "Ver tabla decategorías";
            this.verTablaDeResultadosToolStripMenuItem.Click += new System.EventHandler(this.verTablaDeResultadosToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgCategories, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgOthers, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1019, 317);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgCategories
            // 
            this.dgCategories.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgCategories.AllowUserToAddRows = false;
            this.dgCategories.AllowUserToDeleteRows = false;
            this.dgCategories.AllowUserToOrderColumns = true;
            this.dgCategories.AssignedContextMenuStrip = null;
            this.dgCategories.AutoGenerateColumns = false;
            this.dgCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCategories.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCategories.ColumnHeadersHeight = 30;
            this.dgCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgCategories.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgCategories.ContextMenuStrip = this.contextMenuCategories;
            this.dgCategories.CurrentFilterString = null;
            this.dgCategories.DataSourceView = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgCategories.FilterColumnList = null;
            this.dgCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgCategories.GridColor = System.Drawing.SystemColors.Control;
            this.dgCategories.Location = new System.Drawing.Point(3, 3);
            this.dgCategories.Name = "dgCategories";
            this.dgCategories.RowHeadersVisible = false;
            this.dgCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCategories.Size = new System.Drawing.Size(503, 311);
            this.dgCategories.SortColumn = -1;
            this.dgCategories.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgCategories.TabIndex = 0;
            // 
            // dgOthers
            // 
            this.dgOthers.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.dgOthers.AllowUserToAddRows = false;
            this.dgOthers.AllowUserToDeleteRows = false;
            this.dgOthers.AllowUserToOrderColumns = true;
            this.dgOthers.AssignedContextMenuStrip = null;
            this.dgOthers.AutoGenerateColumns = false;
            this.dgOthers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgOthers.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgOthers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOthers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgOthers.ColumnHeadersHeight = 30;
            this.dgOthers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgOthers.ColumnsToBeFiltered = new string[] {
        "Default"};
            this.dgOthers.ContextMenuStrip = this.contextMenuCategories;
            this.dgOthers.CurrentFilterString = null;
            this.dgOthers.DataSourceView = null;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOthers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgOthers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOthers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgOthers.FilterColumnList = null;
            this.dgOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.dgOthers.GridColor = System.Drawing.SystemColors.Control;
            this.dgOthers.Location = new System.Drawing.Point(512, 3);
            this.dgOthers.Name = "dgOthers";
            this.dgOthers.RowHeadersVisible = false;
            this.dgOthers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOthers.Size = new System.Drawing.Size(504, 311);
            this.dgOthers.SortColumn = -1;
            this.dgOthers.SortDirection = System.Windows.Forms.SortOrder.Ascending;
            this.dgOthers.TabIndex = 0;
            // 
            // frmMonthlyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 337);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.loadingImage);
            this.Name = "frmMonthlyReport";
            this.Text = "Cierre de mes";
            ((System.ComponentModel.ISupportInitialize)(this.loadingImage)).EndInit();
            this.contextMenuCategories.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgOthers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.LoadingImage loadingImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuCategories;
        private System.Windows.Forms.ToolStripMenuItem llenarTablaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTablaDeResultadosToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.LightDatagrid dgCategories;
        private Controls.LightDatagrid dgOthers;
    }
}