// Grant Heath
// StandardDeck.cs
// Assignment-5 OOP-2 Advanced DeckBuilder
// 2024-11-29
// This class creates a full deck of 52 standard playing cards (using Card.cs),
// it creates a card for all 13 ranks and 4 suits Hearts, Diamonds, Clubs, Spades (so 52 cards total)

/// <summary>
/// StandardDeck is inheriting from the Deck class.
/// The point of this class is to create the standard deck (basic 52 card deck)
/// </summary>
public class StandardDeck : Deck
{
    /// <summary>
    /// Initializes a new StandardDeck of cards
    /// </summary>
    public StandardDeck()
    {
        // Define the suits 
        var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };

        // Define the ranks
        var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        // Add each combination of suit and rank to the deck
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                // Create a new Card with the current rank and suit, and add it to the deck
                AddCard(new Card(rank, suit));
            }
        }
    }
}
