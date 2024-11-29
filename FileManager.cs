//Grant Heath
//Advanced Deck Builder Assignment 5
//2024-11-29

using Deck_Builder_Assignment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

/// <summary>
/// Handles file operations for saving and loading the deck data from a JSON file.
/// </summary>
public class FileManager
{
    private static string filePath = "deck.json";  // File path where deck data will be saved

    /// <summary>
    /// Overwrites the existing JSON file with the updated deck data.
    /// </summary>
    public static void OverwriteJsonWithDeck(StandardDeck deck, string jsonFilePath)
    {
        // Step 1: Get the deck's card list from the StandardDeck class
        var deckData = deck.Cards;

        // Step 2: Serialize the deck's card list into a JSON string
        string updatedJson = JsonConvert.SerializeObject(deckData, Formatting.Indented);

        // Step 3: Write the serialized deck list to the JSON file, overwriting its contents
        File.WriteAllText(jsonFilePath, updatedJson);
    }

    /// <summary>
    /// Saves the deck data to a JSON file.
    /// </summary>
    public static void SaveDeck(List<Card> deck)
    {
        try
        {
            // Convert the deck list to JSON format with indentation for readability
            string json = JsonConvert.SerializeObject(deck, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving the deck: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads the deck data from the JSON file.
    /// </summary>
    public static List<Card> LoadDeck()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                var deck = JsonConvert.DeserializeObject<List<Card>>(json);

                if (deck != null)
                {
                    return deck;  // Return the loaded deck if not null
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading the deck: {ex.Message}");
            }
        }

        return new List<Card>();  // Return an empty deck if the file doesn't exist or loading fails
    }
}
