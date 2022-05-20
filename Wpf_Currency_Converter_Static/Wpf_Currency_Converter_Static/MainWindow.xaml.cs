using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Wpf_Currency_Converter_Static {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            lblCurrency.Content = "Hello World";
            BindCurrency();
        }

        private void BindCurrency() {
            DataTable dtCurrency = new DataTable();
            // cols for the table
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");

            // rows for the table
            dtCurrency.Rows.Add("--select--", 0);
            dtCurrency.Rows.Add("Inr", 1);
            dtCurrency.Rows.Add("Usd", 75);
            dtCurrency.Rows.Add("Eur", 85);
            dtCurrency.Rows.Add("Sar", 20);
            dtCurrency.Rows.Add("Dem", 43);
            dtCurrency.Rows.Add("Pound", 5);
            dtCurrency.Rows.Add("JYen", 6.5);
            // this fills in the from dropdown menu
            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            // this tells it to use the text col for the display
            cmbFromCurrency.DisplayMemberPath = "Text";
            // tell it what value is taken when something is selected in the dropdown menu
            cmbFromCurrency.SelectedValuePath = "Value";
            // have the default value selected be the 0/select an item part
            cmbFromCurrency.SelectedIndex = 0;

            // the to dropdown menu should use the same data source
            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e) {
            //lblCurrency.Content = "The button has been clicked!";
            // this will store the converted value so you can show it later
            double convertedValue;
            //Check amount textbox is Null or Blank
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "") {
                //If amount textbox is Null or Blank it will show the below message box   
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //After clicking on message box OK sets the Focus on amount textbox
                txtCurrency.Focus();
                return;
            } else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0) {
                //Else if the currency from is not selected or it is default text --SELECT--
                //It will show the message
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //Set focus on From Combobox
                cmbFromCurrency.Focus();
                return;
            } else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0) {
                //Else if Currency To is not Selected or Select Default Text --SELECT--
                //It will show the message
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //Set focus on To Combobox
                cmbToCurrency.Focus();
                return;
            }
            //If From and To Combobox selected values are same
            if (cmbFromCurrency.Text == cmbToCurrency.Text) {
                //The amount textbox value set in ConvertedValue.
                //double.parse is used to convert datatype String To Double.
                //Textbox text have string and ConvertedValue is double datatype
                convertedValue = double.Parse(txtCurrency.Text);
                //Show in label converted currency and converted currency name.
                // and ToString("N3") is used to place 000 after after the(.)
                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            } else {
                //Calculation for currency converter is From Currency value multiply(*) 
                // with amount textbox value and then the total is divided(/) with To Currency value
                convertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                //Show in label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e) {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.SelectedIndex > 0) {
                cmbFromCurrency.SelectedIndex = 0;
            }
            if (cmbToCurrency.SelectedIndex > 0) {
                cmbToCurrency.SelectedIndex = 0;
            }
            lblCurrency.Content = "";
        }
        // this method will make it where only numbers are allowed into the textbox input
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
