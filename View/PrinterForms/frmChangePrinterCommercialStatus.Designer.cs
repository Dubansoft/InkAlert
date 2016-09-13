namespace InkAlert
{
    partial class frmChangePrinterCommercialStatus
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrinterCommercialStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(194, 124);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(98, 27);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Cambiar";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 110);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esta opción le permite cambiar el estado de una impresora. Por ejemplo, ponerla o" +
    " retirarla de producción.\r\n\r\nSeleccione el nuevo estado de la Impresora";
            // 
            // cmbPrinterCommercialStatus
            // 
            this.cmbPrinterCommercialStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinterCommercialStatus.FormattingEnabled = true;
            this.cmbPrinterCommercialStatus.Location = new System.Drawing.Point(13, 126);
            this.cmbPrinterCommercialStatus.Name = "cmbPrinterCommercialStatus";
            this.cmbPrinterCommercialStatus.Size = new System.Drawing.Size(164, 25);
            this.cmbPrinterCommercialStatus.TabIndex = 0;
            // 
            // frmChangePrinterCommercialStatus
            // 
            this.AcceptButton = this.cmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 172);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPrinterCommercialStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangePrinterCommercialStatus";
            this.Text = "Retirar impresora de producción";
            this.Load += new System.EventHandler(this.frmChangePrinterCommercialStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPrinterCommercialStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSave;
    }
}