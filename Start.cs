
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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InkAlert.Forms;
using System.Drawing.Imaging;
using Awesomium.Windows.Forms;
using System.Net.Mail;
using System.Net;
using FileHelper;

namespace InkAlert
{
    public partial class StartForm : InkAlert.Forms.BaseForms.frmGeneralBase
    {
        FileManager myFileManager = new FileManager();
        TabPage tabWebBrowser;
        WebBrowser webBrowserIE;
        Database database = new Database();
        StoredProcedureParameters[] parameters;
        public StartForm()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserLoginData.Text = "Bienvenido " + GlobalSetup.CurrentSessionUser.Username;

            }
            catch (Exception ee)
            {
                EventLogger.LogEvent(this, ee.Message.ToString(), ee);
            }
            

            cmdPrinterStatus.PerformClick();
            //AddBrowserTab("tabWelcome", "Página principal", "http://localhost:64999/charts/");

        }
        
        private void cmdAddUser_Click(object sender, EventArgs e)
        {

            frmUsers form = Application.OpenForms.OfType<frmUsers>().FirstOrDefault();
            frmUsers formUsers = form ?? new frmUsers();

            AddFormInPanel(formUsers);

            this.UpdateStatus("Cargando lista de usuarios, por favor espere...", 0);
            formUsers.CallBackgroundWorker();
            this.UpdateStatus("Listo", 0);
        }

        private void AddFormInPanel(System.Windows.Forms.Form myForm)
        {
            //Validate Database Connection
            if (!Validation.ValidateDbConnection(database)) { return; }

            foreach (TabPage tab in tabContainer.TabPages)
            {
                foreach (Control myControl in (tab.Controls)){
                    if (myControl is Panel){
                        if (myControl.Controls.Contains(myForm))
                        {
                            tabContainer.SelectedTab = tab;
                            return;
                        }
                    }


                }
            }

            TabPage newTab = new System.Windows.Forms.TabPage();

            newTab.Text = "Cargando...";

            this.tabContainer.Controls.Add(newTab);
            this.tabContainer.SelectedTab = newTab;

            //
            // newTab
            //
            newTab.Name = myForm.Text;
            newTab.TabIndex = 0;
            newTab.Text = myForm.Text + "         ";

            Panel newPanel = new System.Windows.Forms.Panel();
            newTab.Controls.Add(newPanel);
            //
            // newPanel
            //
            newPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newPanel.Location = new System.Drawing.Point(0, 132);
            newPanel.Margin = new System.Windows.Forms.Padding(4);
            newPanel.Name = "newPanel" + 1;

            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            myForm.TopLevel = false;
            newPanel.Controls.Add(myForm);
            newPanel.Tag = myForm;
            myForm.Show();

        }

        private void cmdLocations_Click(object sender, EventArgs e)
        {
            frmLocations form = Application.OpenForms.OfType<frmLocations>().FirstOrDefault();
            frmLocations formLocations = form ?? new frmLocations();
            AddFormInPanel(formLocations);
            formLocations.CallBackgroundWorker();
        }

        private void cmdPrinterTypes_Click(object sender, EventArgs e)
        {
            frmPrinterTypes form = Application.OpenForms.OfType<frmPrinterTypes>().FirstOrDefault();
            frmPrinterTypes formPrinterTypes = form ?? new frmPrinterTypes();
            AddFormInPanel(formPrinterTypes);
            formPrinterTypes.CallBackgroundWorker();
        }

        private void cmdPrinterMakes_Click(object sender, EventArgs e)
        {
            frmPrinterMakes form = Application.OpenForms.OfType<frmPrinterMakes>().FirstOrDefault();
            frmPrinterMakes formPrinterMakes = form ?? new frmPrinterMakes();
            AddFormInPanel(formPrinterMakes);
            formPrinterMakes.CallBackgroundWorker();
        }

        private void cmdPrinterModels_Click(object sender, EventArgs e)
        {
            frmPrinterModels form = Application.OpenForms.OfType<frmPrinterModels>().FirstOrDefault();
            frmPrinterModels formPrinterModels = form ?? new frmPrinterModels();
            AddFormInPanel(formPrinterModels);
            formPrinterModels.CallBackgroundWorker();
        }

        private void cmdPrinterSeries_Click(object sender, EventArgs e)
        {
            frmPrinterSeries form = Application.OpenForms.OfType<frmPrinterSeries>().FirstOrDefault();
            frmPrinterSeries formPrinterSeries = form ?? new frmPrinterSeries();
            AddFormInPanel(formPrinterSeries);
            formPrinterSeries.CallBackgroundWorker();
        }

        private void cmdOids_Click(object sender, EventArgs e)
        {
            frmOids form = Application.OpenForms.OfType<frmOids>().FirstOrDefault();
            frmOids formOids = form ?? new frmOids();
            AddFormInPanel(formOids);
            formOids.CallBackgroundWorker();
        }

        private void cmdAreas_Click(object sender, EventArgs e)
        {
            frmAreas form = Application.OpenForms.OfType<frmAreas>().FirstOrDefault();
            frmAreas formAreas = form ?? new frmAreas();
            AddFormInPanel(formAreas);

            this.UpdateStatus("Cargando lista de áreas, por favor espere...", 0);
            formAreas.CallBackgroundWorker();
            this.UpdateStatus("Listo", 0);
        }

        private void cmdPrinters_Click(object sender, EventArgs e)
        {
            frmPrinterStatus form = Application.OpenForms.OfType<frmPrinterStatus>().FirstOrDefault();
            frmPrinterStatus formPrinters = form ?? new frmPrinterStatus();
            AddFormInPanel(formPrinters);

            formPrinters.gridRefresh();

        }

        public void UpdateStatus(string statusString, int progressValue)
        {
            string newStatusString = statusString.ToString();
            this.lblStatus.Text = newStatusString;

            int progressVal = progressValue;
            this.progressBar.Value = progressVal;

            if (progressBar.Value == 0 || progressBar.Value == 100)
            {
                progressBar.Visible = false;
            }
            else {
                progressBar.Visible = true;
            }
        }

        public void UpdateStatusCounters(string statusString)
        {
            string newStatusString = statusString.ToString();
            this.lblSelectionStatus.Text = "|   "  + newStatusString;
        }

        public void UpdateStatusSelection(string statusString)
        {
            string newStatusString = statusString.ToString();
            this.lblSelectionStatus.Text = "|   " + newStatusString;
        }

        public void FullStatusUpdate(string statusString, int progressValue, string CountersStatusString, string SelectionStatusString)
        {
            UpdateStatus(statusString, progressValue);
            UpdateStatusCounters(CountersStatusString);
            UpdateStatusSelection(SelectionStatusString);
        }

        public void ToggleLoadingImage(object sender, bool imageVisible, PictureBox pictureBox)
        {
            try
            {
                if (sender is Form)
                {
                    PictureBox myPicturebox = new PictureBox();
                    myPicturebox = pictureBox;
                    myPicturebox.Dock = System.Windows.Forms.DockStyle.Fill;
                    myPicturebox.Visible = imageVisible;
                }
            }
            catch (Exception e)
            {
                EventLogger.LogEvent(this, e.Message.ToString(),e);
            }


        }

        private void tabContainer_DoubleClick(object sender, EventArgs e)
        {
            closeTab();
        }

        private bool closeTab()
        {
            if (MessageBox.Show("¿Desea cerrar la pestaña " + tabContainer.SelectedTab.Text.Trim() + "?", "Cerrar pestaña", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Control myControl in tabContainer.SelectedTab.Controls)
                {
                    if (myControl is Panel)
                    {
                        Panel myPanel = ((Panel)myControl);

                        foreach (Control myControlInsidePanel in myPanel.Controls)
                        {
                            if (myControlInsidePanel is Form)
                            {
                                ((Form)myControlInsidePanel).Close();
                            }
                        }

                    }
                }

                tabContainer.TabPages.Remove(tabContainer.SelectedTab);
                return true;
            }
            return false;
        }

        private void cmdSettings_Click(object sender, EventArgs e)
        {

            frmSettings form = Application.OpenForms.OfType<frmSettings>().FirstOrDefault();
            frmSettings formSettings = form ?? new frmSettings();
            formSettings.ShowDialog();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Uri myUrl = new Uri("http://localhost/phpmyadmin");
            //webBrowser1.Navigate(myUrl);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string FileName = @"F:\Documents\Dubansoft\WinDocs\Desktop\Backup\image.png";
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save(FileName, ImageFormat.Png);
            //pictureBox1.Image = bmpScreenshot;
        }

        private void ribbonOrbMenuItem1_Click(object sender, EventArgs e)
        {
            frmLogin form = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
            frmLogin formLogin = form ?? new frmLogin();
            formLogin.ShowDialog();
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void AddBrowserTab(System.Windows.Forms.Form myForm)
        {
            foreach (TabPage tab in tabContainer.TabPages)
            {
                foreach (Control myControl in (tab.Controls))
                {
                    if (myControl is Panel)
                    {
                        if (myControl.Controls.Contains(myForm))
                        {
                            tabContainer.SelectedTab = tab;
                            return;
                        }
                    }


                }
            }

            TabPage newTab = new System.Windows.Forms.TabPage();

            newTab.Text = "Cargando...";

            this.tabContainer.Controls.Add(newTab);
            this.tabContainer.SelectedTab = newTab;

            //
            // newTab
            //
            newTab.Name = myForm.Text;
            newTab.TabIndex = 0;
            newTab.Text = myForm.Text;

            Panel newPanel = new System.Windows.Forms.Panel();
            newTab.Controls.Add(newPanel);
            //
            // newPanel
            //
            newPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newPanel.Location = new System.Drawing.Point(0, 132);
            newPanel.Margin = new System.Windows.Forms.Padding(4);
            newPanel.Name = "newPanel" + 1;

            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            myForm.TopLevel = false;
            newPanel.Controls.Add(myForm);
            newPanel.Tag = myForm;
            myForm.Show();

        }

        private void cmdDatabaseAdmin_Click(object sender, EventArgs e)
        {

            AddBrowserTab("tabDatabaseAdmin", "PhpMyAdmin", "http://" + GlobalSetup.DataBaseServerName + "/");
        }

        public void AddBrowserTab(string tabName, string tabTitle, string Url)
        {


            //
            // tabWebBrowser
            //
            TabPage tabWebBrowser = new TabPage();
            tabWebBrowser.Location = new Point(4, 26);
            tabWebBrowser.Name = tabName;
            tabWebBrowser.Padding = new System.Windows.Forms.Padding(3);
            tabWebBrowser.Size = new System.Drawing.Size(987, 479);
            tabWebBrowser.TabIndex = 1;
            tabWebBrowser.Text = tabTitle + "         "; ;
            tabWebBrowser.UseVisualStyleBackColor = true;
            //
            // webBrowser
            //
            WebControl webBrowser = new WebControl();
            webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            webBrowser.Location = new System.Drawing.Point(3, 3);
            webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser.Name = tabName + "WebBrowser";
            webBrowser.TabIndex = 0;
            webBrowser.Source = new Uri(Url);

            tabWebBrowser.Controls.Add(webBrowser);
            this.tabContainer.Controls.Add(tabWebBrowser);
            
            

        }

        public void AddIEBrowserTab(string tabName, string tabTitle, string Url)
        {
            //
            // tabWebBrowser
            //
            this.tabWebBrowser = new TabPage();
            this.tabWebBrowser.Location = new Point(4, 26);
            this.tabWebBrowser.Name = tabName;
            this.tabWebBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebBrowser.Size = new System.Drawing.Size(987, 479);
            this.tabWebBrowser.TabIndex = 1;
            this.tabWebBrowser.Text = tabTitle + "         "; ;
            this.tabWebBrowser.UseVisualStyleBackColor = true;
            //
            // webBrowser
            //

            this.webBrowserIE = new WebBrowser();
            this.webBrowserIE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserIE.Location = new System.Drawing.Point(3, 3);
            this.webBrowserIE.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserIE.Name = tabName + "IEWebBrowser";
            this.webBrowserIE.TabIndex = 0;
            this.webBrowserIE.Url = new Uri(Url);


            this.tabContainer.Controls.Add(this.tabWebBrowser);
            this.tabWebBrowser.Controls.Add(this.webBrowserIE);


        }


        private void timerDatabaseUpdate_Tick(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();

            this.UpdateStatus("Mantenimiento de la base de datos en progreso...", 0);

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                parameters = new StoredProcedureParameters[2];
                parameters[0] = new StoredProcedureParameters("_monthsToKeep", GlobalSetup.PrinterHistoryCleanUpInterval.ToString());
                parameters[1] = new StoredProcedureParameters("_todayNumeric", DateEngine.CurrentDateInteger);

                BackgroundWorker b = o as BackgroundWorker;
                database.RunStoredProcedure("DatabaseMaintenance", parameters);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                this.UpdateStatus("Se completó el mantenimiento de la base de datos el " + DateEngine.CurrentDateShort + " a las " + DateEngine.CurrentTimeShort, 0);
            });
            this.timerDatabaseUpdate.Enabled = false;
            bw.RunWorkerAsync();
        }

        private void UpdateStatus(object p, int v)
        {
            throw new NotImplementedException();
        }

        private void cmdConsumables_Click(object sender, EventArgs e)
        {
            frmConsumables form = Application.OpenForms.OfType<frmConsumables>().FirstOrDefault();
            frmConsumables formConsumables = form ?? new frmConsumables();
            AddFormInPanel(formConsumables);
            formConsumables.CallBackgroundWorker();
        }

        private void tabContainer_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption.

            //e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);

            Rectangle redRectangle = new Rectangle(e.Bounds.Right - 20, e.Bounds.Top + 6, 15, 15);

            //Brush BackBrush = new SolidBrush(this.panel1.BackColor); //Set background color

            //e.Graphics.FillRectangle(BackBrush, e.Bounds);

            e.Graphics.DrawIcon(new Icon("Resources/close.ico"), redRectangle);
            e.Graphics.DrawString(this.tabContainer.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();

            SolidBrush fillBrush = new SolidBrush(this.panel1.BackColor);


            //draw rectangle behind the tabs
            Rectangle lasttabrect = tabContainer.GetTabRect(tabContainer.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right, 0);

            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            background.Size = new Size(tabContainer.Right - background.Left, lasttabrect.Height + 1);
            e.Graphics.FillRectangle(fillBrush, background);


        }

        private void tabContainer_MouseDown(object sender, MouseEventArgs e)
        {



            //Looping through the controls.
            for (int i = 0; i < this.tabContainer.TabPages.Count; i++)
            {
                Rectangle r = tabContainer.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 20, r.Top + 6, 20, 20);
                if (closeButton.Contains(e.Location))
                {
                    if (closeTab())
                    {
                        break;
                    }
                }
            }
        }

        private void cmdCounterCycles_Click(object sender, EventArgs e)
        {
            frmICounterCycles form = Application.OpenForms.OfType<frmICounterCycles>().FirstOrDefault();
            frmICounterCycles formCounters = form ?? new frmICounterCycles();
            AddFormInPanel(formCounters);
            formCounters.CallBackgroundWorker();
        }

        private void ribbonButton1_Click_1(object sender, EventArgs e)
        {
            frmMonthlyReport form = Application.OpenForms.OfType<frmMonthlyReport>().FirstOrDefault();
            frmMonthlyReport formReports = form ?? new frmMonthlyReport();
            AddFormInPanel(formReports);
        }

        private void cmdPrinterSerials_Click(object sender, EventArgs e)
        {
            frmPrinterSerial form = Application.OpenForms.OfType<frmPrinterSerial>().FirstOrDefault();
            frmPrinterSerial formSerials = form ?? new frmPrinterSerial();
            AddFormInPanel(formSerials);
            formSerials.CallBackgroundWorker();
        }

        private void cmdLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("inkalertsoftware@gmail.com");
                message.To.Add(new MailAddress("inkalertsoftware@gmail.com"));
                message.Subject = "InkAlert - Alerta de tóner bajo";
                message.Body = @"
                    <h2>InkAlert - Alerta de tóner bajo</h2>
                    <p>Esta es una alerta automática enviada por InkAlert para informarle que el tóner de Farmacia
                    se encuentra actualmente al 1%";
                message.Priority = MailPriority.High;
                message.IsBodyHtml = true;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("inkalertsoftware@gmail.com", "22005104");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }
    }
}
