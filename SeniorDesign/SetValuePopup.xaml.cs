using System;
using System.Collections.Generic;
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
using System.Linq;

namespace SeniorDesign
{
    /// <summary>
    /// Interaction logic for SetValuePopup.xaml
    /// </summary>
    public partial class SetValuePopup : UserControl
    {
        private MainWindow parent; // Reference to the main window in order to set values on the main window

        private string message; // Controls the display of which type of popup this is (what value is being set)

        private int mode; // What type of popup this is

        private double min; // Minimum possible value to set 
        
        private double max; // Maximum possible value to set

        private double increment; // Increment of + and - buttons

        /// <summary>
        /// Constructor for the set value popup
        /// </summary>
        /// <param name="mode">Integer variable that determines what type of popup this is</param>
        public SetValuePopup(int mode, MainWindow window, double currentValue)
        {
            InitializeComponent();
            this.mode = mode; //set the mode of the window to be the passed in value
            switch (this.mode) // depending on the mode, adjust settings of the popup window
            {
                case 1:
                    message = "\nSet Motor Supply Voltage (Volts)";
                    min = 0;
                    max = 24;
                    increment = .5;
                    slValue.TickFrequency = 2;
                    break;
                case 2:
                    message = "\nSet Motor Current Limit (Amps)";
                    min = 0;
                    max = 5.4;
                    increment = .1;
                    slValue.TickFrequency = .6;
                    break;
                case 3:
                    message = "\nSet Brake Constant Current (Amps)";
                    min = 0;
                    max = 3;
                    increment = .1;
                    slValue.TickFrequency = .25;
                    break;
                case 4:
                    message = "\nSet Load Cell Torque (oz in)";
                    min = 0;
                    max = 41;
                    increment = 1;
                    slValue.TickFrequency = 3;
                    break;
            }
            slValue.Minimum = min;
            slValue.Maximum = max;
            ThisBlock.Text = message; // set the text display of the window accordingly
            TextBox.Text = Convert.ToString(currentValue); // populate the starting value on the popup with the current reading from the main window
            parent = window; // set the parent to be the passed in reference to the main window
        }

        /// <summary>
        /// Event handler to set designated value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetValue(object sender, RoutedEventArgs e)
        {
            if (MainWindow.manualModeEngaged == false) // can only set a value if manual mode is not engaged 
            {
                double currentVal = Convert.ToDouble(TextBox.Text);
                if(currentVal < min || currentVal > max) // if the value entered into the window is not within the allowed range
                {
                    MessageBox.Show("ERROR: Value out of range. Value will not be set.");
                }
                else
                {
                    switch (mode) // depending on the mode, set the associated value back on the main window
                    {
                        case 1:
                            parent.SupplyVoltageData.Content = currentVal.ToString("0.####");
                            parent.SetSupplyVoltageField(currentVal);
                            break;
                        case 2:
                            parent.SupplyCurrentData.Content = currentVal.ToString("0.####");
                            parent.SetSupplyCurrentLimitField(currentVal);
                            break;
                        case 3:
                            parent.BrakeCurrentData.Content = currentVal.ToString("0.####");
                            parent.SetBrakeConstantCurrentField(currentVal);
                            break;
                        case 4:
                            parent.LoadCellTorqueData.Content = currentVal.ToString("0.####");  
                            break;
                    }
                    Window.GetWindow(this).Close(); // once done, close the popup window
                }  
            }
            else MessageBox.Show("ERROR: Manual Mode is engaged, cannot currently set this value"); //display error message indicating current mode of operation
        }

        /// <summary>
        /// Event handler to decrement the current value by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementValue(object sender, RoutedEventArgs e)
        {
            double currentVal = Convert.ToDouble((string)TextBox.Text); // get the current value as a double
            if (currentVal - increment < min )
            {
                MessageBox.Show("ERROR: Intended value out of range. Current value will not be decremented.");
            }
            else
            {
                currentVal -= increment; // subtract the increment from the current value
                TextBox.Text = currentVal.ToString("0.####"); // set the new value
            }  
        }

        /// <summary>
        /// Event handler to increment the current value by one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementValue(object sender, RoutedEventArgs e)
        {
            double currentVal = Convert.ToDouble((string)TextBox.Text); // get the current value as a double
            if (currentVal + increment > max)
            {
                MessageBox.Show("ERROR: Intended value out of range. Current value will not be incremented.");
            }
            else
            {
                currentVal += increment; // add the increment to the current value
                TextBox.Text = currentVal.ToString("0.####"); // set the new value
            }  
        }


    }
}
