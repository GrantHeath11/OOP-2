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

            // Lets user pick who goes first
            if (selectedItem != null)
            {
                if (selectedItem.Content.ToString() == "Player X")
                {
                    currentPlayer = "X";
                }
                else if (selectedItem.Content.ToString() == "Player O")
                {
                    currentPlayer = "O";
                }

                TextBox_Current_Player_Tracker.Text = currentPlayer;

                // Enable buttons to start the game
                EnableButtons(true);
            }
        }


        /// <summary>
        /// Gives the user permission to use the tic tac toe buttons
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
        /// <summary>
        /// Disables the buttons so the user cant continue pressing them while the game is not active
        /// </summary>
        /// <param name="enable"></param>
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

        /// <summary>
        /// Each time one of the tic tac toe grid buttons are pressed function is ran to handle their clicks
        /// </summary>
        /// <param name="sender"></param>
        private void HandleButtonClick(object sender)
        {
            Button clickedButton = sender as Button;

            // Check if the button is already marked
            if (clickedButton.Content.ToString() != "X" && clickedButton.Content.ToString() != "O")
            {
                // Mark the button with the current player's symbol
                clickedButton.Content = currentPlayer;

                // Checks for the winner before switching the player
                CheckForWinner();

                // Switch the player
                Player_Changer();

                // Updates TextBox_Current_Player_Tracker with the new current player
                TextBox_Current_Player_Tracker.Text = currentPlayer;
            
        }

    }

        /// <summary>
        /// Textbox for Player O's Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_o_Player(object sender, TextChangedEventArgs e)
        {
            oPlayerName = PlayerOTextBox.Text;
        }

        /// <summary>
        /// Textbox for Player X's Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_X_Player(object sender, TextChangedEventArgs e)
        {
            xPlayerName = PlayerXTextBox.Text;

        }

        /// <summary>
        /// Textbox which shows which players turn is currently happening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Current_Player(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Function to swap players turns
        /// </summary>
        private void Player_Changer() {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }

            else { currentPlayer = "X"; }
        }

        /// <summary>
        /// Checks for a winner after each move
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

            // Inputs each possible win condition into isLineEqual function which checks if they are all the same value
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
                draws++;
                MessageBox.Show("It's a draw!", "Game Over");
                UpdateWinCounts();

            }
        }

        private void UpdateWinCounts()
        {
            // Updates the two textboxes with the current amount of games won each player has
            TextBox_X_Wins.Text = $"{xWins}";
            TextBox_O_Wins.Text = $"{oWins}";
            Textbox_Drawed_games.Text = $"{draws}";
        }

       /// <summary>
       /// Function checks each possible win column/row, if 3 values in a row are the same value
       /// this function returns true to indicate that someone won the game
       /// </summary>
       /// <param name="value1"></param>
       /// <param name="value2"></param>
       /// <param name="value3"></param>
       /// <returns></returns>
        private bool IsLineEqual(string value1, string value2, string value3)
        {
            return value1 == value2 && value2 == value3 && !string.IsNullOrEmpty(value1);
        }

        /// <summary>
        /// checks if board is full, if the board is full and there is no winner at this point then it counts the game as a draw
        /// </summary>
        private bool IsBoardFull(string[,] board)
        {
            // loops for each value in the tic tac toe board
            // as long as there are empty spots this function returns false so the game continues
            foreach (var counter in board)
            {
                if (string.IsNullOrEmpty(counter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Exit button
        /// Closes program when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// resets the board so another game can be played
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset(object sender, RoutedEventArgs e)
        {
            // Clear the tic tac toe board
            Button_Top_Left_Name.Content = string.Empty;
            Button_Top_Mid_Name.Content = string.Empty;
            Button_Top_Right_Name.Content = string.Empty;
            Button_Mid_Left_Name.Content = string.Empty;
            Button_Mid_Mid_Name.Content = string.Empty;
            Button_Mid_Right_Name.Content = string.Empty;
            Button_Bot_Left_Name.Content = string.Empty;
            Button_Bot_Mid_Name.Content = string.Empty;
            Button_Bot_Right_Name.Content = string.Empty;

            // Re enable all buttons
            EnableButtons(true);
        }

        private void Textbox_Drawed_games_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}