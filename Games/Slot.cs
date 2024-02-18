using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace casino_Work.Games
{
    internal class Slot : IGame
    {
        Random rnd = new Random();
        public string Name => "Slot";

        public string Description => "игра 3 в ряд выпадает 3 одинаковые числа вы победили !";

        public bool PlayGame()
        {
            int slot1 = rnd.Next(1, 6);
            int slot2 = rnd.Next(1, 6);
            int slot3 = rnd.Next(1, 6);
            Console.WriteLine(slot1+" "+slot2+" "+slot3);
            if (slot1 == slot2 && slot2== slot3 && slot1 == slot3)
            {
                //Console.WriteLine("You Win!!!");
                return true;
            }
            else
            {
                //Console.WriteLine("You Loss!!!");
                return false;
            }

        }
    }
}
