namespace CatacombsOfTheClass;

internal class Color
{
    private int _r;
    private int _g;
    private int _b;
    //Bytes would also be appropriate considering the range of color values, but ints are generally used more
    public int R {
        get => _r;
        set => _r = ValidateValue(value);
    }
    public int G {
        get => _g;
        set => _g = ValidateValue(value);
    }
    public int B {
        get => _b;
        set => _b = ValidateValue(value);
    }

    private int ValidateValue(int value)
    {
        if (value < 0)
            value = 0;
        else if (value > 255)
            value = 255;
       
        return value;
    }

    public static Color Red => new (255, 0, 0);
    public static Color Green => new (0, 128, 0);
    public static Color Blue => new(0, 255, 0);
    public static Color White => new (255,255,255);
    public static Color Black => new (0, 0, 0);
    public static Color Orange => new (255, 165, 0);
    public static Color Yellow => new (255, 255, 0);
    public static Color Purple => new (128, 0, 128);

    
    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public override string ToString () => $"R{R} G{G} B{B}";
}
