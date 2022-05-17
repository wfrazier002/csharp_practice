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

namespace Wpf_Practice9_Listbox_listmatch {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // create a list of match elements; will be used in the gui
            List<Match> matches = new List<Match>();
            matches.Add(new Match() { 
                Team1 = "Bahamuts", Team2 = "Gull Wings", Score1 = 9999, Score2 = 7777, Completion = 85
            });
            matches.Add(new Match() {
                Team1 = "Albed Sychs",
                Team2 = "Besaid Auracs",
                Score1 = 5,
                Score2 = 35,
                Completion = 50
            });
            matches.Add(new Match() {
                Team1 = "Bahamuts",
                Team2 = "Albed Sychs",
                Score1 = 95,
                Score2 = 3,
                Completion = 95
            });
            matches.Add(new Match() {
                Team1 = "Bahamuts",
                Team2 = "Besaid Auracs",
                Score1 = 20,
                Score2 = 35,
                Completion = 100
            });
            // connect the list matches w/ the listbox in the gui
            lbMatches.ItemsSource = matches;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            // lbMatches.SelectedItem - is an object
            // lbMatches.SelectedItem as Match - use the object as type Match
            if (lbMatches.SelectedItem != null) {
                MessageBox.Show(
                        "Selected Match: " + (lbMatches.SelectedItem as Match).Team1
                        + " " + (lbMatches.SelectedItem as Match).Score1
                        + " " + (lbMatches.SelectedItem as Match).Score2
                        + " " + (lbMatches.SelectedItem as Match).Team2
                    );
            }
        }
    }
}
