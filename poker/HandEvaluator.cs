using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace casino_Work
{
    public enum Hand //можливі комбінації
    {
        Nothing,
        OnePair, 
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHause,
        FourKind
    }
    public struct HandValue //необхідні зміни для встановлення старшої карти
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }
    public class HandEvaluator : Card
    {
        public int heartsSum;
        public int diamondSum;
        public int clubSum;
        public int spadesSum;
        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand) //стартові значення
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0; 
            spadesSum = 0;
            cards = new Card[sortedHand.Length];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues 
        { 
            get { return handValue; } 
            set { handValue = value; }
        }
        public Card[] Cards 
        { 
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
                cards[5] = value[5];
                cards[6] = value[6];
            } 
        }

        public Hand EvaluateHand() //головна функція
        {
            getNumberOfSuit();
            if (FourKind())
                return Hand.FourKind;
            else if(FullHause())
                return Hand.FullHause;
            else if(Flush())
                return Hand.Flush;
            else if(Straight())
                return Hand.Straight;
            else if (ThreeKind())
                return Hand.ThreeKind;
            else if(TwoPairs())
                return Hand.TwoPairs;
            else if (OnePair())
                return Hand.OnePair;

            handValue.HighCard = (int)cards[6].MyValue;
            return Hand.Nothing;
        }
        private void getNumberOfSuit()
        {
            foreach(var element in Cards)
            {
                if (element.MySuit == Card.Suit.Hearts)
                    heartsSum++;
                else if (element.MySuit == Card.Suit.Diamonds)
                    diamondSum++;
                else if (element.MySuit == Card.Suit.Clubs)
                    clubSum++;
                else if (element.MySuit == Card.Suit.Spades)
                    spadesSum++;
            }
            
        }

        private bool FourKind()
        {
            for (int i = 0; i < cards.Length - 3; i++)
            {
                if (cards[i].MyValue == cards[i + 1].MyValue && cards[i + 1].MyValue == cards[i + 2].MyValue && cards[i + 2].MyValue == cards[i + 3].MyValue && i < cards.Length - 4)
                {
                    handValue.Total = (int)cards[i].MyValue * 4;
                    handValue.HighCard = (int)(cards[cards.Length - 1].MyValue);
                    return true;
                }
                else if (cards[i].MyValue == cards[i + 1].MyValue && cards[i + 1].MyValue == cards[i + 2].MyValue && cards[i + 2].MyValue == cards[i + 3].MyValue && i == cards.Length - 4)
                {
                    handValue.Total = (int)cards[i].MyValue * 4;
                    handValue.HighCard = (int)(cards[i - 1].MyValue);
                    return true;
                }
            }
            return false;
        }

        private bool ThreeKind()
        {
            for (int i = 0; i < cards.Length-2; i++)
            {
                if (cards[i].MyValue == cards[i+1].MyValue && cards[i+1].MyValue == cards[i+2].MyValue && cards[i + 3].MyValue != cards[i].MyValue && i< cards.Length - 3)
                {
                    handValue.Total = (int)cards[i].MyValue* 3;
                    handValue.HighCard = (int)(cards[cards.Length-1].MyValue);
                    return true;
                }
                else if (cards[i].MyValue == cards[i + 1].MyValue && cards[i + 1].MyValue == cards[i + 2].MyValue && i == cards.Length - 3)
                {
                    handValue.Total = (int)cards[i].MyValue * 3;
                    handValue.HighCard = (int)(cards[i-1].MyValue);
                    return true;
                }
            }
            return false;
        }

        private bool OnePair()
        {
            for(int i = 0;i < cards.Length-2;i++)
            {
                if (cards[i].MyValue == cards[i+1].MyValue  && i <cards.Length-2)
                {
                    handValue.Total = (int)cards[i].MyValue * 2;
                    handValue.HighCard = (int)(cards[cards.Length-1].MyValue);
                    return true;
                }
                else if (cards[i].MyValue == cards[i + 1].MyValue && i == cards.Length - 2)
                {
                    handValue.Total = (int)cards[i].MyValue * 2;
                    handValue.HighCard = (int)(cards[cards.Length - 1].MyValue);
                    return true;
                }
            }
            return false;
        }
        private bool TwoPairs()
        {
            int tempValue=0;
            int kol = 0;//pair counter
            for (int i = 0; i < cards.Length - 2; i++)
            {
                if (cards[i].MyValue == cards[i + 1].MyValue && i < cards.Length - 3)
                {
                    kol++;
                    tempValue = tempValue+ (int)cards[i].MyValue * 2;
                }
                if (cards[i].MyValue == cards[i + 1].MyValue && i == cards.Length - 3)
                {
                    kol++;
                    tempValue = tempValue+ (int)cards[i].MyValue * 2;
                }
            }
            if (kol>1)
            {
                handValue.Total = tempValue;
                handValue.HighCard = (int)(cards[cards.Length-1].MyValue);
                return true;
            }
            return false;
        }
        private bool Straight() 
        {
            for (int i = 0;i < cards.Length - 4;i++)
            {
                if (cards[i].MyValue+1 == cards[i + 1].MyValue && cards[i + 1].MyValue +1 == cards[i + 2].MyValue && cards[i + 2].MyValue +1 == cards[i + 3].MyValue && cards[i + 3].MyValue+1 == cards[i + 4].MyValue)
                {
                    handValue.Total = (int)cards[i].MyValue;
                    return true;
                }
            }
            return false;
        }
        private bool FullHause()
        {
            int x = 0;//checkbox for pairs
            int y = 0;//chaeckbox for triples
            int temp = 0;
            for (int i = 0; i < cards.Length - 2; i++)
            {
                if (cards[i].MyValue == cards[i + 1].MyValue && cards[i + 2].MyValue != cards[i].MyValue && i < cards.Length - 2)//find a pair
                {
                    x++;
                    temp = temp + (int)cards[i].MyValue + (int)cards[i + 1].MyValue;
                }

            }
            for (int i = 0; i < cards.Length - 3; i++)
            { 
                if (cards[i].MyValue == cards[i + 1].MyValue && cards[i + 1].MyValue == cards[i + 2].MyValue && cards[i + 1].MyValue != cards[i + 3].MyValue && i < cards.Length - 3)
                {
                    y++;
                    temp = temp + (int)cards[i].MyValue + (int)cards[i + 1].MyValue + (int)cards[i + 2].MyValue;
                }
            }
            if (x >= 1 && y >= 1)
            {
                handValue.Total = temp;
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            if (heartsSum >= 5 || diamondSum >=5 || clubSum >= 5 || spadesSum >=5)
            {
                handValue.Total = (int)cards[6].MyValue;
                return true;
            }
            return false;
        }
    }
}