
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace InkAlert.Controls
{
    public partial class LightDatagrid : DataGridView//: FilterDataGridView
    {
        #region Member Variables
        private string columnName = string.Empty;
        private Hashtable checkedFilterHashTable = new Hashtable();
        private Hashtable oldCheckedFilterHashTable = new Hashtable();

        private string mainFilteringColumn = string.Empty;
        ArrayList mainColumnFilterList = new ArrayList();

        string oldFilterString = string.Empty;

        private int positionX = 0;
        private int positionY = 0;
        private DataTable dataSource = null;

        private DataView dataSourceView = null;
        public DataView DataSourceView
        {
            get { return dataSourceView; }
            set { dataSourceView = value; }
        }

        private string currentFilterString;
        public string CurrentFilterString
        {
            get { return currentFilterString; }
            set { currentFilterString = value; }
        }

        private ArrayList filterColumnList;
        [Browsable(false)]
        public ArrayList FilterColumnList
        {
            get { return filterColumnList; }
            set { filterColumnList = value; }
        }

        private int sortColumn;
        public int SortColumn
        {
            get { return (sortColumn > 0) ? sortColumn : -1; }
            set { sortColumn = value; }
        }

        private SortOrder sortDirection = SortOrder.Ascending;
        public SortOrder SortDirection
        {
            get { return sortDirection; }
            set { sortDirection = value; }
        }

        private string[] columnsToBeFiltered = new string[] { "Default" };
        [Browsable(false)]
        public string[] ColumnsToBeFiltered
        {
            get { return columnsToBeFiltered; }
            set
            {
                columnsToBeFiltered = value;

            }
        }

        private DataTable dtDatagridSource = new DataTable();
        [Browsable(false)]
        public DataTable DtDatagridSource
        {
            get { return dtDatagridSource; }
            set
            {
                dtDatagridSource = value;

            }
        }

        private ContextMenuStrip assignedContextMenuStrip;
        public ContextMenuStrip AssignedContextMenuStrip
        {
            get { return assignedContextMenuStrip; }
            set { assignedContextMenuStrip = value; }
        }


        #endregion
        public LightDatagrid()
        {
            InitializeComponent();
        }

        System.Windows.Forms.DataGridViewCellStyle ligthGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ColumnHeadersHeight = 30;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridColor = System.Drawing.SystemColors.Control;
            this.ReadOnly = false;
            this.RowHeadersVisible = false;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TabIndex = 0;
            this.AutoGenerateColumns = false;
            this.ScrollBars = ScrollBars.Both;
            this.Font = new Font(this.DefaultCellStyle.Font.ToString(), 8, FontStyle.Regular);
            this.EditMode = DataGridViewEditMode.EditOnKeystroke;
            this.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.lightDatagrid_DataError);

        }

        private void filterColumns()
        {
            filterColumnList = new ArrayList();
            for (int i = 0; i < ColumnsToBeFiltered.Length; i++)
            {
                filterColumnList.Add(ColumnsToBeFiltered[i].ToString());
            }
        }

        private void dg_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.SortColumn = e.ColumnIndex;
            this.SortDirection = this.SortOrder;

            try
            {
                string columnValueType = this.Columns[e.ColumnIndex].ValueType.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Los datos de la columna no son válidos");
                return;
            }


            if (this.Columns[e.ColumnIndex].ValueType.ToString() == "System.Drawing.Image")
            {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                if (dataSource == null)
                {
                    dataSource = (DataTable)this.DtDatagridSource;
                }

                positionY = e.Y;
                positionX = Cursor.Position.X - 75;

                bool flag = false;
                for (int columnCount = 0; columnCount < dataSource.Columns.Count; columnCount++)
                {
                    if (!flag)
                    {
                        if (this.Columns[columnCount].Name == this.Columns[e.ColumnIndex].Name)
                        {
                            flag = true;
                        }
                    }
                }

                filterColumns();

                ContextMenu filterContextMenu = new ContextMenu();
                if (filterColumnList.Contains(this.Columns[e.ColumnIndex].Name.ToString()))
                {
                    columnName = this.Columns[e.ColumnIndex].Name;

                    //////

                    ArrayList columnFilterList = new ArrayList();

                    if (string.IsNullOrEmpty(CurrentFilterString))
                    {
                        this.mainFilteringColumn = columnName;

                    }

                    DataTable dtPrintersInCurrentFilter = new DataTable();

                    if (mainFilteringColumn == columnName)
                    {
                        dtPrintersInCurrentFilter = DtDatagridSource;
                    }
                    else
                    {
                        if (!(this.DataSource is DataTable))
                        {
                            dtPrintersInCurrentFilter = ((DataView)this.DataSource).ToTable();
                        }
                        else
                        {
                            dtPrintersInCurrentFilter = (DataTable)this.DataSource;
                        }
                    }


                    //////



                    for (int count = 0; count < dtPrintersInCurrentFilter.Rows.Count; count++)
                    {
                        try
                        {
                            string currentRowValue = Convert.ToString(dtPrintersInCurrentFilter.Rows[count][columnName].ToString());

                            DataRow[] rowsInCurrentFilter = dtPrintersInCurrentFilter.Select();


                            if (currentRowValue.Trim().Length != 0)
                            {

                                for (int i = 0; i < rowsInCurrentFilter.Length; i++)
                                {
                                    if (!columnFilterList.Contains(currentRowValue))
                                    {
                                        if (rowsInCurrentFilter[i][columnName].ToString().Trim() == currentRowValue.Trim())
                                        {
                                            columnFilterList.Add(currentRowValue);
                                        }
                                        else if (this.mainFilteringColumn == columnName)
                                        {
                                            columnFilterList.Add(currentRowValue);
                                        }
                                    }
                                }


                            }

                        }
                        catch (Exception ee)
                        {

                            MessageBox.Show(ee.Message.ToString());
                        }
                    }

                    columnFilterList.Sort();

                    for (int count = 0; count < columnFilterList.Count; count++)
                    {
                        MenuItem uniqueColumnsMenuItem = new MenuItem();
                        uniqueColumnsMenuItem.Name = columnFilterList[count].ToString();
                        uniqueColumnsMenuItem.Text = columnFilterList[count].ToString();

                        if (checkedFilterHashTable.Contains(columnName))
                        {
                            if (((ArrayList)checkedFilterHashTable[columnName]).Contains(uniqueColumnsMenuItem.Text))
                                uniqueColumnsMenuItem.Checked = true;
                            else
                                uniqueColumnsMenuItem.Checked = false;
                        }

                        uniqueColumnsMenuItem.Click += new EventHandler(menuItem_Click);
                        filterContextMenu.MenuItems.Add(uniqueColumnsMenuItem);
                    }

                    filterContextMenu.MenuItems.Add("-");
                    MenuItem clearThisFilterMenuItem = new MenuItem();
                    clearThisFilterMenuItem.Name = "Limpiar este filtro";
                    clearThisFilterMenuItem.Text = "Limpiar este filtro";
                    filterContextMenu.MenuItems.Add(clearThisFilterMenuItem);
                    filterContextMenu.MenuItems.Add("-");

                    MenuItem clearAllFilterMenuItem = new MenuItem();
                    clearAllFilterMenuItem.Name = "Limpiar todos los filtros";
                    clearAllFilterMenuItem.Text = "Limpiar todos los filtros";
                    filterContextMenu.MenuItems.Add(clearAllFilterMenuItem);

                    clearThisFilterMenuItem.Click += new EventHandler(menuItem_Click);
                    clearAllFilterMenuItem.Click += new EventHandler(menuItem_Click);

                }

                filterContextMenu.Show(this, new Point(positionX, e.Y));


                return;
            }

            try
            {
                string clickedColumn = this.Columns[e.ColumnIndex].Name;

                if (clickedColumn.ToString() == "printerStatusImage")
                {
                    // Check which column is selected, otherwise set NewColumn to null.
                    DataGridViewColumn newColumn = this.Columns["printerStatus"];

                    DataGridViewColumn oldColumn = this.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not currently sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            this.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }

                    // If no column has been selected, display an error dialog  box.
                    if (newColumn == null)
                    {
                        MessageBox.Show("Select a single column and try again.",
                            "Error: Invalid Selection", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;
                        this.SortDirection = newColumn.HeaderCell.SortGlyphDirection;
                    }
                }

            }
            catch (Exception)
            {
            }

        }

        public void RestoreSortOrder(SortOrder SortDirection, int SortColumn)
        {
            //return;

            switch (SortDirection)
            {
                case SortOrder.Ascending:
                    this.Sort(this.Columns[SortColumn], ListSortDirection.Ascending);
                    break;
                case SortOrder.Descending:
                    this.Sort(this.Columns[SortColumn], ListSortDirection.Descending);
                    break;
                case SortOrder.None:
                    //this.Sort(this.Columns[SortColumn], ListSortDirection.Ascending);
                    break;
            }
        }
        
        private void dg_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                if (CurrentFilterString != string.Empty && CurrentFilterString != null && DataSourceView != null)
                {
                    this.DataSourceView.RowFilter = CurrentFilterString;
                    this.DataSource = DataSourceView;
                }

                if (this.RowCount > 0)
                {
                    foreach (DataGridViewRow row in this.Rows)
                    {
                        row.ContextMenuStrip = this.AssignedContextMenuStrip;

                    }
                }
                else
                {
                    this.ContextMenuStrip = this.AssignedContextMenuStrip;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void menuItem_Click(object sender, EventArgs e)
        {
            string clickedItemString = ((MenuItem)sender).Text;
            if (clickedItemString == "Limpiar este filtro")
            {
                checkedFilterHashTable.Remove(columnName);
                SetDataSource();
            }
            else if (clickedItemString == "Limpiar todos los filtros")
            {
                checkedFilterHashTable.Clear();
                SetDataSource();

            }
            else
            {
                oldCheckedFilterHashTable = checkedFilterHashTable;
                oldFilterString = CurrentFilterString;

                if (checkedFilterHashTable.Contains(columnName))
                {
                    if (((ArrayList)checkedFilterHashTable[columnName]).Contains(clickedItemString))
                        ((ArrayList)checkedFilterHashTable[columnName]).Remove(clickedItemString);
                    else
                        ((ArrayList)checkedFilterHashTable[columnName]).Add(clickedItemString);
                }
                else
                {
                    ArrayList addFilterArrayList = new ArrayList();
                    addFilterArrayList.Add(clickedItemString);
                    checkedFilterHashTable.Add(columnName, addFilterArrayList);
                }
            }

            string filterString = string.Empty;
            CurrentFilterString = string.Empty;

            IDictionaryEnumerator enumerator = checkedFilterHashTable.GetEnumerator();
            ArrayList columnsArrayList = new ArrayList();
            int hashCount = 0;
            while (enumerator.MoveNext())
            {
                columnsArrayList = (ArrayList)enumerator.Value;
                if (columnsArrayList.Count > 0)
                {
                    for (int count = 0; count < columnsArrayList.Count; count++)
                    {
                        if (hashCount == 0 && count == 0)
                            filterString = "(" + enumerator.Key.ToString() + " = '" + columnsArrayList[count].ToString() + "'";
                        else if (hashCount != 0 && count == 0)
                            filterString = filterString + " and (" + enumerator.Key.ToString() + " = '" + columnsArrayList[count].ToString() + "'";
                        else
                            filterString = filterString + " or " + enumerator.Key.ToString() + " = '" + columnsArrayList[count].ToString() + "'";
                    }
                    filterString = filterString + ")";
                    hashCount = 1;
                }
            }

            CurrentFilterString = filterString;


            if (CurrentFilterString.Contains("''"))
            {
                MessageBox.Show("El valor '' no puede ser aplicado como filtro. Intente ordenar en su lugar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SetDataSource();

        }

        public void SetDataSource(DataTable sentDataTable = null)
        {

        SetFilter:

            if(sentDataTable != null)
            {
                this.DtDatagridSource = sentDataTable;
                DataSourceView = new DataView(sentDataTable);
            }
            else
            {
                DataSourceView = new DataView(DtDatagridSource);
            }

            DataSourceView.RowFilter = CurrentFilterString;

            this.DataSource = (DataTable)DataSourceView.ToTable();

            
            if (this.Rows.GetRowCount(DataGridViewElementStates.Visible) == 0 
                && sentDataTable.Rows.Count > 0)
            {
                MessageBox.Show("El filtro que se ha aplicado no ha devuelto ningún resultado. Se restablecerá el último filtro válido.", "Filtro no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.checkedFilterHashTable = oldCheckedFilterHashTable;
                this.CurrentFilterString = oldFilterString;

                this.ContextMenuStrip = null;
                goto SetFilter;

            }

            if (SortColumn > -1)
            {
                RestoreSortOrder(SortDirection, SortColumn);
            }
        }

        private void lightDatagrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
    }
}
