namespace TheFountainOfObjects;

enum Difficulty
{ 
    Story = 3,
    Easy = 4,
    Medium = 6,
    Hard = 8
}

internal class GameManager
{
    private readonly Dungeon _dungeon;
    private readonly Player _player;
    private readonly InputManager _inputManager;

    private bool _gameActive;

    public static bool IsFountainActive = false;

    //I really didn't want to have to use this pattern, but because events haven't been introduced yet I can't just use an event to move the maelstrom
    //That's right, this is literally *only* for the maelstrom (at least at time of writing this comment)
    public static GameManager Instance { get; private set; }

    public Player Player => _player;
    public int Size => _dungeon.Size;
    public GameManager (Difficulty difficulty)
    {
        Instance = this;
        _dungeon = new Dungeon ((int)difficulty);
        _player = new Player ();
        _inputManager = new InputManager ();
        SetupGame(difficulty);
    }

    public void BeginGame()
    {
        DisplayObjective();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(false);
        GameLoop();
    }

    private void SetupGame(Difficulty difficulty)
    {
        _dungeon.Rooms[0, 0].TryChangeRoom(RoomType.Entrance);

        var mid = Size / 2;
        _dungeon.Rooms[mid, mid].TryChangeRoom(RoomType.Fountain);
        var intDifficulty = (int)difficulty;
        if(intDifficulty >= 8)
        {
            _dungeon.Rooms[6, 6].TryChangeRoom(RoomType.Pit);
            _dungeon.Rooms[0, 4].TryChangeRoom(RoomType.Pit);
            _dungeon.Rooms[1, 3].TryChangeRoom(RoomType.Maelstrom);
            _dungeon.Rooms[0, 2].TryChangeRoom(RoomType.Amarok);
        }

        if(intDifficulty >= 6)
        {
            _dungeon.Rooms[4, 2].TryChangeRoom(RoomType.Pit);
            _dungeon.Rooms[3, 4].TryChangeRoom(RoomType.Maelstrom);
            _dungeon.Rooms[5, 0].TryChangeRoom(RoomType.Amarok);
            _dungeon.Rooms[1, 4].TryChangeRoom(RoomType.Amarok);
        }

        if(intDifficulty >= 4)
        {
            _dungeon.Rooms[1, 1].TryChangeRoom(RoomType.Pit);
        }

        _gameActive = true;
    }

    private void GameLoop()
    {
        while(_gameActive)
        {
            DungeonRenderer.DisplayDungeon (_dungeon, _player.Position);
            _dungeon.VisitRoom(Player.Position);
            Console.WriteLine($"You have {Player.ArrowCount} arrows available to fire.");
            Console.WriteLine("Enter 'help' for information about commands.");

            var input = _inputManager.GetInput ();
            var command = GetCommandFromInput (input);

            command.Execute(this);

            CheckEndConditions();
        }
    }

    public void MovePlayer(Point direction)
    {
        var newRow = Player.Position.Row + direction.Row;
        var newColumn = Player.Position.Column + direction.Column;

        //Pretty sure the Math class has been mentioned previously so this theoretically shouldn't be against my personal challenge
        newRow = Math.Clamp(newRow, 0, Size - 1);
        newColumn = Math.Clamp(newColumn, 0, Size - 1);
        
        Player.Position = new Point(newRow, newColumn);
    }

    private void CheckEndConditions ()
    {
        CheckForWin();
        CheckForDeath();
        
    }

    private void CheckForDeath()
    {
        var pos = Player.Position;
        var roomType = _dungeon.Rooms[pos.Row,pos.Column].RoomActions;

        if(roomType is IDangerRooms danger)
        {
            if(!danger.IsCleared)
                KillPlayer(danger.GetDeathReason());
        }
    }

    private void CheckForWin()
    {
        if (!IsFountainActive || Player.Position != Point.Zero)
            return;


        _gameActive = false;
        Console.Clear();
        DungeonRenderer.DisplayDungeon(_dungeon, _player.Position);
        Console.WriteLine("You stand in the entrance of the cavern.");
        Console.WriteLine("You can hear the far off sounds of the reactivated Fountain of Objects.");
        Console.WriteLine("Congratulations on completing your objective.");
    }

    public void EnableFountain()
    {
        IsFountainActive = true;
        Console.WriteLine("The fountain is enabled. Hooray!");
    }

    private void KillPlayer(string causeOfDeath)
    {
        _gameActive = false;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You have died.");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Cause of death: {causeOfDeath}");
    }

    public void DisplayObjective()
    {
        Console.Clear();
        Console.WriteLine("You have entered the Cavern of Objects, maze of rooms where you must find The Fountain of Objects and reactivate it.");
        Console.WriteLine("Light is only visible in the entrance, you must use your other senses to navigate.");
        Console.WriteLine("After reactivating the fountain, return to the entrance to complete the mission.");
        Console.WriteLine("There are dangers lurking in the caverns.");
        Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. Entering a room with a pit leads to death.");
        Console.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location.");
        Console.WriteLine("You will hear their growling and moaning when nearby.");
        Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell them when they are nearby.");
        Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot arrows. Be warned, you only have a limited supply.");
    }

    public void ShootInDirection(Point direction)
    {
        if (Player.ArrowCount <= 0)
            return;

        var row = Player.Position.Row + direction.Row;
        var column = Player.Position.Column + direction.Column;

        if(_dungeon.Rooms[row,column].RoomActions is IDangerRooms danger)
        {
            danger.Clear();
        }
        else
        {
            DungeonRenderer.FireArrow("You hear the arrow clatter to the ground. It doesn't sound like you hit anything.");
        }

        Player.ArrowCount--;
    }

    public void MoveRoom(Point newPosition, RoomType type)
    {
        if(!_dungeon.Rooms[newPosition.Row,newPosition.Column].TryChangeRoom(type))
            Console.WriteLine("You get the feeling that threat was eliminated...");
    }

    public Point GetFountainRoom()
    {
        var position = Size / 2;
        return new (position, position);
    }

    private ICommand GetCommandFromInput(string input)
    {
        var commandArray = input.ToLower().Split (' ');

        return commandArray[0] switch
        {
            "enable" => new EnableCommand(commandArray[1]),
            "move" =>  new MoveCommand(commandArray[1]),
            "shoot" => new ShootCommand(commandArray[1]),
            "help" => new HelpCommand(),
            "exit" => new ExitCommand(),
            _ => throw new NotImplementedException()
        };
    }
}
