namespace TheFountainOfObjects;

internal static class DirectionGetter
{
    public static Point GetDirection(string direction)
    {
        return direction switch
        {
            "north" => new Point(-1, 0),
            "south" => new Point(1, 0),
            "east" => new Point(0, 1),
            "west" => new Point(0, -1),
            _ => new Point(0, 0)
        };
    }
}

