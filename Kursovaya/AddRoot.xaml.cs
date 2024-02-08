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
using Microsoft.Win32;


namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для AddRoot.xaml
    /// </summary>
    public partial class AddRoot : Window
    {
        public AddRoot()
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


            //your connection string 
            string   connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
           
           
            try
            {
                int a = Convert.ToInt32(OG.Text);
                if (a < 11 && a > 0)
                {
                    string z = ZANR.SelectionBoxItem.ToString();
                    conn.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" INSERT INTO Fils([NAME], [ZANR], [YEAR],[TIME],[OG],[OPIS],[IMAGE]) SELECT '" + NAME.Text + "', '" + z + "', '" + YEAR.Text + "', '" + TIME.Text + "', '" + OG.Text + "','" + OPIS.Text + "', * FROM OPENROWSET(BULK N'" + PHOTO.Text + "', SINGLE_BLOB) IMAGE;");
                    string sqlQery = stringBuilder.ToString();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQery, conn))
                    {
                        sqlCommand.ExecuteNonQuery();

                    }
                    stringBuilder.Clear();
                    Close();
                    conn.Close();
                }
                else
                {
                    OG.Text = "От 1 до 5";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void File(object sender, RoutedEventArgs e)
        {
            
                OpenFileDialog Dir = new OpenFileDialog();
            if (Dir.ShowDialog() == true)
            {

                PHOTO.Text = Dir.FileName;
            }
        }
    }
}