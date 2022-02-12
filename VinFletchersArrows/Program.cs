Console.Title = "Vin Fletcher's Arrow Shop";

//pseudo-fields used for pretty menu options
var options = new string[] { "Buy Premade Arrow", "Build Custom Arrow" };
var heads = new string[] { "Steel", "Wood", "Obsidian" };
var fletchings = new string[] { "Plastic", "Turkey Feathers", "Goose Feathers" };
var premades = new string[] { "Elite Arrow", "Beginner Arrow", "Marksman Arrow" };

Console.WriteLine("Welcome to Vin Fletcher's Arrow Shop, let's build your dream arrow!");
DisplayMenu(options);
var optionInput = GetInput("Which would you like? ",0, options.Length);

var arrow = optionInput == (int)Options.Premade ? SelectPremadeArrow() : BuildCustomArrow();

//This line has also been modified for Vin's Trouble challenge and again for The Properties of Arrows challenge
Console.WriteLine($"You have chosen a {arrow.ArrowHead} tipped arrow with {arrow.Fletching} fletching that is {arrow.Length}cm long. That will be {arrow.Cost:#.##} gold.");

//These next two methods are not very pretty, but until we're making multiple classes this is how they will stay
Arrow BuildCustomArrow()
{
    Console.WriteLine("The Arrow Heads we currently have in stock are: ");
    DisplayMenu(heads);
    var headInput = GetInput("Which Arrow Head would you like? ", 0, heads.Length);
    Console.Clear();
    Console.WriteLine("These are the Fletchings we have in stock: ");
    DisplayMenu(fletchings);
    var fletchingInput = GetInput("Which Fletching would you like? ", 0, fletchings.Length);
    Console.Clear();
    var shaft = GetInput("How long would you like the arrow shaft to be? (60 - 100)", 60, 100);
    return new Arrow(shaft, IntToArrowHead(headInput), IntToFletching(fletchingInput));
}

Arrow SelectPremadeArrow()
{
    Console.WriteLine("The premade arrows currently in stock are: ");
    DisplayMenu(premades);
    var input = GetInput("Which Arrow would you like? ",0,premades.Length);

    return input switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow(),
        _ => Arrow.CreateEliteArrow()
    };
}

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
    Console.WriteLine($"Select an option using a number from 1 - {menu.Length}");
}

ArrowHead IntToArrowHead(int head)
{
    return head switch
    {
        1 => ArrowHead.Steel,
        2 => ArrowHead.Wood,
        3 => ArrowHead.Obsidian,
        _ => ArrowHead.Steel //Not necessary because input is limited, but i don't like disabling warnings so this is only here to make the compiler happy
    };
}

Fletching IntToFletching(int fletching)
{
    return fletching switch
    {
        1 => Fletching.Plastic,
        2 => Fletching.TurkeyFeathers,
        3 => Fletching.GooseFeathers,
        _ => Fletching.Plastic //Ditto previous comment
    };
}

//Modified for Vin's Trouble challenge and again for The Properties of Arrows challenge and finally for the Arrow Factories challenge
class Arrow
{
    private readonly static float _lengthCost = 0.05f;

    private readonly int _shaftLength;
    private readonly ArrowHead _arrowHead;
    private readonly Fletching _fletching;
    private readonly float _cost;
    

    public ArrowHead ArrowHead => _arrowHead;
    public Fletching Fletching => _fletching;
    public int Length => _shaftLength;

    public float Cost => _cost;

    public Arrow(int shaftLength, ArrowHead arrowHead, Fletching fletching)
    {
        _shaftLength = shaftLength;
        _arrowHead = arrowHead;
        _fletching = fletching;

        //Realized accessing the property would needlessly calculate this every time, setting it once is more efficient
        _cost = (int)_arrowHead + (int)_fletching + (_shaftLength * _lengthCost);
    }

    public static Arrow CreateEliteArrow () => new (95, ArrowHead.Steel, Fletching.Plastic);
    public static Arrow CreateBeginnerArrow () => new (75, ArrowHead.Wood, Fletching.GooseFeathers);
    public static Arrow CreateMarksmanArrow () => new (65, ArrowHead.Obsidian, Fletching.TurkeyFeathers);
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

enum Options
{
    Premade = 1,
    Custom = 2
}