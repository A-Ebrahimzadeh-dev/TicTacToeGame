using TicTacToeGame.Game;
using TicTacToeGame.Models;

namespace TicTacToeGame.AI;

public class AI(MiniMax miniMax)
{
    private readonly MiniMax _miniMax = miniMax;

    public Move GetBestMove(Board board)
    {
        ArgumentNullException.ThrowIfNull(board);

        return _miniMax.FindBestMove(board);
    }
}