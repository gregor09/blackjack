using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Game.Controllers;

namespace Game
{
    class Game
    {
        public Hand hand;
        public Hand hand2;
        public Hand dealerHand;
        private int points;
        private List<Hand> hands = new List<Hand>();

        private Dealer dealer = new Dealer();
       
        public Game()
        {
            hand = new Hand(dealer.DealCards(), dealer.DealCards());
            hands.Add(hand);
            dealerHand = new Hand(dealer.DealCards(), dealer.DealCards());
        }
       
        public List<Hand> SplitCards()
        {
            hand2 = new Hand(hand.card2, dealer.DealCards());
            hand.RemoveCard(hand.card2);
            hand.AddCard(dealer.DealCards());
            hands.Add(hand2);
            return hands;
        }

        public void PlayAfterSplit()
        {
            ConsoleKeyInfo pressedChar;
            do
            {
                Console.SetCursorPosition(48, 18);
                Console.Write("Hit or Stand for Hand 1");
                pressedChar = Console.ReadKey(true);
                int hashCode = pressedChar.Key.GetHashCode();
                if (pressedChar.Key == ConsoleKey.Enter)
                {
                    hand.AddCard(dealer.DealCards());
                    PrintAfterSplit();
                }
            }
            while (pressedChar.Key != ConsoleKey.Spacebar);

            do
            {
                Console.SetCursorPosition(48, 18);
                Console.Write("Hit or Stand for Hand 2");
                pressedChar = Console.ReadKey(true);
                int hashCode2 = pressedChar.Key.GetHashCode();
                if (pressedChar.Key == ConsoleKey.Enter)
                {
                    hand2.AddCard(dealer.DealCards());
                    PrintAfterSplit();
                }
            }
            while (pressedChar.Key != ConsoleKey.Spacebar);
        }

        public Hand AddCard(Hand hand)
        {
            hand.AddCard(dealer.DealCards());
            return hand;
        }
        

        public int CountHandPoints(Hand hand)
        {
            points = hand.CountHandPoints();
            return points;
        }


        public void PrintCards()
        {
            points = hand.CountHandPoints();
            Console.SetCursorPosition(50, 20);
            hand.PrintHand();
            Console.Write(" Pts: " + points);
        }

        public void PrintAfterSplit()
        {
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("                        ");
            Console.SetCursorPosition(50, 20);
            points = hand.CountHandPoints();
            hand.PrintHand();
            Console.Write(" Pts: " + points);
            Console.SetCursorPosition(50, 21);
            Console.WriteLine("                        ");
            Console.SetCursorPosition(50, 21);
            points = hand2.CountHandPoints();
            hand2.PrintHand();
            Console.Write(" Pts: " + points);

        }

        public void PrintDealerCard1()
        {
            points = dealerHand.card1.CountPoints();
            Console.SetCursorPosition(50, 9);
            Console.Write(dealerHand.card1);
            Console.Write(" Pts: " + points);
        }

        public void PrintAllDealerCards()
        {
            points = dealerHand.CountHandPoints();
            Console.SetCursorPosition(50, 9);
            dealerHand.PrintHand();
            Console.Write(" Pts: " + points);
        }

        public void PlayAgain()
        {
            hand = new Hand(dealer.DealCards(), dealer.DealCards());
            hands.Add(hand);
            dealerHand = new Hand(dealer.DealCards(), dealer.DealCards());
        }


    }
}
