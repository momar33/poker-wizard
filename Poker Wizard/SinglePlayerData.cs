using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Wizard
{
    class SinglePlayerData
    {
        public string Name { get; set; }
        public int TotalGamesPlayed { get; private set; }
        public Dictionary<string, int> gamesPlayed = new Dictionary<string, int>();
        public int AvistaGamesPlayed { get; private set; }
        public int PdcGamesPlayed { get; private set; }
        private List<SingleGamePlayerData> _playersGameData = new List<SingleGamePlayerData>();

        // Move to settings
        readonly int numGamesBeforeDrop = 3;

        public SinglePlayerData (List<SingleGamePlayerData> allGameData, string name, List<string> locations)
        {
            this.Name = name;
            _playersGameData.AddRange(allGameData.Where(data => data.PlayersName == this.Name));

            TotalGamesPlayed = _playersGameData.Count();

            foreach (string loc in locations)
            {
                int gp = _playersGameData.Where(data => data.GameLocation == loc).Count();
                gamesPlayed.Add(loc, gp);
            }
        }

        public List<SingleGamePlayerData> GetGames(CustomParameters parameters)
        {
            List<SingleGamePlayerData> gameList = new List<SingleGamePlayerData>();
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            if (parameters.league)
            {
                startDate = FrmStatistics.seasonStartDate;
                endDate = DateTime.Today;
            }
            else
            {
                startDate = parameters.startDate;
                endDate = parameters.endDate;
            }

            foreach (SingleGamePlayerData game in _playersGameData)
            {
                if ((parameters.location == "All" || game.GameLocation == parameters.location) &&
                    (game.GameDate >= startDate && game.GameDate <= endDate))
                {
                    gameList.Add(game);
                }
                gameList = gameList.OrderBy(gameData => gameData.GameDate).ToList();
            }

            if (gameList.Count() < parameters.minGames)
            {
                gameList = null;
            }
            else if (parameters.league && parameters.dropGames && gameList.Count() >= numGamesBeforeDrop)
            {
                gameList = gameList.OrderByDescending(data => data.PlayerPoints)
                                   .Reverse()
                                   .Skip(2)
                                   .ToList();
            }

            return gameList;
        }

        public List<string> GetTotalPlayerData(CustomParameters parameters)
        {
            return new TotalPlayerData(GetGames(parameters)).Totals;
        }

        public void AddTotalPlayerDataToList(CustomParameters parameters, List<List<string>> totalPlayerDataList)
        {            
            if (this.GetGames(parameters) != null)
            {
                List<string> totalPlayerData = new TotalPlayerData(GetGames(parameters)).Totals;
                totalPlayerData.Insert(0, this.Name);
                totalPlayerDataList.Add(totalPlayerData);
            }
        }

        public List<string> GetBankrollSeries(CustomParameters parameters)
        {
            double currentTotal = 0;
            List<SingleGamePlayerData> games;
            List<string> series = new List<string>();
            games = GetGames(parameters);

            series.Add(currentTotal.ToString());

            foreach (SingleGamePlayerData game in games)
            {
                currentTotal += game.AmountNetted;
                series.Add(currentTotal.ToString());
            }

            return series;
        }
    }
}
