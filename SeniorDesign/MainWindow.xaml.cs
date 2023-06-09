﻿using System;
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

        private double brakeConstantCurrent = 0;

        private double openLoopTorque = 0;

        private double closedLoopTorque = 0;

        private double tcTemp = 0;

        private double outputPower = 0;

        private double inputPower = 0;

        private double systemEfficiency = 0; // will be a function of input power and output power

        public static bool closedLoopEngaged = false; // determines whether the system is in open loop or closed loop mode

        public static bool manualModeEngaged = false; // determines whether the system is being manually controlled or controlled by the remote terminal

        
        /// <summary>
        /// Constructor for the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetSupplyVoltageField(double val) { supplyVoltage = val; } // setter for supply voltage field
        public void SetSupplyCurrentLimitField(double val) { supplyCurrentLimit = val; } // setter for supply current limit field
        public void SetBrakeConstantCurrentField(double val) { brakeConstantCurrent = val; } // setter for brake constant current field
        public void SetOpenLoopTorqueField(double val) { openLoopTorque = val; } // setter for open loop torque field
        public void SetClosedLoopTorqueField(double val) { closedLoopTorque = val; } // setter for closed loop torque field
        public void SetTCTempField(double val) { tcTemp = val; } // setter for TC temp field
        public void SetOutputPowerField(double val) { outputPower = val; } // setter for output power field
        public void SetInputPowerField(double val) { inputPower = val; } // setter for intput power field

        /// <summary>
        /// Event handler to create a set supply voltage popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSupplyVoltage(object sender, RoutedEventArgs e)
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
        private void SetCurrentLimit(object sender, RoutedEventArgs e)
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
        private void SetBrakeConstantCurrent(object sender, RoutedEventArgs e)
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
        private void SetLoadCellTorque(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Load Cell Torque",
                Height = 250, Width = 400,
                Content = new SetValuePopup(4, this, openLoopTorque)
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to change the loop mode of operation (open or closed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeLoopMode(object sender, RoutedEventArgs e)
        {
            if (closedLoopEngaged == true) // if in closed loop mode
            {
                closedLoopEngaged = false; // switch to open loop mode
                TorqueMode.Content = "Open Loop Mode"; // update the display

            }
            else if (closedLoopEngaged == false) // if in open loop mode
            {
                closedLoopEngaged = true; // switch to closed loop mode
                TorqueMode.Content = "Closed Loop Mode"; // update the display
            }
        }

        /// <summary>
        /// Event handler for the graph button to generate and display curves of the monitored data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectGraph(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Select Graph",
                Height = 250, Width = 400,
                Content = new GraphPopup(this)
            };
            window.ShowDialog();
        }

        /// <summary>
        /// Event handler to export current readings to a CSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ExportDataCSV(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Function to compute input power of the system
        /// </summary>
        /// <param name="amps"></param>
        /// <param name="volts"></param>
        /// <returns></returns>
        private double ComputeInputPower(double amps, double volts)
        {
            return 0.0;
        }

        /// <summary>
        /// Function to compute output power of the system in watts
        /// </summary>
        /// <returns></returns>
        private double ComputeOutputPowerWatts()
        {
            return 0.0;
        }

        /// <summary>
        /// Function to compute output power of the system in HP
        /// </summary>
        /// <returns></returns>
        private double ComputeOutputPowerHP()
        {
            return 0.0;
        }

        /// <summary>
        /// Function to report the system efficiency and display it on the UI
        /// </summary>
        private void ReportSystemEfficiency()
        {

        }

    }
}
