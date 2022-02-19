namespace TheFountainOfObjects;

//Debated whether to make this a class or have some interfaces, figured class would be easiest so I don't have a whole bunch of unused members in an interface
//and also so i don't have to add even more switches/conditions to determine whether a given room has a specific interface or not
internal abstract class RoomActions
{
    public virtual void RoomAction () { return; }
    public virtual void AdjacentAction () { return; }
    public virtual void DiagonalAction () { return; }
    public virtual string Display () => " ";
}

internal class EmptyRoom : RoomActions { }

internal class FountainRoom : RoomActions
{
    public override void RoomAction () => Console.WriteLine("You hear rushing water nearby. The fountain must be here!");
    public override void AdjacentAction () => Console.WriteLine("You hear a faint dripping from a nearby room");
    public override string Display () => "F";
}

