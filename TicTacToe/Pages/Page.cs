using System;

namespace TicTacToe.Pages
{
    internal class Page
    {
        public Game game;

        public Page(ref Game game)
        {
            this.game = game;
        }

        public void Run()
        {
            var screenSize = Printer.GetScreenSize();
            Draw(ref screenSize);
            while (true)
            {
                if (ShouldRedraw(screenSize)) // jika window resize
                {
                    Run(); // render ulang halaman ini
                    return;
                }
                if (!Console.KeyAvailable) continue;
                GameState prevState = game.currentState;
                bool redraw = OnKeyCode(Console.ReadKey(true).Key);
                if (redraw)
                {
                    if (game.currentState != prevState) return; // berganti halaman
                    Run(); // render ulang halaman ini
                    return;
                }
            }
        }

        public virtual void Draw(ref (int width, int height) screenSize)
        {
            Console.Clear();
        }

        /// <summary>
        /// Return true jika ingin redraw
        /// </summary>
        public virtual bool OnKeyCode(ConsoleKey key)
        {
            return false;
        }

        /// <summary>
        /// Cek apakah screen size (window size) berubah
        /// </summary>
        protected bool ShouldRedraw((int, int) prevScreenSize)
        {
            var screenSize = Printer.GetScreenSize();
            return prevScreenSize != screenSize;
        }
    }
}
