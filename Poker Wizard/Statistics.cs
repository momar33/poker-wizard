using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Poker_Wizard.Properties;
using IniParser;
using IniParser.Model;

namespace Poker_Wizard
{
    struct CustomParameters
    {
        public bool individual;
        public bool table;
        public string location;
        public DateTime startDate;
        public DateTime endDate;
        public int minGames;
        public List<string> names;
        public bool dropGames;
        public bool league;
    }

    public partial class FrmStatistics : Form
    {
        private List<SingleGamePlayerData> allSingleGamePlayerData = new List<SingleGamePlayerData>();
        private List<SinglePlayerData> allPlayerData = new List<SinglePlayerData>();
        private List<SingleGameData> gameData = new List<SingleGameData>();
        ListView[] lvTemp = new ListView[2];
        private List<string> allNames = new List<string>();
        private string PokerDataDirectory { get; set; }
        public static List<string> locations = new List<string> { "All" };
        
        public enum TabPageType { IndividualTable, GroupTable, IndividualChart, GroupChart }

        public static DateTime seasonStartDate = new DateTime(2019, 9, 26); // change to setting

        private FileIniDataParser fileIniData = new FileIniDataParser();
        private IniData settings;

        private List<string> pdcLeagueNames = new List<string> { "Shawn", "Lucas", "Christy", "Jeremy" };

        private readonly List<string> groupHeaders = new List<string>() { "Player",
                                                                           "Spent",
                                                                           "Won",
                                                                           "Net",
                                                                           "Points",
                                                                           "Avg Spent",
                                                                           "Avg Won",
                                                                           "Avg Net",
                                                                           "Avg Points",
                                                                           "Avg Place",
                                                                           "Games",
                                                                           "Rebuys",
                                                                           "Avg Rebuys",
                                                                           "% Beaten"};

        private readonly List<string> summaryHeaders = new List<string>() { "",
                                                                            "Place",
                                                                            "Spent",
                                                                            "Won",
                                                                            "Net",
                                                                            "Points",
                                                                            "Rebuys",
                                                                            "% Beaten"};

        private readonly List<string> individualHeaders = new List<string>() {"Date",
                                                                              "Location",
                                                                              "Place",
                                                                              "Spent",
                                                                              "Won",
                                                                              "Net",
                                                                              "Points",
                                                                              "Rebuys",
                                                                              "Bounties" };

        public FrmStatistics(Form frmSettings)
        {
            InitializeComponent();

            settings = fileIniData.ReadFile(Settings.Default.IniFile);

            LoadAllGameData();
        }

        private void LoadAllGameData()
        {
            string playerName = "";
            int playerPlace = 0;
            int playerRebuys = 0;
            int playerBounties = 0;

            DateTime gameDate = new DateTime();
            string gameLocation;
            double potSize = 0;

            //MessageBox.Show(Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"]));

            foreach (var folder in Directory.EnumerateDirectories(Environment.ExpandEnvironmentVariables(settings[Settings.Default.IniSection]["ResultsFolder"])))
            {
                foreach (var file in Directory.EnumerateFiles(folder, "*.txt"))
                {
                    List<SingleGamePlayerData> playerDataList = new List<SingleGamePlayerData>();

                    var fileStream = new FileStream(@file, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string line;

                        int totalRebuys = 0;
                        int numPlayers = 0;

                        // Get Date
                        line = streamReader.ReadLine();
                        gameDate = DateTime.Parse(line.Substring(14));

                        gameLocation = Path.GetFileName(Path.GetDirectoryName(file));

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            // process the line
                            string[] subStrings = Regex.Split(line, ", ");
                            string[] subStrings2 = Regex.Split(subStrings[0], " - ");

                            playerName = subStrings2[1];
                            playerPlace = Int32.Parse(subStrings2[0]);
                            playerRebuys = Int32.Parse(subStrings[1]);
                            playerBounties = Int32.Parse(subStrings[2]);
                            totalRebuys += playerRebuys;
                            numPlayers++;

                            playerDataList.Add(new SingleGamePlayerData(playerName, playerPlace, playerRebuys, playerBounties, gameLocation, gameDate));

                            // Add player name to name list if its not  already there
                            if (allNames.FindIndex(o => string.Equals(playerName, o, StringComparison.OrdinalIgnoreCase)) < 0)
                            {
                                allNames.Add(playerName);
                            }

                            // Add location to list if its not  already there
                            if (locations.FindIndex(o => string.Equals(gameLocation, o, StringComparison.OrdinalIgnoreCase)) < 0)
                            {
                                locations.Add(gameLocation);
                            }

                        }

                        potSize = (numPlayers + totalRebuys) * 10;

                        playerDataList.ForEach(playerData => playerData.CalcRemainingData(numPlayers, totalRebuys));

                        // Add individual player data to list
                        allSingleGamePlayerData.AddRange(playerDataList);

                        // Create new game data
                        gameData.Add(new SingleGameData(gameDate, gameLocation, playerDataList));
                    }
                }
            }

