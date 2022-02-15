namespace PackingInventory;

internal class Rations : InventoryItem
{
    public Rations() : this(1, 0.5f) { }
    private Rations(float weight, float volume) : base(weight, volume) { }

    public override string ToString () => "Ration";
}
