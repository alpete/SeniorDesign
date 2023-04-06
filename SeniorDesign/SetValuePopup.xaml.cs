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
        private MainWindow parent; // Field to reference the main window in order to set values on the main window

        private string message = ""; // Field to control the display of which type of popup this is (what value is being set)

        /// <summary>
        /// Constructor for the set value popup
        /// </summary>
        /// <param name="mode">Integer variable that determines what type of popup this is</param>
        public SetValuePopup(int mode, MainWindow window)
        {
            InitializeComponent();        
            switch (mode) //depending on the mode, change the main message of the popup
            {
                case 1:
                    message = "\nSet Supply Voltage (Volts)";
                    break;
                case 2:
                    message = "\nSet Current Limit (Amps)";
                    break;
                case 3:
                    message = "\nSet Brake Constant Current (Amps)";
                    break;
                case 4:
                    message = "\nSet Open Loop Torque (oz in)";
                    break;
                case 5:
                    message = "\nSet Closed Loop Torque (oz in)";
                    break;
            }
            ThisBlock.Text = message; //set the text display of the window accordingly
            parent = window; //set the parent to be the passed in reference to the main window
        }

        /// <summary>
        /// Event handler to set designated value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetValue(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).Close(); //once done, close the popup window
        }

    }
}
