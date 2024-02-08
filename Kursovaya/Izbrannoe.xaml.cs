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

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Izbrannoe.xaml
    /// </summary>
    public partial class Izbrannoe : Window
    {
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
        public Izbrannoe()
        {
            InitializeComponent();
            login.Content = Login.login;
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
        public void BestMove(object sender, RoutedEventArgs e)
        {
            /*BestMove bestMove = new BestMove();*/
            this.Close();
            /* bestMove.Show();*/
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
        public void Search(object sender, RoutedEventArgs e)
        {
            this.Close();
            Search search = new Search();
            search.Show();
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
            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                

                DataTable dt = ExecuteSql("select * From Izbrannoe where Login = '" + Login.login + "'");
                listviewUsers.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();



        }
        private void Delete(object sender, RoutedEventArgs e)
        {
          
            try
            {
                ListViewItem listViewItem = new ListViewItem();
                //listviewUsers.SelectedItems[index] = listViewItem.IsSelected;
                int index = listviewUsers.SelectedIndex;
                //ListViewItem listViewItem = new ListViewItem();
                //string index = listviewUsers.ItemsSource.ToString()

                string stri = (string)((DataRowView)listviewUsers.SelectedItems[0])[2].ToString();
                
                Izbrannoe izbran = new Izbrannoe();
                DataTable dt_user = izbran.Select("Select * from Izbrannoe where Name = '" + stri + "' and Login = '" + Login.login + "'  ;");


                if (dt_user.Rows.Count > 0) // если такая запись существует       
                {
                    Search search = new Search();
                    // ищем в базе данных фильм с такими данными         

                    string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connString);

                    conn.Open();
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append("delete from Izbrannoe where Name = '" + stri + "' and Login = '" + Login.login + "' ");
                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand com = new SqlCommand(sqlQuery, conn))
                    {
                        com.ExecuteNonQuery();


                    }
                    strBuilder.Clear();
                    this.Close();
                    Izbrannoe izbrannoe = new Izbrannoe();
                    izbrannoe.Show();

                    conn.Close();

                }
                else
                {
                    Non.Content = "Избранное не существует";
                }
            }




            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Izbrannoe izbrannoe = new Izbrannoe();
            izbrannoe.Show();
        }
        private void Opisanie(object sender, RoutedEventArgs e)
        {
            string str = (string)((DataRowView)listviewUsers.SelectedItems[0])[2].ToString();

            Opis opis = new Opis();
            opis.names.Text = str;

            opis.Show();
        }
    }
}
