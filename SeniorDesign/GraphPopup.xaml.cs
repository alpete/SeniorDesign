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

namespace SeniorDesign
{
    /// <summary>
    /// Interaction logic for GraphPopup.xaml
    /// </summary>
    public partial class GraphPopup : UserControl
    {
        private MainWindow parent; // Field to reference the main window in order to set values on the main window

        /// <summary>
        /// Constructor for the graph popup
        /// </summary>
        public GraphPopup(MainWindow window)
        {
            InitializeComponent();
            parent = window; //set the parent to be the passed in reference to the main window
        }

        /// <summary>
        /// Event handler to set designated value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GraphData(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).Close(); //once done, close the popup window
        }
    }
}
