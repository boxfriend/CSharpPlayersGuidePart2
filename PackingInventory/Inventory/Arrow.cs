namespace PackingInventory.Inventory;

internal class Arrow : InventoryItem
{
    public Arrow () : this(0.1f, 0.05f) { }
    private Arrow (float weight, float volume) : base(weight, volume) { }
}
