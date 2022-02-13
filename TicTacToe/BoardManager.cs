namespace TicTacToe;

internal class BoardManager
{
    private Cell[,] _cells;

    public BoardManager ()
    {
        _cells = new Cell[3,3];

        for(var i = 0; i < 3; i++)
        {
            for(var j = 0; j < 3; j++)
            {
                _cells[i,j] = new Cell(i,j);
            }
        }
    }

    public Cell TryInsertSymbol(int positionInput, Symbol symbol)
    {
        var cell = InputAsCell(positionInput);
        if (cell.Symbol != Symbol.Empty)
            return null;

        cell.Symbol = symbol;
        return cell;
    }

    public void DisplayBoard()
    {
        var lineSeparator = "---+---+---";
        Console.WriteLine($" {_cells[2,0].Text} | {_cells[2, 1].Text} | {_cells[2, 2].Text} ");
        Console.WriteLine(lineSeparator);
        Console.WriteLine($" {_cells[1, 0].Text} | {_cells[1, 1].Text} | {_cells[1, 2].Text} ");
        Console.WriteLine(lineSeparator);
        Console.WriteLine($" {_cells[0, 0].Text} | {_cells[0, 1].Text} | {_cells[0, 2].Text} ");
    }

    private Cell InputAsCell(int input)
    {
        return input switch
        {
            1 => _cells[0, 0],
            2 => _cells[0, 1],
            3 => _cells[0, 2],
            4 => _cells[1, 0],
            5 => _cells[1, 1],
            6 => _cells[1, 2],
            7 => _cells[2, 0],
            8 => _cells[2, 1],
            9 => _cells[2, 2],
            _ => throw new NotImplementedException()
        };
    }

    public bool HasWon(Cell cell)
    {
        if (cell.Symbol == Symbol.Empty)
            return false;

        return CheckX(cell.X, cell.Symbol) || CheckY(cell.Y, cell.Symbol) || CheckDiag(cell.Symbol);
    }

    private bool CheckX(int x, Symbol symbol)
    {
        for(var i = 0; i < 3; i++)
        {
            if (_cells[x, i].Symbol != symbol)
                return false;
        }

        return true;
    }

    private bool CheckY(int y, Symbol symbol)
    {
        for (var i = 0; i < 3; i++)
        {
            if (_cells[i, y].Symbol != symbol)
                return false;
        }

        return true;
    }

    private bool CheckDiag(Symbol symbol)
    {
        if (_cells[1, 1].Symbol != symbol)
            return false;

        if (_cells[2, 0].Symbol == symbol && _cells[0, 2].Symbol == symbol)
            return true;

        if (_cells[2, 2].Symbol == symbol && _cells[0, 0].Symbol == symbol)
            return true;

        return false;
    }
}
