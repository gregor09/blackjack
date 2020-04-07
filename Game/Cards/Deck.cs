using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Game
{

    class Deck
    {

        private Card card;
        private List<Card> cards = new List<Card>();

        private string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] suits = { "♠", "♥", "♣", "♦" };

        public List<Card> MakeDeck()
        {

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    for (int s = 0; s < suits.Length; s++)
                    {
                        cards.Add(new Card(values[i], suits[s]));
                    }
                }
            }
            return cards;
        }


    }
}
