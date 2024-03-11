using System;

namespace TicTacToe.Pages
{
    internal class InGamePage : Page
    {
        readonly TicTacToe tictactoe = new TicTacToe();
        
        public InGamePage(ref Game game) : base(ref game)
        {
        }

        public override void Draw(ref (int width, int height) screenSize)
        {
            base.Draw(ref screenSize);
            Printer.VerticalPadding(2);
            Console.WriteLine("  ↤ ESC");
            // ╔══╦══╗
            // ║  ║  ║
            // ╠══╬══╣
            // ║  ║  ║
            // ╚══╩══╝

            if (!tictactoe.gameOver)
            {
                Printer.VerticalPadding(6);
                DisplayBoardCentered();

                Printer.VerticalPadding(2);
                Printer.CenterScreen($"{(char)tictactoe.state}'s turn");
                Printer.VerticalPadding(2);
                Printer.CenterScreen("Press ←↑↓→ to move the cursor, ↲ ENTER to make a move");
            } else
            {
                Printer.VerticalPadding(3);
                Printer.CenterScreen("█▀▀ ▄▀█ █▀▄▀█ █▀▀   █▀█ █░█ █▀▀ █▀█");
                Printer.CenterScreen("█▄█ █▀█ █░▀░█ ██▄   █▄█ ▀▄▀ ██▄ █▀▄");
                Printer.VerticalPadding(1);
                DisplayBoardCentered();
                Printer.VerticalPadding(2);
                if (tictactoe.state == State.DRAW)
                {
                    Printer.CenterScreen("Draw!");
                } else
                {
                    Printer.CenterScreen($"The winner is {(tictactoe.state == State.O_WINNER ? 'O' : 'X')}!");
                }
                Printer.VerticalPadding(2);
                Printer.CenterScreen("Press ↲ ENTER to reset");
            }
        }

        public void DisplayBoardCentered()
        {
            Printer.CenterScreen("╔═══╦═══╦═══╗");
            for (int i = 0; i < tictactoe.GRID_SIZE; i++)
            {
                Console.Write(
                    Printer.LeftPaddingOfCenteredText(
                        new string(' ', tictactoe.GRID_SIZE * 4 + 1)
                    )
                );
                Console.Write("║ ");
                for (int j = 0; j < tictactoe.GRID_SIZE; j++)
                {
                    if (tictactoe.row == i && tictactoe.column == j)
                    {
                        Console.BackgroundColor = game.primaryColor;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write($"{(char)tictactoe.board[i, j]}");
                    Console.ResetColor();
                    Console.Write(" ║ ");
                }
                Console.WriteLine();
                if (i == tictactoe.GRID_SIZE - 1)
                {
                    Printer.CenterScreen("╚═══╩═══╩═══╝");
                }
                else
                {
                    Printer.CenterScreen("╠═══╬═══╬═══╣");
                }
            }
        }

        public override bool OnKeyCode(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    if (!tictactoe.gameOver)
                    {
                        tictactoe.SetValue();
                    } else
                    {
                        tictactoe.Reset();
                    }
                    return true;
                case ConsoleKey.UpArrow:
                    tictactoe.MoveCursor(-1, 0);
                    return true;
                case ConsoleKey.DownArrow:
                    tictactoe.MoveCursor(1, 0);
                    return true;
                case ConsoleKey.LeftArrow:
                    tictactoe.MoveCursor(0, -1);
                    return true;
                case ConsoleKey.RightArrow:
                    tictactoe.MoveCursor(0, 1);
                    return true;
                case ConsoleKey.Escape:
                    game.currentState = GameState.MainMenu;
                    tictactoe.Reset();
                    return true;
            }

            return false;
        }
    }
}
