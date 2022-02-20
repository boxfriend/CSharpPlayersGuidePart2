using TheOldRobot;

Console.Title = "The Old Robot";
var robot = new Robot();
Console.WriteLine("You come across an old robot. You may give it commands to operate.");

var i = 1;
while(true)
{
    var input = GetInput(i++);

    if (input == "stop")
        break;

    robot.Commands.Add(Robot.GetCommandFromInput(input));
}

robot.Run();


string GetInput (int commandNumber)
{
    var input = "";
    while(!ValidateInput(input!))
    {
        Console.WriteLine("Valid Commands: On Off North South East West");
        Console.WriteLine("Enter Stop if you wish to stop entering commands.");
        Console.Write($"Input command number {commandNumber}: ");
        input = Console.ReadLine();
    }
    return input!;
}

bool ValidateInput(string input)
{
    if (string.IsNullOrEmpty(input))
        return false;

    input = input.ToLower().Trim();

    return input == "on" || input == "off" || 
        input == "north" || input == "south" || 
        input == "east" || input == "west" || input == "stop";
}