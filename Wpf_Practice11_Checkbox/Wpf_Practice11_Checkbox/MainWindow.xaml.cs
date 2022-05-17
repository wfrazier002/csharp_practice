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

namespace Wpf_Practice11_Checkbox {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        // this method should work for both when the box is checked and when it is unchecked
        private void checkboxAllToppings_Checked(object sender, RoutedEventArgs e) {
            // checkboxalltoppings.ischecked can't be used by itself, you have to compare it and see if it's true or false
            bool isChecked = (checkboxAllToppings.IsChecked == true);
            checkboxbacon.IsChecked = isChecked;
            checkboxsalami.IsChecked = isChecked;
            checkboxonions.IsChecked = isChecked;
            checkboxpepperoni.IsChecked = isChecked;
            checkboxcheese.IsChecked = isChecked;
            checkboxolives.IsChecked = isChecked;
        }

        private void singleCheckBoxChecked(object sender, RoutedEventArgs e) {
            checkboxAllToppings.IsChecked = null;
            // get a list of all the checkboxes in the children section
            var listCheckBoxes = this.childrenCheckboxes.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
            // count all the children checkboxes
            int countTotalCheckBoxes = this.childrenCheckboxes.Children.OfType<CheckBox>().Count();
            // if all the child checkboxes are checked, check the all checkbox
            if (countTotalCheckBoxes == listCheckBoxes.Count()) {
                checkboxAllToppings.IsChecked = true;
            }
            if (listCheckBoxes.Count() == 0) {
                checkboxAllToppings.IsChecked = false;
            }
        }

        
    }
}
