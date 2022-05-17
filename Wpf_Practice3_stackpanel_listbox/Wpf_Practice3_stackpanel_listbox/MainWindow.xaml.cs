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

namespace Wpf_Practice3_stackpanel_listbox {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        /*
         * NOTE: if you set a debug point, then start debugging, you can open a special window called a wpf visualizer / visual tree by selecting a variable in the locals window
         * to do this, click the magnifying glass and the window will pop up, which will give you a detailed view of the tree in which the items are made/stored
         */

        // created as a button click event handler; add in here whatever you want the program to do when the button is clicked
        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("thanks for clicking the button");
        }
    }
}
