using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqliteConnection _dbConnection;
        private ObservableCollection<Car> _cars;
        public MainWindow()
        {
            InitializeComponent();
            _dbConnection = new SqliteConnection("Data Source=cars.db");
            _dbConnection.Open();

            _cars = new ObservableCollection<Car>(GetCarsFromDB());
            CarsDataGrid.ItemsSource = _cars;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var assemblyWindow = new AssemblyWindow();
            assemblyWindow.ShowDialog();
        }

        private ObservableCollection<Car> GetCarsFromDB()
        {
            var cars = new ObservableCollection<Car>();

            var sqlCommand = new SqliteCommand("SELECT * FROM cars", _dbConnection);
            var sqliteReader = sqlCommand.ExecuteReader();

            while (sqliteReader.Read())
            {
                cars.Add(new Car
                {
                    ID = Convert.ToInt32(sqliteReader["ID"]),
                    Brand = sqliteReader["Brand"].ToString(),
                    Model = sqliteReader["Model"].ToString(),
                    Year = Convert.ToInt32(sqliteReader["Year"]),
                    Availability = sqliteReader["Availability"].ToString()
                });
            }

            return cars;
        }
    }

    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Availability { get; set; }
    }
}

