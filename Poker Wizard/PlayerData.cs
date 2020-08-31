using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Wizard
{
    public class PlayerData
    {
        public string Name { get; private set; }
        public int Rebuys { get; set; }
        public int Bounties { get; set; } = 0;
        public bool Eliminated { get; set; } = false;
        public int Place { get; set; } = 0;

        public PlayerData(string playerName)
        {
            Name = playerName;
        }
    }
}
