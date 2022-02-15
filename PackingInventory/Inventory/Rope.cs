namespace PackingInventory;

internal class Rope : InventoryItem
{
    public Rope () : this(1, 1.5f) { }
    private Rope (float weight, float volume) : base(weight, volume) { }

    public override string ToString () => "Rope";
}
