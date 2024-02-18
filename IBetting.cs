using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal interface IBetting
    {
        List<IGame> games { get; set; }
        void SelectGame();

        int EnterBetting();

    }
}
