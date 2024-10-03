/*
 *  Grant Heath
 *  In class assignment October 3, 2024
 * 
 *  Try this:
 *  Make a Windows application with two combo boxes and an output control.
 *  When the program starts and the form loads, at runtime, 
 *  add some integers to the Items property of the ComboBox.
 *  When the program is run, if there are two integers selected, 
 *  add them and put the result in the output control.
 */

namespace Finished_ICE_Week5

{
    public partial class Form1 : Form
    {
        private object label1;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs when program starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Add integers to comboBoxFirstValue
            comboBoxFirstValue.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            // Add integers to comboBoxSecondValue
            comboBoxSecondValue.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

        }

        /// <summary>
        /// runs when user enters value to combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFirstValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  When user selects number from comboBoxSecondValue method AddValues is ran
            AddValues();
        }

        /// <summary>
        /// runs when user enters value to combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSecondValue_SelectedIndexChanged_1(object sender, EventArgs e)
        {    //  When user selects number from comboBoxSecondValue method AddValues is ran
            AddValues();

        }

        /// <summary>
        /// When a combo box is populated method runs
        /// </summary>
        private void AddValues()
        {
            // makes sure both comboBoxes are populated
            if (comboBoxFirstValue.SelectedItem != null && comboBoxSecondValue.SelectedItem != null)
            {
                // Get the selected values and try to parse them as integers,
                // if they are valid integers this will add them together and output the result
                if (int.TryParse(comboBoxFirstValue.SelectedItem.ToString(), out int firstValue) &&
                    int.TryParse(comboBoxSecondValue.SelectedItem.ToString(), out int secondValue))
                {
                    // Adds the values
                    int result = firstValue + secondValue;

                    // Output the result in labelOutput
                    labelOutput.Text = $"Result: {result}";
                }
            }
        }

        /// <summary>
        /// label click event that I cannot remove withot breaking everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// label click event that I cannot remove withot breaking everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelOutput_Click(object sender, EventArgs e)
        {

        }

        private void labelOutput_Click_1(object sender, EventArgs e)
        {

        }

 
    }
}
