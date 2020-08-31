using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Poker_Wizard.Properties;
using Color = System.Drawing.Color;
using System.Configuration;
using System.Collections;
using IniParser;
using IniParser.Model;

namespace Poker_Wizard
{
    public enum State
    {
        NotStarted,
        TimeRunning,
        Paused,
        EndOfRound,
        EndOfGame
    }

    public partial class FrmMain : Form
    {
        private TableLayoutPanelArray PlayerControlArray;
        private CurrentGameData currentGameData;
        private int timerAtZeroCount = 0;

        private SettingsForm frmSettings;
        private Fonts fonts;
        private FileIniDataParser fileIniData = new FileIniDataParser();
        private IniData settings = new IniData();
        

        public FrmMain()
        {
            InitializeComponent();

            InitializeINI();
            currentGameData = new CurrentGameData();

            // Create control array for player screen (name, rebuys, rebuy button, remove button)
            PlayerControlArray = new TableLayoutPanelArray(pnlPlayers, this);

            // Create settings form
            frmSettings = new SettingsForm(this, tlpHeaders, PlayerControlArray, currentGameData);

            fonts = new Fonts(this);

            // Add default player names
            List<string> startingPlayers = settings[Settings.Default.IniSection]["StartingPlayerNames"].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in startingPlayers)
            {
                currentGameData.players.Add(new PlayerData(s));
                PlayerControlArray.AddNewPanel(tlpHeaders, currentGameData);
            }

            // Refresh data with new info
            UpdateCurrentGameData(startingPlayers.Count);
            UpdateDataControls(currentGameData);

            fonts.ResizeAllFonts();

            pnlMainScreen.BringToFront();

            // Disable players panel since we start on main screen
            pnlPlayers.Enabled = false;

            // Disable rebuy buttons untill game has started
            PlayerControlArray.DisableRebuyButtons();

        }

        private void InitializeINI()
        {
            if (File.Exists(Settings.Default.IniFile))
            {
                settings = fileIniData.ReadFile(Settings.Default.IniFile);
            }
            else
            {
                settings.Sections.AddSection("default");
                settings["default"].AddKey("Blinds", "0");
                settings["default"].AddKey("Bounties", "0");
                settings["default"].AddKey("NumberOfStartingPlayers", "4");
                settings["default"].AddKey("TimeIsPerPlayer", "false");
                settings["default"].AddKey("SecondsPerRound", "1800");
                settings["default"].AddKey("SecondsPerPlayer", "240");
                settings["default"].AddKey("MaxSecondsPerRound", "1920");
                settings["default"].AddKey("StartingChips", "1500");
                settings["default"].AddKey("BuyinCost", "10");
                settings["default"].AddKey("MaximumPlayers", "14");
                settings["default"].AddKey("LowTime", "120");
                settings["default"].AddKey("MinimumRoundMinutes", "0.1");
                settings["default"].AddKey("LowMinutes", "2");
                settings["default"].AddKey("MaximumRoundMinutes", "60");
                settings["default"].AddKey("MaximumRounds", "20");
                settings["default"].AddKey("LastRebuyRound", "6");
                settings["default"].AddKey("StartingPlayerNames", "Shawn, Jeremy, Lucas, Christy");
                settings["default"].AddKey("MaximumRebuys", "9");
                settings["default"].AddKey("UniqueBlindRounds", "11");
                settings["default"].AddKey("ExistingLocations", "");
                settings["default"].AddKey("ResultsFolder", "");
                settings["default"].AddKey("GameLocation", "");
                fileIniData.WriteFile(Settings.Default.IniFile, settings);
            }
        }

        private void ReloadIni()
        {
            settings = fileIniData.ReadFile(Settings.Default.IniFile);
            currentGameData.ReadIni();
            PlayerControlArray.ReadIni();
        }

        public int GetPlayerPanelWidth()
        {
            return tlpHeaders.Width;
        }

        //**********************************************************************
        //
        //  Updates calculated game data based on number of players remaining
        //  and number of rebuys
        // 
        //**********************************************************************
        public void UpdateCurrentGameData(int numPlayers)
        {
            int rebuyCount = 0;
            bool timeIsPerPlayer = Convert.ToBoolean(settings[Settings.Default.IniSection]["TimeIsPerPlayer"]);
            int secondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerRound"]);
            int secondsPerPlayer = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerPlayer"]);
            int maxSecondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["MaxSecondsPerRound"]);

