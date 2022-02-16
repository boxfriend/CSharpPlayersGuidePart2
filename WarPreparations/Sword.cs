namespace WarPreparations;

internal record class Sword(SwordMaterial Material, Gemstone Stone);

enum SwordMaterial
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

enum Gemstone
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone
}