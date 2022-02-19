namespace TheFountainOfObjects;

internal class DungeonRenderer
{
    public static void DisplayDungeon(Dungeon dungeon, Point playerPosition)
    {
        Console.Clear();
        for (var i = 0; i < dungeon.Rooms.GetLength(0); i++)
        {
            Console.Write("|");
            for (var j = 0; j < dungeon.Rooms.GetLength(1); j++)
            {
                var room = dungeon.Rooms[i, j];
                var roomChar = playerPosition == new Point(i, j) ? "x" : room.ToString();

                Console.Write(roomChar);
                Console.Write("|");
            }
            Console.WriteLine();
        }
    }

    public static void FireArrow (string result)
    {
        Console.Clear();
        Console.WriteLine("You fire an arrow into the room.");
        Console.WriteLine(result);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(false);
    }
}