            foreach ( string name in allNames)
            {
                SinglePlayerData singlePlayerData = new SinglePlayerData(allSingleGamePlayerData, name, locations);
                allPlayerData.Add(singlePlayerData);
            }

            // sort names alphabetically
            allNames.Sort();
        }

        private void CreateIndividualTabPage(string name, Control[] controlArray)
        {
            // Create new tab
            TabPage newTabPage = new TabPage();
            ListView lvGames = new ListView();
            ListView lvSummary = new ListView();

            // Create page and controls
            TableLayoutPanel tempPanel = new TableLayoutPanel();
            Label lblSummary = new Label();
            Label lblGames = new Label();
            Font labelFont = new Font("Arial", 20, FontStyle.Bold);

            // assign temp listview
            controlArray[0] = lvGames;
            controlArray[1] = lvSummary;
            controlArray[2] = newTabPage;

            // Set label properties
            lblSummary.Text = "Summary";
            lblSummary.Font = labelFont;
            lblSummary.AutoSize = true;
            lblSummary.Dock = DockStyle.Left;
            lblGames.Text = "List of Games";
            lblGames.Font = labelFont;
            lblGames.AutoSize = true;
            lblGames.Dock = DockStyle.Left;

            // Set tab page properties
            newTabPage.Name = name;
            newTabPage.Text = name;
            newTabPage.Controls.Add(tempPanel);

            // Set panel properties
            tempPanel.Dock = DockStyle.Fill;

            // Set listview properties
            lvGames.View = View.Details;
            lvGames.Dock = DockStyle.Left;
            lvGames.FullRowSelect = true;
            lvGames.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(ColumnClick);

            lvSummary.View = View.Details;
            lvSummary.Dock = DockStyle.Left;
            lvSummary.FullRowSelect = true;
            lvSummary.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(ColumnClick);

            // Add controls to panel
            tempPanel.Controls.Add(lblSummary, 0, 0);
            tempPanel.Controls.Add(lvSummary, 0, 1);
            tempPanel.Controls.Add(lblGames, 0, 2);
            tempPanel.Controls.Add(lvGames, 0, 3);
        }

        private void CreateGroupTabPage(string tabName, Control[] controlArray)
        {
            // Create new tab
            TabPage newTabPage = new TabPage();
            ListView lvCustomTotals = new ListView();

            // Create page and controls
            TableLayoutPanel tempPanel = new TableLayoutPanel();

            // assign temp listview
            controlArray[0] = lvCustomTotals;
            controlArray[1] = newTabPage;

            // Set tab page properties
            newTabPage.Name = tabName;
            newTabPage.Text = tabName;
            newTabPage.Controls.Add(tempPanel);

            // Set panel properties
            tempPanel.Dock = DockStyle.Fill;

            // Set listview properties
            lvCustomTotals.View = View.Details;
            lvCustomTotals.Dock = DockStyle.Fill;
            lvCustomTotals.FullRowSelect = true;
            lvCustomTotals.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(ColumnClick);

            // Add controls to panel
            tempPanel.Controls.Add(lvCustomTotals, 0, 0);
        }

        private void CreateChartTabPage(string tabName, Control[] controlArray)
        {
            // Create new tab
            TabPage newTabPage = new TabPage();
            Chart newChart = new Chart();

            // assign controls
            controlArray[0] = newChart;
            controlArray[1] = newTabPage;

            // Set tab page properties
            newTabPage.Name = tabName;
            newTabPage.Text = tabName;

            // Set chart properties
            newChart.Dock = DockStyle.Fill;
            newChart.Legends.Add("Players");
            newChart.MouseMove += new System.Windows.Forms.MouseEventHandler(Chart_MouseMove);

            // Add controls to panel
            newTabPage.Controls.Add(newChart);
        }

        private void PopulateIndividualTab(CustomParameters parameters)
        {
            Control[] controlArray = new Control[3];
            List<SingleGamePlayerData> customDataList;
            List<string> customTotalData;

            // Create page and controls
            CreateIndividualTabPage(parameters.names[0], controlArray);

            // Get player data
            customDataList = allPlayerData.Single(data => data.Name == parameters.names[0]).GetGames(parameters);
            customTotalData = allPlayerData.Single(data => data.Name == parameters.names[0]).GetTotalPlayerData(parameters);

            // Populate individual game data listView
            PopulateIndividualListView(customDataList, (ListView)controlArray[0]);

            // Populate summary listView
            PopulateSummaryListView(customTotalData, (ListView)controlArray[1]);

            // Add and select tab page
            tabControlCustom.TabPages.Add((TabPage)controlArray[2]);
            tabControlCustom.SelectedTab = (TabPage)controlArray[2];
        }

