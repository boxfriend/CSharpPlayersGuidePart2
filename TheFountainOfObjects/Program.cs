using TheFountainOfObjects;

Console.Title = "The Fountain of Objects";

Console.WriteLine("Welcome to The Fountain of Objects.");
Console.WriteLine("Would you like to attempt this on Easy, Medium, or Hard difficulty?");
var input = GetInput();
var dungeonSize = DifficultyToSize(input);

var gameManager = new GameManager(dungeonSize);
gameManager.BeginGame();

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
        "easy" => true,
        "medium" => true,
        "hard" => true,
        _ => false
    };
}

int DifficultyToSize(string input)
{
    return input.ToLower() switch
    {
        "easy" => 4,
        "medium" => 6,
        "hard" => 8,
        _ => 4
    };
}