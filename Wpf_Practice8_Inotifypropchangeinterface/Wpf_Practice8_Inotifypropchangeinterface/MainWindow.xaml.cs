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

namespace Wpf_Practice8_Inotifypropchangeinterface {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // need to call that class we made to be able to get/set the boxes properly
        public Sum sumObj { get; set; }

        public MainWindow() {
            InitializeComponent();

            //set a default val for num1 and num2
            sumObj = new Sum { Num1 = "9999", Num2 = "9999" };
            this.DataContext = sumObj; // does the activation of the 2 nums
        }
    }
}
