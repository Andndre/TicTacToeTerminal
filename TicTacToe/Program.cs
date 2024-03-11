using TicTacToe.Pages;

namespace TicTacToe
{
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
            var game = new Game(GameState.MainMenu);

            // Pages
            Page mainMenu = new MainMenuPage(ref game);
            game.AddStateHandler(GameState.MainMenu, ref mainMenu);
            Page help = new HelpPage(ref game);
            game.AddStateHandler(GameState.Help, ref help);
            Page inGame = new InGamePage(ref game);
            game.AddStateHandler(GameState.InGame, ref inGame);

            // Run
            game.Run();
        }
    }
}
