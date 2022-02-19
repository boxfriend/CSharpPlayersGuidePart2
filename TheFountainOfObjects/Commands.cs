using System;

namespace TheFountainOfObjects;
internal interface ICommand
{
    void Execute(GameManager manager);
}

internal class EnableCommand : ICommand
{
    private readonly string _commandAction;

    public EnableCommand(string commandAction) => _commandAction = commandAction;

    public void Execute(GameManager manager)
    {
        if (_commandAction != "fountain" || manager.Player.Position != manager.GetFountainRoom())
        {
            Console.WriteLine("Command failed to execute. Are you sure it is time to use that?");
            return;
        }

        manager.EnableFountain();
    }
}

internal class MoveCommand : ICommand 
{
    private readonly string _commandAction;
    public MoveCommand(string commandAction) => _commandAction = commandAction;
    public void Execute(GameManager manager)
    {
        var dir = DirectionGetter.GetDirection(_commandAction);

        manager.MovePlayer(dir);
    }
}
internal class HelpCommand : ICommand
{

    private static string[] _commands = new string[]
    {
        "Help - Displays 'Help' screen and information about commands",
        "Move <direction> - Allows movement in a direction 'north', 'south', 'east', or 'west'.",
        "Shoot <direction> - Fires an arrow into the room in the direction specified.",
        "Enable Fountain - Turns the Fountain of Objects on.",
        "Exit - Exit the application"
    };

    public void Execute(GameManager manager)
    {
        Console.Title = "Help menu";
        manager.DisplayObjective();
        Console.WriteLine();
        foreach(var command in _commands)
            Console.WriteLine(command);

        Console.WriteLine("Press any key to return to the game...");
        Console.ReadKey(false);
        Console.Title = "The Fountain of Objects";
    }
}

internal class ExitCommand : ICommand
{
    public void Execute (GameManager manager) => Environment.Exit(0);
}

internal class ShootCommand : ICommand
{
    private readonly string _commandAction;

    public ShootCommand (string commandAction) => _commandAction = commandAction;
    public void Execute(GameManager manager)
    {
        var dir = DirectionGetter.GetDirection (_commandAction);
        manager.ShootInDirection(dir);
    }
}