
# TicTacToe App

This is the classical TicTacToe game we use to play as kids written by me in C# on .NET MAUI app framework.

I bet you cannot win the logic coded into the computer's moves.


## Features

- *Intuitive User Interface:* Simple and easy-to-use interface for a seamless gaming experience.
- *Intelligent Computer Opponent:* The computer makes intelligent moves to provide a challenging experience.
  - Computer checks for winning moves.
  - Blocks the player's potential winning moves.
  - Prioritizes taking the center and corners.
- *Game State Management:* Automatically detects game end conditions (win, lose, draw) and restarts the game.
- *Cross-Platform:* Runs on Android, iOS, Windows, and macOS.




## Screenshots

![App Screenshot](https://github.com/Brainydaps/TicTacToeApp/assets/41041115/ec13dd96-c656-4b5a-b7d8-c99ab887242b)



## Installation

1. *Clone the repository:*
    sh
    git clone https://github.com/Brainydaps/TicTacToeApp.git
    cd TicTacToeApp
    

2. *Build the project:*
    - Open the solution file TicTacToeApp.sln in Visual Studio.
    - Restore the NuGet packages and build the solution.

3. *Run the app:*
    - Select the target platform (Android, iOS, Windows, or macOS) and run the application.

## How to Play

1. The game board consists of a 3x3 grid.
2. The player always plays as "X" and the computer plays as "O".
3. Click on an empty cell to make your move.
4. The computer will then make its move.
5. The game ends when there is a win, lose, or draw, and a message will be displayed.
6. The game will automatically restart after displaying the result.

## Game Logic

- The computer uses a heuristic-based strategy to make its moves:
  - *Winning Move:* If the computer can win in the next move, it will take that move.
  - *Blocking Move:* If the player can win in the next move, the computer will block that move.
  - *Center Priority:* The computer will take the center if it is available.
  - *Corner Priority:* The computer will take any available corner.
  - *Fallback:* If none of the above, the computer will take any available cell.
