using TicTacToeGame.Enums;

namespace TicTacToeGame.Models;

public class Player(string name, PlayerSymbol symbol, bool isHuman)
{
    public string Name { get; } = name;

    public PlayerSymbol Symbol { get; } = symbol;

    public bool IsHuman { get; } = isHuman;
}
