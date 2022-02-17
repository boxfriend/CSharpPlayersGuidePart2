namespace ColoredItems;

internal abstract class Item { }
internal class Sword : Item { 
    public Sword () { }
    public override string ToString () => "Sword";
}
internal class Bow : Item { 
    public Bow () { }
    public override string ToString () => "Bow";
}
internal class Axe : Item { 
    public Axe () { }
    public override string ToString () => "Axe";
}
//Overriding ToString() for each of these so it doesn't include the namespace when printing to console