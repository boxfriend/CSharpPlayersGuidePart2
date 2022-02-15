namespace TheOldRobot;

internal class OnCommand : RobotCommand
{
    public override void Run (Robot bot) => bot.IsPowered = true;
}

internal class OffCommand : RobotCommand
{
    public override void Run (Robot bot) => bot.IsPowered = false;
}

internal class NorthCommand : RobotCommand
{
    public override void Run (Robot bot)
    {
        if(!bot.IsPowered) 
            return;

        bot.Y += 1;
    }
}

internal class SouthCommand : RobotCommand
{
    public override void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.Y -= 1;
    }
}

internal class WestCommand : RobotCommand
{
    public override void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.X -= 1;
    }
}

internal class EastCommand : RobotCommand
{
    public override void Run (Robot bot)
    {
        if (!bot.IsPowered)
            return;

        bot.X += 1;
    }
}