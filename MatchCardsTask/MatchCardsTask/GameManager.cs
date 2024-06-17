using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public static class GameManager
    {
        public static void PlayGame(MatchService matchService, Deck deck)
        {
            int turnCounter = 0;
            bool isCurrentPlayerOne = true;

            Card prevCard = null;
            Card currentCard = null;

            while (deck.Cards.Count > 0)
            {
                turnCounter++;
                Console.Clear();
                Console.WriteLine($"\nTurn number: {turnCounter} - {(isCurrentPlayerOne ? "Player 1's" : "Player 2's")} turn...");


                currentCard = deck.DrawTopCardFromDeck();
                Console.WriteLine($"\nThe drawn card is the {currentCard.Value} of {currentCard.Suit}");
                Console.WriteLine($"\nNumber of cards left in the deck: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(deck.Cards.Count);
                Console.ResetColor();
                Console.WriteLine($"\nMatch Condition type: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(matchService.GetSelectedMatchType());
                Console.ResetColor();

                if (prevCard != null && matchService.CheckMatchOnSelectedType(prevCard, currentCard))
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\nThat's a match!");
                    Console.WriteLine($"\nThe winner is: {(isCurrentPlayerOne ? "Player 1!" : "Player 2!")}");
                    Console.ResetColor();
                    return;
                }

                prevCard = currentCard;
                Thread.Sleep(1000);  // 1000ms delay

                if (deck.Cards.Count == 0)
                {
                    Console.WriteLine("\nThe deck is empty!");
                    break;
                }

                isCurrentPlayerOne = !isCurrentPlayerOne;
            }
        }

        public static bool AskForReplay()
        {
            Console.WriteLine("\nDo you want to play again? (y/n)");
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "y" || input == "yes")
                {
                    Console.Clear();
                    return true;
                }
                if (input == "n" || input == "no")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Thank you for Playing! \n\n\n");
                    Console.WriteLine("A project by Dyllan Hope. \n\n\n");
                    Console.ResetColor();
                    return false;
                }
                Console.WriteLine("Please enter 'y' or 'n'.");
            }
        }
    }
}
