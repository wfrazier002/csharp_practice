using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Wpf_Currency_Converter_With_DB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        SqlConnection connection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();

        private int CurrencyId = 0;
        private double FromAmount = 0;
        private double ToAmount = 0;

        public MainWindow() {
            InitializeComponent();
            lblCurrency.Content = "Hello World";
            BindCurrency();
            GetData();
        }

        public void myConnection() {
            String connection1 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            connection = new SqlConnection(connection1);
            connection.Open();
        }

        public void closeConnection() {
            connection.Close();
        }

        private void BindCurrency() {
            myConnection();
            DataTable dataTable = new DataTable();
            sqlCommand = new SqlCommand("Select Id, CurrencyName from Currency_Exchanges", connection);
            sqlCommand.CommandType = CommandType.Text;
            dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);
            
            try {
                // if the table is empty, add the initial/first row which is always the --select-- row
                //if (dataTable.Rows.Count == 0) {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["Id"] = 0;
                    dataRow["CurrencyName"] = "--select currency--";
                    dataTable.Rows.InsertAt(dataRow, 0);
                //}
                    
                // if it's not empty, the display it in the drop down menus
                if (dataTable != null && dataTable.Rows.Count > 0) {
                    // from ddm
                    cmbFromCurrency.ItemsSource = dataTable.DefaultView;
                    cmbFromCurrency.DisplayMemberPath = "CurrencyName";
                    cmbFromCurrency.SelectedValuePath = "Id";
                    cmbFromCurrency.SelectedIndex = 0;
                    // to ddm
                    cmbToCurrency.ItemsSource = dataTable.DefaultView;
                    cmbToCurrency.DisplayMemberPath = "CurrencyName";
                    cmbToCurrency.SelectedValuePath = "Id";
                    cmbToCurrency.SelectedIndex = 0;
                }

            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            closeConnection();
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

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            myConnection();
            try {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "") {
                    MessageBox.Show("Please enter amount for a currency");
                    txtAmount.Focus();
                    return;
                } else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "") {
                    MessageBox.Show("Please enter a name for the currency");
                    txtCurrencyName.Focus();
                    return;
                } else {
                    // if there is a currency id, then you are updating an existing item
                    if (CurrencyId > 0) {
                        // ask if they want to update, and only update if they say yes
                        if (MessageBox.Show("Are you sure you want to update?", "information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                            sqlCommand = new SqlCommand("Update Currency_Exchanges set Amount = @Amount, CurrencyName = @CurrencyName Where Id = @Id", connection);
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Parameters.AddWithValue("@Id", CurrencyId);
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Update was successful.");
                        }
                        // else do nothing as there was no change
                    } else {
                        // there was no currency id, so your saving a new item
                        if (MessageBox.Show("Are you sure you want to save?", "information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                            sqlCommand = new SqlCommand("Insert into Currency_Exchanges (Amount, CurrencyName) values (@Amount, @CurrencyName)", connection);
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Update was successful.");
                        }
                    }
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            closeConnection();
            ClearCurrencyConversions();
        }

        private void ClearCurrencyConversions() {
            try {
                txtAmount.Text = "";
                txtCurrencyName.Text = "";
                btnSave.Content = "Save";
                GetData();
                CurrencyId = 0;
                BindCurrency();
                txtAmount.Focus();

            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void GetData() {
            try {
                myConnection();
                DataTable dataTable = new DataTable();
                sqlCommand = new SqlCommand("Select * from Currency_Exchanges", connection);
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0) {
                    dgvCurrency.ItemsSource = dataTable.DefaultView;
                } else {
                    dgvCurrency.ItemsSource = null;
                }
                closeConnection();
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            try {
                ClearCurrencyConversions();
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e) {
            try {
                DataGrid dataGrid = (DataGrid)sender;
                DataRowView row_selected = dataGrid.CurrentItem as DataRowView;

                if (row_selected != null) {
                    if (dgvCurrency.Items.Count > 0) {
                        if (dataGrid.SelectedCells.Count > 0) {
                            CurrencyId = Int32.Parse(row_selected["Id"].ToString());
                            // this is the edit col
                            if (dataGrid.SelectedCells[0].Column.DisplayIndex == 0) {
                                txtAmount.Text = row_selected["Amount"].ToString();
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString();
                                btnSave.Content = "Update";
                            }
                            // this is the delete col
                            if (dataGrid.SelectedCells[0].Column.DisplayIndex == 1) {
                                // display a warning asking if they really want to delete the item
                                if (MessageBox.Show("Are you sure you want to delete this item?", "information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                                    myConnection();
                                    sqlCommand = new SqlCommand("Delete from Currency_Exchanges where Id = @Id",connection);
                                    sqlCommand.CommandType = CommandType.Text;
                                    sqlCommand.Parameters.AddWithValue("@Id", CurrencyId);
                                    sqlCommand.ExecuteNonQuery();
                                    closeConnection();

                                    MessageBox.Show("Item has been successfully deleted");
                                    ClearCurrencyConversions();
                                }
                            }
                        }
                    }
                } 
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
