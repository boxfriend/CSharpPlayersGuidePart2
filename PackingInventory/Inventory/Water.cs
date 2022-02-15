namespace PackingInventory;

internal class Water : InventoryItem
{
    public Water () : this(2, 3) { }
    private Water (float weight, float volume) : base(weight, volume) { }

    public override string ToString () => "Water";
}
