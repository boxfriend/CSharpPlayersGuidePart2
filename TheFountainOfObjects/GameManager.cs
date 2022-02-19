namespace TheFountainOfObjects;

internal class GameManager
{
    private readonly Dungeon _dungeon;
    private readonly Player _player;
    private readonly InputManager _inputManager;

    private bool _gameActive;

    public Player Player => _player;

    public GameManager (int size)
    {
        _dungeon = new Dungeon (size);
        _player = new Player ();
        _inputManager = new InputManager ();
    }

    public void BeginGame()
    {
        var mid = _dungeon.Size/2;
        _dungeon.Rooms[mid, mid].TryChangeRoom(RoomType.Fountain);
        DungeonRenderer.DisplayDungeon(_dungeon, _player.Position);
        _gameActive = true;
        GameLoop();
    }

    private void GameLoop()
    {
        while(_gameActive)
        {
            Console.Clear ();
            DungeonRenderer.DisplayDungeon (_dungeon, _player.Position);
            _dungeon.VisitRoom(Player.Position);
            Console.WriteLine("Enter 'help' for information about commands.");
            var input = _inputManager.GetInput ();
            var command = GetCommandFromInput (input);
            command.Execute(this);
        }
    }

    public void MovePlayer(Point direction)
    {
        //This would be easier with operator overrides but that hasn't been introduced yet
        var newPosition = new Point(Player.Position.Row + direction.Row, Player.Position.Column + direction.Column);

        if (newPosition.Row < 0 || newPosition.Row >= _dungeon.Size)
            return;

        if(newPosition.Column < 0 || newPosition.Column >= _dungeon.Size)
            return;

        Player.Position = newPosition;
    }

    public void EnableFountain()
    {
        _gameActive = false;
        Console.WriteLine("The fountain is enabled. Hooray!");
    }

    public void KillPlayer(string causeOfDeath)
    {
        _gameActive = false;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have died.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Cause of death: {causeOfDeath}");
    }

    private ICommand GetCommandFromInput(string input)
    {
        var commandArray = input.ToLower().Split (' ');

        return commandArray[0] switch
        {
            "enable" => new EnableCommand(commandArray[1]),
            "move" =>  new MoveCommand(commandArray[1]),
            "help" => new HelpCommand(),
            "exit" => new ExitCommand(),
            _ => throw new NotImplementedException()
        };
    }
}
