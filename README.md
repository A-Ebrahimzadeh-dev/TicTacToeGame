# TicTacToeGame

![Game](https://img.shields.io/badge/Game-Tic--Tac--Toe-orange)
![Platform](https://img.shields.io/badge/Platform-.NET%208-blue)
![Language](https://img.shields.io/badge/Language-C%23-purple)
![AI](https://img.shields.io/badge/AI-Minimax-red)
![License](https://img.shields.io/badge/License-MIT-green)

A C# (.NET Console) implementation of the classic Tic-Tac-Toe game featuring an AI opponent powered by the Minimax search algorithm. Developed as an educational project with a clean object-oriented architecture.

---

# 📖 Overview

This project implements the classic **3×3 Tic-Tac-Toe** game as a **C# .NET Console Application**.

The primary objective is not only to create a playable game, but also to demonstrate the implementation of the **Minimax search algorithm**, one of the fundamental search algorithms taught in introductory Artificial Intelligence courses.

The AI explores the complete game tree using **Depth-First Search (DFS)** and always selects the optimal move, making it impossible to defeat when both players play optimally.

---

# ✨ Features

- Classic 3×3 Tic-Tac-Toe
- Human vs AI gameplay
- Human player always starts first
- AI powered by the recursive Minimax algorithm
- Complete game tree exploration
- Depth-aware utility evaluation
- Console-based user interface
- Object-Oriented Programming (OOP)
- Clean and modular architecture

---

# 🧠 Artificial Intelligence

The AI uses the **classic recursive Minimax algorithm** without any optimizations.

## Characteristics

- Recursive implementation
- Depth-First Search (DFS)
- Complete state-space exploration
- Terminal state evaluation
- Utility-based decision making
- Backtracking using `ApplyMove()` and `UndoMove()`
- No randomness
- No Alpha-Beta pruning
- No Machine Learning
- No Neural Networks

## Utility Function

| Game Result | Score |
|------------|------:|
| AI Win | `10 - depth` |
| Human Win | `depth - 10` |
| Draw | `0` |

Using the search depth allows the AI to:

- Prefer faster victories.
- Delay unavoidable defeats.
- Always choose the optimal move.

---

# 🏛️ Project Architecture

Each class has a single responsibility and collaborates with the others through a simple, modular design.

```text
Program
│
├── Game
│   ├── Board
│   ├── AI
│   │   └── MiniMax
│   └── ConsoleHelper
│
├── Models
│   ├── Player
│   ├── Move
│   └── Cell
│
└── Enums
    ├── PlayerSymbol
    └── GameResult
```

---

# 📂 Project Structure

```text
TicTacToeGame
│
├── AI
│   ├── AI.cs
│   └── MiniMax.cs
│
├── Console
│   └── ConsoleHelper.cs
│
├── Enums
│   ├── GameResult.cs
│   └── PlayerSymbol.cs
│
├── Game
│   ├── Board.cs
│   └── Game.cs
│
├── Models
│   ├── Cell.cs
│   ├── Move.cs
│   └── Player.cs
│
└── Program.cs
```

---

# 📋 Project Information

| Property | Value |
|----------|-------|
| Language | C# |
| Framework | .NET 8 |
| Application Type | Console |
| AI Algorithm | Minimax |
| Search Strategy | Depth-First Search (DFS) |
| Programming Style | Object-Oriented Programming |
| License | MIT |

---

# ▶️ Running the Project

## Requirements

- .NET SDK 8.0 or later

Clone the repository:

```bash
git clone https://github.com/A-Ebrahimzadeh-dev/TicTacToeGame.git
```

Navigate to the project folder:

```bash
cd TicTacToeGame
```

Run the application:

```bash
dotnet run
```

---

# 🎮 Example Gameplay

```text
    0   1   2

0   X | O | X
   ---+---+---
1     | X |
   ---+---+---
2   O |   |

Your turn (X)

Enter row: 2
Enter column: 2

AI is thinking...
```

---

# 📚 Concepts Demonstrated

- Object-Oriented Programming (OOP)
- Minimax Search Algorithm
- Depth-First Search (DFS)
- Recursive Algorithms
- Backtracking
- State Space Search
- Utility Functions
- Single Responsibility Principle (SRP)
- Clean Architecture

---

# 🚀 Future Improvements

Possible future enhancements include:

- Alpha-Beta Pruning
- Difficulty Levels
- WinForms or WPF graphical interface
- Multiplayer mode
- Move history
- Game statistics

---

# 🎓 Educational Purpose

This project was developed as part of an Artificial Intelligence course to demonstrate how classical search algorithms can be applied to deterministic two-player games.

The implementation intentionally avoids advanced optimizations such as Alpha-Beta Pruning in order to keep the algorithm simple, readable, and suitable for educational purposes.

---

# 👨‍💻 Author

**Amirhossein Ebrahimzadeh**

GitHub: https://github.com/A-Ebrahimzadeh-dev

---

# 📄 License

This project is licensed under the MIT License.

See the [LICENSE](LICENSE) file for more information.
