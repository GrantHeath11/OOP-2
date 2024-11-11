/*
 *  Grant Heath
 *  Deck-Builder-Assignment_4
 *  Card.cs
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
namespace Deck_Builder_Assignment_4
{
    /// <summary>
    /// Class to create card object
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Getter and Setter for Suit
        /// </summary>
        public string Suit { 
            get; 
            set; 
        }

        /// <summary>
        /// Getter and Setter for Rank
        /// </summary>
        public string Rank { 
            get; 
            set; 
        }
        
        /// <summary>
        /// Card Constructer
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Puts each card in string format, Rank (Value of the Card) of Suit (Which suit the card is)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //  returns formatted string
            return $"{Rank} of {Suit}";
        }
    }
}

