//  *****************************************
//  ** DataGridViewColumnSelector ver 1.0  **
//  **                                     **
//  ** Author : Vincenzo Rossi             **
//  ** Country: Naples, Italy              **
//  ** Year   : 2008                       **
//  ** Mail   : redmaster@tiscali.it       **
//  **                                     **
//  ** Released under                      **
//  **   The Code Project Open License     **
//  **                                     **
//  **   Please do not remove this header, **
//  **   I will be grateful if you mention **
//  **   me in your credits. Thank you     **
//  **                                     **
//  *****************************************

//  Copyright 2015 Jhorman Duban Rodr�guez Pulgar�n
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
//  Jhorman Duban Rodr�guez., hereby disclaims all copyright interest in 
//  the program "InkAlert" (which makes passes at 
//  compilers) written by Jhorman Duban Rodr�guez.
//  
//  Jhorman Duban Rodr�guez,
//  5 January 2016
//  For more information, visit <http://www.codigoinnovador.com/projects/inkalert/>


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace InkAlert
{
    /// <summary>
    /// Add column show/hide capability to a DataGridView. When user right-clicks 
    /// the cell origin a popup, containing a list of checkbox and column names, is
    /// shown. 
    /// </summary>
    public class DataGridViewColumnSelector
    {
        // the DataGridView to which the DataGridViewColumnSelector is attached
        private DataGridView mDataGridView = null;
        // a CheckedListBox containing the column header text and checkboxes
        private CheckedListBox mCheckedListBox;
        // a ToolStripDropDown object used to show the popup
        private ToolStripDropDown mPopup;
        
        /// <summary>
        /// The max height of the popup
        /// </summary>
        public int MaxHeight = 600;
        /// <summary>
        /// The width of the popup
        /// </summary>
        public int Width = 200;

        /// <summary>
        /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
        /// </summary>
        public DataGridView DataGridView
        {
            get { return mDataGridView; }
            set { 
                  // If any, remove handler from current DataGridView 
                  //if (mDataGridView != null) mDataGridView.CellMouseClick -= new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
                  // Set the new DataGridView
                  mDataGridView = value;
                  // Attach CellMouseClick handler to DataGridView
                  //if (mDataGridView!=null) mDataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
              }
        }

        // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
        // columns header text. Then it shows the popup. 
        // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
        // DataGridView columns (column additions or name changes and so on).
        public void showColumnMenu(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right && e.RowIndex==-1 && e.ColumnIndex==-1) {
                mCheckedListBox.Items.Clear();
                foreach (DataGridViewColumn c in mDataGridView.Columns){
                    mCheckedListBox.Items.Add(c.HeaderText, c.Visible);
                }
                int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                mCheckedListBox.Width = this.Width;
                mPopup.Show(mDataGridView.PointToScreen(new Point (30,30)));
            //}
        }

        // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
        // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
        // added to ToolStripDropDown.
        public DataGridViewColumnSelector() {
            mCheckedListBox = new CheckedListBox();
            mCheckedListBox.CheckOnClick = true;
            mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);

            ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
            mControlHost.Padding = Padding.Empty;
            mControlHost.Margin = Padding.Empty;
            mControlHost.AutoSize = false;

            mPopup = new ToolStripDropDown();
            mPopup.Padding = Padding.Empty;
            mPopup.Items.Add(mControlHost);
        }

        public DataGridViewColumnSelector(DataGridView dgv) : this() {
            this.DataGridView = dgv;
        }

        // When user checks / unchecks a checkbox, the related column visibility is 
        // switched.
        void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e){
            mDataGridView.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
        }
    }
}
