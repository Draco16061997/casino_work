using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    internal class DealCard : Deck
    {
        private Card[] PlayerHand;
        private Card[] ComputerHand;
        private Card[] SortedPlayerHand;
        private Card[] SortedComputerHand;
        private Card[] CommonCards;
        private Card[] PlayerHandStart;
        private Card[] ComputerHandStart;

        public DealCard() 
        {
            PlayerHand = new Card[7];
            ComputerHand = new Card[7];
            SortedPlayerHand = new Card[7];
            SortedComputerHand = new Card[7];
            CommonCards = new Card[5];
            PlayerHandStart = new Card[2];
            ComputerHandStart = new Card[2];
        }

        public bool Deal()
        {
            SetUpDeck();
            getHand();
            UniteHand();
            sortCards();
            displayCards();

            if (EvaluateHands())
                return true;
            else return false;
        }
        public void getHand()
        {
            for (int i = 0; i < PlayerHandStart.Length; i++)
            { PlayerHandStart[i] = getDeck[i]; }
            for (int i = PlayerHandStart.Length; i < PlayerHandStart.Length+ ComputerHandStart.Length; i++)
            { ComputerHandStart[i - (PlayerHandStart.Length)] = getDeck[i];}
            for (int i = PlayerHandStart.Length + ComputerHandStart.Length; i < PlayerHandStart.Length + ComputerHandStart.Length+ CommonCards.Length; i++)
            { CommonCards[i -(PlayerHandStart.Length + ComputerHandStart.Length)] = getDeck[i];}
        }
        public void UniteHand()
        {
            PlayerHand = PlayerHandStart.Concat(CommonCards).ToArray();
            ComputerHand = ComputerHandStart.Concat(CommonCards).ToArray();
        }
        public void sortCards()
        {
            var queryPlayer = from hand in PlayerHand orderby hand.MyValue select hand;
            var queryComputer = from hand in ComputerHand orderby hand.MyValue select hand;
            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                SortedPlayerHand[index] = element;
                index++;
            }
            index = 0; 
            foreach (var element in queryComputer.ToList())
            {
                SortedComputerHand[index] = element;
                index++;
            }
        }

        public void displayCards()
        {
            foreach (var card in SortedPlayerHand)
            {
                Console.WriteLine($"{ card.MySuit}\t{ card.MyValue}");
            }

        }
        public bool EvaluateHands()
        {
            //created the obgect of evaluation
            HandEvaluator PlayerHandEvaluator = new HandEvaluator(SortedPlayerHand);
            HandEvaluator ComputerHandEvaluator = new HandEvaluator(SortedComputerHand);
            //get the hands
            Hand PlayerHand = PlayerHandEvaluator.EvaluateHand();
            Hand ComputerHand = ComputerHandEvaluator.EvaluateHand();
            //display
            Console.WriteLine("\nPlayer`s hand: "+PlayerHand);
            Console.WriteLine("\nComputer`s hand: " + ComputerHand);

            //  determin the winner
            if (PlayerHand>ComputerHand)
            {
                Console.WriteLine("PLAYER WIN");
                return true;
            }
            else if(ComputerHand>PlayerHand)
            {
                Console.WriteLine("COMPUTER WIN");
                return false;
            }
            else 
            { 
                if(PlayerHandEvaluator.HandValues.Total> ComputerHandEvaluator.HandValues.Total)
                {
                    Console.WriteLine("PLAYER WIN");
                    return true;
                }
                    
                else if (PlayerHandEvaluator.HandValues.Total < ComputerHandEvaluator.HandValues.Total)
                {
                    return false;
                    Console.WriteLine("COMPUTER WIN");
                }


                else if (PlayerHandEvaluator.HandValues.HighCard > ComputerHandEvaluator.HandValues.HighCard)
                {
                    Console.WriteLine("PLAYER WIN");
                    return true;
                }
                    
                else if (PlayerHandEvaluator.HandValues.HighCard < ComputerHandEvaluator.HandValues.HighCard)
                {
                    return false;
                    Console.WriteLine("COMPUTER WIN");
                }
                
                
            }
            return false;
        }
    }
}
