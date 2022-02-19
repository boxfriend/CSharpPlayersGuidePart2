namespace TheFountainOfObjects;

//Debated whether to make this a class or have some interfaces, figured class would be easiest so I don't have a whole bunch of unused members in an interface
//and also so i don't have to add even more switches/conditions to determine whether a given room has a specific interface or not
internal abstract class RoomActions
{
    public virtual void RoomAction (Room thisRoom) { return; }
    public virtual void AdjacentAction () { return; }
    public virtual void DiagonalAction () { return; }
    public virtual string Display () => " ";
}
internal interface IDangerRooms
{
    public string GetDeathReason ();
    public bool IsCleared { get; }
    public void Clear ();
}

internal class EntranceRoom : RoomActions
{
    public override void RoomAction (Room thisRoom) => Console.WriteLine("You see light coming from outside. This must be the entrance.");
}

internal class EmptyRoom : RoomActions {
    public override void RoomAction (Room thisRoom) => Console.WriteLine("You are standing in a room of complete darkness. Somehow you can tell there is nothing here.");
}

internal class FountainRoom : RoomActions
{
    public override void RoomAction (Room thisRoom)
    {
        if(!GameManager.IsFountainActive)
            Console.WriteLine("You hear dripping water nearby. The fountain must be here!");
        else
            Console.WriteLine("You hear rushing water! The Fountain of Objects is active!");
    }

    public override void AdjacentAction ()
    {
        if (!GameManager.IsFountainActive)
            Console.WriteLine("You hear a faint dripping from a nearby room.");
        else
            Console.WriteLine("You hear the rushing of water from a nearby room.");
    }

    public override void DiagonalAction ()
    {
        if(GameManager.IsFountainActive)
            Console.WriteLine("You hear the rushing of water from somewhere nearby.");
    }

    public override string Display () => "F";
}

internal class PitRoom : RoomActions, IDangerRooms
{
    public bool IsCleared { get; } = false;
    public void Clear ()
    {
        DungeonRenderer.FireArrow("It doesn't sound like you hit anything.");
    }

    public override void AdjacentAction () => Console.WriteLine("You feel a strong draft from a nearby room.");
    public override void DiagonalAction () => Console.WriteLine("You feel a draft from somewhere nearby.");

    public string GetDeathReason () => "fell into a pit.";
}

internal class AmarokRoom : RoomActions, IDangerRooms
{
    public bool IsCleared { get; private set; } = false;

    public void Clear ()
    {
        IsCleared = true;
        DungeonRenderer.FireArrow("You hear the piercing cry of a dying monster. Success!");
    }

    public override void AdjacentAction ()
    {
        if (!IsCleared) 
            Console.WriteLine("You smell the strong stench of a monster in a nearby room."); 
    }


    public override void DiagonalAction ()
    {
        if (!IsCleared)
            Console.WriteLine("You smell the stench of a monster somewhere nearby.");
    }

    public string GetDeathReason () => "mauled by a monster.";
}

internal class MaelstromRoom : RoomActions, IDangerRooms
{
    public bool IsCleared { get; } = true;

    public void Clear ()
    {
        DungeonRenderer.FireArrow("You feel wind brush against your head and hear the clatter of an arrow behind you.");
    }

    public override void RoomAction (Room thisRoom)
    {
        Console.WriteLine("A strong wind has pushed you into another room...");
        thisRoom.TryChangeRoom(RoomType.Empty);
        var playerDirection = new Point(1,1);
        var playerPosition = GameManager.Instance.Player.Position;
        GameManager.Instance.MovePlayer(playerDirection);

        var newRow = playerPosition.Row - 2;
        var newColumn = playerPosition.Column - 2;

        newRow = Math.Clamp(newRow, 0, GameManager.Instance.Size-1);
        newColumn = Math.Clamp(newColumn, 0, GameManager.Instance.Size-1);
        var newPos = new Point(newRow, newColumn);
        GameManager.Instance.MoveRoom(newPos,RoomType.Maelstrom);
    }

    public override void AdjacentAction () => Console.WriteLine("You hear the growling and groaning of a maelstrom wreaking havoc in a nearby room.");
    public override void DiagonalAction () => Console.WriteLine("You hear the wind of a maelstrom somewhere nearby.");

    public string GetDeathReason () => string.Empty;
}