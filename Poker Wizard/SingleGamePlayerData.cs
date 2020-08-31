using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Wizard
{
    class SingleGamePlayerData
    {
        public DateTime GameDate;
        public string PlayersName { get; }
        public int PlayersPlace { get; }
        public int PlayersRebuys { get; }
        public int PlayersBounties { get; }

        public int AmountSpent { get; }
        public double AmountWon { get; private set; }
        public double AmountNetted { get; private set; }
        public double PlayerPoints { get; private set; }
        public string GameLocation { get; }
        public int PlayersInGame { get; private set; }
        public double OpponentsPlayed { get; private set; }
        public double OpponentsBeaten { get; private set; }
        public int RebuysInGame { get; private set; }

        public SingleGamePlayerData(string PlayersName, int PlayersPlace, int PlayersRebuys, int PlayersBounties, string GameLocation, DateTime GameDate)
        {
            this.PlayersPlace = PlayersPlace;
            this.PlayersName = PlayersName;
            this.PlayersRebuys = PlayersRebuys;
            this.PlayersBounties = PlayersBounties;

            this.AmountSpent = (PlayersRebuys + 1) * 10;

            this.GameDate = GameDate;

            this.GameLocation = GameLocation;

            this.PlayerPoints = Math.Max(this.PlayersInGame + 1 - this.PlayersPlace - (0.5 * this.PlayersRebuys), 0);

            if (this.GameLocation == "Avista")
            {
                this.PlayerPoints += this.PlayersBounties;
            }
        }

        public string[] DataArray()
        {
            string[] data = { this.GameDate.Date.ToString("d"),
                              this.GameLocation.ToString(),
                              this.PlayersPlace.ToString(),
                              this.AmountSpent.ToString(),
                              this.AmountWon.ToString(),
                              this.AmountNetted.ToString(),
                              this.PlayerPoints.ToString(),
                              this.PlayersRebuys.ToString(),
                              this.PlayersBounties.ToString()};

            return data;
        }

        public void CalcRemainingData(int PlayersInGame, int RebuysInGame)
        {
            double potSize = (PlayersInGame + RebuysInGame) * 10;

            this.PlayersInGame = PlayersInGame;
            this.RebuysInGame = RebuysInGame;

            this.AmountWon = GetWinnings(this.PlayersInGame, potSize);
            this.AmountNetted = this.AmountWon - this.AmountSpent;
            this.OpponentsPlayed = this.PlayersInGame - 1;
            this.OpponentsBeaten = this.PlayersInGame - this.PlayersPlace;
            
            this.PlayerPoints = Math.Max(this.PlayersInGame + 1 - this.PlayersPlace - (0.5 * this.PlayersRebuys), 0);

            if (GameLocation == "AVISTA")
            {
                this.PlayerPoints += this.PlayersBounties;
            }

        }

        private double GetWinnings(double numberOfPlayers, double potSize)
        {
            double winnings = 0;

            if (numberOfPlayers <= 6)
            {
                switch (this.PlayersPlace)
                {
                    case 1:
                        winnings = potSize * 0.6;
                        break;
                    case 2:
                        winnings = potSize * 0.4;
                        break;
                    default:
                        break;

                }
            }
            else if (numberOfPlayers <= 10)
            {
                switch (this.PlayersPlace)
                {
                    case 1:
                        winnings = potSize * 0.5;
                        break;
                    case 2:
                        winnings = potSize * 0.3;
                        break;
                    case 3:
                        winnings = potSize * 0.2;
                        break;
                    default:
                        break;

                }
            }
            else
            {
                switch (this.PlayersPlace)
                {
                    case 1:
                        winnings = potSize * 0.5;
                        break;
                    case 2:
                        winnings = potSize * 0.25;
                        break;
                    case 3:
                        winnings = potSize * 0.15;
                        break;
                    case 4:
                        winnings = potSize * 0.1;
                        break;
                    default:
                        break;

                }
            }

            return winnings;
        }
    }
}
