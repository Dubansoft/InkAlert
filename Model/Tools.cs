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

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace InkAlert
{

    public class Trick : Database
    {
        public Trick(string cmdString)
        {
            CmdString = cmdString;
        }

        public Trick(){}

        private string toolsError;
        public string ToolsError
        {
            get { return toolsError; }
            set { toolsError = value; }
        }

        public bool bindComboBox(
            ComboBox myComboBox,
            string displayMember,
            string valueMember = "id",
            string storedProcedureName = null,
            string newDataTableName = "table",
            string commandText = null
            )
        {
            try
            {
                ToolsError = string.Empty;
                //read from database and create the datatable
                ReadTable(storedProcedureName, newDataTableName, commandText);

                //Fill the comboBox with display member and value member
                myComboBox.DisplayMember = displayMember;
                myComboBox.ValueMember = valueMember;
                myComboBox.DataSource = DbDataset1.Tables[newDataTableName];
                return true;
            }
            catch (Exception e)
            {
                ToolsError = e.Message.ToString();
                return false;
            }

        }

        public bool bindListBox(
            ListBox myListBox,
            string displayMember,
            string valueMember = "id",
            string storedProcedureName = null,
            string newDataTableName = "table",
            string commandText = null
            )
        {
            try
            {
                ToolsError = string.Empty;
                //read from database and create the datatable
                ReadTable(storedProcedureName, newDataTableName, commandText);

                //Fill the comboBox with display member and value member
                myListBox.DisplayMember = displayMember;
                myListBox.ValueMember = valueMember;
                myListBox.DataSource = DbDataset1.Tables[newDataTableName];
                return true;
            }
            catch (Exception e)
            {
                ToolsError = e.Message.ToString();
                return false;
            }
        }

        internal bool fillLocalCmb_Custom(ComboBox senderComboBox, ComboBox targetComboBox, string dataTableName, string customQuery, string defaultStoredProcedureName, string displayMember, string valueMember = "")
        {


            try
            {
                //Fill cmbPrinterSerieName
                if ((int)senderComboBox.SelectedIndex > -1)
                {
                    ReadTable(null, dataTableName, customQuery);
                }
                else
                {
                    ReadTable(defaultStoredProcedureName, dataTableName);
                }

                if(DbDataset1.Tables[dataTableName].Rows.Count > 0)
                {
                    targetComboBox.DataSource = DbDataset1.Tables[dataTableName];
                }
                else
                {
                    DataTable myNoResultsTable = NoResultsTable(valueMember, displayMember);
                    targetComboBox.DataSource = myNoResultsTable;

                }

                targetComboBox.DisplayMember = displayMember;
                targetComboBox.ValueMember = valueMember;


                return true;
            }
            catch (Exception e)
            {
                this.Error = e.Message.ToString();
                return false;
            }
        }

        public string Capitalise(string textToCapitalise)
        {
            return (UppercaseFirst(textToCapitalise.ToLower()));
        }

        string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public DataTable NoResultsTable (string valueMember, string displayMember)
        {

            DataTable noResultsTable = new DataTable();
            noResultsTable.Columns.Add(valueMember, typeof(int));
            noResultsTable.Columns.Add(displayMember, typeof(string));

            noResultsTable.Rows.Add(0, "--Sin resultados--");
            return noResultsTable;

        }


    }

    internal static class Validation
    {

        public static bool ValidateDbConnection(Database sentDatabaseInstance)
        {
            if (!sentDatabaseInstance.TryConnect())
            {
                return false;
            }
            return true;
        }

    }

    public class LayoutHelper
    {
        private readonly PdfDocument _document;
        private readonly XUnit _topPosition;
        private readonly XUnit _bottomMargin;
        private XUnit _currentPosition;

        public LayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin)
        {
            _document = document;
            _topPosition = topPosition;
            _bottomMargin = bottomMargin;
            // Set a value outside the page - a new page will be created on the first request.
            _currentPosition = bottomMargin + 10000;
        }

        public XUnit GetLinePosition(XUnit requestedHeight)
        {
            return GetLinePosition(requestedHeight, -1f);
        }

        public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight)
        {
            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (_currentPosition + required > _bottomMargin)
                CreatePage();
            XUnit result = _currentPosition;
            _currentPosition += requestedHeight;
            return result;
        }

        public XGraphics Gfx { get; private set; }
        public PdfPage Page { get; private set; }

        void CreatePage()
        {
            Page = _document.AddPage();
            Page.Size = PageSize.A4;
            Gfx = XGraphics.FromPdfPage(Page);
            _currentPosition = _topPosition;
        }
    }

    public enum PrinterConnectionType
    {
        USB = 1,
        Red = 2,
        UsbyRed = 3,
        SinDefinir = 4
    }

    public enum PrinterCommercialStatus
    {
        Produccion = 1,
        Contingencia = 2,
        Reparacion = 3,
        Sin_definir = 4,
        Eliminada = 5
    }

    public enum AreaStatus
    {
        Activa = 1,
        Clausurada = 2
    }

    public class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selectable { get; set; }
    }
}


