using TicTacToeGame.AI;
using TicTacToeGame.Console;
using TicTacToeGame.Enums;
using TicTacToeGame.Models;

namespace TicTacToeGame.Game;

public class Game(ConsoleHelper console, AI.AI ai)
{
    private const string HumanPlayerName = "Human";
    private const string AiPlayerName = "AI";

    private readonly ConsoleHelper _console = console;
    private readonly AI.AI _ai = ai;
    private readonly Board _board = new Board();
    private readonly Player _humanPlayer = new Player(HumanPlayerName, PlayerSymbol.X, isHuman: true);
    private readonly Player _aiPlayer = new Player(AiPlayerName, PlayerSymbol.O, isHuman: false);

    public void Run()
    {
        _console.DisplayMessage("Welcome to Tic Tac Toe!");
        _console.DisplayMessage("You are X. The AI is O. You always move first.");
        _console.DisplayMessage($"Enter row and column between 0 and {Board.Size - 1}.");

        bool playAgain = true;

        while (playAgain)
        {
            PlaySingleGame();
            playAgain = _console.AskPlayAgain();
        }

        _console.DisplayMessage("Thanks for playing!");
    }

    private void PlaySingleGame()
    {
        _board.Reset();
        _console.DisplayMessage(string.Empty);
        _console.DisplayMessage("--- New Game ---");
        _console.DisplayBoard(_board);

        while (true)
        {
            if (!ExecuteHumanTurn())
            {
                continue;
            }

            if (TryFinishGame())
            {
                return;
            }

            ExecuteAiTurn();

            if (TryFinishGame())
            {
                return;
            }
        }
    }

    private bool ExecuteHumanTurn()
    {
        _console.DisplayMessage(string.Empty);
        _console.DisplayMessage("Your turn (X).");

        Move move = _console.ReadMove();

        if (!IsWithinBounds(move))
        {
            _console.DisplayMessage(
                $"Invalid input: coordinates must be between 0 and {Board.Size - 1}.");
            return false;
        }

        if (!_board.IsCellEmpty(move.Row, move.Column))
        {
            _console.DisplayMessage("That cell is already occupied. Choose another one.");
            return false;
        }

        _board.ApplyMove(move, _humanPlayer.Symbol);
        _console.DisplayBoard(_board);
        return true;
    }

    private void ExecuteAiTurn()
    {
        _console.DisplayMessage(string.Empty);
        _console.DisplayMessage("AI is thinking...");

        Move move = _ai.GetBestMove(_board);
        _board.ApplyMove(move, _aiPlayer.Symbol);
        _console.DisplayBoard(_board);
    }

    private bool TryFinishGame()
    {
        GameResult result = _board.CheckWinner();

        if (result == GameResult.None && _board.CheckDraw())
        {
            result = GameResult.Draw;
        }

        if (result == GameResult.None)
        {
            return false;
        }

        _console.DisplayMessage(string.Empty);
        _console.DisplayMessage(GetResultMessage(result));
        return true;
    }

    private static bool IsWithinBounds(Move move)
    {
        return move.Row >= 0
            && move.Row < Board.Size
            && move.Column >= 0
            && move.Column < Board.Size;
    }

    private static string GetResultMessage(GameResult result)
    {
        return result switch
        {
            GameResult.HumanWin => "You win! Congratulations!",
            GameResult.AIWin => "AI wins! Better luck next time.",
            GameResult.Draw => "It's a draw!",
            _ => "The game has ended."
        };
    }
}
