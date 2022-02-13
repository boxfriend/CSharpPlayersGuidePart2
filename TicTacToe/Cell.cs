namespace TicTacToe;

internal class Cell
{
    public int X { get; }
    public int Y { get; }
    public Symbol Symbol 
    {
        get => _symbol;
        set
        {
            _symbol = value;
            Text = value == Symbol.Empty ? " " : value.ToString();
        }
    }

    private Symbol _symbol = Symbol.Empty;

    public string Text { get; private set; } = " ";

    public Cell(int x, int y)
    {
        X = x; 
        Y = y;
    }
}
