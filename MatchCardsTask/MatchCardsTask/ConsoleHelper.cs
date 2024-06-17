using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match
{
    public class ConsoleHelper
    {
        // Used to clear the current screen and make picking an option more user friendly
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            int currentSelection = 0;
            ConsoleKey key;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                Console.WriteLine("\nPlease select one of the following match conditions to play by in your match:");

                // Write the current item with a different colour and indicator and the rest as normal
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n-> {options[i]}");
                    }
                    else
                    {
                        Console.Write($"\n{options[i]}");
                    }
                    Console.ResetColor();
                }

                // Read key input value
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > 0) currentSelection--;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < options.Length - 1) currentSelection++;
                            break;
                        }
                    // Escape clause
                    case ConsoleKey.Escape:
                        {
                            if (canCancel) return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return currentSelection;
        }
    }
}
