/*
 *  Grant Heath
 *  Deck-Builder-Assignment_4
 *  Deck.cs
 * 
 */
using System;
using System.Collections.Generic;
using System.Windows;

namespace Deck_Builder_Assignment_4
{
    /// <summary>
    /// Class for the Deck file
    /// </summary>
    internal class Deck
    {
        private List<Card> cards; // stores list of cards in the deck
        private Random random; //random number for shuffling deck

        /// <summary>
        /// Initializes components of deck file
        /// </summary>
        public Deck()
        {
            cards = new List<Card>();
            random = new Random();
            InitializeDeck();
        }

        /// <summary>
        /// Gets current list of cards
        /// </summary>
        public List<Card> Cards
        {
            get { return cards; }
        }

        /// <summary>
        /// For each suit and each rank InitializeDeck() will create a new card with attribute suit and rank
        /// </summary>
        private void InitializeDeck()
        {
            // List of Suits
            string[] suits = { "Spades", "Clubs", "Diamonds", "Hearts" };
            // List of card values
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            //  Creates each value in each suit 
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        /// <summary>
        /// Shuffles the current Deck of cards
        /// </summary>
        public void Shuffle()
        {
            //  If deck is empty return and do nothing since there is nothing to sort
            if (cards.Count == 0)
            {
                MessageBox.Show("The Deck is Empty");
                return; 
            }

            Random randomNumber = new Random();
            int count = cards.Count;

            // Clones current list of cards
            List<Card> shuffledDeck = new List<Card>(cards);

            cards.Clear();  // Clear the original list of cards

            //  for each card in the cloned list
            foreach (var card in shuffledDeck)
            {
                // Add the card at a random index in the original deck
                int randomIndex = randomNumber.Next(cards.Count + 1);
                cards.Insert(randomIndex, card);
            }
        }

        /// <summary>
        /// If Deck isnt empty save the card at the first index and remove it from the deck 
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        {
            if (cards.Count > 0)
            {
                //  saves card from first index
                Card dealtCard = cards[0];
                //  removes card from deck
                cards.RemoveAt(0);
                //  returns dealtCard
                return dealtCard;
            }
            // Returns null if deck is empty
            return null; 
        }

        /// <summary>
        /// Resets deck to original unshuffled state
        /// </summary>
        public void Reset()
        {
            cards.Clear();
            InitializeDeck();

        }
    
    }
}
