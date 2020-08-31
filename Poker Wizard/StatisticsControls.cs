using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Poker_Wizard
{
    public partial class FrmStatistics : Form
    {
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            CustomParameters parameters = new CustomParameters();

            cbLocation.DataSource = locations;

            parameters.location = cbLocation.Text;
            parameters.startDate = dtpStart.Value;
            parameters.endDate = dtpEnd.Value;
            parameters.minGames = int.Parse(tbMinGamesPlayed.Text);
            parameters.names = new List<string> { "Shawn" };
            parameters.dropGames = cbDropLowest.Checked;
            parameters.league = false;

            PopulateIndividualTab(parameters);

            lbNames.Items.AddRange(allNames.ToArray());
            lbNames.SelectedIndex = 0;
        }

        private void BtnSubmitCustom_Click(object sender, EventArgs e)
        {
            CustomParameters parameters = new CustomParameters
            {
                individual = rbIndividual.Checked,
                table = rbTable.Checked,
                location = cbLocation.Text,
                startDate = dtpStart.Value,
                endDate = dtpEnd.Value,
                minGames = int.Parse(tbMinGamesPlayed.Text),
                names = new List<string>(),
                dropGames = cbDropLowest.Checked,
                league = false
            };

            foreach (object item in lbNames.SelectedItems)
            {
                parameters.names.Add(item.ToString());
            }

            if (rbIndividual.Checked)
            {
                if (parameters.names.Count > 0)
                {
                    PopulateIndividualTab(parameters);
                }
            }
            else
            {
                if (rbTable.Checked)
                {
                    PopulateGroupTab(parameters, tabControlCustom, "Custom");
                }
                else
                {
                    PopulateLineChartTab(parameters, tabControlCustom, "Custom");
                }
            }
        }

        private void BtnSubmitPremade_Click(object sender, EventArgs e)
        {
            CustomParameters parameters = new CustomParameters();
            List<SingleGamePlayerData> playerData = new List<SingleGamePlayerData>();
            int selectedIndex = 0;

            selectedIndex = tabControlPremade.SelectedIndex;

            tabControlPremade.Visible = false;

            tabControlPremade.TabPages.Clear();

            // Get date range
            parameters.startDate = dtpStartPremade.Value;
            parameters.endDate = dtpEndPremade.Value;

            // Get min games played
            parameters.minGames = int.Parse(tbMinGamesPlayedPremade.Text);

            parameters.names = allNames;
            parameters.individual = false;
            parameters.table = true;
            parameters.dropGames = cbDropLowest.Checked;
            parameters.league = false;

            // Get relevant data for each premade tab

            // Overall
            parameters.location = locations[0];
            PopulateGroupTab(parameters, tabControlPremade, "Overall");

            // Avista
            parameters.location = locations[1];
            PopulateGroupTab(parameters, tabControlPremade, "Avista");

            // Avista Season

            // PDC
            parameters.location = locations[2];
            PopulateGroupTab(parameters, tabControlPremade, "PDC");

            // PDC Season
            parameters.names = pdcLeagueNames;
            parameters.league = true;
            PopulateGroupTab(parameters, tabControlPremade, "PDC League");

            // Bankrolls
            parameters.location = locations[0];
            parameters.names = allNames;
            parameters.league = false;
            PopulateLineChartTab(parameters, tabControlPremade, "Bankrolls");

            // Avista Bankrolls
            parameters.location = locations[1];
            PopulateLineChartTab(parameters, tabControlPremade, "Avista Bankrolls");

            // PDC Bankrolls
            parameters.location = locations[2];
            PopulateLineChartTab(parameters, tabControlPremade, "PDC Bankrolls");

            tabControlPremade.SelectedIndex = selectedIndex == -1 ? 0 : selectedIndex;
            tabControlPremade.Visible = true;
        }

        private void RbGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIndividual.Checked)
            {
                lbNames.SelectionMode = SelectionMode.One;
                tbMinGamesPlayed.Enabled = false;
                gbGraphTable.Enabled = false;
            }
            else
            {
                lbNames.SelectionMode = SelectionMode.MultiSimple;
                tbMinGamesPlayed.Enabled = true;
                gbGraphTable.Enabled = true;
            }
        }

        private void TbMinGamesPlayedPremade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbMinGamesPlayed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TabControlType_KeyUp(object sender, KeyEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            if (e.KeyCode == Keys.Enter)
            {
                if (tc.SelectedIndex == 0 )
                {
                    btnSubmitPremade.PerformClick();
                }
                else
                {
                    btnSubmitCustom.PerformClick();
                }
            }
        }

        private void TabControlType_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Equals(tabPremade))
            {
                tabControlPremade.Visible = true;
                tabControlCustom.Visible = false;
            }
            else
            {
                tabControlPremade.Visible = false;
                tabControlCustom.Visible = true;
            }
        }

        private void TabControlCustom_MouseUp(object sender, MouseEventArgs e)
        {
            TabPage page = this.tabControlCustom.SelectedTab;


            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < this.tabControlCustom.TabCount; ++i)
                {
                    if (this.tabControlCustom.GetTabRect(i).Contains(e.Location))
                    {
                        foreach (Control control in this.tabControlCustom.TabPages[i].Controls)
                        {
                            control.Dispose();
                        }
                        this.tabControlCustom.TabPages[i].Dispose();
                    }
                }
            }
        }

        // Compares two ListView items based on a selected column.
        private class ListViewComparer : System.Collections.IComparer
        {
            private readonly int ColumnNumber;
            private readonly SortOrder SortOrder;

            public ListViewComparer(int column_number,
                SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Compare two ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Get the objects as ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Get the corresponding sub-item values.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Compare them.
                int result;
                if (double.TryParse(string_x, out double double_x) &&
                    double.TryParse(string_y, out double double_y))
                {
                    // Treat as a number.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    if (DateTime.TryParse(string_x, out DateTime date_x) &&
                        DateTime.TryParse(string_y, out DateTime date_y))
                    {
                        // Treat as a date.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Treat as a string.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Return the correct result depending on whether
                // we're sorting ascending or descending.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        private ColumnHeader SortingColumn = null;

        public void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lv.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort descending.
                sort_order = SortOrder.Descending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("< "))
                    {
                        sort_order = SortOrder.Ascending;
                    }
                    else
                    {
                        sort_order = SortOrder.Descending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Descending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lv.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            lv.Sort();

            RecolorListItems(lv);
        }

        private static void RecolorListItems(ListView lv)
        {
            for (int index = 0; index < lv.Items.Count; index++)
            {
                var item = lv.Items[index];
                item.BackColor = (index % 2 == 0) ? Color.LightGray : Color.White;
            }
        }

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chart = (sender as Chart);
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var name = result.Series.Name;
                    if (result.Object is DataPoint prop)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 4 &&
                            Math.Abs(pos.Y - pointYPixel) < 4)
                        {
                            tooltip.Show(name + ": " + DateTime.FromOADate(prop.XValue).ToString("%M/dd/yyyy") + ", $" + prop.YValues[0], chart,
                                            pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

    }
}

