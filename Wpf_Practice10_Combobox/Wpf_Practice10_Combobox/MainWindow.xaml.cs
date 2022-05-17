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

namespace Wpf_Practice10_Combobox {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // create a prop called name and put it into the combobox
            // get all the colors available in visual studios for c#
            // the System.Windows.Media.Colors class has get methods for each of it's colors; this getproperties is grabbing them all 
            comboBoxColors.ItemsSource = typeof(Colors).GetProperties();
            // a different approach would be to make a list of all the colors then put that into itemssource
        }
    }
}
