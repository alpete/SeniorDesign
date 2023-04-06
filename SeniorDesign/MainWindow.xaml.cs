using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double supplyVoltage = 0;

        private double supplyCurrentLimit = 0;

        public double brakeConstantCurrent = 0;

        public double openLoopTorque = 0;

        public double closedLoopTorque = 0;

        public double tcTemp = 0;

        public double outputPower = 0;

        public bool motorSuppliedPower = false;

        private bool manualModeEngaged = false;


        /// <summary>
        /// Constructor for the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to create a set supply voltage popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetSupplyVoltage(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title="Set Supply Voltage",
                Height = 250, Width = 400,
                Content = new SetValuePopup(1, this, Convert.ToDouble(SupplyVoltageData.Content))
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to create a set current limit popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetCurrentLimit(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Current Limit",
                Height = 250, Width = 400,
                Content = new SetValuePopup(2, this, Convert.ToDouble(SupplyCurrentData.Content))
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to create a set brake constant current popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetBrakeConstantCurrent(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Brake Constant Current",
                Height = 250, Width = 400,
                Content = new SetValuePopup(3, this, Convert.ToDouble(BrakeCurrentData.Content))
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to create a set open loop torque popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetOpenLoopTorque(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Open Loop Torque",
                Height = 250, Width = 400,
                Content = new SetValuePopup(4, this, openLoopTorque)
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to create a set closed loop torque popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetClosedLoopTorque(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Closed Loop Torque",
                Height = 250, Width = 400,
                Content = new SetValuePopup(5, this, closedLoopTorque)
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler for the graph button to generate and display curves of the monitored data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectGraph(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Select Graph",
                Height = 250, Width = 400,
                Content = new GraphPopup(this)
            };
            window.ShowDialog();
        }


    }
}
