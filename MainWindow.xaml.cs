//Authors: Sharanya, Bhupinder, Keval
using System;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Models;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private readonly Vm vm;
        public MainWindow()
        {
            InitializeComponent();

            vm = new();
            DataContext = vm;
        }

        private void PlayerChoice_Click(object sender, RoutedEventArgs e)
        {
            PlayerChoices playerChoice = (PlayerChoices)Enum.Parse(typeof(PlayerChoices), (sender as Button).Content.ToString());
            vm.SetPlayerChoice(playerChoice);
        }

        private void PlayerMove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int row = (int)button.GetValue(Grid.RowProperty);
            int col = (int)button.GetValue(Grid.ColumnProperty);

            vm.MarkPlayerMove(row, col);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            vm.InitGame();
        }
    }
}
