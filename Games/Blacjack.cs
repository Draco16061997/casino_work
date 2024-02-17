using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;





namespace casino_Work.Games
{
    internal class Blacjack : IGame
    {
        Random rnd = new Random();
        public string Name => "Blacjack";

        public string Description => $"Чтобы победить тебе надо набрать больше очков \n" +
            $"чем у меня но чтобы было менше 21 \n" +
            $"очка если ваш счет будет больше чем 21 или \n" +
            $"меньше чем у меня то вы проиграли (";

        public bool PlayGame()
        {
            Console.WriteLine("Сиграем в " + Name);
            Console.WriteLine(Description);
            

           

            int CountDiller = rnd.Next(2, 21);
            int CountPlayer = 0;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("брать карту ('Y')  не брать ('N') ");
            Console.WriteLine("");
            Console.WriteLine("============");
            
            

            while (true)
            {
                Console.WriteLine("Береш карту?");
                if (CountPlayer < 22) 
                {
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        CountPlayer += rnd.Next(2, 10);
                        Console.WriteLine(CountPlayer);

                        
                    }
                    else
                    {
                        if (CountPlayer > CountDiller) 
                        {
                        Console.WriteLine("Your Win!!!");
                        Console.WriteLine("YOU " + CountPlayer + " Diler " + CountDiller);
                        return true;
                            break;
                        }
                        else if (CountDiller == CountPlayer) 
                        {
                            Console.WriteLine("Ничия начинаем 2 раунд");
                            PlayGame();

                        }
                        else
                        {
                            Console.WriteLine("Game Over!!!");
                            Console.WriteLine("YOU " + CountPlayer + " Diler " + CountDiller);
                            return false;
                            break;

                        }
                    }
                }
                else { Console.WriteLine("Geme Over!!!");
                    return false;
                    break;
                }

                
            }
                
                    

        }
    }
}


