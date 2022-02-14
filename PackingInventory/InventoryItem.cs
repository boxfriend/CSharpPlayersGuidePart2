using PackingInventory.Inventory;

namespace PackingInventory;

internal class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }

    public static InventoryItem CreateItemFromInt(int item)
    {
        return item switch 
        { 
            1 => new Arrow(),
            2 => new Bow(),
            3 => new Rations(),
            4 => new Rope(),
            5 => new Sword(),
            6 => new Water(),
            _ => throw new NotSupportedException(),
        };
    }
}

