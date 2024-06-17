using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        //initialize the complete deck with the specified number of decks
        public Deck(int deckCount)
        {
            Cards = new();

            for (int i = 0; i < deckCount; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Value value in Enum.GetValues(typeof(Value)))
                    {
                        Cards.Add(new Card(value, suit));
                    }
                }
            }
        }
        // shuffle the current complete deck using the Knuth-Durstenfeld Shuffle recommended as one of the best/most optimal shuffle algorithms
        public void ShuffleCompleteDeck()
        {
            // initialise a variable of Random in order to use the Random.next() method
            Random rng = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int j = rng.Next(i, Cards.Count);
                Card temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }

            Console.WriteLine("\n====================================");
            Console.WriteLine("\nDeck has been generated and shuffled!");
            Console.WriteLine("\n====================================");
        }

        //draw a random card from the complete deck and remove the selection from the complete deck
        public Card DrawTopCardFromDeck()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("The deck is empty!");

            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }
    }
}
