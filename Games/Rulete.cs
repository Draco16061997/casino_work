using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;




namespace casino_Work.Games
{
    internal class Rulete : IGame
    {
        

        
        

        public string Name => "Рулетка";

        public string Description => "введите число от 0 до 10 и запустите рулетку";

        public bool PlayGame()
        {
            Random rnd = new Random();
            int rNum = rnd.Next(0, 10);
            Console.WriteLine("введите число от 0 до 10");
            string num = Console.ReadLine();

           
            bool success = int.TryParse(num, out int newNum);


            if (success ) 
            { 
                if (newNum >= 0 && newNum <= 10)
                {
                    if (newNum == rNum )
                        {

                        Console.WriteLine("Випало " + rNum + " You Win");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Випало " + rNum + " You Loss");
                        return false;
                    }
                }
                else { Console.WriteLine("не коректное число ");
                    PlayGame();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("вы ввели не число ");
                PlayGame();
                return false;
            }

        }
    }
}
