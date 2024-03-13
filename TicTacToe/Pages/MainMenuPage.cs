using System;

namespace TicTacToe.Pages
{
    internal class MainMenuPage : Page
    {
        // Ada 3 tombol pada halaman ini. Variabel ini mengindikasikan
        // apa tombol yang dipilih
        int selectedButton = 1;

        public MainMenuPage(ref Game game) : base(ref game)
        {
        }

        public override void Draw(ref (int width, int height) screenSize)
        {
            base.Draw(ref screenSize);
            Printer.VerticalPadding(6);

            Printer.CenterScreen("████████╗██╗░█████╗░  ████████╗░█████╗░░█████╗░  ████████╗░█████╗░███████╗");
            Printer.CenterScreen("╚══██╔══╝██║██╔══██╗  ╚══██╔══╝██╔══██╗██╔══██╗  ╚══██╔══╝██╔══██╗██╔════╝");
            Printer.CenterScreen("░░░██║░░░██║██║░░╚═╝  ░░░██║░░░███████║██║░░╚═╝  ░░░██║░░░██║░░██║█████╗░░");
            Printer.CenterScreen("░░░██║░░░██║██║░░██╗  ░░░██║░░░██╔══██║██║░░██╗  ░░░██║░░░██║░░██║██╔══╝░░");
            Printer.CenterScreen("░░░██║░░░██║╚█████╔╝  ░░░██║░░░██║░░██║╚█████╔╝  ░░░██║░░░╚█████╔╝███████╗");
            Printer.CenterScreen("░░░╚═╝░░░╚═╝░╚════╝░  ░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ░░░╚═╝░░░░╚════╝░╚══════╝");
            Printer.VerticalPadding(2);

            DrawBtn(" !       PLAY      ! ", selectedButton == 1);
            DrawBtn(" ?   HOW TO PLAY   ? ", selectedButton == 2);
            DrawBtn(" x    QUIT GAME    x ", selectedButton == 3);

            Printer.VerticalPadding(6);

            Printer.CenterScreen("Press ↑ and ↓ to navigate and ↲ ENTER to select.");
        }
        
        public override bool OnKeyCode(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    --selectedButton;
                    if (selectedButton < 1) selectedButton = 1;
                    return true;
                case ConsoleKey.DownArrow:
                    ++selectedButton;
                    if (selectedButton > 3) selectedButton = 3;
                    return true;
                case ConsoleKey.Enter:
                    switch (selectedButton)
                    {
                        case 1:
                            game.currentState = GameState.InGame;
                            return true;
                        case 2:
                            game.currentState = GameState.Help;
                            return true;
                        case 3:
                            game.currentState = GameState.Quit;
                            return true;
                    }
                    break;
            }

            return false;
        }

        private void DrawBtn(string text, bool isSelected)
        {
            Console.Write(Printer.LeftPaddingOfCenteredText(text));
            if (isSelected)
            {
                Console.BackgroundColor = game.primaryColor;
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
    }
}
