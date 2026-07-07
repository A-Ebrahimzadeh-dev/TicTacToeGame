using TicTacToeGame.Enums;
using TicTacToeGame.Models;

namespace TicTacToeGame.Game;

public class Board
{
    public const int Size = 3;

    public const int WinScore = 10;

    private readonly Cell[,] _cells;

    public Board()
    {
        _cells = new Cell[Size, Size];

        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                _cells[row, column] = new Cell(row, column);
            }
        }
    }

    public PlayerSymbol GetSymbol(int row, int column)
    {
        ValidateCoordinates(row, column);
        return _cells[row, column].Symbol;
    }

    public void ApplyMove(Move move, PlayerSymbol symbol)
    {
        ValidateCoordinates(move.Row, move.Column);
        _cells[move.Row, move.Column].PlaceSymbol(symbol);
    }

    public void UndoMove(Move move)
    {
        ValidateCoordinates(move.Row, move.Column);
        _cells[move.Row, move.Column].Clear();
    }

    public GameResult CheckWinner()
    {
        for (int row = 0; row < Size; row++)
        {
            GameResult rowResult = CheckLineWinner(
                _cells[row, 0].Symbol,
                _cells[row, 1].Symbol,
                _cells[row, 2].Symbol);

            if (rowResult != GameResult.None)
            {
                return rowResult;
            }
        }

        for (int column = 0; column < Size; column++)
        {
            GameResult columnResult = CheckLineWinner(
                _cells[0, column].Symbol,
                _cells[1, column].Symbol,
                _cells[2, column].Symbol);

            if (columnResult != GameResult.None)
            {
                return columnResult;
            }
        }

        GameResult mainDiagonalResult = CheckLineWinner(
            _cells[0, 0].Symbol,
            _cells[1, 1].Symbol,
            _cells[2, 2].Symbol);

        if (mainDiagonalResult != GameResult.None)
        {
            return mainDiagonalResult;
        }

        GameResult antiDiagonalResult = CheckLineWinner(
            _cells[0, 2].Symbol,
            _cells[1, 1].Symbol,
            _cells[2, 0].Symbol);

        return antiDiagonalResult;
    }

    public bool CheckDraw()
    {
        return IsFull() && CheckWinner() == GameResult.None;
    }

    public bool IsFull()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                if (_cells[row, column].IsEmpty)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool IsCellEmpty(int row, int column)
    {
        ValidateCoordinates(row, column);
        return _cells[row, column].IsEmpty;
    }

    public IReadOnlyList<Move> GetAvailableMoves()
    {
        List<Move> availableMoves = new List<Move>();

        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                if (_cells[row, column].IsEmpty)
                {
                    availableMoves.Add(new Move(row, column));
                }
            }
        }

        return availableMoves;
    }

    public void Reset()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                _cells[row, column].Clear();
            }
        }
    }

    private static GameResult CheckLineWinner(
        PlayerSymbol first,
        PlayerSymbol second,
        PlayerSymbol third)
    {
        if (first == PlayerSymbol.Empty)
        {
            return GameResult.None;
        }

        if (first == second && second == third)
        {
            return first switch
            {
                PlayerSymbol.X => GameResult.HumanWin,
                PlayerSymbol.O => GameResult.AIWin,
                _ => GameResult.None
            };
        }

        return GameResult.None;
    }

    private static void ValidateCoordinates(int row, int column)
    {
        if (row < 0 || row >= Size || column < 0 || column >= Size)
        {
            throw new ArgumentOutOfRangeException(
                $"Coordinates ({row}, {column}) are outside the {Size}x{Size} board.");
        }
    }
}
