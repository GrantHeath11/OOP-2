// Grant Heath
// CustomDeck.cs
// Assignment-5 OOP-2 Advanced DeckBuilder
// 2024-11-29
// CustomDeck allows user to enter their own cards into the deck

using System;
using System.Collections.Generic;

namespace Deck_Builder_Assignment
{
    public class CustomDeck
    {
        public List<Card> Cards { get; set; }

        public CustomDeck()
        {
            Cards = new List<Card>(); // Initialize with an empty list of custom cards
        }



        /// <summary>
        /// Adds a custom card with the specified suit and rank.
        /// </summary>
        public void AddCustomCard(string suit, string rank)
        {
            if (string.IsNullOrEmpty(suit) || string.IsNullOrEmpty(rank))
            {
                throw new ArgumentException("Both rank and suit must be provided for the custom card.");
            }

            // Create the new card and add it to the custom deck
            Card customCard = new Card(rank, suit);
            Cards.Add(customCard);  // Add the card to the list of cards
        }
        /// <summary>
        /// Retrieves the list of custom cards in the deck.
        /// </summary>
        public List<Card> GetCustomCards()
        {
            return Cards;
        }

    }
}
