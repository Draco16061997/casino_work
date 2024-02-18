using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work.Games
{
    internal interface IGame
    {
        string Name { get; }

        string Description { get; }

        
        bool PlayGame();

    }

}