        private void PopulateGroupTab(CustomParameters parameters, TabControl tabControl, string tabName)
        {
            List<List<string>> totals = new List<List<string>>();
            Control[] controlArray = new Control[2];

            // Create page and controls
            CreateGroupTabPage(tabName, controlArray);

            // Get player data
            foreach (string name in parameters.names)
            {
                allPlayerData.Single(data => data.Name == name).AddTotalPlayerDataToList(parameters, totals);
            }

            //customDataList = allPlayerData.Single(data => data.Name == parameters.names[0]).GetGames(parameters);

            // Populate group data listView
            PopulateGoupListView(totals, (ListView)controlArray[0]);

            // Add and select tab page
            tabControl.TabPages.Add((TabPage)controlArray[1]);
            tabControl.SelectedTab = (TabPage)controlArray[1];
        }

        private void PopulateGoupListView(List<List<string>> totals, ListView listView)
        {
            listView.View = View.Details;
            //listView.GridLines = true;
            listView.Clear();

            // Add Headers
            groupHeaders.ForEach(header =>
            {
                listView.Columns.Add(header);
                listView.Columns[groupHeaders.IndexOf(header)].TextAlign = HorizontalAlignment.Center;
                listView.Columns[groupHeaders.IndexOf(header)].Width = 70;
            });

            foreach (List<string> player in totals)
            {
                ListViewItem item = new ListViewItem(player.ToArray());

                listView.Items.Add(item);
            }
            RecolorListItems(listView);
        }

        private void PopulateIndividualListView(List<SingleGamePlayerData> customDataList, ListView listView)
        {
            // Add Headers
            individualHeaders.ForEach(header =>
            {
                listView.Columns.Add(header);
                listView.Columns[individualHeaders.IndexOf(header)].TextAlign = HorizontalAlignment.Center;
                listView.Columns[individualHeaders.IndexOf(header)].Width = 70;
            });

            // Add player data
            if (customDataList != null)
            {
                foreach (SingleGamePlayerData customData in customDataList)
                {
                    ListViewItem item = new ListViewItem(customData.DataArray());

                    listView.Items.Add(item);
                }
            }

            // Determine if there should be a scroll bar
            if (listView.Items.Count > 0)
            {
                if (listView.ClientSize.Height < (listView.Items.Count + 1) * listView.Items[0].Bounds.Height)
                {
                    listView.Width = (listView.Columns.Count * 70) + 21;
                }
                else
                {
                    listView.Width = (listView.Columns.Count * 70) + 4;
                }
            }

            listView.GridLines = true;

            RecolorListItems(listView);
        }

        private void PopulateSummaryListView(List<string> customTotalData, ListView listView)
        {
            ListViewItem total = new ListViewItem("Total");
            ListViewItem average = new ListViewItem("Average");

            // Add Headers
            summaryHeaders.ForEach(header =>
            {
                listView.Columns.Add(header);
                listView.Columns[summaryHeaders.IndexOf(header)].TextAlign = HorizontalAlignment.Center;
                listView.Columns[summaryHeaders.IndexOf(header)].Width = 70;
            });

            if (customTotalData != null)
            {
                total.SubItems.Add("");
                total.SubItems.AddRange(customTotalData.GetRange(0, 4).ToArray());
                total.SubItems.Add(customTotalData[10]);
                total.SubItems.Add(customTotalData[12]);

                average.SubItems.Add(customTotalData[8]);
                average.SubItems.AddRange(customTotalData.GetRange(4, 4).ToArray());
                average.SubItems.Add(customTotalData[11]);
            }

            total.BackColor = Color.LightGray;
            listView.GridLines = true;
            listView.Height = 62;
            listView.Width = (listView.Columns.Count * 70) + 4;

            listView.Items.Add(total);
            listView.Items.Add(average);
        }

        private List<SingleGamePlayerData> GetCustomIndividualData(CustomParameters parameters)
        {
            return allPlayerData.Single(data => data.Name == parameters.names[0]).GetGames(parameters);
        }

        private static void GetCustomGroupData(List<SingleGamePlayerData> customDataList, CustomParameters parameters)
        {
            List<SingleGamePlayerData> playerData = new List<SingleGamePlayerData>();

            foreach (string name in parameters.names)
            {
                if (playerData.Count(data => data.PlayersName == name) < parameters.minGames)
                {
                    playerData.RemoveAll(data => data.PlayersName == name);
                }
            }
        }

