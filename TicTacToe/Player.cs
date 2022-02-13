namespace TicTacToe;

internal class Player
{
    public Symbol Symbol { get; init; }
}

public enum Symbol { X = 0, O = 1, Empty = -1 }