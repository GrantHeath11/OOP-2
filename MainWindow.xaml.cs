using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Data.SqlClient;
using System.Windows;


namespace In_Class_Exercise___3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string connectionString = "Server=ALIENWARELAPTOP;Database=OOP-2;Trusted_Connection=True;";

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string insertQuery = "INSERT INTO product (product_name, quantity ) VALUES (@productName, @quantity)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@productName", ProductNameTextBox.Text);
                    command.Parameters.AddWithValue("@quantity", int.Parse(QuantityTextBox.Text));

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Data saved successfully!");
                    else
                        MessageBox.Show("Error saving data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            PersonListBox.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT product_name, description, quantity FROM product";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productName = reader["product_name"].ToString();
                                int quantity = (int)reader["quantity"];
                                string description = reader["description"].ToString();
                                PersonListBox.Items.Add($"Name:{productName}\nQuantity:{quantity}\nDescription{description}\n\n");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}