        private void PopulateLineChartTab(CustomParameters parameters, TabControl tabControl, string tabName)
        {
            List<SinglePlayerData> players = new List<SinglePlayerData>();
            Control[] controlArray = new Control[2];

            // Create page and controls
            CreateChartTabPage(tabName, controlArray);

            // Get player data
            foreach (string name in parameters.names)
            {
                players.Add(allPlayerData.Single(data => data.Name == name));
            }

            // Populate chart
            PopulateLineChart((Chart)controlArray[0], players, parameters);

            // Add and select tab page
            tabControl.TabPages.Add((TabPage)controlArray[1]);
            tabControl.SelectedTab = (TabPage)controlArray[1];
        }

        public List<List<string>> GetLeagueData()
        {
            List<List<string>> leagueData = new List<List<string>>();
            CustomParameters parameters = new CustomParameters
            {
                location = locations[2],
                names = pdcLeagueNames,
                league = true//,
                //dropGames = true
            };

            foreach (string name in parameters.names)
            {
                allPlayerData.Single(data => data.Name == name).AddTotalPlayerDataToList(parameters, leagueData);
            }

            leagueData.Sort((x, y) => float.Parse(y[4]).CompareTo(float.Parse(x[4])));

            return leagueData;
        }

        public List<List<string>> GetLastGameData()
        {
            List<List<string>> valueList = new List<List<string>>();
            SingleGameData lastGame;

            gameData = gameData.OrderBy(data => data.GameDate).ToList();
            lastGame = gameData.Where(data => data.GameLocation == settings[Settings.Default.IniSection]["GameLocation"].ToUpper()).Select(data => data).Last();

            string date = lastGame.GameDate.ToString("MMMM") + " " + lastGame.GameDate.Day.ToString() + FrmMain.GetDaySuffix(lastGame.GameDate.Day);
            date = "Results for " + date;

            valueList.Add(new List<string> { date, lastGame.GameLocation, "", "", "", "", "" });

            foreach (SingleGamePlayerData data in lastGame.PlayerDataList)
            {
                string place = data.PlayersPlace.ToString();
                string name = data.PlayersName;
                string spent = data.AmountSpent.ToString();
                string won = data.AmountWon.ToString();
                string net = data.AmountNetted.ToString();
                string rebuys = data.PlayersRebuys.ToString();
                string points = data.PlayerPoints.ToString();

                valueList.Add(new List<string> { place, name, spent, won, net, rebuys, points });
            }

            return valueList;
        }

        private static void PopulateLineChart(Chart chart, List<SinglePlayerData> players, CustomParameters parameters)
        {
            chart.Series.Clear();
            chart.ChartAreas.Add(new ChartArea());

            foreach (SinglePlayerData player in players)
            {
                if (player.GetGames(parameters) != null)
                {
                    double runningTotal = 0;
                    List<SingleGamePlayerData> games;

                    games = player.GetGames(parameters);
                    chart.Series.Add(player.Name);
                    chart.Series[player.Name].IsVisibleInLegend = true;
                    chart.Series[player.Name].ChartType = SeriesChartType.Line;
                    chart.Series[player.Name].XValueType = ChartValueType.DateTime;
                    chart.Series[player.Name].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[player.Name].BorderWidth = 2;

                    chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                    chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                    chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                    foreach (SingleGamePlayerData game in games)
                    {
                        runningTotal += game.AmountNetted;
                        chart.Series[player.Name].Points.AddXY(game.GameDate, runningTotal);
                    }
                }
            }
            ChangeYScale(chart);
        }

        private static void ChangeYScale(object chart)
        {
            double max = Double.MinValue;
            double min = Double.MaxValue;
            double size = 0;

            Chart tmpChart = (Chart)chart;

            for (int s = 0; s < tmpChart.Series.Count(); s++)
            {
                foreach (DataPoint dp in tmpChart.Series[s].Points)
                {
                    min = Math.Min(min, dp.YValues[0]);
                    max = Math.Max(max, dp.YValues[0]);
                }
            }
            tmpChart.ChartAreas[0].AxisY.Maximum = (Math.Ceiling((max / 10)) * 10);
            tmpChart.ChartAreas[0].AxisY.Minimum = (Math.Floor((min / 10)) * 10);

            size = tmpChart.ChartAreas[0].AxisY.Maximum - tmpChart.ChartAreas[0].AxisY.Minimum;

            StripLine line = new StripLine
            {
                BorderColor = Color.Transparent,
                BackColor = Color.Black
            };

            line.StripWidth = size / 200;

            tmpChart.ChartAreas[0].AxisY.StripLines.Add(line);
        }
    }
}
