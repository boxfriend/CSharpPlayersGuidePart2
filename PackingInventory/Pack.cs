namespace PackingInventory;

internal class Pack
{
    private readonly InventoryItem[] _inventory;
    private int _index;
    public int Capacity { get; init; }
    public float MaxWeight { get; init; }
    public float MaxVolume { get; init; }
    public int Contains => _index;
    public float Weight { get; private set; }
    public float Volume { get; private set; }

    public bool IsFull => _index >= Capacity || Weight >= MaxWeight || Volume >= MaxVolume;

    public Pack (int capacity, float maxWeight, float maxVolume)
    {
        //ensures a minimum of 1 to prevent completely empty packs, would throw an error normally but those haven't been introduced yet
        capacity = capacity > 0 ? capacity : 1;
        maxWeight = maxWeight > 0 ? maxWeight : 1;
        maxVolume = maxVolume > 0 ? maxVolume : 1;

        Capacity = capacity;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;

        _inventory = new InventoryItem[capacity];
    }

    public static Pack CreateStandardPack () => new(10, 10, 10);

    public bool Add(InventoryItem item)
    {
        if (_index >= Capacity || Weight + item.Weight > MaxWeight || Volume + item.Volume > MaxVolume)
            return false;

        _inventory[_index++] = item;
        Weight += item.Weight;
        Volume += item.Volume;
        return true;
    }

    public override string ToString ()
    {
        var str = "Pack containing: ";
        foreach(var item in _inventory)
            str += $"{item?.ToString()} ";

        return str;
    }
}
