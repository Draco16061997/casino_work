using casino_Work.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;



Blacjack blacjack = new Blacjack();

blacjack.PlayGame();




namespace casino_Work.Games
{
    internal class Blacjack : IGame
    {
        Random rnd = new Random();
        public string Name => "Blacjack";

        public string Description => "Блэкджек - это комбинация из туза и любой другой карты стоимостью 10 очков " +
            "(валет, дама, король или десятка). " +
            "Это должны быть первые две сданные Вам карты. Получив блэкджек, " +
            "Вы точно не проиграете. Однако, если у дилера тоже будет блэкджек, " +
            "то Вы сыграете вничью.";

        public bool PlayGame()
        {
            Console.WriteLine("Сиграем в " + Name);
            Console.WriteLine(Description);
            

           

            int CauntDiller = rnd.Next(2, 21);
            int CountPlayer = 0;

            Console.WriteLine("две кнопки Y беру еще карту  and N не беру");
            Console.WriteLine("============");


            while (true)
                {
                
                Console.WriteLine("Береш карту?");
                
                string les = Console.ReadLine();
                if (CountPlayer <= 21)
                {

                    if (les == "Y")
                    {
                        CountPlayer += rnd.Next(2, 10);
                        Console.WriteLine(CountPlayer);
                    }
                    else {
                        Console.WriteLine("else");
                    }



                }
                else {
                    Console.WriteLine("Game over!");
                    return false;
                    break;
                }

            }
        }
        


    }
}

