using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Wpf_Practice_ZooManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        // need an sql connection to connect the code to the db
        SqlConnection sqlConnection;

        public MainWindow() {
            InitializeComponent();

            // connection string
            //string connectionString = ConfigurationManager.ConnectionStrings["Wpf_Practice_Zoo_Manager.Properties.Settings.Database_Csharp_SqlConnectionString"].ConnectionString; 
            //string connectionString = ConfigurationManager.ConnectionStrings["Wpf_Practice_Zoo_Manager.Properties.Settings.WpfTestSqlConnectionString"].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings["Wpf_Practice_ZooManager.Properties.Settings.WPFTESTSQL_MDFConnectionString"].ConnectionString;
            // initialize the sql connection here in the constructor
            sqlConnection = new SqlConnection(connectionString);
            // call the func to fill in the listbox
            ShowZoos();
            ShowAnimals();
        }
        private void ShowZoos() {
            try {
                // select everything from the Zoo table
                string query = "select * from Zoo";
                // have to use a sqldataadaptor to connect the query to the db and run it
                // the adapter basically acts as an interface btw c# and sql
                // the adapter takes care of opening and closing connections btw the 2
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                // the using stmt will fill the listbox named ListZoos w/ the content from the zooTable table
                using (sqlDataAdapter) {
                    DataTable zooTable = new DataTable();
                    // fill up the newly created datatable w/ the query results in the adapter
                    sqlDataAdapter.Fill(zooTable);
                    // the col we want to see is the location
                    ListZoos.DisplayMemberPath = "location";
                    // the value behind a specific item is the Id
                    ListZoos.SelectedValuePath = "Id";
                    // next, we want to get a view of the table
                    // the item source for the list is the zooTable
                    ListZoos.ItemsSource = zooTable.DefaultView;
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
        }

        private void ShowAnimals() {
            try {
                // select everything from the Zoo table
                string query = "select * from Animal";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                // the using stmt will fill the listbox named ListAnimals w/ the content from the animalTable table
                using (sqlDataAdapter) {
                    DataTable animalTable = new DataTable();
                    // fill up the newly created datatable w/ the query results in the adapter
                    sqlDataAdapter.Fill(animalTable);
                    // the col we want to see is the name
                    ListAnimals.DisplayMemberPath = "name";
                    // the value behind a specific item is the Id
                    ListAnimals.SelectedValuePath = "Id";
                    // next, we want to get a view of the table
                    // the item source for the list is the animalTable
                    ListAnimals.ItemsSource = animalTable.DefaultView;
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
        }

        private void ShowAnimalsInZoo() {
            try {
                // select everything from the Zoo table
                string query = "select * from Animal an inner join ZooAnimal az on an.Id = az.animalId where az.zooId = @zooId;";
                // since there is a variable in this query, and it is gotten from one of the listboxes, we'll need to use sqlcommand first, then plug that into sqldataadapter
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                // the using stmt will fill the listbox named ListZoos w/ the content from the zooTable table
                using (sqlDataAdapter) {
                    // now, first start by entering the value of the variable that is in the query
                    // in this case, we want the value to change depending on what zoo is clicked from the zoo list
                    sqlCommand.Parameters.AddWithValue("@zooId", ListZoos.SelectedValue);
                    DataTable zooAnimalTable = new DataTable();
                    // fill up the newly created datatable w/ the query results in the adapter
                    sqlDataAdapter.Fill(zooAnimalTable);
                    // the col we want to see is the location
                    ListZooAnimals.DisplayMemberPath = "name";
                    // the value behind a specific item is the Id
                    ListZooAnimals.SelectedValuePath = "Id";
                    // next, we want to get a view of the table
                    // the item source for the list is the zooTable
                    ListZooAnimals.ItemsSource = zooAnimalTable.DefaultView;
                }
            } catch (Exception exception) {
                //MessageBox.Show(exception.ToString());
            }
        }

        private void ListZoos_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ShowAnimalsInZoo();
            ShowSelectedZooInTxtBox();
        }

        private void ListAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //MessageBox.Show("Listbox for animals was clicked");
            ShowSelectedAnimalInTxtBox();
        }

        private void Delete_Zoo_Click(object sender, RoutedEventArgs e) {
            try {
                //MessageBox.Show("this button will delete a zoo once implemented");
                string query = "delete from Zoo where id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", ListZoos.SelectedValue);
                sqlCommand.ExecuteScalar();     
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowZoos();
            } 
        }

        private void Add_Zoo_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "insert into dbo.Zoo values (@location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@location", inputtxtBox.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void Add_Animal_To_Zoo_Click(object sender, RoutedEventArgs e) {
            // using selectedvalue of animal list and selectedvalue of zoo list, insert those values into the zoo animals table
            try {
                string query = "insert into dbo.ZooAnimal values (@zooId, @animalId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@zooId", ListZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@animalId", ListAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowAnimalsInZoo();
            }
        }

        private void Add_Animal_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "insert into dbo.Animal values (@name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", inputtxtBox.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowAnimals();
            }
        }

        private void Delete_Animal_Click(object sender, RoutedEventArgs e) {
            try {
                //MessageBox.Show("this button will delete a zoo once implemented");
                string query = "delete from Animal where id = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowAnimals();
            }
        }

        private void Remove_Animal_From_Zoo_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "delete from dbo.ZooAnimal where zooId = @zooId and animalId = @animalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@zooId", ListZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@animalId", ListZooAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowAnimalsInZoo();
            }
        }

        private void ShowSelectedZooInTxtBox() {
            try {
                string query = "select location from Zoo where Id = @zooId;";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter) {
                    sqlCommand.Parameters.AddWithValue("@zooId", ListZoos.SelectedValue);
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);
                    inputtxtBox.Text = zooTable.Rows[0]["location"].ToString();
                }
            } catch (Exception exception) {
                //MessageBox.Show(exception.ToString());
            }
        }

        private void ShowSelectedAnimalInTxtBox() {
            try {
                string query = "select name from Animal where Id = @animalId;";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter) {
                    sqlCommand.Parameters.AddWithValue("@animalId", ListAnimals.SelectedValue);
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);
                    inputtxtBox.Text = animalTable.Rows[0]["name"].ToString();
                }
            } catch (Exception exception) {
                //MessageBox.Show(exception.ToString());
            }
        }

        private void UpdateZoo_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "update dbo.Zoo set location = @location where Id = @zooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@location", inputtxtBox.Text);
                sqlCommand.Parameters.AddWithValue("@zooId", ListZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "update dbo.Animal set name = @name where Id = @animalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@name", inputtxtBox.Text);
                sqlCommand.Parameters.AddWithValue("@animalId", ListAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            } finally {
                sqlConnection.Close();
                ShowAnimals();
            }
        }
    }
}
