namespace CatacombsOfTheClass;

internal class Point
{
    //Answer to challenge question: These are not immutable because I want to be able to modify the point without impacting GC too much
    //Had structs been introduced at this point, this would be a struct and therefore not subject to GC so being immutable would be preferred
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    
    //This technically breaks my personal challenge of not using any concepts not yet discussed in the book.
    //But i'm also lazy and don't want to have to manually convert this to a string every time so we have an override of the object.ToString() method
    public override string ToString () => $"({X},{Y})";

}
