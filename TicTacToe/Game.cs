using System;

namespace TicTacToe
{
    internal class Game
    {
        // Board kosong secara default
        char[,] board = {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
        };

        readonly ConsoleColor primaryColor = ConsoleColor.DarkBlue;

        enum GameState
        {
            MainMenu,
            Help,
            InGame,
            Quit
        }

        GameState state = GameState.MainMenu;

        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            GameLoop();
        }

        private void GameLoop()
        {
            while (true)
            {
                Console.Clear();
                switch(state)
                {
                    case GameState.MainMenu:
                        MainMenu();
                        break;
                    case GameState.Help:
                        HelpPage();
                        break;
                    case GameState.Quit:
                        return;
                }
            }
        }

        private void MainMenu()
        {
            // Initial States
            int selected = 1;
            // Methods
            void DrawBtn(string text, bool isSelected)
            {
                Console.Write(Printer.LeftPaddingOfCenteredText(text));
                if (isSelected)
                {
                    Console.BackgroundColor = primaryColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(text);
                Console.ResetColor();
            }
        Draw:
            // TODO: Improve performance: Do not use clear
            Console.Clear();
            var screenSize = Printer.GetScreenSize();
            Printer.VerticalPadding(6);

            Printer.CenterScreen("████████╗██╗░█████╗░  ████████╗░█████╗░░█████╗░  ████████╗░█████╗░███████╗");
            Printer.CenterScreen("╚══██╔══╝██║██╔══██╗  ╚══██╔══╝██╔══██╗██╔══██╗  ╚══██╔══╝██╔══██╗██╔════╝");
            Printer.CenterScreen("░░░██║░░░██║██║░░╚═╝  ░░░██║░░░███████║██║░░╚═╝  ░░░██║░░░██║░░██║█████╗░░");
            Printer.CenterScreen("░░░██║░░░██║██║░░██╗  ░░░██║░░░██╔══██║██║░░██╗  ░░░██║░░░██║░░██║██╔══╝░░");
            Printer.CenterScreen("░░░██║░░░██║╚█████╔╝  ░░░██║░░░██║░░██║╚█████╔╝  ░░░██║░░░╚█████╔╝███████╗");
            Printer.CenterScreen("░░░╚═╝░░░╚═╝░╚════╝░  ░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ░░░╚═╝░░░░╚════╝░╚══════╝");
            Printer.VerticalPadding(2);

            DrawBtn(" !       PLAY      ! ", selected == 1);
            DrawBtn(" ?   HOW TO PLAY   ? ", selected == 2);
            DrawBtn(" x    QUIT GAME    x ", selected == 3);

            Printer.VerticalPadding(6);

            Printer.CenterScreen("Press ↑ and ↓ to navigate and ↲ ENTER to select.");

            while (true)
            {
                // goto Draw juga berguna jika ada state yang berubah
                if (ShouldRedraw(screenSize)) goto Draw;
                if (!Console.KeyAvailable) continue;
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        --selected;
                        if (selected < 1) selected = 1;
                        goto Draw;
                    case ConsoleKey.DownArrow:
                        ++selected;
                        if (selected > 3) selected = 3;
                        goto Draw;
                    case ConsoleKey.Enter:
                        switch (selected)
                        {
                            case 1:
                                state = GameState.InGame;
                                return;
                            case 2:
                                state = GameState.Help;
                                return;
                            case 3:
                                state = GameState.Quit;
                                return;
                        }
                        break;
                }
            }
        }

        private void HelpPage ()
        {
        Draw:
            Console.Clear();
            var screenSize = Printer.GetScreenSize();
            Printer.VerticalPadding(6);

            Printer.CenterScreen("█░█ █▀▀ █░░ █▀█");
            Printer.CenterScreen("█▀█ ██▄ █▄▄ █▀▀");

            Printer.VerticalPadding(3);
            Printer.CenterScreen("In Game");
            Printer.CenterScreen("-------");
            Printer.VerticalPadding(6);
            Printer.CenterScreen("press ENTER to go back.");

            while (true)
            {
                if (ShouldRedraw(screenSize)) goto Draw;
                if (!Console.KeyAvailable) continue;
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        state = GameState.MainMenu;
                        return;
                }
            }
        }

        private bool ShouldRedraw((int, int) prevScreenSize)
        {
            var screenSize = Printer.GetScreenSize();
            return prevScreenSize != screenSize;
        }
    }
}


// Referensi:
// - Update line: https://stackoverflow.com/questions/888533/how-can-i-update-the-current-line-in-a-c-sharp-windows-console-app
// - Buffer size: https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
// Delay (thread sleep): https://stackoverflow.com/questions/5449956/how-to-add-a-delay-for-a-2-or-3-seconds
// Get keyboard key: https://stackoverflow.com/questions/63818349/c-sharp-net-console-application-getting-keyboard-input
// Goto: https://stackoverflow.com/questions/324831/breaking-out-of-a-nested-loop
// Comparing tuple: https://www.c-sharpcorner.com/article/compare-tuples-in-c-sharp/
// Function inside function: https://stackoverflow.com/questions/5884319/c-function-in-function-possible
// ASCII art generator: https://fsymbols.com/generators/carty/
// Symbols not working: https://stackoverflow.com/questions/66313257/currency-symbol-not-showing-in-c-sharp-console-application
