# TicTacToeGame

A C# (.NET Console) implementation of the classic Tic-Tac-Toe game featuring an AI opponent powered by the Minimax search algorithm. Developed as an educational project with a clean object-oriented architecture.

---

## 📖 Overview

This project implements the classic 3×3 Tic-Tac-Toe game in C# as a .NET Console Application.

The primary goal of the project is not only to create a playable game, but also to demonstrate the implementation of the Minimax search algorithm, one of the fundamental algorithms taught in introductory Artificial Intelligence courses.

The AI explores the complete game tree using Depth-First Search (DFS) and always chooses the optimal move, making it impossible to defeat when both players follow the game rules.

---

## ✨ Features

- Classic 3×3 Tic-Tac-Toe
- Human vs AI gameplay
- Human player always starts first
- AI powered by the recursive Minimax algorithm
- Complete game tree exploration
- Depth-aware utility evaluation
- Console-based user interface
- Object-Oriented Design (OOP)
- Clean and modular architecture

---

## 🧠 Artificial Intelligence

The AI uses the classic recursive Minimax algorithm without any optimizations.

### Characteristics

- Recursive implementation
- Depth-First Search (DFS)
- Full state-space exploration
- Terminal state evaluation
- Utility-based decision making
- Backtracking using ApplyMove / UndoMove
- No randomness
- No Alpha-Beta pruning
- No Machine Learning
- No Neural Networks

### Utility Function

| Game Result | Score |
|------------|------:|
| AI Win | 10 - depth |
| Human Win | depth - 10 |
| Draw | 0 |

Using the search depth allows the AI to:

- Prefer faster victories.
- Delay unavoidable defeats.
- Always select the optimal move.

---

## 🏛 Project Architecture

The project follows a simple Object-Oriented architecture where every class has a single responsibility.

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

---

## 📂 Project Structure

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

---

## ▶️ Running the Project

### Requirements

- .NET SDK 8.0 (or later)

Clone the repository:

git clone https://github.com/A-Ebrahimzadeh-dev/TicTacToeGame.git

Navigate to the project directory:

cd TicTacToeGame

Run the application:

dotnet run

---

## 🎮 Example Gameplay

    0   1   2

0   X | O | X
   ---+---+---
1     | X |
   ---+---+---
2   O |   |

Your turn (X)

Row: 2
Column: 2

AI is thinking...

---

## 📚 Concepts Demonstrated

- Object-Oriented Programming (OOP)
- Recursive Algorithms
- Minimax Search
- Depth-First Search (DFS)
- Backtracking
- State Space Search
- Utility Functions
- Clean Architecture
- Separation of Concerns
- Single Responsibility Principle (SRP)

---

## 🎓 Educational Purpose

This project was developed as part of an Artificial Intelligence course to demonstrate how classical search algorithms can be applied to solve deterministic two-player games.

The implementation intentionally avoids advanced optimizations such as Alpha-Beta Pruning in order to keep the algorithm easy to understand and suitable for educational purposes.

---

## 📄 License

This project is released for educational purposes.
