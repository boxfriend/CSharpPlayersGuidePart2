namespace TheOldRobot;

internal abstract class RobotCommand
{
    public abstract void Run (Robot bot);

    public static RobotCommand GetCommandFromInput(string input)
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
