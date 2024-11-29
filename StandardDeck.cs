//Grant Heath
//Advanced Deck Builder Assignment 5
//2024-11-29

using Deck_Builder_Assignment;

public class StandardDeck : Deck
{
    public StandardDeck()
    {
        InitializeDeck(); // Initialize the deck of 52 cards
    }

    /// <summary>
    /// Initalizes standard deck
    /// </summary>
    private void InitializeDeck()
    {
        //default data for deck
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        //for each suit
        foreach (var suit in suits)
        {
            //for each rank
            foreach (var rank in ranks)
            {
                //create new card
                Cards.Add(new Card(rank, suit));
            }
        }
    }
}
