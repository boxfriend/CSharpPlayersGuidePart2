namespace TheFountainOfObjects;

internal class Room
{
    public RoomType Type { get; private set; } = RoomType.Empty;

    private RoomActions _roomActions = new EmptyRoom();

    public bool IsVisited { get; private set; }

    public bool TryChangeRoom(RoomType newType)
    {
        //Prevents overwriting a non-empty room with a non-empty room
        if (Type != RoomType.Empty && newType != RoomType.Empty)
            return false;

        //Obviously we don't want the fountain to move
        if(Type == RoomType.Fountain)
            return false;

        Type = newType;
        _roomActions = TypeToActions(newType);
        return true;
    }

    public void VisitRoom()
    {
        IsVisited = true;
        _roomActions.RoomAction();
    }

    public void AdjacentAction () => _roomActions.AdjacentAction();

    public void DiagonalAction () => _roomActions.DiagonalAction();

    public override string ToString ()
    {
        if (!IsVisited)
            return "?";

        return _roomActions.Display();
    }

    private RoomActions TypeToActions(RoomType type)
    {
        return type switch
        { 
            RoomType.Fountain => new FountainRoom(),
            _ => new EmptyRoom()
        };
    }
}

enum RoomType
{
    Empty,
    Fountain
}
