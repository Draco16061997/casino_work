using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal class Poker : IGame
    {
        public string Name => "Poker";
        public string Description => $"Победит лучшая комбинация.";

        public bool PlayGame()
        {
            DealCard Game = new DealCard();
            if (Game.Deal())
                return true;
            else return false;
        }
    }

}
