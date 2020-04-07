using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game
{
    class Hand
    {
        private List<Card> cards = new List<Card>();
        private int points;
        public Card card1;
        public Card card2;

        public Hand(Card card1, Card card2)
        {
            this.card1 = card1;
            this.card2 = card2;
            cards.Add(card1);
            cards.Add(card2);
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }

        public int CountHandPoints()
        {
            points = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                int sum = cards.ElementAt(i).CountPoints();
                points = points + sum;
            }

            var aceCard = cards.Where(c => c.Value == "A").Select(c => c).FirstOrDefault();
            if (points > 21 && cards.Contains(aceCard))
            {
                points = points - 10;
            }

            return points;
        }

        public void PrintHand()
        {
            cards.ForEach(Console.Write);
        }

      
       
    }
}
