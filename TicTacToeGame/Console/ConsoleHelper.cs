using TicTacToeGame.Enums;
using TicTacToeGame.Game;
using TicTacToeGame.Models;

namespace TicTacToeGame.Console;

public class ConsoleHelper
{
    public void DisplayMessage(string message)
    {
        System.Console.WriteLine(message);
    }

    public void DisplayBoard(Board board)
    {
        System.Console.WriteLine();

        System.Console.WriteLine("    0   1   2");

        for (int row = 0; row < Board.Size; row++)
        {
            System.Console.Write($"{row} ");

            for (int column = 0; column < Board.Size; column++)
            {
                char symbol = GetSymbolCharacter(board.GetSymbol(row, column));

                System.Console.Write($" {symbol} ");

                if (column < Board.Size - 1)
                {
                    System.Console.Write("|");
                }
            }

            System.Console.WriteLine();

            if (row < Board.Size - 1)
            {
                System.Console.WriteLine("   ---+---+---");
            }
        }

        System.Console.WriteLine();
    }

    public Move ReadMove()
    {
        while (true)
        {
            System.Console.Write("Row: ");

            if (!int.TryParse(System.Console.ReadLine(), out int row))
            {
                DisplayMessage("Please enter a valid integer.");
                continue;
            }

            System.Console.Write("Column: ");

            if (!int.TryParse(System.Console.ReadLine(), out int column))
            {
                DisplayMessage("Please enter a valid integer.");
                continue;
            }

            return new Move(row, column);
        }
    }

    public bool AskPlayAgain()
    {
        while (true)
        {
            System.Console.Write("Play again? (Y/N): ");

            string? input = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            input = input.Trim().ToUpperInvariant();

            if (input == "Y")
            {
                return true;
            }

            if (input == "N")
            {
                return false;
            }

            DisplayMessage("Please enter Y or N.");
        }
    }

    private static char GetSymbolCharacter(PlayerSymbol symbol)
    {
        return symbol switch
        {
            PlayerSymbol.X => 'X',
            PlayerSymbol.O => 'O',
            _ => ' '
        };
    }
}