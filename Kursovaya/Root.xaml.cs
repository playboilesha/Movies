using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Navigation;



namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Root.xaml
    /// </summary>
    public partial class Root : Window
    {
        public Root()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //your connection string 
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            
            string films = "select * from Fils";
            SqlCommand sqlCommand = new SqlCommand(films, conn);
             
            List<Films> films1 = new List<Films>();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Films fl = new Films();
                fl.ID = sqlDataReader[0].ToString();
                fl.Name = sqlDataReader[1].ToString();
                fl.Zanr = sqlDataReader[2].ToString();
                fl.Year = sqlDataReader[3].ToString();
                fl.Time = sqlDataReader[4].ToString();
                fl.Opis = sqlDataReader[5].ToString();
                fl.Image = sqlDataReader[6].ToString();
                    fl.Og = int.Parse( sqlDataReader[7].ToString());
                    films1.Add(fl);


            }
            sqlDataReader.Close();
            FilmsGrid.ItemsSource = films1;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
         
            AddRoot addRoot = new AddRoot();
            addRoot.Show();


        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {



            //your connection string 
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();

                string films = "select * from Fils";
                SqlCommand sqlCommand = new SqlCommand(films, conn);

                List<Films> films1 = new List<Films>();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Films fl = new Films();
                    fl.ID = sqlDataReader[0].ToString();
                    fl.Name = sqlDataReader[1].ToString();
                    fl.Zanr = sqlDataReader[2].ToString();
                    fl.Year = sqlDataReader[3].ToString();
                    fl.Time = sqlDataReader[4].ToString();
                    fl.Opis = sqlDataReader[5].ToString();
                    fl.Image = sqlDataReader[6].ToString();
                    fl.Og = int.Parse(sqlDataReader[7].ToString());
                    films1.Add(fl);


                }
                sqlDataReader.Close();
                FilmsGrid.ItemsSource = films1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            DeleteRoot deleteRoot = new DeleteRoot();
            deleteRoot.Show();

        }
        private void Close(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Svert(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.WindowState = WindowState.Minimized;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }
    }
}
