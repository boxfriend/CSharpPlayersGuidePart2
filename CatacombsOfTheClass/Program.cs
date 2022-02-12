using CatacombsOfTheClass;

var sectionSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

var point = new Point(2,3);
var otherPoint = new Point(-4,0);
Console.WriteLine($"Point 1: {point}. Point 2: {otherPoint}");
PassedPedestal(1);

var red = Color.Red;
var funnyColor = new Color(69, 69, 69);
Console.WriteLine($"Red: {red}\nFunny Color: {funnyColor}");
PassedPedestal(2);

var cardDeck = Card.CreateDeck();
foreach(var card in cardDeck)
    Console.WriteLine(card);
PassedPedestal(3);


Console.WriteLine("It's time to mess with doors now.");
Console.Write("You are creating a door, please enter an integer representing its passcode: ");
var passcode = Convert.ToInt32(Console.ReadLine());
var door = new Door(passcode);
Console.WriteLine("You may now enter commands for the door, commands consist of 'open' 'close' 'lock' 'unlock' 'change passcode' and 'exit'.");
while (true)
{
    Console.WriteLine($"The door is {door.State}.");
    Console.Write("What would you like to do? ");
    var command = Console.ReadLine();

    if (command == null)
        continue;

    if (command == "exit")
        break;

    if(!door.ProcessCommand(command))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That didn't work.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
PassedPedestal(4);
Console.WriteLine("You have created a Password Validator class. Let's test it out.");
while(true)
{
    Console.WriteLine("Enter a password to determine if it is valid. Enter 'exit' to leave.");
    Console.Write("Password: ");
    var password = Console.ReadLine();
    if (password == null)
        continue;

    if (password.ToLower() == "exit")
        break;

    if (PasswordValidator.ValidatePassword(password))
        Console.WriteLine("This is a valid password!");
    else
        Console.WriteLine("That password is not valid.");
}
Console.WriteLine(sectionSeparator);
Console.ForegroundColor= ConsoleColor.Green;
Console.WriteLine("You have passed all five pedestals.");
Console.ForegroundColor = ConsoleColor.White;

void PassedPedestal(int pedestalNumber)
{
    var num = pedestalNumber switch
    {
        1 => "first",
        2 => "second",
        3 => "third",
        4 => "fourth",
        5 => "fifth",
        _ => "NaN"
    };
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"You have passed the {num} pedestal.");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(sectionSeparator);
}