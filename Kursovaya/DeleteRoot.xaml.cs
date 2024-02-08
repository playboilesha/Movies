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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для DeleteRoot.xaml
    /// </summary>
    public partial class DeleteRoot : Window
    {
        public DeleteRoot()
        {
            InitializeComponent();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
            Root root = new Root();
            root.Show();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("delete from Fils where NAME = '" + NAME.Text + "' and YEAR = '" + Year.Text + "' ");
                string sqlQery = stringBuilder.ToString();
                using (SqlCommand sqlCommand = new SqlCommand(sqlQery, conn))
                {
                    sqlCommand.ExecuteNonQuery();
                }
                stringBuilder.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
            conn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
