
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp;
using System.IO;
using System.Diagnostics;
using FileHelper;

namespace InkAlert.Forms
{
    public partial class frmCounterList : InkAlert.Forms.BaseForms.frmGeneralBase
    {

        StoredProcedureParameters[] parameters;
        Database database = new Database();
        frmICounterCycles myICounterCycleForm = Application.OpenForms.OfType<frmICounterCycles>().FirstOrDefault();

        string currentCycleName;
        public string CurrentCycleName
        {
            get{return currentCycleName;}
            set{currentCycleName = value;}
        }
        
        string currentCycleMonth;
        public string CurrentCycleMonth
        {
            get { return currentCycleMonth; }
            set { currentCycleMonth = value; }
        }

        string currentCycleYear;
        public string CurrentCycleYear
        {
            get { return currentCycleYear; }
            set { currentCycleYear = value; }
        }

        public frmCounterList()
        {
            InitializeComponent();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportCountersToPdf();
        }
        

        private bool exportCountersToPdf()
        {
            PdfDocument document = new PdfDocument();

            // Sample uses DIN A4, page height is 29.7 cm. We use margins of 2.5 cm.
            LayoutHelper helper = new LayoutHelper(document, XUnit.FromCentimeter(2.5), XUnit.FromCentimeter(29.7 - 2.5));
            XUnit left = XUnit.FromCentimeter(2.5);

            XFont mainHeaderFont = new XFont("Times", 13, XFontStyle.Bold);
            XFont subtitleFont = new XFont("Times", 12, XFontStyle.Bold);
            XFont standardFont = new XFont("Courier New", 10, XFontStyle.Regular);
            XFont noteFont = new XFont("Times", 9, XFontStyle.Italic);
            XFont footerFont = new XFont("Times", 7, XFontStyle.Italic);

            foreach (DataGridViewRow dgvRow in dgCounterList.SelectedRows)
            {
                string _areaName = dgvRow.Cells["areaName"].Value.ToString();
                string _pcName = dgvRow.Cells["areaHostName"].Value.ToString();
                string _pcIp = dgvRow.Cells["areaIpAddress"].Value.ToString();
                string _printerModel = dgvRow.Cells["printerModelName"].Value.ToString();

                string _printerSerial = dgvRow.Cells["printerSerial"].Value.ToString();
                string _replacedPrinterSerial = dgvRow.Cells["replacedSerial"].Value.ToString();

                string _printerBlackCounter = dgvRow.Cells["blackCounter"].Value.ToString();
                string _counterSharpDate = dgvRow.Cells["counterDate"].Value.ToString();
                string _reportDate = dgvRow.Cells["saveDate"].Value.ToString();

                PdfPage page = document.AddPage();
                page.Size = PageSize.Letter;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                //Rects for all page data
                object[,] pdfDataRects = new object[,]
                    {
                        {"Contador de impresión " + this.CurrentCycleMonth + " de " + this.CurrentCycleYear, new XRect(0, 20, page.Width, page.Height), mainHeaderFont, true},

                        {"Área: " + _areaName, new XRect(40, 85, page.Width, page.Height), standardFont, false},
                        {"Fecha del documento: " + _reportDate, new XRect(40, 100, page.Width, page.Height),standardFont, false },

                        {"Información del Computador", new XRect(35, 140, page.Width, page.Height),subtitleFont, false },

                        {"Nombre: " + _pcName, new XRect(40, 165, page.Width, page.Height),standardFont, false },
                        {"IPv4: " + _pcIp, new XRect(40, 185, page.Width, page.Height),standardFont, false },

                        {"Información de la impresora", new XRect(35, 205, page.Width, page.Height),subtitleFont, false },

                        {"Modelo: " + _printerModel, new XRect(40, 225, page.Width, page.Height),standardFont, false },
                        {"Serial: " + _printerSerial, new XRect(40, 245, page.Width, page.Height),standardFont, false },

                        {"Contador de uso: " + _printerBlackCounter + " páginas", new XRect(40, 265, page.Width, page.Height),standardFont, false },

                        {"Fecha y hora del contador: " + _counterSharpDate, new XRect(40, 285, page.Width, page.Height),standardFont, false },

                        {"Reporte de contador generado por InkAlert.", new XRect(460, 770, page.Width, page.Height),footerFont, false },


                    };

                //


                //Add page contents:
                for (int i = 0; i < (pdfDataRects.Length) / 4; i++)
                {
                    bool centerAlign = (Boolean)pdfDataRects[i, 3];

                    gfx.DrawRectangle(XBrushes.Transparent, new XRect(20, 30, page.Width - 40, 30));

                    gfx.DrawString((string)pdfDataRects[i, 0], (XFont)pdfDataRects[i, 2], XBrushes.Black, (XRect)pdfDataRects[i, 1], centerAlign ? XStringFormats.TopCenter : XStringFormats.TopLeft);

                }

                if (_printerSerial.Trim().ToString() == _replacedPrinterSerial.Trim().ToString())
                {
                    gfx.DrawString("NOTA: El serial " + _printerSerial + " es el serial actualmente asignado al área.", noteFont, XBrushes.Black, new XRect(40, 325, page.Width, page.Height), XStringFormats.TopLeft);
                }
                else
                {
                    gfx.DrawString("NOTA: El serial " + _printerSerial + " está reemplazando al serial  " + _replacedPrinterSerial + " asignado al área.", noteFont, XBrushes.Black, new XRect(40, 325, page.Width, page.Height), XStringFormats.TopLeft);
                }

                //gfx.DrawString(printerName, font, XBrushes.Black, pageTitleRect, XStringFormats.TopLeft);


            }


            // Save the document...

            SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            mySaveFileDialog.Title = "Guardar contadores como...";
            mySaveFileDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            mySaveFileDialog.FileName = "Contadores " + GlobalSetup.Months[DateTime.Today.Month - 1].ToString();
            mySaveFileDialog.DefaultExt = ".pdf";
            mySaveFileDialog.Filter = "Documentos PDF (.pdf)|*.pdf";
            DialogResult mySaveFileDialogResult = mySaveFileDialog.ShowDialog();

            if (mySaveFileDialogResult == DialogResult.OK)
            {


                string filename = Path.GetFullPath(mySaveFileDialog.FileName);

            RetrySafePdfFile:


                try
                {
                    document.Save(filename);

                    // ...and start a viewer.
                    Process.Start(filename);
                    return true;
                }
                catch (Exception)
                {
                    DialogResult saveConfirmationDialog = MessageBox.Show("Por favor valide que el archivo '" + filename + "' no esté siendo utilizado por otro programa y que usted tenga permisos de escritura en la ruta seleccionada.", "Error al guardar el archivo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    if (saveConfirmationDialog == DialogResult.Retry)
                    {
                        goto RetrySafePdfFile;
                    }
                    return false;
                }


            }
            return false;
        }

        private void exportarComoCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GetClipboardContent only copies cells selected.
            dgCounterList.SelectAll();

            //By default no headers are included either.
            dgCounterList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            Clipboard.SetDataObject(dgCounterList.GetClipboardContent());

            dgCounterList.ClearSelection();

            MessageBox.Show("Se copió al portapapeles el contenido de la lista. Utilice Control + V para pegar el contenido en otro aplicativo", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCounterList.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar contadores seleccionados?", "Eliminar contador", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    foreach (DataGridViewRow selectedRow in dgCounterList.SelectedRows) {

                        parameters = new StoredProcedureParameters[2];
                        parameters[0] = new StoredProcedureParameters("_counterId", selectedRow.Cells["id"].Value.ToString());
                        parameters[1] = new StoredProcedureParameters("_printerSerial", selectedRow.Cells["printerSerial"].Value.ToString());

                        if (!database.RunStoredProcedure("ICounterCycle_RemoveCounter", parameters))
                        {
                            EventLogger.LogEvent(this, "Falló la eliminación del contador. " + database.Error, null);
                            MessageBox.Show("No se ha podido eliminar el contador seleccionado. Por favor inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            
                            return;
                        }

                    }


                    myICounterCycleForm.verContadoresToolStripMenuItem.PerformClick();
                    this.Close();
                }
            }
        }

        private void frmCounterList_Load(object sender, EventArgs e)
        {
            dgCounterList.MultiSelect = true;
        }

        private void exportarTodosComoPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgCounterList.SelectAll();
            exportCountersToPdf();

        }
    }
}
