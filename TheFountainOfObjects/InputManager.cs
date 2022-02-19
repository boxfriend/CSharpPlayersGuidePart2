namespace TheFountainOfObjects;
internal class InputManager
{
    private static string[] _validCommands = new string[] { "move", "enable" };

    public string GetInput()
    {
        var input = "";
        while(!ValidateInput(input!))
        {
            Console.Write("Enter a valid command: ");
            input = Console.ReadLine();
        }

        return input;
    }
    private static bool ValidateInput(string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        var commandArray = input.ToLower().Split(' ');

        if (commandArray.Length < 1)
            return false;

        return commandArray[0] switch
        {
            "enable" => commandArray[1] == "fountain",
            "move" => commandArray[1] == "east" || commandArray[1] == "west" || commandArray[1] == "north" || commandArray[1] == "south",
            "shoot" => commandArray[1] == "east" || commandArray[1] == "west" || commandArray[1] == "north" || commandArray[1] == "south",
            "help" => true,
            "exit" => true,
            _ => false
        };
    }
}
