using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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

namespace Wpf_Currency_Converter_With_API {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        Root currencyVals = new Root();

        public MainWindow() {
            InitializeComponent();
            ClearControls();
            GetValue();
        }

        private async void GetValue()   {
            currencyVals = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=6140d94f78ec4324bc47438945bb61a7");
            BindCurrency();
        }

        public static async Task<Root> GetData<T>(string url) {
            var myRoot = new Root();
            try {
                using (var client = new HttpClient()) {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK) {
                        var responseString = await responseMessage.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<Root>(responseString);
                        //MessageBox.Show("Timestamp: " + responseObject.timestamp, "information", MessageBoxButton.OK, MessageBoxImage.Information);
                        return responseObject;
                    }
                    return myRoot;
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
                return myRoot;
            }
        }

        private void BindCurrency() {
            try {
                DataTable dtCurrency = new DataTable();
                // cols for the table
                dtCurrency.Columns.Add("Text");
                dtCurrency.Columns.Add("Value");

                // rows for the table
                dtCurrency.Rows.Add("--Select--", 0);
                dtCurrency.Rows.Add("INR", currencyVals.rates.INR);
                dtCurrency.Rows.Add("USD", currencyVals.rates.USD);
                dtCurrency.Rows.Add("JPY", currencyVals.rates.JPY);
                dtCurrency.Rows.Add("NZD", currencyVals.rates.NZD);
                dtCurrency.Rows.Add("EUR", currencyVals.rates.EUR);
                dtCurrency.Rows.Add("CAD", currencyVals.rates.CAD);
                dtCurrency.Rows.Add("ISK", currencyVals.rates.ISK);
                dtCurrency.Rows.Add("PHP", currencyVals.rates.PHP);
                dtCurrency.Rows.Add("DKK", currencyVals.rates.DKK);
                dtCurrency.Rows.Add("CZK", currencyVals.rates.CZK);
                cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
                cmbFromCurrency.DisplayMemberPath = "Text";
                cmbFromCurrency.SelectedValuePath = "Value";
                cmbFromCurrency.SelectedIndex = 0;
                cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
                cmbToCurrency.DisplayMemberPath = "Text";
                cmbToCurrency.SelectedValuePath = "Value";
                cmbToCurrency.SelectedIndex = 0;

            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            
                
    }

        private void ClearControls() {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.SelectedIndex > 0) {
                cmbFromCurrency.SelectedIndex = 0;
            }
            if (cmbToCurrency.SelectedIndex > 0) {
                cmbToCurrency.SelectedIndex = 0;
            }
            lblCurrency.Content = "";
            txtCurrency.Focus();
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
                //convertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                convertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbFromCurrency.SelectedValue.ToString());
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
