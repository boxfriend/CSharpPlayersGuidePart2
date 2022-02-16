namespace RoomCoordinates;

internal readonly struct Coordinate
{
    public int Row { get; init; }
    public int Column { get; init; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacent(Coordinate other)
    {

        if(Row == other.Row)
            return other.Column == Column + 1 || other.Column == Column - 1;

        if(Column == other.Column)
            return other.Row == Row + 1 || other.Row == Row - 1;

        return false;
    }

    public override string ToString () => $"({Row}, {Column})";
}
