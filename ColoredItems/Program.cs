using ColoredItems;

var coloredSword = new ColoredItem<Sword>();
var coloredBow = new ColoredItem<Bow>(ConsoleColor.Red);
var coloredAxe = new ColoredItem<Axe>() { Color = ConsoleColor.Green };

Console.ForegroundColor = coloredSword.Color;
Console.WriteLine(coloredSword);
Console.ForegroundColor = coloredBow.Color;
Console.WriteLine(coloredBow);
Console.ForegroundColor = coloredAxe.Color;
Console.WriteLine(coloredAxe);
Console.ForegroundColor = ConsoleColor.White;
