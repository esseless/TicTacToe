using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicTacToe.Models
{
    public class Vm : INotifyPropertyChanged
    {
        #region constants

        private const string computer = " (Computer)";
        private const string player = " (You)";
        private const string TIE = "Tie";

        #endregion

        #region properties

        private string playersLabel1 = "X";
        public string PlayersLabel1 { get => playersLabel1; set { playersLabel1 = value; OnPropertyChanged(); } }

        private string playersLabel2 = "O";
        public string PlayersLabel2 { get => playersLabel2; set { playersLabel2 = value; OnPropertyChanged(); } }

        private Choices playerChoice;
        public Choices PlayerChoice { get => playerChoice; set { playerChoice = value; OnPropertyChanged(); } }

        private Choices computerChoice;

        private bool allowChoosing = true;
        public bool AllowChoosing { get => allowChoosing; set { allowChoosing = value; OnPropertyChanged(); } }

        private bool enableGameBoard;
        public bool EnableGameBoard { get => enableGameBoard; set { enableGameBoard = value; OnPropertyChanged(); } }

        private Choices[,] dirtyGameBoard = new Choices[3, 3];

        private Choices[,] gameBoard = new Choices[3, 3];
        public Choices[,] GameBoard { get => gameBoard; set { gameBoard = value; OnPropertyChanged(); } }

        private string winner = Choices.Blank.ToString();
        public string Winner { get => winner; set { winner = value; OnPropertyChanged(); } }

        private bool showGameResult;
        public bool ShowGameResult { get => showGameResult; set { showGameResult = value; OnPropertyChanged(); } }

        #endregion

        #region constructor

        public Vm()
        {
            InitGame();
        }

        #endregion

        #region properties modifiers
        public void InitGame()
        {
            for (int i = 0; i < 9; i++)
            {
                dirtyGameBoard[i % 3, i / 3] = Choices.Blank;
            }

            GameBoard = dirtyGameBoard;

            AllowChoosing = true;
            EnableGameBoard = false;
            ShowGameResult = false;
            Winner = Choices.Blank.ToString();
            ResetChoiceLables();
        }

        public void SetPlayerChoice(PlayerChoices choice)
        {
            Choices player = (Choices)Enum.Parse(typeof(Choices), choice.ToString());
            PlayerChoice = player;
            computerChoice = player == Choices.X ? Choices.O : Choices.X;

            AllowChoosing = !AllowChoosing;
            EnableGameBoard = !EnableGameBoard;

            UpdateChoiceLables();

            if (PlayerChoice == Choices.O)
            {
                MarkComputerMove();
            }
        }

        private void UpdateChoiceLables()
        {
            if (PlayerChoice == Choices.X)
            {
                PlayersLabel1 += player;
                PlayersLabel2 += computer;
            }
            else
            {
                PlayersLabel1 += computer;
                PlayersLabel2 += player;
            }
        }

        private void ResetChoiceLables()
        {
            PlayersLabel1 = Choices.X.ToString();
            PlayersLabel2 = Choices.O.ToString();
        }

        public void MarkPlayerMove(int row, int col)
        {
            dirtyGameBoard[row, col] = PlayerChoice;
            GameBoard = dirtyGameBoard;

            if (Winner == Choices.Blank.ToString())
            {
                MarkComputerMove();
            }
            else
            {
                DeclareWinner();
            }
        }

        private void MarkComputerMove()
        {
            List<Move> moves = GetMovesLeft();
            if (moves.Count > 0)
            {
                Random r = new();
                int index = r.Next(0, moves.Count);
                dirtyGameBoard[moves[index].Row, moves[index].Col] = computerChoice;
                GameBoard = dirtyGameBoard;
            }
            DeclareWinner();
        }

        private List<Move> GetMovesLeft()
        {
            List<Move> moves = new();
            for (int i = 0; i < 9; i++)
            {
                int r = i % 3;
                int c = i / 3;
                if (GameBoard[r, c] == Choices.Blank)
                {
                    Move move = new() { Row = r, Col = c };
                    moves.Add(move);
                }
            }
            return moves;
        }

        private string CheckWinner()
        {
            // Horizontal
            for (int i = 0; i < 3; i++)
            {
                if (IsWinningRow(GameBoard[i, 0], GameBoard[i, 1], GameBoard[i, 2]))
                {
                    return GameBoard[i, 0].ToString();
                }
            }

            // Vertical
            for (int j = 0; j < 3; j++)
            {
                if (IsWinningRow(GameBoard[0, j], GameBoard[1, j], GameBoard[2, j]))
                {
                    return GameBoard[0, j].ToString();
                }
            }

            // Diagonal
            if (IsWinningRow(GameBoard[0, 0], GameBoard[1, 1], GameBoard[2, 2]))
            {
                return GameBoard[0, 0].ToString();
            }
            if (IsWinningRow(GameBoard[2, 0], GameBoard[1, 1], GameBoard[0, 2]))
            {
                return GameBoard[2, 0].ToString();
            }

            List<Move> moves = GetMovesLeft();
            return moves.Count > 0 ? Choices.Blank.ToString() : TIE;
        }

        private void DeclareWinner()
        {
            string cell = CheckWinner();
            if (cell != Choices.Blank.ToString())
            {
                Winner = cell;
                EnableGameBoard = !EnableGameBoard;
                ShowGameResult = !ShowGameResult;
            }
        }

        private static bool IsWinningRow(Choices val1, Choices val2, Choices val3)
        {
            return val1 != Choices.Blank && val1 == val2 && val2 == val3;
        }

        #endregion

        #region property change handlers

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
