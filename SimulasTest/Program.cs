var chestState = LockState.Locked;
Console.Title = "Simula's Test";
while(true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"The chest is {GetStateAsString(chestState)}. What do you want to do? ");
    var input = Console.ReadLine();
    if(String.IsNullOrWhiteSpace(input) || !IsValidCommand(input.ToLower()))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid Input. Try again.");
        continue;
    }
    input = input.ToLower();
    if (!IsValidTransition(chestState,input))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You cannot do that right now.");
        continue;
    }

    chestState = GetNewState(input);
}

bool IsValidCommand(string command) => command == "unlock" || command == "lock" || command == "open" || command == "close"; 

bool IsValidTransition(LockState state, string command)
{
    return state switch
    {
        LockState.Locked => command == "unlock",
        LockState.Unlocked => command == "open" || command == "lock",
        LockState.Open => command == "close"
    };
}

LockState GetNewState(string command)
{
    return command switch
    {
        "open" => LockState.Open,
        "close" => LockState.Unlocked,
        "unlock" => LockState.Unlocked,
        "lock" => LockState.Locked
    };
}

string GetStateAsString(LockState state)
{
    return state switch
    {
        LockState.Locked => "locked",
        LockState.Unlocked => "unlocked",
        LockState.Open => "open"
    };
}

enum LockState { Locked, Unlocked, Open }