using casino_Work;
using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//Betting betting = new Betting(new List<IGame>() { new Blacjack(), new Slot(), new Rulete()} );

//betting.SelectGame();


namespace casino_Work
{
    internal class Betting : IBetting
    {
        public List<IGame> games { get; set; }

        public Betting (List<IGame> games)
        {
            this.games = games;
            
        }

        public int EnterBetting()
        {
            Console.WriteLine("Ваша ставка: ");
            bool isCoin = int.TryParse(Console.ReadLine(), out int Coin);
            return isCoin ? Coin :  EnterBetting();

            
        }

        public void SelectGame()
        {
            int multiplex = 2;
            Console.WriteLine("Выберете игру: ");
            for (int i = 0; i < games.Count; i++)
            {
                Console.WriteLine($" {i+1} {games[i].Name}");
            }

            bool sources = int.TryParse(Console.ReadLine(), out int select);

            Console.WriteLine("Внесите ставку !");
            int betting = EnterBetting();


            if (sources) 
            {
                if (games[select - 1].PlayGame())
                {
                    Console.WriteLine("Win");
                    Console.WriteLine($"You Win {betting * multiplex} Coins");
                
                }
                else { Console.WriteLine("Lose");
                    Console.WriteLine($"You Loss {betting } Coins");
                }
                

            }
            else { SelectGame(); }
        }
    }
}
