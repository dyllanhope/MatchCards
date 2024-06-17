using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public class MatchService
    {

        public enum MatchType
        {
            SuitMatch = 0,
            ValueMatch,
            BothMatch
        }

        private MatchType selectedMatchType;

        //use the set type to determine whether the previous and current cards match in the requested manner
        public bool CheckMatchOnSelectedType(Card? prevCard, Card currentCard)
        {
            if (prevCard != null)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("\n**COMPARING**");
                Console.WriteLine($"\nPrevious card: {prevCard.Value} of {prevCard.Suit}");
                Console.WriteLine($"\nCurrent card: {currentCard.Value} of {currentCard.Suit}");
                Console.WriteLine("\n=============================");

                switch (selectedMatchType)
                {
                    case MatchType.SuitMatch:
                        return prevCard.Suit == currentCard.Suit;
                    case MatchType.ValueMatch:
                        return prevCard.Value == currentCard.Value;
                    case MatchType.BothMatch:
                        return prevCard.Suit == currentCard.Suit && prevCard.Value == currentCard.Value;
                    default:
                        return prevCard.Suit == currentCard.Suit && prevCard.Value == currentCard.Value;
                }
            }
            else
            {
                return false;
            }
        }

        // set the selected match type in from the input request in the main program
        public void SetSelectedMatchType(MatchType type)
        {
            selectedMatchType = type;
        }
        public MatchType GetSelectedMatchType()
        {
            return selectedMatchType;
        }
    }
}
