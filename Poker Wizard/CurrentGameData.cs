using System;
using System.Collections.Generic;
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
    public class CurrentGameData
    {
        private static readonly string[] PDC_BLINDS = new string[11] { "15 / 30",
                                                                       "25 / 50",
                                                                       "50 / 100",
                                                                       "75 / 150",
                                                                       "100 / 200",
                                                                       "150 / 300",
                                                                       "200 / 400",
                                                                       "300 / 600",
                                                                       "400 / 800",
                                                                       "500 / 1000",
                                                                       "600 / 1200"};

        private static readonly string[] AVISTA_BLINDS = new string[11] { "5 / 10",
                                                                          "10 / 20",
                                                                          "20 / 40",
                                                                          "40 / 80",
                                                                          "75 / 150",
                                                                          "125 / 250",
                                                                          "200 / 400",
                                                                          "300 / 600",
                                                                          "400 / 800",
                                                                          "500 / 1000",
                                                                          "600 / 1200"};

        public int StartingPlayers { get; set; }
        public int PlayersLeft { get; set; }
        public int TotalChips { get; set; }
        public int AverageStack { get; set; }
        public int Seconds { get; set; }
        public int Pot { get; set; }
        public int Round { get; set; } = 1;
        private string[] blinds;
        public State State { get; set; } = State.NotStarted;

        private readonly double[] payouts = new double[4] { 0, 0, 0, 0 };

        public List<PlayerData> players = new List<PlayerData>();

        private FileIniDataParser fileIniData = new FileIniDataParser();
        private IniData settings;

        public CurrentGameData()
        {
            settings = fileIniData.ReadFile(Settings.Default.IniFile);
            if (Equals(settings[Settings.Default.IniSection]["Blinds"], "0"))
            {
                blinds = PDC_BLINDS;
            }
            else
            {
                blinds = AVISTA_BLINDS;
            }
        }

        public void ReadIni()
        {
            settings = fileIniData.ReadFile(Settings.Default.IniFile);
        }

        public void ChangeBlindsSchedule(int blindsChoice)
        {
            if (blindsChoice == 0)
            {
                blinds = PDC_BLINDS;
            }
            else
            {
                blinds = AVISTA_BLINDS;
            }
        }

        public string GetBlinds()
        {
            string blnds = "";
            int uniqueBlindRounds = Int32.Parse(settings[Settings.Default.IniSection]["UniqueBlindRounds"]);
            if (Round > uniqueBlindRounds)
            {
                blnds = (600 + (Round - uniqueBlindRounds) * 200 + " / " + (1200 + (Round - uniqueBlindRounds) * 400));
            }
            else
            {
                blnds = blinds[Round - 1];
            }
            return blnds;
        }

        public string GetNextBlinds()
        {
            int nextRound = Round + 1;

            string blnds = "";
            if (nextRound > 11)
            {
                blnds = (600 + (nextRound - 11) * 200 + " / " + (1200 + (nextRound - 11) * 400));
            }
            else
            {
                blnds = blinds[nextRound - 1];
            }
            return blnds;
        }

        public void NextRound()
        {
            Round++;
        }

        public int GetMinutes()
        {
            return Seconds / 60;
        }

        public int GetSeconds()
        {
            return Seconds % 60;
        }

        public void ResetTime()
        {
            bool timeIsPerPlayer = Convert.ToBoolean(settings[Settings.Default.IniSection]["TimeIsPerPlayer"]);
            int secondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerRound"]);
            int secondsPerPlayer = Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerPlayer"]);
            int maxSecondsPerRound = Int32.Parse(settings[Settings.Default.IniSection]["MaxSecondsPerRound"]);

            if (timeIsPerPlayer)
            {
                Seconds = Math.Min((PlayersLeft * secondsPerPlayer), maxSecondsPerRound);
            }
            else
            {
                Seconds = secondsPerRound;
            }
        }

        public void SetTime(double minutes)
        {
            Seconds = (int)(minutes * 60);
        }

        public double[] GetPayouts()
        {
            return payouts;
        }

        public int ReduceTime()
        {
            return Seconds--;
        }

        public void SetPayouts()
        {
            if (StartingPlayers <= 6)
            {
                payouts[0] = Pot * 0.6;
                payouts[1] = Pot * 0.4;
                payouts[2] = 0;
                payouts[3] = 0;
            }
            else if (StartingPlayers <= 10)
            {
                payouts[0] = Pot * 0.5;
                payouts[1] = Pot * 0.3;
                payouts[2] = Pot * 0.2;
                payouts[3] = 0;
            }
            else
            {
                payouts[0] = Pot * 0.5;
                payouts[1] = Pot * 0.25;
                payouts[2] = Pot * 0.15;
                payouts[3] = Pot * 0.1;
            }
        }

        public void UpdateCurrentGameData(int numPlayers)
        {
            int rebuyCount = 0;

            foreach (PlayerData p in players)
            {
                rebuyCount += p.Rebuys;
            }

            if (State == State.NotStarted)
            {
                StartingPlayers = numPlayers;
                Seconds = StartingPlayers * Int32.Parse(settings[Settings.Default.IniSection]["SecondsPerPlayer"]);
            }

            PlayersLeft = numPlayers;
            TotalChips = (StartingPlayers + rebuyCount) * Int32.Parse(settings[Settings.Default.IniSection]["StartingChips"]);
            AverageStack = TotalChips / numPlayers;

            Pot = (StartingPlayers + rebuyCount) * Int32.Parse(settings[Settings.Default.IniSection]["BuyinCost"]);

            SetPayouts();
        }
    }
}