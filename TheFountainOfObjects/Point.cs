namespace TheFountainOfObjects;

internal record struct Point(int Row, int Column)
{   

    public static readonly Point Zero = new (0, 0);

    public bool IsAdjacent(Point otherPoint)
    {
        if (this == otherPoint)
            return false;

        (var row, var column) = otherPoint;

        if (Row == row)
            return column == Column+1 || column == Column-1;

        if(Column == column)
            return row == Row + 1 || row == Row - 1;

        return false;
    }

    public bool IsDiagonal(Point otherPoint)
    {
        if (this == otherPoint)
            return false;
        
        (var row, var column) = otherPoint;

        if (Row == row || Column == column)
            return false;

        return (Row == row + 1 || Row == row - 1) && (Column == column + 1 || Column == column - 1);
        
    }

    public bool IsNear(Point otherPoint) => IsAdjacent(otherPoint) || IsDiagonal(otherPoint);
}
