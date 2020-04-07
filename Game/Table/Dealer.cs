using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Dealer
    {
        private List<Card> cards;
        private List<Card> mixedCards;
        private Card card;

        private Deck deck = new Deck();

        public Dealer()
        {
            cards = deck.MakeDeck();
            mixedCards = new List<Card>();

            while (cards.Count > 0)
            {
                Random rnd = new Random();
                int r = rnd.Next(0, cards.Count);
                mixedCards.Add(cards.ElementAt(r));
                cards.RemoveAt(r);
            }
        }
    

        public Card DealCards()
        {
            if (mixedCards.Count == 0)
            {
                Console.WriteLine("No more cards left to draw!");
            }
            else
            {
                card = mixedCards.ElementAt(mixedCards.Count - 1);
                mixedCards.RemoveAt(mixedCards.Count - 1);
            }

            return card;
        }
 

    }
}
