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
        int mode; // 1 = set supply voltage, 2 = set current limit, 3 = brake constant current, 4 = open loop torque, 5 = closed loop torque

        public SetValuePopup(int mode)
        {
            InitializeComponent();
            this.mode = mode;
            foreach (Grid g in FindVisualChildren<Grid>(this))
            {
                foreach (TextBlock tb in FindVisualChildren<TextBlock>(g))
                {
                    if (tb.Tag.Equals("This"))
                    {
                        switch (this.mode)
                        {
                            case 1:
                                tb.Text = "Set Supply Voltage (Volts)";
                                break;
                            case 2:
                                tb.Text = "Set Current Limit (Amps)";
                                break;
                            case 3:
                                tb.Text = "Set Brake Constant Current (Amps)";
                                break;
                            case 4:
                                tb.Text = "Set Open Loop Torque";
                                break;
                            case 5:
                                tb.Text = "Set Closed Loop Torque";
                                break;
                        }
                    }
                }
            }
            
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }


    }
}
