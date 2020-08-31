using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using MsgBox;
using Poker_Wizard.Properties;
using Color = System.Drawing.Color;

namespace Poker_Wizard
{
    public partial class FrmMain : Form
    {
        private ToolStripMenuItem temp;
        private bool buzzerBuzzing = false;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            temp = this.locationToolStripMenuItem;

            Text = "Poker Wizard - " + settings[Settings.Default.IniSection]["GameLocation"];

            UpdateLocationMenu();

            if (Directory.Exists(Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"])) &&
                settings[Settings.Default.IniSection]["ExistingLocations"].Length != 0 &&
                settings[Settings.Default.IniSection]["GameLocation"].Length != 0)
            {
                pnlPlayersScreen.Visible = false;
                pnlFirstTime.Visible = false;
                pnlMainScreen.Visible = true;
            }
            else
            {
                pnlPlayersScreen.Visible = false;
                pnlFirstTime.Visible = true;
                pnlMainScreen.Visible = false;
            }
        }

        private void LocationClickEvent(object sender, System.EventArgs e)
        {
            temp.CheckState = CheckState.Unchecked;
            temp = (ToolStripMenuItem)sender;
            
            temp.CheckState = CheckState.Checked;

            Text = "Poker Wizard - " + temp.Text;

            settings[Settings.Default.IniSection]["GameLocation"] = temp.Text;
            fileIniData.WriteFile(Settings.Default.IniFile, settings);


            //Settings.Default.Save();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.M)
            {
                if (menuStrip1.Visible)
                {
                    menuStrip1.Visible = false;
                }
                else
                {
                    menuStrip1.Visible = true;
                }
            }
            if (e.KeyCode == Keys.F)
            {
                if (FormBorderStyle == FormBorderStyle.None)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                btnStart.PerformClick();
            }
            if (e.KeyCode == Keys.Oemtilde)
            {
                if (pnlMainScreen.Visible)
                {
                    btnPlayersScreen.PerformClick();
                }
                else
                {
                    btnHomeScreen.PerformClick();
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            fonts.ResizeAllFonts();
        }

        private void BtnFirstTime_Click(object sender, EventArgs e)
        {

            string osDrive = Path.GetPathRoot(Environment.SystemDirectory);
            string currentDrive = settings[Settings.Default.IniSection]["ResultsFolder"].Substring(0, 3);
            if (osDrive != currentDrive)
            {
                settings[Settings.Default.IniSection]["ResultsFolder"] = settings[Settings.Default.IniSection]["ResultsFolder"].Replace(currentDrive, osDrive);
                fileIniData.WriteFile(Settings.Default.IniFile, settings);
            }

            if (Directory.Exists(Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"])))// &&
                //settings[Settings.Default.IniSection]["ExistingLocations"].Length != 0 &&
                //settings[Settings.Default.IniSection]["GameLocation"].Length != 0)
            {
                pnlPlayersScreen.Visible = false;
                pnlFirstTime.Visible = false;
                pnlMainScreen.Visible = true;
            }
            else
            {
                pnlPlayersScreen.Visible = false;
                pnlFirstTime.Visible = true;
                pnlMainScreen.Visible = false;
            }
        }

        private void TableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
            TableLayoutPanel box = sender as TableLayoutPanel;
            DrawGroupBox(box, e.Graphics, Color.White);
        }

        private void BtnHomeScreen_Click(object sender, EventArgs e)
        {
            pnlPlayersScreen.Visible = false;
            pnlMainScreen.Visible = true;
            fonts.ResizeAllFonts();
            //UpdateCurrentGameData(TableLayoutPanelArray.playersLeft);
            UpdateDataControls(currentGameData);
            pnlPlayers.Enabled = false;
            pnlMainScreen.Focus();
        }


        private void BtnPlayersScreen_Click(object sender, EventArgs e)
        {
            int lastRebuyRound = Int32.Parse(settings[Settings.Default.IniSection]["LastRebuyRound"]);

            pnlMainScreen.Visible = false;
            pnlPlayersScreen.Visible = true;
            fonts.ResizeAllFonts();
            pnlPlayers.Enabled = true;
            pnlPlayersScreen.Focus();
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            bool duplicate = false;

            do
            {
                //pnlPlayers.AutoScrollPosition = new Point(0, -100);

                InputBox.ShowDialog("Enter Name", "Add New Player", InputBox.Buttons.OkCancel, InputBox.Type.TextBox, null, false, new Font("Arial", 10F, FontStyle.Bold));
                if (InputBox.ResultValue.Length != 0)
                {
                    foreach (PlayerData playerData in currentGameData.players)
                    {
                        if (playerData.Name == InputBox.ResultValue)
                        {
                            MessageBox.Show("Player already exists.  No duplicates!");
                            duplicate = true;
                        }
                    }

                    if (currentGameData.players.Count < Int32.Parse(settings[Settings.Default.IniSection]["MaximumPlayers"]))
                    {

                        if (!duplicate)
                        {
                            currentGameData.players.Add(new PlayerData(InputBox.ResultValue.ToString()));
                            PlayerControlArray.AddNewPanel(tlpHeaders, currentGameData);
                            UpdateCurrentGameData(currentGameData.players.Count);
                            UpdateDataControls(currentGameData);

                            fonts.ResizeFonts(pnlPlayers);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Currently Limited to " + Int32.Parse(settings[Settings.Default.IniSection]["MaximumPlayers"]) + " players.");
                    }

                    duplicate = false;

                }
            } while (InputBox.ResultValue.Length != 0);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!buzzerBuzzing)
            {
                switch (currentGameData.State)
                {
                    case State.NotStarted:
                        StartGame();
                        break;
                    case State.TimeRunning:
                        Pause();
                        break;
                    case State.Paused:
                        ResumeTimer();
                        break;
                    case State.EndOfRound:
                        StartNextRound();
                        break;
                }

                pnlMainScreen.Focus();
            }
        }

        private void TmrPokerTimer_Tick(object sender, EventArgs e)
        {
            if (currentGameData.Seconds > 0)
            {
                currentGameData.ReduceTime();
                lblTime.Text = currentGameData.GetMinutes().ToString("D2") + ":" + currentGameData.GetSeconds().ToString("D2");
            }

            if (currentGameData.Seconds <= 0)
            {
                if (timerAtZeroCount == 0)
                {
                    buzzerBuzzing = true;
                    SoundPlayer player = new SoundPlayer(Properties.Resources.BUZZER);
                    player.Play();
                    timerAtZeroCount++;
                }
                else if (timerAtZeroCount < 5)
                {
                    // Wait for sound to finish
                    timerAtZeroCount++;
                }
                else
                {
                    buzzerBuzzing = false;
                    EndOfRound();
                }

            }
            else if (currentGameData.Seconds <= Int32.Parse(settings[Settings.Default.IniSection]["LowTime"]))
            {
                lblTime.ForeColor = Color.Red;
            }
        }

        private void SetTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            double time = 0;
            double minimumRoundMinutes = Convert.ToDouble(settings[Settings.Default.IniSection]["MinimumRoundMinutes"]);
            double maximumRoundMinutes = Convert.ToDouble(settings[Settings.Default.IniSection]["MaximumRoundMinutes"]);

            do
            {
                result = InputBox.ShowDialog("Enter Time in Minutes\n(min: " + minimumRoundMinutes + ", max: " + maximumRoundMinutes + ")", "Enter Time", InputBox.Buttons.OkCancel, InputBox.Type.TextBox, null, false, new Font("Arial", 10F, FontStyle.Bold));

            } while ((!double.TryParse(InputBox.ResultValue, out double val) ||
                     Convert.ToDouble(InputBox.ResultValue) < minimumRoundMinutes ||
                     Convert.ToDouble(InputBox.ResultValue) > maximumRoundMinutes) &&
                     result != DialogResult.Cancel);

            if (result == DialogResult.OK && InputBox.ResultValue.Length != 0)
            {
                time = Convert.ToDouble(InputBox.ResultValue);
                if (time <= Convert.ToDouble(settings[Settings.Default.IniSection]["LowMinutes"]))
                {
                    lblTime.ForeColor = Color.Red;
                }
                else
                {
                    lblTime.ForeColor = Color.White;
                }

                currentGameData.SetTime(time);
                UpdateDataControls(currentGameData);
            }
        }

        private void SetRoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            int lastRebuyRound = Int32.Parse(settings[Settings.Default.IniSection]["LastRebuyRound"]);

            do
            {
                result = InputBox.ShowDialog("Enter Round\n(min: 1, max: " + settings[Settings.Default.IniSection]["MaximumRounds"] + ", no decimals)", "Enter Round", InputBox.Buttons.OkCancel, InputBox.Type.TextBox, null, false, new Font("Arial", 10F, FontStyle.Bold));

            } while ((!int.TryParse(InputBox.ResultValue, out int val) ||
                      Convert.ToInt32(InputBox.ResultValue) == 0 ||
                      Convert.ToInt32(InputBox.ResultValue) > Int32.Parse(settings[Settings.Default.IniSection]["MaximumRounds"])) &&
                      result != DialogResult.Cancel);

            if (result == DialogResult.OK && InputBox.ResultValue.Length != 0)
            {
                currentGameData.Round = Convert.ToInt32(InputBox.ResultValue);

                if (currentGameData.Round < lastRebuyRound)
                {
                    lblNoRebuys.Text = "No rebuys after this round!";
                    lblNoRebuys.Visible = false;
                }
                else if (currentGameData.Round == lastRebuyRound)
                {
                    lblNoRebuys.Visible = true;
                    lblNoRebuys.Text = "No rebuys after this round!";
                    Fonts.ResizeFont(lblNoRebuys);
                }
                else if (currentGameData.Round > lastRebuyRound)
                {
                    lblNoRebuys.Text = "No rebuys!!!!";
                    lblNoRebuys.Visible = true;
                    Fonts.ResizeFont(lblNoRebuys);
                }

                UpdateDataControls(currentGameData);
            }

            fonts.ResizeAllFonts();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings.ShowDialog(this);
            // reload ini file
            //InitializeINI();
            //UpdateCurrentGameData(currentGameData.players.Count);
            //UpdateDataControls(currentGameData);
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            ReloadIni();
            UpdateLocationMenu();
            UpdateCurrentGameData(currentGameData.PlayersLeft);
            UpdateDataControls(currentGameData);
        }

        private void StatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string resultsPath = Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"]);

            if (!Directory.Exists(resultsPath))
            {
                MessageBox.Show("Please go to settings and set a results folder location.");
            }
            else if (IsDirectoryEmpty(resultsPath))
            {
                MessageBox.Show("Chosen results folder is empty.  Go to settings and select a different results folder.");
            }
            else
            {
                FrmStatistics Statistics = new FrmStatistics(frmSettings);
                Statistics.Show();
            }


        }

        private static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void UpdateLeagueStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSeasonStats();

            MessageBox.Show("Season stats have been updated.");
        }

        private void UpdateLastGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<List<string>> lastGameData;
            string location;
            FrmStatistics Statistics = new FrmStatistics(frmSettings);

            lastGameData = Statistics.GetLastGameData();

            while (lastGameData.Count < 14)
            {
                lastGameData.Add(new List<string>() { "", "", "", "", "", "", "" });
            }

            location = lastGameData[0][1];

            UpdateGoogleSpreadsheetCell("1pgtVGwY1ba3BxL5p5HwS_aYpDj1Go_Y1UPgam9S57Ac", "'" + location.ToUpper() + " Last Game'!C3", lastGameData[0][0]);

            lastGameData.Remove(lastGameData.First());
            UpdateGoogleSpreadsheetCellRange("1pgtVGwY1ba3BxL5p5HwS_aYpDj1Go_Y1UPgam9S57Ac", "'" + location.ToUpper() + " Last Game'!C7:I20", lastGameData);

            MessageBox.Show("Last Game stats have been updated.");
        }
    }
}
