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
// oracle
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public static string user { get; set; }
        // public static string password { get; set; }
        // public static string host { get; set; }
         

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Connect()
        {
            string user = "robert";
            string password = "082000";
            string host = "137.184.92.195:1539/XE";
            string connString = $"User Id = {user}; Password = {password}; Data Source = {host};";
            using OracleConnection con = new(connString);
            using OracleCommand command = con.CreateCommand();
            try
            {
                con.Open();
                command.CommandText = "select * from users";
                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt64(0));  // id
                    Console.WriteLine(reader.GetString(1)); // name
                    Console.WriteLine(reader.GetString(2)); // email
                    Console.WriteLine(reader.GetString(3)); // password

                }
                reader.Dispose();
                MessageBox.Show("Conexion exitosa", "Oracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {

                MessageBox.Show( e.Message, "Oracle", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Btn_conectar_Click(object sender, RoutedEventArgs e)
        {
            Connect();
        }

        private void CrearConexion_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
