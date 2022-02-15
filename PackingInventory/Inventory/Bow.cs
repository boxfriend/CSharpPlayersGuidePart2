namespace PackingInventory.Inventory;

internal class Bow : InventoryItem
{
    public Bow () : this(1, 4) { }
    private Bow (float weight, float volume) : base(weight, volume) { }

    public override string ToString () => "Bow";
}
