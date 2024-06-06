using System;
using System.Linq;
using Microsoft.Maui.Controls;

namespace TicTacToeApp
{
    public partial class MainPage : ContentPage
    {
        private string[] board;
        private bool isPlayerTurn;

        public MainPage()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            board = new string[9];
            isPlayerTurn = true;
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                var button = (Button)FindByName($"Button{i}");
                button.Text = board[i] ?? string.Empty;
                button.IsEnabled = string.IsNullOrEmpty(board[i]);
            }

            var winner = CheckWinner();
            if (winner != null)
            {
                DisplayAlert("Game Over", winner == "Draw" ? "It's a draw!" : $"{winner} wins!", "New Game");
                NewGame();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int index = int.Parse(button.ClassId);

            if (isPlayerTurn)
            {
                board[index] = "X";
                isPlayerTurn = false;
                UpdateBoard();
                ComputerMove();
            }
        }

        private void ComputerMove()
        {
            int? bestMove = FindBestMove();

            if (bestMove.HasValue)
            {
                board[bestMove.Value] = "O";
                isPlayerTurn = true;
                UpdateBoard();
            }
        }

        private int? FindBestMove()
        {
            // Check for a winning move
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == null)
                {
                    board[i] = "O";
                    if (CheckWinner() == "O")
                    {
                        board[i] = null;
                        return i;
                    }
                    board[i] = null;
                }
            }

            // Block the player's winning move
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == null)
                {
                    board[i] = "X";
                    if (CheckWinner() == "X")
                    {
                        board[i] = null;
                        return i;
                    }
                    board[i] = null;
                }
            }

            // Take the center if available
            if (board[4] == null)
            {
                return 4;
            }

            // Take any of the corners if available
            int[] corners = { 0, 2, 6, 8 };
            foreach (var corner in corners)
            {
                if (board[corner] == null)
                {
                    return corner;
                }
            }

            // Take any available space
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == null)
                {
                    return i;
                }
            }

            return null;
        }

        private string CheckWinner()
        {
            string[,] winningCombinations = new string[,]
            {
                { "0", "1", "2" },
                { "3", "4", "5" },
                { "6", "7", "8" },
                { "0", "3", "6" },
                { "1", "4", "7" },
                { "2", "5", "8" },
                { "0", "4", "8" },
                { "2", "4", "6" }
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                string a = board[int.Parse(winningCombinations[i, 0])];
                string b = board[int.Parse(winningCombinations[i, 1])];
                string c = board[int.Parse(winningCombinations[i, 2])];

                if (a != null && a == b && a == c)
                {
                    return a;
                }
            }

            return board.All(b => b != null) ? "Draw" : null;
        }
    }
}
