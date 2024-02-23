using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal class Deck : Card
    {
        const int Num_of_cards = 52;
        private Card[] deck;
        public Deck() 
        { 
            deck = new Card[Num_of_cards];
        }

        public Card[] getDeck { get { return deck; } }
        public void SetUpDeck()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }
            ShuffleCards();
        }
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            for ( int shuffleTimes =0; shuffleTimes<1000; shuffleTimes++)
            {
                for (int i = 0; i<Num_of_cards; i++)
                {
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
