// Filename: Car.cs
// Project Name: CarList_Assignment
// Description: Class to represent a car object with properties and methods to manage car data.
// Author: Grant Heath
// Date: Oct 17th, 2024

/// <summary>
/// Public class to track cars.
/// </summary>
public class Car
{
    #region Creating Instance of car class and id number
    // Tracks Car ID.
    private static int idNumCounter;

    /// <summary>
    /// Creates a new instance of the Car class.
    /// </summary>
    /// <param name="make">The make of the car.</param>
    /// <param name="model">The model of the car.</param>
    /// <param name="year">The year of the car.</param>
    /// <param name="price">The price of the car.</param>
    public Car(string make, string model, int year, decimal price)
    {
        idNumCounter++;
        IDNum = idNumCounter; // Set the IDNum to the current counter value
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }
    #endregion
    #region getters and setters
    /// <summary>
    /// Gets or sets the identification number of the car.
    /// </summary>
    public int IDNum
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets or sets the make of the car.
    /// </summary>
    public string Make
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the model of the car.
    /// </summary>
    public string Model
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the year of the car.
    /// </summary>
    public int Year
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the price of the car.
    /// </summary>
    public decimal Price
    {
        get;
        set;
    }
    #endregion
    #region ToString

    /// <summary>
    /// Converts the current car object into a formatted string value.
    /// </summary>
    /// <returns>A formatted string representation of the car.</returns>
    public override string ToString()
    {
        return $"{IDNum}: {Make} {Model}, {Year}, {Price:C}"; // {Price:C} specifies the value as currency.
    }
    #endregion
}
