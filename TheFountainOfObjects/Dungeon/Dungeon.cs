namespace TheFountainOfObjects;

internal class Dungeon
{
    private readonly Room[,] _rooms;

    public Room[,] Rooms => _rooms;
    public int Size { get; }

    public Dungeon(int size)
    {
        _rooms = new Room[size,size];
        Size = size;
        SpawnRooms();
    }

    public void VisitRoom(Point position)
    {
        (var row, var column) = position;
        _rooms[row, column].VisitRoom();
        ScanNearbyRooms(position);
    }

    private void ScanNearbyRooms(Point position)
    {
        for(var i = -1; i <= 1; i++)
        {
            for(var j = -1; j <= 1; j++)
            {
                var row = position.Row + i;
                var column = position.Column + j;
                if(row < 0 || column < 0 || row >= Size || column >= Size)
                    continue;

                var room = _rooms[row,column];
                if (position.IsAdjacent(new Point(row,column)))
                    room.AdjacentAction();
                else
                    room.DiagonalAction();
            }
        }
    }

    private void SpawnRooms ()
    {
        for(var i = 0; i < _rooms.GetLength(0); i++)
        {
            for(var j = 0; j < _rooms.GetLength(1); j++)
            {
                _rooms[i, j] = new Room();
            }
        }
    }
}
