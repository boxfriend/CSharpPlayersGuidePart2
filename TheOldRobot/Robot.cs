namespace TheOldRobot;

internal class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new ();
    public void Run()
    {
        foreach(IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }

    //Moved factory method to Robot class since it doesn't make much sense for it to be part of an interface
    public static IRobotCommand GetCommandFromInput (string input)
    {
        return input.ToLower() switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "south" => new SouthCommand(),
            "east" => new EastCommand(),
            "west" => new WestCommand(),
            _ => throw new NotImplementedException()
        };
    }
}
