using PackingInventory;

Console.Title = "Packing Inventory";

var items = new string[] { "Arrow", "Bow", "Food Rations", "Rope", "Sword", "Water" };

Console.WriteLine("You are packing for the dangerous journey ahead.");
Console.WriteLine("Would you like to get a Standard Pack which holds 10 items?");
Console.Write("Press 'y' to get a Standard Pack. Press any other key to customize a pack: ");
var key = Console.ReadKey().KeyChar;
var pack = key == 'y' ? Pack.CreateStandardPack() : BuildAPack();
DisplayPack(pack,true);

while(!pack.IsFull)
{

    Console.Clear();
    DisplayPack(pack, true);
    Console.WriteLine("What would you like to add to your pack?");
    DisplayItems();
    var input = GetInput();
    if (input > items.Length)
        continue;

    var num = Convert.ToInt32(input);
    var itemToAdd = InventoryItem.CreateItemFromInt(num+1);
    if(!pack.Add(itemToAdd))
    {
        Console.WriteLine("You cannot add that right now.");
    }

    DisplayPack(pack,false);
    Console.WriteLine("Press 'q' to stop adding things to your pack.");
    var quitKey = Console.ReadKey().KeyChar;
    if (quitKey == 'q')
        break;
}

if (pack.IsFull)
    Console.WriteLine("Your pack is now full and cannot be added to.");
else
    Console.WriteLine("You have stopped packing your bags");

DisplayPack(pack,true);


void DisplayItems()
{
    for(var i = 0; i < items.Length; i++)
    {
        Console.WriteLine($"{i+1} - {items[i]}");
    }
}

Pack BuildAPack()
{

    Console.WriteLine("How many items should your pack hold?");
    var capacity = GetInput();
    Console.WriteLine("How many pounds of weight should your pack hold?");
    var weight = GetInput();
    Console.WriteLine("How much volume should your pack contain?");
    var volume = GetInput();

    return new (capacity, weight, volume);
}

void DisplayPack(Pack pack, bool all)
{
    if(all) Console.WriteLine($"You have a {pack.Capacity} slot pack. It can hold {pack.MaxWeight} pounds with volume of {pack.MaxVolume}");
    Console.WriteLine($"Your pack currently contains {pack.Contains} items that weigh a total of {pack.Weight} pounds with a contained volume of {pack.Volume}");
}
int GetInput()
{
    var input = "";
    while(!ValidateInput(input!))
    {
        Console.Write("Enter a whole number greater than 0: ");
        input = Console.ReadLine();
    }

    return Convert.ToInt32(input);
}
static bool ValidateInput (string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        return false;
    }

    foreach (var ch in input)
    {
        if (!char.IsDigit(ch))
        {
            return false;
        }
    }

    var num = Convert.ToInt32(input);
    return num > 0;
}