using RoomCoordinates;

//So apparently the Random class is introduced later in the book making this illegal for my personal challenge
//I'm going to allow it though because otherwise this becomes tedious AF
var rng = new Random();
var coords = new Coordinate[10];
for(var i = 0; i < 10; i++)
    coords[i] = new Coordinate(rng.Next(0,10), rng.Next(0,10));

foreach(var coord in coords)
    Console.WriteLine(coord);

for(var j = 0; j < 10; j++)
{
    var coord1 = coords[rng.Next(0,coords.Length)];
    var coord2 = coords[rng.Next(0, coords.Length)];
    Console.WriteLine($"Coordinate {coord1} adjacent to {coord2}? {coord1.IsAdjacent(coord2)}");
}

