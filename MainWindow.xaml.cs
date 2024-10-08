using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Tic Tac Toe Project
namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global varibles for tracking total wins, draws, and whos turn it is
        private string currentPlayer;
        private int oWins;
        private int xWins;
        private int draws = 0; 
        private string xPlayerName;
        private string oPlayerName;

        /// <summary>
        /// Main Window for initaizingComponents
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Top_Left(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Top_Mid(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Top_Right(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Mid_Left(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Mid_Mid(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Mid_Right(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Bot_Mid(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }
        
        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Bot_Right(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);

        }

        /// <summary>
        /// A button in the tic tac toe grid, when button is pressed it signals the HandleButtonClick() function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Bot_Left(object sender, RoutedEventArgs e)
        {
            HandleButtonClick(sender);
        }
       
        /// <summary>
        /// ComboBox for selecting which player goes first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string player = selectedItem.Content.ToString();
                TextBox_Current_Player_Tracker.Text = player;
                //testing player_changer
                Player_Changer();
                TextBox_Current_Player_Tracker.Text = player;
                EnableButtons(true);



            }
        }

        /// <summary>
        /// Makes the game unplayable until someone is picked to play first
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtons(bool enable)
        {
            Button_Top_Left_Name.IsEnabled = true;
            Button_Top_Mid_Name.IsEnabled = true;
            Button_Top_Right_Name.IsEnabled = true;
            Button_Mid_Left_Name.IsEnabled = true;
            Button_Mid_Mid_Name.IsEnabled = true;
            Button_Mid_Right_Name.IsEnabled = true;
            Button_Bot_Left_Name.IsEnabled = true;
            Button_Bot_Mid_Name.IsEnabled = true;
            Button_Bot_Right_Name.IsEnabled = true;
        }
        private void DisableButtons(bool enable)
        {
            Button_Top_Left_Name.IsEnabled = false;
            Button_Top_Mid_Name.IsEnabled = false;
            Button_Top_Right_Name.IsEnabled = false;
            Button_Mid_Left_Name.IsEnabled = false;
            Button_Mid_Mid_Name.IsEnabled = false;
            Button_Mid_Right_Name.IsEnabled = false;
            Button_Bot_Left_Name.IsEnabled = false;
            Button_Bot_Mid_Name.IsEnabled = false;
            Button_Bot_Right_Name.IsEnabled = false;
        }
        private void HandleButtonClick(object sender)
        {
            Button clickedButton = sender as Button;

            // Check if the button is already marked
            if (clickedButton.Content.ToString() != "X" && clickedButton.Content.ToString() != "O")
            {
                // Mark the button with the current player's symbol
                clickedButton.Content = currentPlayer;

                // Check for the winner before switching the player
                CheckForWinner();

                // Switch the current player
                Player_Changer();

                // Updates TextBox_Current_Player with the new current player
                TextBox_Current_Player_Tracker.Text = currentPlayer;
            
        }

    }


    private void TextBox_o_Player(object sender, TextChangedEventArgs e)
        {
            oPlayerName = PlayerOTextBox.Text;
        }

        private void TextBox_X_Player(object sender, TextChangedEventArgs e)
        {
            xPlayerName = PlayerXTextBox.Text;

        }

        private void TextBox_Current_Player(object sender, TextChangedEventArgs e)
        {

        }
        private void Player_Changer() {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }

            else { currentPlayer = "X"; }
        }

        /// <summary>
        /// Checks for a winning condition after each move
        /// </summary>
        private void CheckForWinner()
        {
            // Array to store the current state of the game board
            string[,] board = new string[3, 3]
            {
            { Button_Top_Left_Name.Content.ToString(), Button_Top_Mid_Name.Content.ToString(), Button_Top_Right_Name.Content.ToString() },
            { Button_Mid_Left_Name.Content.ToString(), Button_Mid_Mid_Name.Content.ToString(), Button_Mid_Right_Name.Content.ToString() },
            { Button_Bot_Left_Name.Content.ToString(), Button_Bot_Mid_Name.Content.ToString(), Button_Bot_Right_Name.Content.ToString() }
            };

            // Check rows, columns, and diagonals for a winner
            if (IsLineEqual(board[0, 0], board[0, 1], board[0, 2]) ||
                IsLineEqual(board[1, 0], board[1, 1], board[1, 2]) ||
                IsLineEqual(board[2, 0], board[2, 1], board[2, 2]) ||
                IsLineEqual(board[0, 0], board[1, 0], board[2, 0]) ||
                IsLineEqual(board[0, 1], board[1, 1], board[2, 1]) ||
                IsLineEqual(board[0, 2], board[1, 2], board[2, 2]) ||
                IsLineEqual(board[0, 0], board[1, 1], board[2, 2]) ||
                IsLineEqual(board[0, 2], board[1, 1], board[2, 0]))
            {
                // Disable buttons if there's a winner and display the winner
                DisableButtons(false);

                if (currentPlayer == "X")
                {
                    xWins++;
                    MessageBox.Show($"{xPlayerName}(X) wins!", "Game Over");
                }
                else
                {
                    oWins++;
                    MessageBox.Show($"{oPlayerName}(O) wins!", "Game Over");
                }

                // Update the displayed win counts
                UpdateWinCounts();
            }
            else if (IsBoardFull(board))
            {
                // If the board is full and there's no winner, it's a draw
                MessageBox.Show("It's a draw!", "Game Over");
            }
        }

        private void UpdateWinCounts()
        {
            // Assuming you have two TextBoxes or Labels to display win counts
            TextBox_X_Wins.Text = $"{xWins}";
            TextBox_O_Wins.Text = $"{oWins}";
        }

        /// <summary>
        /// Helper function to check if three values in a line are equal and not empty
        /// </summary>
        private bool IsLineEqual(string a, string b, string c)
        {
            return a == b && b == c && !string.IsNullOrEmpty(a);
        }

        /// <summary>
        /// Helper function to check if the board is full
        /// </summary>
        private bool IsBoardFull(string[,] board)
        {
            foreach (var cell in board)
            {
                if (string.IsNullOrEmpty(cell))
                {
                    return false;
                }
            }
            return true;
        }

        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonReset(object sender, RoutedEventArgs e)
        {
            // Clear the content of all Tic Tac Toe grid buttons
            Button_Top_Left_Name.Content = string.Empty;
            Button_Top_Mid_Name.Content = string.Empty;
            Button_Top_Right_Name.Content = string.Empty;
            Button_Mid_Left_Name.Content = string.Empty;
            Button_Mid_Mid_Name.Content = string.Empty;
            Button_Mid_Right_Name.Content = string.Empty;
            Button_Bot_Left_Name.Content = string.Empty;
            Button_Bot_Mid_Name.Content = string.Empty;
            Button_Bot_Right_Name.Content = string.Empty;

            // Re-enable all buttons
            EnableButtons(true);

            // Reset the current player to the default
            currentPlayer = "X";
            TextBox_Current_Player_Tracker.Text = currentPlayer;
        }
    }
}