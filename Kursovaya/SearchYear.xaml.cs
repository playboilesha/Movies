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
    /// Логика взаимодействия для SearchYear.xaml
    /// </summary>
    public partial class SearchYear : Window
    {
        public SearchYear()
        {
            InitializeComponent();
            login.Content = Login.login;
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
        public void MainStr(object sender, RoutedEventArgs e)
        {
            this.Close();
            Main main = new Main();
            main.Show();
        }
        public void Zhanr(object sender, RoutedEventArgs e)
        {
            this.Close();
            Zanry zanry = new Zanry();
            zanry.Show();
        }
        public void Izbrannoe(object sender, RoutedEventArgs e)
        {
            Izbrannoe izbrannoe = new Izbrannoe();
            izbrannoe.Show();
            this.Close();
        }
        public void Lenguage(object sender, RoutedEventArgs e)
        {

        }
        public void Film(object sender, RoutedEventArgs e)
        {


        }

        public void Film1(object sender, RoutedEventArgs e)
        {


        }
        public void Year(object sender, RoutedEventArgs e)
        {



        }
      
        public void Nazvan(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Close();

        }
        public void cmdGetFIlm(object sender, RoutedEventArgs e)
        {
            string text = NAME.Text;
           
            Search search = new Search();
            if (NAME.Text.Length > 0) // проверяем введён ли имя       
            {             // ищем в базе данных фильм с такими данными         
                DataTable dt_user = search.Select("Select * from Fils where YEAR = '" + text + "';");
                if (dt_user.Rows.Count > 0) // если такая запись существует       
                {
                   
                    DataTable dataTable = new DataTable();
                    //your connection string 
                    string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

                    //create instanace of database connection
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    SqlDataReader sqlDataReader = null;

                    SqlCommand sqlCommand = new SqlCommand($"Select * from [dbo].[Fils] where [YEAR] = '" + text + "' ;", conn);
                    sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        NAMEES.Text = (sqlDataReader["NAME"].ToString());
                        ZANR.Text = (sqlDataReader["ZANR"].ToString());
                        
                        TIME.Text = (sqlDataReader["TIME"].ToString());
                        OPIS.Text = (sqlDataReader["OPIS"].ToString());
                        OG.Text = (sqlDataReader["OG"].ToString());

                        byte[] imegesBytes = (byte[])sqlDataReader["Image"];

                        MemoryStream ms = new MemoryStream();
                        ms.Write(imegesBytes, 0, imegesBytes.Length);
                        ms.Seek(0, SeekOrigin.Begin);
                        var resimKaynak = new BitmapImage();
                        resimKaynak.BeginInit();
                        resimKaynak.StreamSource = ms;
                        resimKaynak.EndInit();
                        Photo.Source = resimKaynak;

                        ZANR1.Text = "Жанр:";
                        NAMEES1.Text = "Название:";
                        TIME1.Text = "Длительность, мин:";
                        OPIS1.Text = "Описание:";
                        OG1.Text = "Оценка:";

                        Non.Content = " ";
                    }

                    /* using (var sr = new StreamReader("C:\\4 сем\\ооп\\Kursovaya\\Kursovaya\\opis.txt"))
                     {
                         var str = sr.Read();
                         ZANR.Text = str.ToString();
                     }*/
                    conn.Close();


                    //foreach(var i in dt_user.Rows)
                    //OPIS.Text = dt_user.Rows[i]; //записываем 
                    //Main main = new Main();



                }
                else
                {
                    Non.Content = "не найден";
                }
                // выводим ошибку  

            }
        }
        public void Exite(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void Log_out(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public ResourceDictionary CurrentTheme = new ResourceDictionary();
        public void temaWhite(object sender, RoutedEventArgs e)
        {
            CurrentTheme.Source = new Uri("Tema.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(CurrentTheme);
        }
        public void temaBlack(object sender, RoutedEventArgs e)
        {
            CurrentTheme.Source = new Uri("Tema2.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(CurrentTheme);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

