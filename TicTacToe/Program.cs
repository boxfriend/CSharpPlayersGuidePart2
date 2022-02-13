using TicTacToe;

Console.Title = "Tic-Tac-Toe";
var gameManager = new GameManager();
LoopGames(gameManager);

void LoopGames(GameManager gameManager)
{
    var input = ' ';
    Console.Clear();
    gameManager.BeginGame();

    Console.Write("To quit enter 'q', enter anything else to play again: ");
    input = Console.ReadKey().KeyChar;

    if (input != 'q')
        LoopGames(new GameManager());
}