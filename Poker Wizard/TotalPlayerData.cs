using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Wizard
{
    class TotalPlayerData
    {
        public List<string> Totals { get; private set; }

        public int    TotalSpent { get; private set; }
        public double TotalWon { get; private set; }
        public double TotalNet { get; private set; }
        public double TotalPoints { get; private set; }
        public double AverageSpent { get; private set; }
        public double AverageWon { get; private set; }
        public double AverageNet { get; private set; }
        public double AveragePoints { get; private set; }
        public double AveragePlace { get; private set; }
        public int    GamesPlayed { get; private set; }
        public int    TotalRebuys { get; private set; }
        public int    TotalBounties { get; private set; }
        public double PercentBeaten { get; private set; }
        public double AverageRebuys { get; private set; }


        public TotalPlayerData(List<SingleGamePlayerData> singleGamePlayerData)
        {
            if (singleGamePlayerData != null)
            {
                this.Totals = new List<string>
                {
                    singleGamePlayerData.Sum(data => data.AmountSpent).ToString(),
                    singleGamePlayerData.Sum(data => data.AmountWon).ToString(),
                    singleGamePlayerData.Sum(data => data.AmountNetted).ToString(),
                    singleGamePlayerData.Sum(data => data.PlayerPoints).ToString(),
                    singleGamePlayerData.Average(data => data.AmountSpent).ToString("F2"),
                    singleGamePlayerData.Average(data => data.AmountWon).ToString("F2"),
                    singleGamePlayerData.Average(data => data.AmountNetted).ToString("F2"),
                    singleGamePlayerData.Average(data => data.PlayerPoints).ToString("F2"),
                    singleGamePlayerData.Average(data => data.PlayersPlace).ToString("F2"),
                    singleGamePlayerData.Count().ToString(),
                    singleGamePlayerData.Sum(data => data.PlayersRebuys).ToString(),

                    singleGamePlayerData.Average(data => data.PlayersRebuys).ToString("F2"),
                    (singleGamePlayerData.Sum(data => data.OpponentsBeaten) / singleGamePlayerData.Sum(data => data.OpponentsPlayed)).ToString("P2")
                };
            }
            
        }
    }
}
