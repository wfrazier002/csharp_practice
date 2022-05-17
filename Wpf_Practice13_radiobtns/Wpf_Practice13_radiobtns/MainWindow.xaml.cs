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

namespace Wpf_Practice13_radiobtns {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            MessageBox.Show("you clicked yes. i love meat too.");
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) {
            MessageBox.Show("you clicked no. guess that means you don't like meat.");
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e) {
            MessageBox.Show("you clicked maybe. guess that means you'll eat it, but it's not your fav.");
        }
    }
}
