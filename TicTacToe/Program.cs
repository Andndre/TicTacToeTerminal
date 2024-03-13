using TicTacToe.Pages;

namespace TicTacToe
{
    // Halaman yang ada pada game
    public enum GameState
    {
        MainMenu,
        Help,
        InGame,
        Quit
    }

    internal class Program
    {

        static void Main()
        {
            // Membuat objek game dengan default state yaitu MainMenu
            var game = new Game(GameState.MainMenu);

            // Semua halaman
            // halaman utama
            Page mainMenu = new MainMenuPage(ref game);
            // menambahkan halaman utama ke game dengan state: MainMenu
            game.AddStateHandler(GameState.MainMenu, ref mainMenu);
            // halaman help
            Page help = new HelpPage(ref game);
            // menambahkan halaman help ke game dengan state: Help
            game.AddStateHandler(GameState.Help, ref help);
            // halaman game
            Page inGame = new InGamePage(ref game);
            // menambahkan halaman game ke game dengan state: InGame
            game.AddStateHandler(GameState.InGame, ref inGame);

            // Run
            game.Run();
        }
    }
}