            foreach (PlayerData p in currentGameData.players)
            {
                rebuyCount += p.Rebuys;
            }

            if (currentGameData.State == State.NotStarted)
            {
                currentGameData.StartingPlayers = numPlayers;

                if (timeIsPerPlayer)
                {
                    currentGameData.Seconds = Math.Min((currentGameData.StartingPlayers * secondsPerPlayer), maxSecondsPerRound);
                }
                else
                {
                    currentGameData.Seconds = secondsPerRound;
                }
            }

            currentGameData.PlayersLeft = numPlayers;
            currentGameData.TotalChips = (currentGameData.StartingPlayers + rebuyCount) * Int32.Parse(settings[Settings.Default.IniSection]["StartingChips"]);
            currentGameData.AverageStack = currentGameData.TotalChips / numPlayers;

            currentGameData.Pot = (currentGameData.StartingPlayers + rebuyCount) * Int32.Parse(settings[Settings.Default.IniSection]["BuyinCost"]);

            currentGameData.SetPayouts();
        }

        private void StartGame()
        {
            int lastRebuyRound = Int32.Parse(settings[Settings.Default.IniSection]["LastRebuyRound"]);

            tmrPokerTimer.Enabled = true;
            btnStart.Text = "Pause";
            currentGameData.State = State.TimeRunning;
            btnAddPlayer.Enabled = false;
            settingsToolStripMenuItem.Enabled = false;

            if (currentGameData.Round == lastRebuyRound)
            {
                lblNoRebuys.Visible = true;
                lblNoRebuys.Text = "No rebuys after this round!";
                Fonts.ResizeFont(lblNoRebuys);
            }
            else if (currentGameData.Round > lastRebuyRound)
            {
                lblNoRebuys.Visible = true;
                lblNoRebuys.Text = "No rebuys!!!!";
                Fonts.ResizeFont(lblNoRebuys);
            }

            if (lastRebuyRound == 0)
            {
                PlayerControlArray.DisableRebuyButtons();
            }
            else
            {
                PlayerControlArray.EnableRebuyButtons();
            }
        }

        private void Pause()
        {
            tmrPokerTimer.Enabled = false;
            btnStart.Text = "Continue";
            currentGameData.State = State.Paused;
        }

        private void ResumeTimer()
        {
            tmrPokerTimer.Enabled = true;
            btnStart.Text = "Pause";
            currentGameData.State = State.TimeRunning;
        }

        private void EndOfRound()
        {
            currentGameData.State = State.EndOfRound;
            btnStart.Text = "Start";
            tmrPokerTimer.Enabled = false;
            PlayerControlArray.EnableRemoveButtons();
            PlayerControlArray.EnableRebuyButtons();
        }

        public void EndOfGame(List<Label> placeLabels)
        {
            string path = Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"]) + "\\" + settings[Settings.Default.IniSection]["GameLocation"];

            // Set remaining place label to 1st
            placeLabels.First(label => label.Text.Length == 0).Text = "1st";

            // Set the remaining players place to 1
            currentGameData.players.First(player => player.Eliminated == false).Place = 1;

            currentGameData.State = State.EndOfGame;

            // Sort the player list by place
            List<PlayerData> sortedList = currentGameData.players.OrderBy(player => player.Place).ToList();

            // Create directory in case it doesn't exist
            Directory.CreateDirectory(path);

            // Save the results
            using (StreamWriter writer = new StreamWriter(path + "\\Poker Results " + DateTime.Now.ToString("M-d-yyyy") + ".txt"))
            {
                writer.WriteLine("Poker Results " + DateTime.Now.ToString("M-d-yyyy"));
                foreach (PlayerData playerData in sortedList)
                {
                    writer.WriteLine(playerData.Place + " - " + playerData.Name + ", " + playerData.Rebuys + ", " + playerData.Bounties);
                }
            }

            // Calculate values for last game played
            //UpdateLastGameStats(sortedList);

            MessageBox.Show("Results have been saved to drop box.");
        }

        private void UpdateLastGameStats(List<PlayerData> sortedList)
        {
            List<List<string>> valueList = new List<List<string>>();
            string date = "";

            foreach (PlayerData data in sortedList)
            {
                string place = data.Place.ToString();
                string name = data.Name;
                double spent = (data.Rebuys * 10 + 10);
                double won = 0;
                double net = 0;
                string rebuys = data.Rebuys.ToString();
                double points = Math.Max(sortedList.Count() - data.Place + 1 - (data.Rebuys * 0.5), 0);

                if (data.Place <= 4)
                {
                    won = currentGameData.GetPayouts()[data.Place - 1];
                }

                net = won - spent;


                valueList.Add(new List<string> { place, name, spent.ToString(), won.ToString(), net.ToString(), rebuys, points.ToString() });
            }

            while (valueList.Count <= Int32.Parse(settings[Settings.Default.IniSection]["MaximumPlayers"]) - sortedList.Count)
            {
                valueList.Add(new List<string> { "", "", "", "", "", "", "" });
            }

            UpdateGoogleSpreadsheetCellRange("1pgtVGwY1ba3BxL5p5HwS_aYpDj1Go_Y1UPgam9S57Ac", "'" + settings[Settings.Default.IniSection]["GameLocation"].ToUpper() + " Last Game'!C7:I20", valueList);

            if (DateTime.Today.Hour < 2)
            {
                date = DateTime.Today.ToString("MMMM") + " " + DateTime.Today.Date.Day.ToString() + GetDaySuffix(DateTime.Today.Date.Day);
            }
            else
            {
                date = DateTime.Today.ToString("MMMM") + " " + (DateTime.Today.Date.Day - 1).ToString() + GetDaySuffix(DateTime.Today.Date.Day);
            }

            date = "Results for " + date;

            UpdateGoogleSpreadsheetCell("1pgtVGwY1ba3BxL5p5HwS_aYpDj1Go_Y1UPgam9S57Ac", "'" + settings[Settings.Default.IniSection]["GameLocation"].ToUpper() + " Last Game'!C3", date);
        }

        public static string GetDaySuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        private void UpdateSeasonStats()
        {
            List<List<string>> leagueData;
            FrmStatistics Statistics = new FrmStatistics(frmSettings);

            leagueData = Statistics.GetLeagueData();

            //MessageBox.Show(settings[Settings.Default.IniSection]["GameLocation"].ToUpper());

            UpdateGoogleSpreadsheetCellRange("1pgtVGwY1ba3BxL5p5HwS_aYpDj1Go_Y1UPgam9S57Ac", "'" + settings[Settings.Default.IniSection]["GameLocation"].ToUpper() + " Seasons'!C5:P8", leagueData);
        }

        public void StartNextRound()
        {
            int seconds;
            bool timeIsPerPlayer = Convert.ToBoolean(settings[Settings.Default.IniSection]["TimeIsPerPlayer"]);
            int secondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerRound"]);
            //int secondsPerPlayer = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerPlayer"]);
            //int maxSecondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["MaxSecondsPerRound"]);
            int lastRebuyRound = Int32.Parse(settings[Settings.Default.IniSection]["LastRebuyRound"]);

            //if (timeIsPerPlayer)
            //{
            //    seconds = secondsPerPlayer;
            //}
            //else
            //{
            //    seconds = secondsPerRound;
            //}

            currentGameData.NextRound();
            currentGameData.ResetTime();

            if (currentGameData.Round == lastRebuyRound)
            {
                lblNoRebuys.Visible = true;
                lblNoRebuys.Text = "No rebuys after this round!";
                Fonts.ResizeFont(lblNoRebuys);
            }
            else if (currentGameData.Round > lastRebuyRound)
            {
                lblNoRebuys.Visible = true;
                lblNoRebuys.Text = "No rebuys!!!!";
                Fonts.ResizeFont(lblNoRebuys);
            }

            lblRound.Text = "Round " + currentGameData.Round;
            lblBlinds.Text = currentGameData.GetBlinds();
            lblNextBlinds.Text = currentGameData.GetNextBlinds();

            lblTime.ForeColor = Color.White;

            lblTime.Text = currentGameData.GetMinutes().ToString("D2") + ":" + currentGameData.GetSeconds().ToString("D2");
            tmrPokerTimer.Enabled = true;

            //Reset sound counter
            timerAtZeroCount = 0;

            currentGameData.State = State.TimeRunning;
            btnStart.Text = "Pause";

            fonts.ResizeAllFonts();
        }

        public void UpdateDataControls(CurrentGameData currentGameData)
        {
            lblPlayersLeftVal.Text = currentGameData.PlayersLeft.ToString();
            lblTotalChipsVal.Text = currentGameData.TotalChips.ToString();
            lblAvgStackVal.Text = currentGameData.AverageStack.ToString();
            lblTime.Text = currentGameData.GetMinutes().ToString("D2") + ":" + currentGameData.GetSeconds().ToString("D2");
            lblRound.Text = "Round " + currentGameData.Round;
            lblBlinds.Text = currentGameData.GetBlinds();
            lblNextBlinds.Text = currentGameData.GetNextBlinds();
            lblPotVal.Text = "$" + currentGameData.Pot;
            lblFirstVal.Text = "$" + currentGameData.GetPayouts()[0];
            lblSecondVal.Text = "$" + currentGameData.GetPayouts()[1];
            lblThirdVal.Text = "$" + currentGameData.GetPayouts()[2];
            lblFourthVal.Text = "$" + currentGameData.GetPayouts()[3];
        }

        private void UpdateLocationMenu()
        {
            locationToolStripMenuItem.DropDownItems.Clear();
            List<string> existingLocations = settings[Settings.Default.IniSection]["ExistingLocations"].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string location in existingLocations)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(location);
                item.Click += new System.EventHandler(this.LocationClickEvent);

                if (string.Equals(location, settings[Settings.Default.IniSection]["GameLocation"]))
                {
                    item.PerformClick();// = CheckState.Checked;
                }
                else
                {
                    item.CheckState = CheckState.Unchecked;
                }

                locationToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        private void DrawGroupBox(TableLayoutPanel box, Graphics g, Color borderColor)
        {
            if (box != null)
            {

                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush, this.Height / 100);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void UpdateGoogleSpreadsheetCellRange(string spreadSheetID, string range, List<List<string>> valueList)
        {
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "Update Poker Data";

            UserCredential credential;
            string credentialsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Dropbox\\Projects\\Poker Wizard\\Poker Wizard\\credentials.json";

            using (var stream =
                new FileStream(credentialsPath, FileMode.Open, FileAccess.ReadWrite))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            List<ValueRange> dataList = new List<ValueRange>();

            var obList = new List<object>();
            var data = new ValueRange
            {
                Values = valueList.Select(list => list.ToArray()).ToArray(),
                Range = range
            };

            dataList.Add(data);

            BatchUpdateValuesRequest requestBody = new BatchUpdateValuesRequest
            {
                ValueInputOption = "RAW",
                Data = dataList
            };

            SpreadsheetsResource.ValuesResource.BatchUpdateRequest request = service.Spreadsheets.Values.BatchUpdate(requestBody, spreadSheetID);

            BatchUpdateValuesResponse response = request.Execute();
        }

        private void UpdateGoogleSpreadsheetCell(string spreadSheetID, string cell, string value)
        {
            List<List<string>> valueList = new List<List<string>>
            {
                new List<string> { value }
            };

            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "Update Poker Data";

            UserCredential credential;
            string credentialsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Dropbox\\Projects\\Poker Wizard\\Poker Wizard\\credentials.json";

            using (var stream =
                new FileStream(credentialsPath, FileMode.Open, FileAccess.ReadWrite))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            List<ValueRange> dataList = new List<ValueRange>();

            var obList = new List<object>();
            var data = new ValueRange
            {
                Values = valueList.Select(list => list.ToArray()).ToArray(),
                Range = cell
            };

            dataList.Add(data);

            BatchUpdateValuesRequest requestBody = new BatchUpdateValuesRequest
            {
                ValueInputOption = "RAW",
                Data = dataList
            };

            SpreadsheetsResource.ValuesResource.BatchUpdateRequest request = service.Spreadsheets.Values.BatchUpdate(requestBody, spreadSheetID);

            BatchUpdateValuesResponse response = request.Execute();
        }
    }
}
 