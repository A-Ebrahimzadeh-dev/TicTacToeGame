namespace TicTacToeGame.Models;

public class Move(int row, int column)
{
    public int Row { get; } = row;

    public int Column { get; } = column;
}
