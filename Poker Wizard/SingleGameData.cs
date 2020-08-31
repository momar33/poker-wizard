using System;
using System.Collections.Generic;

namespace Poker_Wizard
{
    class SingleGameData
    {
        public DateTime GameDate { get; }
        public string GameLocation { get; }
        public List<SingleGamePlayerData> PlayerDataList = new List<SingleGamePlayerData>();

        public SingleGameData(DateTime GameDate, string GameLocation, List<SingleGamePlayerData> PlayerDataList)
        {
            this.GameDate = GameDate;
            this.GameLocation = GameLocation;
            this.PlayerDataList = PlayerDataList;
        }
    }
}
