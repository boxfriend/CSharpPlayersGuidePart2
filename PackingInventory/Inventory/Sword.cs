namespace PackingInventory;

internal class Sword : InventoryItem
{
    public Sword() : this(5, 3) { }
    private Sword (float weight, float volume) : base(weight, volume) { }
}
