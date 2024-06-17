using Match;

public class Program
{

    public static MatchService _matchService = new();
    public static void Main(string[] args)
    {
        bool replayGame;
        do
        {
            Console.WriteLine("\nHello! Welcome to Match! A task project by Dyllan Hope");
            int deckCountInput = GetValidDeckCount();

            Deck deck = new Deck(deckCountInput);
            deck.ShuffleCompleteDeck();

            Console.Clear();
            int selectedCondition = ConsoleHelper.MultipleChoice(true, "Match by suits", "Match by card value", "Match by both card suit & value");

            _matchService.SetSelectedMatchType((MatchService.MatchType)selectedCondition);

            Console.Clear();
            Console.WriteLine("\nGreat! Now let's play!");
            Console.WriteLine("\n======================\n\n");

            GameManager.PlayGame(_matchService, deck);

            replayGame = GameManager.AskForReplay();
        } while (replayGame);
    }

    private static int GetValidDeckCount()
    {
        int deckCountInput;
        while (true)
        {
            Console.WriteLine("\nHow many packs of cards would you like to play with?");
            if (int.TryParse(Console.ReadLine(), out deckCountInput) && deckCountInput > 0)
            {
                Console.WriteLine($"\n\nGreat! You have chosen to use {deckCountInput} packs of cards for your game!");
                return deckCountInput;
            }
            Console.WriteLine("\nUnfortunately, you haven't selected a valid number of packs. Please choose a whole number larger than 0.");
        }
    }
}