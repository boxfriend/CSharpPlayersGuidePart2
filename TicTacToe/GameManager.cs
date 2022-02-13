namespace TicTacToe;

internal class GameManager
{
    private Player[] _players;
    private BoardManager _boardManager;
    private int _numberOfCellsPlayed;

    private bool _gameInProgress;

    public GameManager()
    {
        _players = new Player[2];
        _players[0] = new Player() { Symbol = Symbol.X };
        _players[1] = new Player() { Symbol = Symbol.O };
        _boardManager = new BoardManager();
    }

    public void BeginGame()
    {
        _gameInProgress = true;
        var player = 0;
        while(_gameInProgress)
        {
            player %= _players.Length;
            ProcessTurn(_players[player++]);
        }
    }

    private void ProcessTurn(Player player)
    {
        _boardManager.DisplayBoard();
        var input = "";
        do
        {
            Console.Write($"Player {player.Symbol} choose a number from 1 to 9 to select your position: ");
            input = Console.ReadLine();
        } while (!ValidateInput(input!));
        Console.Clear();

        var position = Convert.ToInt32(input);
        var cell = _boardManager.TryInsertSymbol(position, player.Symbol);
        
        if (cell == null)
        {
            DisplayInvalid();
            ProcessTurn(player);
        } else
        {
            CheckForWinner(cell);
        }

    }

    private void CheckForWinner(Cell cell)
    {
        if (_boardManager.HasWon(cell))
        {
            Winner(cell.Symbol);
        } else if (_numberOfCellsPlayed++ >= 8)
        {
            Tie();
        }
    }
    private void Tie()
    {
        EndGame();
        Console.WriteLine("The game has ended in a tie.");
    }
    private void Winner(Symbol player)
    {
        EndGame();
        Console.WriteLine($"Congrats, Player {player}! You win!");
    }

    private void EndGame ()
    {
        Console.Clear();
        _boardManager.DisplayBoard();
        _gameInProgress = false;
    }

    private static void DisplayInvalid()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid selection.");
        Console.ForegroundColor= ConsoleColor.White;
    }

    private static bool ValidateInput(string input)
    {
        if(string.IsNullOrWhiteSpace(input))
        {
            DisplayInvalid();
            return false;
        }

        foreach (var ch in input)
        {
            if (!char.IsDigit(ch))
            {
                DisplayInvalid();
                return false;
            }
        }

        var num = Convert.ToInt32(input);
        if(num < 0 || num > 9)
        {
            DisplayInvalid();
            return false;
        }
        return true;
    }
}
