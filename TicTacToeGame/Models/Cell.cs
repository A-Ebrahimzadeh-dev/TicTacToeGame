using TicTacToeGame.Enums;

namespace TicTacToeGame.Models;

public class Cell
{
    public int Row { get; }

    public int Column { get; }

    public PlayerSymbol Symbol { get; set; }

    public bool IsEmpty => Symbol == PlayerSymbol.Empty;

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
        Symbol = PlayerSymbol.Empty;
    }

    public Cell(int row, int column, PlayerSymbol symbol)
    {
        Row = row;
        Column = column;
        Symbol = symbol;
    }

    public void Clear()
    {
        Symbol = PlayerSymbol.Empty;
    }

    public void PlaceSymbol(PlayerSymbol symbol)
    {
        Symbol = symbol;
    }
}
