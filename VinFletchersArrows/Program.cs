Console.Title = "Vin Fletcher's Arrow Shop";

//pseudo-fields
var heads = new string[] { "Steel", "Wood", "Obsidian" };
var fletchings = new string[] { "Plastic", "Turkey Feathers", "Goose Feathers" };

Console.WriteLine("Welcome to Vin Fletcher's Arrow Shop, let's build your dream arrow!");
Console.WriteLine("The Arrow Heads we currently have in stock are: ");
DisplayMenu(heads);
var head = GetInput("Which Arrow Head would you like? ",0, heads.Length);
Console.Clear();
Console.WriteLine("These are the Fletchings we have in stock: ");
DisplayMenu(fletchings);
var fletching = GetInput("Which Fletching would you like? ", 0, fletchings.Length);
Console.Clear();
var shaft = GetInput("How long would you like the arrow shaft to be? (60 - 100)", 60, 100);
var arrow = new Arrow(shaft, IntToArrowHead(head), IntToFletching(fletching));

Console.WriteLine($"You have chosen a {arrow.arrowHead} tipped arrow with {arrow.fletching} fletching that is {arrow.shaftLength}cm long. That will be {arrow.GetCost():#.##} gold.");

int GetInput (string text, int min, int max)
{
    Console.Write(text);
    var num = Convert.ToInt32(Console.ReadLine());
    return num > min && num <= max ? num : GetInput(text, min, max);
}

void DisplayMenu(string[] menu)
{
    for(var i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i+1} - {menu[i]}");
    }
}

ArrowHead IntToArrowHead(int head)
{
    return head switch
    {
        1 => ArrowHead.Steel,
        2 => ArrowHead.Wood,
        3 => ArrowHead.Obsidian,
        _ => ArrowHead.Steel
    };
}

Fletching IntToFletching(int fletching)
{
    return fletching switch
    {
        1 => Fletching.Plastic,
        2 => Fletching.TurkeyFeathers,
        3 => Fletching.GooseFeathers,
        _ => Fletching.Plastic
    };
}

class Arrow
{
    public int shaftLength;
    public ArrowHead arrowHead;
    public Fletching fletching;

    public Arrow(int shaftLength, ArrowHead arrowHead, Fletching fletching)
    {
        this.shaftLength = shaftLength;
        this.arrowHead = arrowHead;
        this.fletching = fletching;
    }

    public float GetCost () => (int)arrowHead + (int)fletching + (shaftLength * 0.05f);
}
enum ArrowHead
{
    Steel = 10,
    Wood = 3,
    Obsidian = 5
}
enum Fletching
{
    Plastic = 10,
    TurkeyFeathers = 5,
    GooseFeathers = 3
}