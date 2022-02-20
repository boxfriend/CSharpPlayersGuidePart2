var manticoreHealth = 10;
var consolasHealth = 15;
var roundSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
var roundNumber = 1;

Console.Title = "Hunting the Manticore - Now with RNG!";

//literally all was changed was adding a new Random object and changing distance to be a random number
var rng = new Random();
var distance = rng.Next(100);
Console.Clear();
Console.WriteLine("Player, prepare to defend the city!");

while (manticoreHealth > 0 && consolasHealth > 0)
{
    DisplayRound(roundNumber, consolasHealth, manticoreHealth);
    roundNumber++;
}
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(roundSeparator);
if (manticoreHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Victory! The Manticore has been destroyed! The city of Consolas is safe.");
} else if (consolasHealth <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Unfortunately our heroes have lost. . .");
}
Console.ForegroundColor = ConsoleColor.White;

void DisplayRound (int round, int cityHealth, int enemyHealth)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(roundSeparator);
    Console.WriteLine($"STATUS: Round: {round,3}  City: {cityHealth}/15  Manticore: {enemyHealth}/10");
    var damage = GetDamageAmount(round);
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
    var range = GetNumberInRange("Enter desired cannon range: ");

    var beep = range == distance ? 1000 : 200;
    Console.Beep(beep, 200);
    if (range == distance)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("That was a DIRECT HIT!");
        DamageManticore(damage);
        return;
    }

    var miss = range > distance ? "OVERSHOT" : "UNDERSHOT";
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"That round {miss} the target.");
    DamageCity(1);
}

int GetDamageAmount (int round)
{
    if (round % 3 == 0 && round % 5 == 0)
        return 10;
    else if (round % 3 == 0 || round % 5 == 0)
        return 3;
    else
        return 1;
}

int GetNumberInRange (string text)
{
    Console.Write(text);
    var num = Convert.ToInt32(Console.ReadLine());

    return num > 0 && num < 100 ? num : GetNumberInRange(text);
}

void DamageManticore (int damage) => manticoreHealth -= damage;
void DamageCity (int damage) => consolasHealth -= damage;

/*
 * Answer to challenge question: Since the original Hunting the Manticore challenge happened before classes were introduced a few changes that could be made include the following:
 * Splitting the code up into several classes, one for the Manticore object, one for gathering and validating input, one for the city, one for each weapon, and one for displaying the round
 * Interfaces could include an interface to manage health/taking damage that both the manticore and city implement and one for dealing damage the the weapons implement
 * The weapons could also inherit from a base weapon class that implements the previously mentioned interface
 * there's more i could probably say/change but honestly that's not super important right now, on to the next challenge!
 */