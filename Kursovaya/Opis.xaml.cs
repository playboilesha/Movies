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
using System.Diagnostics;


namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Opis.xaml
    /// </summary>
    public partial class Opis : Window
    {
        public Opis()
        {
            InitializeComponent();
          
        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;

        }
        static DataTable ExecuteSql(string sql)
        {
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            DataTable dt = new DataTable();


            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader read = cmd.ExecuteReader();

                using (read)
                {
                    dt.Load(read);
                }
            }

            return dt;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
           
          
            try
            {
               

                DataTable dt = ExecuteSql("select * From Comm  where NAME = '" + names.Text + "' and LOGIN = '" + Login.login + "'");
                ListViewComm.ItemsSource = dt.DefaultView;
                
            }
            catch (Exception ex)
            {

                
                MessageBox.Show(ex.Message);
            }



            //your connection string 
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            Opis opise = new Opis();
            try
            {
                DataTable dt_user = opise.Select("Select * from Fils where NAME = '" + names.Text + "' ;");
                if (dt_user.Rows.Count > 0) // если такая запись существует       
                {
                   
                    conn.Open();
                    SqlDataReader sqlDataReader = null;

                    SqlCommand sqlCommand = new SqlCommand($"Select * from [dbo].[Fils] where [NAME] = '" + names.Text + "' ;", conn);
                    sqlDataReader = sqlCommand.ExecuteReader();

                   

                    while (sqlDataReader.Read())
                    {
                        names.Text = (sqlDataReader["NAME"].ToString());

                        year.Text = (sqlDataReader["Year"].ToString());

                        opis.Text = (sqlDataReader["OPIS"].ToString());
                        Size.Content = int.Parse(sqlDataReader["OG"].ToString());

                        byte[] imegesBytes = (byte[])sqlDataReader["Image"];
                       
                        MemoryStream ms = new MemoryStream();
                        ms.Write(imegesBytes, 0, imegesBytes.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        var resimKaynak = new BitmapImage();
                        resimKaynak.BeginInit();
                        resimKaynak.StreamSource = ms;
                        resimKaynak.EndInit();
                        Photo.Source = resimKaynak;



                    }

                    /* using (var sr = new StreamReader("C:\\4 сем\\ооп\\Kursovaya\\Kursovaya\\opis.txt"))
                     {
                         var str = sr.Read();
                         ZANR.Text = str.ToString();
                     }*/


                    conn.Close();

                }
                else
                {
                    names.Text = "Нету";
                }
            }
            catch (Exception ex)
            {

                conn.Close();
                MessageBox.Show(ex.Message);
            }

            //foreach(var i in dt_user.Rows)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var val = Og.Text.Trim(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
            if (string.IsNullOrEmpty(val))
            {
                

                int a;

                a = Convert.ToInt32(Og.Text);

                if (a > 0 && a < 11)
                {
                 

                    //your connection string 
                    string connString = @"Data Source=LESHA\GAD;Initial Catalog=TEST;Integrated Security=True"; ;

                    //create instanace of database connection
                    SqlConnection conn = new SqlConnection(connString);
                    try
                    {


                       int b = Convert.ToInt32(Size.Content);
                        int summ;
                        summ = (a + b) / 2;



                        conn.Open();
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("Update Fils set OG = '" + summ + "' where [NAME] = '" + names.Text + "' ");
                        string sqlQery = stringBuilder.ToString();
                        using (SqlCommand sqlCommand1 = new SqlCommand(sqlQery, conn))
                        {
                            sqlCommand1.ExecuteNonQuery();
                        }
                        stringBuilder.Clear();
                        conn.Close();
                        conn.Open();

                        SqlDataReader sqlDataReader = null;

                        SqlCommand sqlCommand = new SqlCommand($"Select * from [dbo].[Fils] where [NAME] = '" + names.Text + "' ;", conn);
                        sqlDataReader = sqlCommand.ExecuteReader();



                        while (sqlDataReader.Read())
                        {
                            Size.Content = int.Parse((sqlDataReader["Og"]).ToString());

                        }
                        conn.Close();
                        Non.Content = " ";
                    }
                    catch (Exception ex)
                    {

                        conn.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Non.Content = "от 1 до 11!";
                }
            }
            else {
                Non.Content = "Введите число!";

            }

            

        }
        private void Comment(object sender, RoutedEventArgs e)
        {


            //your connection string 
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                    conn.Open();
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" INSERT INTO Comm([NAME], [LOGIN], [KOMMENT]) Values( '" + names.Text + "', '" + Login.login + "', '" + KOMMENT.Text + "') ;");
                    string sqlQery = stringBuilder.ToString();
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQery, conn))
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    stringBuilder.Clear();

                DataTable dt = ExecuteSql("select * From Comm  where NAME = '" + names.Text + "' and LOGIN = '" + Login.login + "'");
                ListViewComm.ItemsSource = dt.DefaultView;

                Opis op = new Opis();
              

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            conn.Close();


        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
        }
}
