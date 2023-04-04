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
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetSupplyVoltage(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title="Set Supply Voltage",
                Height = 250, Width = 400,
                Content = new SetValuePopup(1)
            };
            window.ShowDialog();
        }

        public void SetCurrentLimit(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Current Limit",
                Height = 250, Width = 400,
                Content = new SetValuePopup(2)
            };
            window.ShowDialog();
        }

        public void SetBrakeConstantCurrent(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Brake Constant Current",
                Height = 250, Width = 400,
                Content = new SetValuePopup(3)
            };
            window.ShowDialog();
        }

        public void SetOpenLoopTorque(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Open Loop Torque",
                Height = 250, Width = 400,
                Content = new SetValuePopup(4)
            };
            window.ShowDialog();
        }

        public void SetClosedLoopTorque(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Set Closed Loop Torque",
                Height = 250, Width = 400,
                Content = new SetValuePopup(5)
            };
            window.ShowDialog();
        }


    }
}
