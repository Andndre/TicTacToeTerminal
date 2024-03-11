using System;
using TicTacToe.Pages;

namespace TicTacToe
{
    internal class Game
    {
        public readonly ConsoleColor primaryColor = ConsoleColor.DarkBlue;
        public Page[] pages = new Page[10];
        public GameState currentState;

        public Game(GameState defaultState)
        {
            currentState = defaultState;
        }

        public void AddStateHandler(GameState state, ref Page page)
        {
            pages[(int)state] = page;
        }

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            GameLoop();
        }

        private void GameLoop()
        {
            while (currentState != GameState.Quit)
            {
                Page page = pages[(int)currentState];
                page.Run();
            }
            Console.Clear();
            Console.WriteLine("Terimakasih sudah bermain!");
        }
    }
}

// Referensi:
// - Update line: https://stackoverflow.com/questions/888533/how-can-i-update-the-current-line-in-a-c-sharp-windows-console-app
// - Buffer size: https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
// - Delay (thread sleep): https://stackoverflow.com/questions/5449956/how-to-add-a-delay-for-a-2-or-3-seconds
// - Get keyboard key: https://stackoverflow.com/questions/63818349/c-sharp-net-console-application-getting-keyboard-input
// - Goto: https://stackoverflow.com/questions/324831/breaking-out-of-a-nested-loop
// - Comparing tuple: https://www.c-sharpcorner.com/article/compare-tuples-in-c-sharp/
// - Function inside function: https://stackoverflow.com/questions/5884319/c-function-in-function-possible
// - ASCII art generator: https://fsymbols.com/generators/carty/
// - Symbols not working: https://stackoverflow.com/questions/66313257/currency-symbol-not-showing-in-c-sharp-console-application
// - Pass by reference: https://stackoverflow.com/questions/8708632/passing-objects-by-reference-or-value-in-c-sharp
// - Symbols: https://www.i2symbol.com/symbols/
