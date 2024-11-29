// Grant Heath
// Card.cs
// Assignment-5 OOP-2 Advanced DeckBuilder
// 2024-11-29

/// <summary>
/// Represents a card with a rank and a suit.
/// </summary>
public class Card
{
    /// <summary>
    /// Gets or sets the rank of the card 
    /// </summary>
    public string Rank { get; set; }

    /// <summary>
    /// Gets or sets the suit of the card
    /// </summary>
    public string Suit { get; set; }

    /// <summary>
    /// Constructor to create a card with a specific rank and suit.
    /// </summary>
    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }

    /// <summary>
    /// Overrides the ToString method to display the card data as a string 
    /// in the format "'Rank' of 'Suit'"  
    /// </summary>
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
