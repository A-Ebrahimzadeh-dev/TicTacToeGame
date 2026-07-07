using TicTacToeGame.AI;
using TicTacToeGame.Console;
using TicTacToeGame.Game;

ConsoleHelper console = new();
MiniMax miniMax = new();
AI ai = new(miniMax);

Game game = new(console, ai);
game.Run();