using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Wizard.Properties;
using System.IO;
using IniParser;
using IniParser.Model;

namespace Poker_Wizard
{
    public partial class SettingsForm : Form
    {
        private List<Panel> Panels = new List<Panel>();
        private Panel VisiblePanel = null;
        private TableLayoutPanel _header;
        private Fonts fonts;

        private FileIniDataParser fileIniData = new FileIniDataParser();
        private IniData settings;

        enum Bounty
        {
            None,
            OnRebuy,
            OnElimination
        };

        enum Blinds
        {
            PDC,
            AVISTA,
            Custom
        };

        public SettingsForm(Form main, TableLayoutPanel headers, TableLayoutPanelArray playerControlArray, CurrentGameData currentGameData)
        {
            _header = headers;

            fonts = new Fonts(main);

            InitializeComponent();
            this.btnSettingsApply.Click += new System.EventHandler((sender, e) => BtnSettingsApply_Click(this, e, playerControlArray, currentGameData));
            this.btnSettingsOK.Click += new System.EventHandler((sender, e) => BtnSettingsOK_Click(this, e, playerControlArray, currentGameData));

            settings = fileIniData.ReadFile(Settings.Default.IniFile);

            switch (Int32.Parse(settings[Settings.Default.IniSection]["Bounties"]))
            {
                case 0:
                    rbNone.Checked = true;
                    HideBountyColumn(_header, playerControlArray);
                    break;
                case 1:
                    rbOnRebuy.Checked = true;
                    ShowBountyColumn(_header, playerControlArray);
                    break;
                case 2:
                    rbOnElimination.Checked = true;
                    ShowBountyColumn(_header, playerControlArray);
                    break;
                default:
                    break;
            }

            switch (Int32.Parse(settings[Settings.Default.IniSection]["Blinds"]))
            {
                case 0:
                    rbPDC.Checked = true;
                    break;
                case 1:
                    rbAVISTA.Checked = true;
                    break;
                case 2:
                    rbCustom.Checked = true;
                    break;
                default:
                    break;
            }

            if (bool.Parse(settings[Settings.Default.IniSection]["TimeIsPerPlayer"]))
            {
                rbPerPlayer.Checked = true;
            }
            else
            {
                rbPerRound.Checked = true;
            }

            nudRoundLength.Value = (Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerPlayer"]) / 60);
            nudMaxRoundLength.Value = (Int32.Parse(settings[Settings.Default.IniSection]["MaxSecondsPerRound"]) / 60);
            nudStartingChips.Value = Int32.Parse(settings[Settings.Default.IniSection]["StartingChips"]);
            nudBuyinCost.Value = Int32.Parse(settings[Settings.Default.IniSection]["BuyinCost"]);
            nudLastRebuyRound.Value = Int32.Parse(settings[Settings.Default.IniSection]["LastRebuyRound"]);

            List<string> existingLocations = settings[Settings.Default.IniSection]["ExistingLocations"].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string location in existingLocations)
            {
                lbExistingLocations.Items.Add(location);
            }

            tbSaveFolder.Text = settings[Settings.Default.IniSection]["ResultsFolder"];
        }

        private void BtnSettingsApply_Click(object sender, EventArgs e, TableLayoutPanelArray playerControlArray, CurrentGameData currentGameData)
        {
            int roundLengthInMinutes = Int32.Parse(nudRoundLength.Text);
            int maxRoundLengthInMinutes = Int32.Parse(nudMaxRoundLength.Text);

            // Set round time and round type settings
            if (rbPerPlayer.Checked)
            {
                settings[Settings.Default.IniSection]["SecondsPerPlayer"] = (roundLengthInMinutes * 60).ToString();
                settings[Settings.Default.IniSection]["MaxSecondsPerRound"] = (maxRoundLengthInMinutes * 60).ToString();
                settings[Settings.Default.IniSection]["TimeIsPerPlayer"] = true.ToString();
            }
            else if (rbPerRound.Checked)
            {
                settings[Settings.Default.IniSection]["SecondsPerRound"] = (roundLengthInMinutes * 60).ToString();
                settings[Settings.Default.IniSection]["TimeIsPerPlayer"] = false.ToString();
            }

            if (Equals(settings[Settings.Default.IniSection]["Bounties"], "0"))
            {
                HideBountyColumn(_header, playerControlArray);
            }
            else
            {
                ShowBountyColumn(_header, playerControlArray);
            }

            // Save starting chips
            settings[Settings.Default.IniSection]["StartingChips"] = nudStartingChips.Value.ToString();

            // Save rebuy info
            settings[Settings.Default.IniSection]["BuyinCost"] = nudBuyinCost.Value.ToString();
            settings[Settings.Default.IniSection]["LastRebuyRound"] = nudLastRebuyRound.Value.ToString();

            currentGameData.ChangeBlindsSchedule(Int32.Parse(settings[Settings.Default.IniSection]["Blinds"]));

            // Save Results Folder
            settings[Settings.Default.IniSection]["ResultsFolder"] = tbSaveFolder.Text;

            fonts.ResizeAllFonts();
            //Properties.Settings.Default.Save(); // Saves settings in application configuration file
            fileIniData.WriteFile(Settings.Default.IniFile, settings);

            // Activate main form in order to update displayed data
            // main form updates dispalyed data on activate
            Application.OpenForms["frmMain"].Activate();
        }

