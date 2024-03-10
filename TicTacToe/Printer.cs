using System;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace TicTacToe
{
    internal class Printer
    {
        public static string LeftPaddingOfCenteredText(string input)
        {
            var screenSize = GetScreenSize();
            var padding = new string(' ', (screenSize.Item1 - input.Length) / 2);
            return padding;
        }

        public static void CenterScreen(string input)
        {
            var screenSize = GetScreenSize();
            var padding = new string(' ', Math.Max(screenSize.Item1 - input.Length, 0) / 2);
            Console.WriteLine($"{padding}{input}");
        }

        public static (int, int) GetScreenSize()
        {
            // Dapatkan ukuran dari buffer saat ini (sesuai ukuran window)
            return (Console.BufferWidth, Console.BufferHeight);
        }

        public static void VerticalPadding(int height)
        {
            Console.Write(new string('\n', height));
        }
    }
}
