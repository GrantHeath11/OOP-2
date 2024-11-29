// Grant Heath
// MainWindow.xaml.cs
// Assignment-5 OOP-2 Advanced DeckBuilder
// 2024-11-29

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Deck_Builder_Assignment
{
    public partial class MainWindow : Window
    {
        private StandardDeck deck; // Use StandardDeck to hold the deck
        private CustomDeck customDeck; // Reference to the CustomDeck for custom cards

        /// <summary>
        /// Initializes components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            deck = new StandardDeck();  // Initialize with a full standard deck
            customDeck = new CustomDeck();  // Initialize custom deck
            LoadDeck();  // Load deck from JSON
        }

        /// <summary>
        /// Shuffles and saves the deck when pressed
        /// </summary>
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                deck.Shuffle();  // Shuffle the deck
                SaveDeck();  // Save the shuffled deck
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while shuffling the deck: {ex.Message}", "Shuffle Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Deals the specified number of cards when clicked
        /// </summary>
        private void DealButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numCards = 0;
                if (int.TryParse(DealTextBox.Text, out numCards))
                {
                    if (numCards > deck.Cards.Count)
                    {
                        throw new InvalidOperationException("There are not enough cards left to deal.");
                    }
                    else
                    {
                        // Deal the specified number of cards
                        var dealtCards = deck.DealCards(numCards);
                        DealtCardsListBox.ItemsSource = dealtCards;  // Show the dealt cards on the listbox
                        SaveDeck();  // Save the deck to the json file after dealing
                    }
                }
                else
                {
                    throw new ArgumentException("Please enter a valid number.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Dealing Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Resets the deck to a full standard deck and clears the dealt cards when button is pressed.
        /// </summary>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Reset the deck to a full standard deck
                deck = new StandardDeck();
                DealtCardsListBox.ItemsSource = null;  // Clear the dealt cards ListBox
                SaveDeck();  // Save the new deck 
                UpdateDeckView();  // Refresh the deck view after reset
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting the deck: {ex.Message}", "Reset Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Saves the current deck to the JSON file.
        /// </summary>
        private void SaveDeck()
        {
            try
            {
                FileManager.SaveDeck(deck.Cards);  // Save the Cards from the StandardDeck to JSON
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while saving the deck: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Loads the deck from the JSON file. 
        /// If there is no JSON file then it should create one and populate it with a standard deck
        /// </summary>
        private void LoadDeck()
        {
            try
            {
                List<Card> loadedCards = FileManager.LoadDeck();
                if (loadedCards == null || !loadedCards.Any())
                {
                    throw new FileNotFoundException("The deck file is empty or missing. A new deck will be created.");
                }
                deck.Cards = loadedCards;  // Update the decks Cards list
                UpdateDeckView();  // Display the loaded deck on startup
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Load Deck Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the deck: {ex.Message}", "Load Deck Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Refreshes the deck view to show the current deck state when button is clicked
        /// </summary>
        private void ViewDeckButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Refresh the DeckListBox to show the current state of the deck
                UpdateDeckView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while viewing the deck: {ex.Message}", "View Deck Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Updates deck listview
        /// </summary>
        private void UpdateDeckView()
        {
            try
            {
                DeckListBox.ItemsSource = null;  // Clear the previous items
                DeckListBox.ItemsSource = deck.Cards;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the deck view: {ex.Message}", "Update Deck Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Exits the application when clicked.
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while exiting: {ex.Message}", "Exit Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Adds a custom card with the specified suit and rank to the deck when button is clicked.
        /// </summary>
        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string suit = SuitTextBox.Text;
                string rank = RankTextBox.Text;

                if (!string.IsNullOrEmpty(suit) && !string.IsNullOrEmpty(rank))
                {
                    // Add the custom card to both the custom deck and the main deck
                    customDeck.AddCustomCard(suit, rank);  // Add to CustomDeck
                    Card customCard = new Card(rank, suit);  // Create a new card for the main deck
                    deck.Cards.Add(customCard);  // Add to the main deck

                    SaveDeck();  // Save the updated deck
                    UpdateDeckView();  // Refresh the deck view after adding the custom card
                }
                else
                {
                    throw new ArgumentException("Please enter both rank and suit.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add Card Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the custom card: {ex.Message}", "Add Card Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


