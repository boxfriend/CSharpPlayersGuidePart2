namespace TheFountainOfObjects;

internal class Room
{
    public RoomType Type { get; private set; } = RoomType.Empty;

    public bool IsVisited { get; private set; }

    public bool TryChangeRoom(RoomType newType)
    {
        if (Type != RoomType.Empty && newType != RoomType.Empty)
            return false;

        if(Type == RoomType.Fountain)
            return false;

        Type = newType;
        return true;
    }

    public void VisitRoom()
    {
        IsVisited = true;

        switch (Type)
        {
            case RoomType.Fountain:
                Console.WriteLine("You hear rushing water. The fountain must be here!");
                break;
            default:
                break;
        }
    }

    public void AdjacentAction ()
    {
        switch (Type)
        {
            case RoomType.Fountain:
                Console.WriteLine("You hear a faint dripping from a nearby room");
                break;
            default:
                break;
        }
    }

    public void DiagnonalAction()
    {
        switch (Type)
        {
            default:
                break;
        }
    }

    public override string ToString ()
    {
        if (!IsVisited)
            return "?";

        return Type switch
        {
            RoomType.Fountain => "F",
            _ => " "
        };
    }
}

enum RoomType
{
    Empty,
    Fountain
}
