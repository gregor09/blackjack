using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Card
    {
        public string Value { get; set; }

        public string Suit { get; set; }

        private int points;

        public Card(string value, string suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public int CountPoints()
        {
            if (Value == "A")
            {
                points = 11;
            }
            else if (Value == "J" || Value == "Q" || Value == "K")
            {
                points = 10;
            }
            else
            {
                points = Convert.ToInt32(Value);
            }

            return points;
        }

        public override string ToString()
        {
            return $"{ Value}{Suit}  ";
        }


    }
}
