namespace TheOldRobot;

internal class OnCommand : IRobotCommand
{
    public void Run (Robot bot) => bot.IsPowered = true;
}

internal class OffCommand : IRobotCommand
{
    public void Run (Robot bot) => bot.IsPowered = false;
}

internal class NorthCommand : IRobotCommand
{
    public void Run (Robot bot)
    {
        if(!bot.IsPowered) 
            return;

        bot.Y += 1;
    }
}

internal class SouthCommand : IRobotCommand
{
    public void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.Y -= 1;
    }
}

internal class WestCommand : IRobotCommand
{
    public void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.X -= 1;
    }
}

internal class EastCommand : IRobotCommand
{
    public void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.X += 1;
    }
}