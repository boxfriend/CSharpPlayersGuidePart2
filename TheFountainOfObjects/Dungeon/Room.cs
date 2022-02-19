namespace TheFountainOfObjects;

internal class Room
{
    public RoomType Type { get; private set; } = RoomType.Empty;

    public RoomActions RoomActions { get; private set; } = new EmptyRoom();

    public bool IsVisited { get; private set; }

    public bool TryChangeRoom(RoomType newType)
    {
        //Prevents overwriting a non-empty room with a non-empty room
        if (Type != RoomType.Empty && newType != RoomType.Empty)
            return false;

        //Obviously we don't want the entrance or fountain to move
        if(Type == RoomType.Fountain || Type == RoomType.Entrance)
            return false;

        Type = newType;
        RoomActions = TypeToActions(newType);
        return true;
    }

    public void VisitRoom()
    {
        IsVisited = true;
        RoomActions.RoomAction(this);
    }

    public void AdjacentAction () => RoomActions.AdjacentAction();

    public void DiagonalAction () => RoomActions.DiagonalAction();

    public override string ToString ()
    {
        if (!IsVisited)
            return "?";

        return RoomActions.Display();
    }

    private RoomActions TypeToActions(RoomType type)
    {
        return type switch
        { 
            RoomType.Entrance => new EntranceRoom(),
            RoomType.Fountain => new FountainRoom(),
            RoomType.Pit => new PitRoom(),
            RoomType.Amarok => new AmarokRoom(),
            RoomType.Maelstrom => new MaelstromRoom(),
            _ => new EmptyRoom()
        };
    }
}

enum RoomType
{
    Empty,
    Fountain,
    Pit,
    Amarok,
    Maelstrom,
    Entrance
}
