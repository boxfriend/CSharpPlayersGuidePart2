using TheFountainOfObjects;

Console.Title = "The Fountain of Objects";

Console.WriteLine("Welcome to The Fountain of Objects.");
Console.WriteLine("Would you like to attempt this on Story, Easy, Medium, or Hard difficulty?");
var input = GetInput();
var dungeonSize = DifficultyToSize(input);

//Time in the Cavern challenge
var dungeonStart = DateTime.Now;

var gameManager = new GameManager(dungeonSize);
gameManager.BeginGame();

var elapsedTime = DateTime.Now - dungeonStart;
Console.WriteLine($"You completed the objective in {elapsedTime.Hours} hours, {elapsedTime.Minutes} minutes, and {elapsedTime.Seconds} seconds.");

string GetInput()
{
    var input = "";
    while(!ValidateInput(input!))
    {
        Console.Write("Please enter your preferred difficulty level: ");
        input = Console.ReadLine();
    }

    return input;
}

bool ValidateInput(string input)
{
    if(string.IsNullOrWhiteSpace(input))
        return false;

    return input.ToLower() switch
    {
        "story" => true,
        "easy" => true,
        "medium" => true,
        "hard" => true,
        _ => false
    };
}

Difficulty DifficultyToSize(string input)
{
    return input.ToLower() switch
    {
        "story" => Difficulty.Story,
        "easy" => Difficulty.Easy,
        "medium" => Difficulty.Medium,
        "hard" => Difficulty.Hard,
        _ => Difficulty.Easy
    };
}