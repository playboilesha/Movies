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
    /// Логика взаимодействия для Delete_izbran.xaml
    /// </summary>
    public partial class Opisanie : Window
    {

        public Opisanie()
        {
            InitializeComponent();
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            var datasource = @"LESHA\GAD";//your server
            var database = "connection"; //your database name
            var username = "lex"; //username of server to connect
            var password = "12345"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string text = Namee.Text;
            //if (text.Length > 3)
            //{
            //    text = text.Substring(0, 3);
            //}
            //try
            //{
            //   Opisanie delete_Izbran = new Opisanie();
            //    DataTable dt_user = delete_Izbran.Select("Select * from Izbrannoe where Name Like '" + text + "%' and Login = '" + Login.login + "'  ;");


            //    if (dt_user.Rows.Count > 0) // если такая запись существует       
            //    {
            //        Search search = new Search();
            //        if (Namee.Text.Length > 0) // проверяем введён ли имя       
            //        {             // ищем в базе данных фильм с такими данными         

            //            var datasource = @"LESHA\GAD";//your server
            //            var database = "connection"; //your database name
            //            var username = "lex"; //username of server to connect
            //            var password = "12345"; //password
            //            DataTable dataTable = new DataTable();
            //            //your connection string 
            //            string connString = @"Data Source=" + datasource + ";Initial Catalog="
            //                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            //            SqlConnection conn = new SqlConnection(connString);

            //            conn.Open();
            //            StringBuilder strBuilder = new StringBuilder();
            //            strBuilder.Append("delete from Izbrannoe where Name Like '" + text + "%' and Login = '" + Login.login + "' ");
            //            string sqlQuery = strBuilder.ToString();
            //            using (SqlCommand com = new SqlCommand(sqlQuery, conn))
            //            {
            //                com.ExecuteNonQuery();


            //            }
            //            strBuilder.Clear();
            //            this.Close();
                      
            //            conn.Close();
            //        }

            //        else
            //        {
            //            Non.Content = "Избранное не существует";
            //        }
            //    }


            //    else
            //    {
            //        Non.Content = "Введите данные";
            //    }
            //}
            //catch (Exception ex)
            //{

                
            //    MessageBox.Show(ex.Message);
            //}
                  

            
        }
    }
}
