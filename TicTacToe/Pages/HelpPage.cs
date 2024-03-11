using System;

namespace TicTacToe.Pages
{
    internal class HelpPage : Page
    {
        public HelpPage(ref Game game) : base(ref game)
        {
        }

        public override void Draw(ref (int width, int height) screenSize)
        {
            base.Draw(ref screenSize);
            Printer.VerticalPadding(2);
            Console.WriteLine("  ↤ ESC");
            Printer.VerticalPadding(3);

            Printer.CenterScreen("█░█ █▀▀ █░░ █▀█");
            Printer.CenterScreen("█▀█ ██▄ █▄▄ █▀▀");

            Printer.VerticalPadding(3);
            Printer.CenterScreen("HOW TO PLAY");
            Printer.CenterScreen("--------");
            Printer.CenterScreen("1. Use Arrow Keys to move, Enter Key to select, and Escape Key to go back.");
            Printer.CenterScreen("2. The game will Reset if: (1) you quit the game, or");
            Printer.CenterScreen("(2) someone wins or draw");
            Printer.VerticalPadding(6);
            Printer.CenterScreen("press ESC to go back.");
        }

        public override bool OnKeyCode(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    game.currentState = GameState.MainMenu;
                    return true;
            }

            return false;
        }
    }
}
