using System;

namespace TicTacToe
{
    internal class Printer
    {
        // Spasi sebelah kiri yang diperlukan ketika ingin menuliskan teks {input} di tengah tengah window
        public static string LeftPaddingOfCenteredText(string input)
        {
            // Mendapatkan ukuran dari window saat ini
            var screenSize = GetScreenSize();
            // Menghitung spasi sebelah kiri yang diperlukan
            var padding = new string(' ', (screenSize.Item1 - input.Length) / 2);
            return padding;
        }

        // Menuliskan teks {input} di tengah tengah window
        public static void CenterScreen(string input)
        {
            // Mendapatkan ukuran dari window saat ini
            var screenSize = GetScreenSize();
            // Menghitung spasi sebelah kiri yang diperlukan
            var padding = new string(' ', Math.Max(screenSize.Item1 - input.Length, 0) / 2);
            // Menuliskan teks
            Console.WriteLine($"{padding}{input}");
        }

        // Mendapatkan ukuran window saat ini (jumlah character yang bisa ditampung)
        public static (int, int) GetScreenSize()
        {
            // Dapatkan ukuran dari buffer saat ini (sesuai ukuran window)
            return (Console.BufferWidth, Console.BufferHeight);
        }

        // Menuliskan newline sebanyak {height}
        public static void VerticalPadding(int height)
        {
            Console.Write(new string('\n', height));
        }
    }
}
