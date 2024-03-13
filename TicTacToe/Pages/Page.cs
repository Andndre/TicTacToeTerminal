using System;

namespace TicTacToe.Pages
{
    internal class Page
    {
        // Referensi ke game
        public Game game;

        public Page(ref Game game)
        {
            this.game = game;
        }

        // Menjalankan page loop
        public void Run()
        {
            // Mendapatkan ukuran window saat ini
            var screenSize = Printer.GetScreenSize();
            // Menampilkan halaman berdasarkan window size
            Draw(ref screenSize);
            // Lakukan loop untuk mengcapture input user dan mengecek ukuran window
            while (true)
            {
                // Cek juga apakah window size berubah
                if (ShouldRedraw(screenSize)) // jika window resize
                {
                    Run(); // render ulang halaman ini
                    return;
                }
                // Jika tidak ada input maka continue saja
                if (!Console.KeyAvailable) continue;
                // Menyimpan state saat ini
                GameState prevState = game.currentState;
                // Handle input dengan fungsi OnKeyCode. Fungsi ini
                // akan dioverride oleh child class.
                // Fungsi harus mereturn true jika ingin redraw
                bool redraw = OnKeyCode(Console.ReadKey(true).Key);
                if (redraw)
                {
                    // Jika ada perubahan state game (perubahan halaman),
                    // maka jangan jalankan ulang halaman ini, melainkan
                    // keluar dari fungsi ini
                    if (game.currentState != prevState) return; // berganti halaman
                    Run(); // render ulang halaman ini
                    return;
                }
            }
        }

        /// <summary>
        /// Lakukan printing
        /// </summary>
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