        private void BtnSettingsOK_Click(object sender, EventArgs e, TableLayoutPanelArray playerControlArray, CurrentGameData currentGameData)
        {
            BtnSettingsApply_Click(sender, e, playerControlArray, currentGameData);
            this.Close();
        }

        private void BtnSettingsCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GbBounty_CheckChanged(object sender, EventArgs e)
        {
            int bounty = 0;

            if (sender == rbNone)
            {
                bounty = (int)Bounty.None;
            }
            else if (sender == rbOnRebuy)
            {
                bounty = (int)Bounty.OnRebuy;
            }
            else if (sender == rbOnElimination)
            {
                bounty = (int)Bounty.OnElimination;
            }

            settings[Settings.Default.IniSection]["Bounties"] = bounty.ToString();
        }

        private void GbBlinds_CheckChanged(object sender, EventArgs e)
        {
            int blinds = 0;

            if (sender == rbPDC)
            {
                blinds = (int)Blinds.PDC;
            }
            else if (sender == rbAVISTA)
            {
                blinds = (int)Blinds.AVISTA;
            }
            else if (sender == rbCustom)
            {
                blinds = (int)Blinds.Custom;
            }

            settings[Settings.Default.IniSection]["Blinds"] = blinds.ToString();
        }

        private static void HideBountyColumn(TableLayoutPanel header, TableLayoutPanelArray playerControlArray)
        {
            header.ColumnStyles.Clear();
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));

            foreach (TableLayoutPanel c in playerControlArray)
            {
                c.ColumnStyles.Clear();
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            }
        }

        private static void ShowBountyColumn(TableLayoutPanel header, TableLayoutPanelArray playerControlArray)
        {
            header.ColumnStyles.Clear();
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));

            foreach (TableLayoutPanel c in playerControlArray)
            {
                c.ColumnStyles.Clear();
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
                c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            }
        }

        private void TvSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        // Display the appropriate Panel.
        private void DisplayPanel(int index)
        {
            if (Panels.Count < 1) return;

            // If this is the same Panel, do nothing.
            if (VisiblePanel == Panels[index]) return;

            // Hide the previously visible Panel.
            if (VisiblePanel != null) VisiblePanel.Visible = false;

            // Display the appropriate Panel.
            Panels[index].Visible = true;
            VisiblePanel = Panels[index];
        }

        private Boolean firstTime = true;
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (firstTime == true)
            {
                // Move the Panels out of the TabControl.
                tcSettings.Visible = false;
                foreach (TabPage page in tcSettings.TabPages)
                {
                    // Add the Panel to the list.
                    Panel panel = page.Controls[0] as Panel;
                    Panels.Add(panel);

                    // Reparent and move the Panel.
                    panel.Parent = tcSettings.Parent;
                    panel.Location = tcSettings.Location;
                    panel.Visible = false;
                }

                // Display the first panel.
                DisplayPanel(0);

                firstTime = false;
            }
        }

        private void BtnAddLocation_Click(object sender, EventArgs e)
        {
            string seperator = "";

            if (!Equals(settings[Settings.Default.IniSection]["ExistingLocations"], ""))
            {
                seperator = ", ";
            }

            if (tbNewLocation.TextLength != 0)
            {
                lbExistingLocations.Items.Add(tbNewLocation.Text);
                //Settings.Default.ExistingLocations.Add(tbNewLocation.Text);
                settings[Settings.Default.IniSection]["ExistingLocations"] += seperator + tbNewLocation.Text;
                tbNewLocation.Text = "";
            }
        }

        private void TbNewLocation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddLocation.PerformClick();
            }
        }

        private void BtnRemoveLocation_Click(object sender, EventArgs e)
        {
            //Settings.Default.ExistingLocations.Remove(lbExistingLocations.SelectedItem.ToString());

            settings[Settings.Default.IniSection]["ExistingLocations"] = settings[Settings.Default.IniSection]["ExistingLocations"].Replace(lbExistingLocations.SelectedItem.ToString() + ", ", string.Empty);
            settings[Settings.Default.IniSection]["ExistingLocations"] = settings[Settings.Default.IniSection]["ExistingLocations"].Replace(", " + lbExistingLocations.SelectedItem.ToString(), string.Empty);
            lbExistingLocations.Items.Remove(lbExistingLocations.SelectedItem);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdSaveFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                //settings[Settings.Default.IniSection]["ResultsFolder"] = fbdSaveFolder.SelectedPath;
                tbSaveFolder.Text = fbdSaveFolder.SelectedPath;
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
            if (tbSettingsName.TextLength != 0)
            {
                //
            }
        }

    }
}
