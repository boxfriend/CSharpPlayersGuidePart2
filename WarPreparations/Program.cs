using WarPreparations;

var originalSword = new Sword(SwordMaterial.Iron, Gemstone.None);
var diamondSword = originalSword with { Stone = Gemstone.Diamond };
var steelSword = originalSword with { Material = SwordMaterial.Steel };

Console.WriteLine(originalSword);
Console.WriteLine(diamondSword);
Console.WriteLine(steelSword);