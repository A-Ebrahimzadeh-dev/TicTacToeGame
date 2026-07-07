using TicTacToeGame.Enums;
using TicTacToeGame.Game;
using TicTacToeGame.Models;

namespace TicTacToeGame.AI;

public class MiniMax
{
    public Move FindBestMove(Board board)
    {
        IReadOnlyList<Move> availableMoves = board.GetAvailableMoves();

        int bestScore = int.MinValue;
        Move? bestMove = null;

        foreach (Move move in availableMoves)
        {
            board.ApplyMove(move, PlayerSymbol.O);

            int score = Search(board, depth: 1, isMaximizing: false);

            board.UndoMove(move);

            if (score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }

        return bestMove!;
    }

    public int Search(Board board, int depth, bool isMaximizing)
    {
        if (IsTerminalState(board, depth, out int terminalScore))
        {
            return terminalScore;
        }

        if (isMaximizing)
        {
            int bestScore = int.MinValue;

            foreach (Move move in board.GetAvailableMoves())
            {
                board.ApplyMove(move, PlayerSymbol.O);

                int score = Search(board, depth + 1, isMaximizing: false);

                board.UndoMove(move);

                bestScore = Math.Max(bestScore, score);
            }

            return bestScore;
        }

        int bestMinScore = int.MaxValue;

        foreach (Move move in board.GetAvailableMoves())
        {
            board.ApplyMove(move, PlayerSymbol.X);

            int score = Search(board, depth + 1, isMaximizing: true);

            board.UndoMove(move);

            bestMinScore = Math.Min(bestMinScore, score);
        }

        return bestMinScore;
    }

    public int Evaluate(Board board, int depth)
    {
        GameResult winner = board.CheckWinner();

        if (winner == GameResult.AIWin)
        {
            return Board.WinScore - depth;
        }

        if (winner == GameResult.HumanWin)
        {
            return depth - Board.WinScore;
        }

        if (board.CheckDraw())
        {
            return 0;
        }

        throw new InvalidOperationException("Evaluate was called on a non-terminal board state.");
    }

    private bool IsTerminalState(Board board, int depth, out int score)
    {
        GameResult winner = board.CheckWinner();

        if (winner != GameResult.None || board.CheckDraw())
        {
            score = Evaluate(board, depth);
            return true;
        }

        score = 0;
        return false;
    }
}
