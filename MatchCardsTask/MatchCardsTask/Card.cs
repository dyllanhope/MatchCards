using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public enum Value
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    //initialise the card with its value (number) and suit
    public class Card
    {
        public Value Value { get; set; }
        public Suit Suit { get; set; }

        public Card(Value value, Suit suit)
        {
            Suit = suit;
            Value = value;
        }
    }
}
