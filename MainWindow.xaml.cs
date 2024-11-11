/*
 *  Grant Heath
 *  Deck-Builder-Assignment_4
 *  MainWindow.xaml.cs
 * 
 */
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

namespace Deck_Builder_Assignment_4
{
    /// <summary>
    /// MainWindow Class
    /// </summary>
    public partial class MainWindow : Window
    {
        private Deck deck;  // Declare an instance of the Deck class

        /// <summary>
        /// Initializes main window and the deck of cards on startup
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            deck = new Deck();  // Initialize the deck
        }

        /// <summary>
        /// Updates ListView with current Deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            //  Clears ListView
            DeckListView.Items.Clear();  

            // Loop through the deck
            foreach (var card in deck.Cards)
            {
                DeckListView.Items.Add(card.ToString());  // Adds each card to the listView
            }
        }

        /// <summary>
        /// Shuffles Deck when button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            //Shuffles Deck
            deck.Shuffle(); 
            MessageBox.Show("Deck Shuffled Successfully");  // Creates a pop up message to tell the user the deck was shuffled
        }

        /// <summary>
        /// When Reset button is clicked the deck is reset to its unshuffled starting point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            //  Runs Reset in deck file which resets the deck to its default starting point
            deck.Reset();

            //  Resets all Textboxes and listviews
            SuitTextBox.Clear();
            RankTextBox.Clear();
            CardsDealtListView.Items.Clear();
            DrawTextBox.Clear();
            MessageBox.Show("Deck Reset Successfully");  //Tells user the deck has been reset
        }

        /// <summary>
        /// Closes program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  // Closes the application window
        }

        /// <summary>
        /// empty DrawTextbox function visual studio wont let me remove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// When deal button is clicked, Random cards are pulled out of the deck and listed for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealButtpm_Click(object sender, RoutedEventArgs e)
        {
            // Validate the number of cards to draw (it checks the amount of cards in the deck and validates their input is a real valid number)
            if (int.TryParse(DrawTextBox.Text, out int userInput) && userInput > 0 && userInput <= deck.Cards.Count)
            {
                // loops the amount of times the user inputted it for
                for (int i = 0; i < userInput; i++)
                {
                    //  Deals a card each time
                    Card dealtCard = deck.Deal();

                    //  If card returned by deck.Deal() isnt null
                    if (dealtCard != null)
                    {
                        // Adds the dealt card to the ListView
                        CardsDealtListView.Items.Add(dealtCard);

                        // Update the textboxes with card value and suit
                        SuitTextBox.Text = dealtCard.Suit;
                        RankTextBox.Text = dealtCard.Rank;
                    }

                }
            }
            else
            {
                // Display an error message if the input is invalid
                MessageBox.Show($"Must enter a valid amount of cards to deal\nMust be whole number between 0 and {deck.Cards.Count}" );
            }
        }
    }
}
