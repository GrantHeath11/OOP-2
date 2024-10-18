// Filename: MainWindow.xaml.cs
// Project Name: CarList_Assignment
// Description: C# file to implement the logic for the car management program
// Author: Grant Heath
// Date: Oct 17th, 2024

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CarList_Assignment
{
    /// <summary>
    /// MainWindow class for creating and handling the application.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Global list to hold the cars.
        private List<Car> cars;

        #region Initialiaion Methods
        /// <summary>
        /// Initializes a new instance of the MainWindow class and sets up the application on launch.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            cars = CreateCarList();
            PopulateComboBoxes();
            AddCarsToListBox(cars);
        }

        /// <summary>
        /// Clears the input fields on reset.
        /// </summary>
        private void ClearInputFields()
        {
            Make.SelectedIndex = -1; 
            Model.Text = string.Empty; 
            Year.SelectedIndex = -1; 
            Price.Text = string.Empty; 
            New_Checkbox.IsChecked = false; 
        }

        /// <summary>
        /// Populates the combo boxes with preset makes and years on startup.
        /// </summary>
        private void PopulateComboBoxes()
        {
            var makes = new List<string>
            {
                "Toyota", "Honda", "Ford", "Chevrolet", "BMW",
                "Mercedes", "Audi", "Tesla", "Nissan", "Hyundai"
            };
            //Creates list for years 1900-current
            var years = new List<string>();
            for (int year = 1900; year <= System.DateTime.Now.Year; year++)
            //since its a combo box I had to put a range of years so I just did 1900-current
            {
                years.Add(year.ToString()); // Adds each year to the list 'years'.
            }

            Make.ItemsSource = makes; // Set the source for the makes dropdown.
            Year.ItemsSource = years; // Set the source for the years dropdown.
        }

        /// <summary>
        /// Creates and returns the preset list of cars.
        /// </summary>
        /// <returns>A list of Car objects.</returns>
        private List<Car> CreateCarList()
        {
            return new List<Car>
            {
                new Car("Toyota", "Camry", 2022, 24000),
                new Car("Honda", "Civic", 2021, 20000),
                new Car("Ford", "Mustang", 2019, 35000),
                new Car("Chevrolet", "Malibu", 2018, 18000),
                new Car("BMW", "X5", 2020, 50000),
                new Car("Mercedes", "C-Class", 2023, 45000),
                new Car("Audi", "A4", 2020, 38000),
                new Car("Tesla", "Model 3", 2023, 55000),
                new Car("Nissan", "Altima", 2017, 16000),
                new Car("Hyundai", "Elantra", 2019, 17000)
            };
        }
        #endregion
        #region Add New Car to List & ListBox
        /// <summary>
        /// Adds a new car to the existing list with user validation.
        /// </summary>
        /// <returns>True if the car was added successfully; otherwise, false.</returns>
        private bool AddCarToList()
        {
            string make = Make.SelectedItem?.ToString();
            string model = Model.Text;
            string yearText = Year.SelectedItem?.ToString();
            string priceText = Price.Text;
            bool isNew = New_Checkbox.IsChecked ?? false;

            // Validate the input fields.
            if (string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model) ||
                string.IsNullOrEmpty(yearText) || string.IsNullOrEmpty(priceText))
            {
                Text_Box_Successful_Input.Text = "Please fill in all fields.";
                return false;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                Text_Box_Successful_Input.Text = "Invalid price.";
                return false;
            }

            if (!int.TryParse(yearText, out int year))
            {
                Text_Box_Successful_Input.Text = "Invalid year.";
                return false;
            }

            Car newCar = new Car(make, model, year, price);
            cars.Add(newCar); // Add the new car to the list.

            AddCarsToListBox(cars); // Update the ListBox with the new list.
            ClearInputFields(); // Clear the input boxes.

            return true; // Indicate success.
        }


        /// <summary>
        /// Adds the list of cars to the ListBox.
        /// </summary>
        /// <param name="cars">The list of cars to display in the ListBox.</param>
        private void AddCarsToListBox(List<Car> cars)
        {
            CarListBox.Items.Clear(); // Clear the existing items in the ListBox.
            foreach (var car in cars)
            {
                CarListBox.Items.Add(car.ToString()); // Add each car's string representation to the ListBox.
            }
        }
        #endregion
        #region Button Clicks

        /// <summary>
        /// Closes the application when the Exit button is clicked.
        /// </summary>
        /// <param name="sender">The exit button.</param>
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Close application
        }

        /// <summary>
        /// Resets all input values when the Reset button is clicked.
        /// </summary>
        /// <param name="sender">The reset button.</param>
        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearInputFields(); // Clear all input fields.
        }

        /// <summary>
        /// Adds a car to the list when the Enter button is pressed.
        /// Displays a success message if the car is added successfully.
        /// since validation is in the AddCarToList function there is no case that this function fails.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            if (AddCarToList()) // Attempt to add the car.
            {
                Text_Box_Successful_Input.Text = "Car added successfully!"; // Show success message.
            }
        }
        #endregion
        #region Empty Functions for Textboxes and ComboBoxes

        /// <summary>
        /// Empty Function for textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_Box_Successful_Input_TextChanged(object sender, TextChangedEventArgs e) { }

        /// <summary>
        /// Empty function for listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        /// <summary>
        /// Empty function for price textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Price_TextChanged(object sender, TextChangedEventArgs e) { }

        /// <summary>
        /// empty function for comboBox year
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        /// <summary>
        /// Empty function for model textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Model_TextChanged(object sender, TextChangedEventArgs e) { }

        /// <summary>
        /// empty function for Make comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Make_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        #endregion

    }
}

