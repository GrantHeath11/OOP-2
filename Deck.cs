// Grant Heath
// Deck.cs
// Assignment-5 OOP-2 Advanced DeckBuilder
// 2024-11-29
// Deck.cs is in charge of managing the deck, this includes shuffling, adding cards, and dealing cards

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// This class provides methods for adding cards, shuffling, and dealing cards.
/// </summary>
public abstract class Deck
{
    /// <summary>
    /// Getter and setter for cards list.
    /// </summary>
    public List<Card> Cards { get; set; }

    /// <summary>
    /// creates a new empty deck
    /// </summary>
    public Deck()
    {
        Cards = new List<Card>(); 
    }

    /// <summary>
    /// Adds a custom card to the deck.
    /// </summary>
    public void AddCard(Card card)
    {
        Cards.Add(card); 
    }

    /// <summary>
    /// Deals a specified number of cards from the deck and removes them
    /// /// </summary>
    public List<Card> DealCards(int numberOfCards)
    {
        List<Card> dealtCards = Cards.Take(numberOfCards).ToList();
        Cards.RemoveRange(0, numberOfCards);  // Remove dealt cards
        return dealtCards;
    }

    /// <summary>
    /// Shuffles the cards in the deck randomly.
    /// </summary>
    public void Shuffle()
    {
        Random rand = new Random();
        Cards = Cards.OrderBy(card => rand.Next()).ToList(); 
    }
}
