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
        string message = "test";

        public SetValuePopup(int mode)
        {
            InitializeComponent();        
            switch (mode)
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
                    message = "\nSet Open Loop Torque";
                    break;
                case 5:
                    message = "\nSet Closed Loop Torque";
                    break;
            }
            ThisBlock.Text = message;
        }



    }
}
