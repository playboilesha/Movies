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
    /// Логика взаимодействия для Boevik.xaml
    /// </summary>
    public partial class Boevik : Window
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
        public Boevik()
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
        public void Izbrannoe(object sender, RoutedEventArgs e)
        {
            Izbrannoe izbrannoe = new Izbrannoe();
            izbrannoe.Show();
            this.Close();
        }


        public void Exite(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            Zanry zanry = new Zanry();
            this.Hide();
            zanry.Show();
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
            //your connection string 
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

                DataTable dt = ExecuteSql("select * From Fils  where Zanr = 'боевик'");
                listviewUsers.ItemsSource = dt.DefaultView;
            }






            //    DataTable table = new DataTable();
            //    string films = "select * From Filmss  where Zanr = 'комедия'  ";

            //    SqlCommand sqlCommand = new SqlCommand(films, conn);

            //    List<Films> films1 = new List<Films>();
            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //}
            //    while (sqlDataReader.Read())
            //    {
            //        Films fl = new Films();
            //       fl.iD = sqlDataReader[1].ToString();
            //        fl.Name = sqlDataReader[1].ToString();
            //        fl.Zanr = sqlDataReader[2].ToString();
            //        fl.Year = sqlDataReader[3].ToString();
            //        fl.Time = sqlDataReader[4].ToString();
            //        fl.Image = byte.Parse(sqlDataReader[5]);


            //        films1.Add(fl);


            //    }
            //    sqlDataReader.Close();
            //    listviewFilms.ItemsSource = films1;
            //}

            //SqlDataReader reader = command.ExecuteReader();
            //using(reader)
            //{
            //    table.Load(reader);
            //}
            //listviewFilms.ItemsSource = table.DefaultView;
            //adapter.SelectCommand = command;
            //adapter.Fill(table);
            //for(int i = 0; i < table.Rows.Count; i++)
            //{
            //    grid2.Items.Add(new Films(table.Rows[i][0].ToString(), table.Rows[i][1].ToString(), table.Rows[i][2].ToString()));
            //}



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GridViewColumn gridViewColumn = new GridViewColumn();
            int index = listviewUsers.SelectedIndex;
            //ListViewItem listViewItem = new ListViewItem();
            //string index = listviewUsers.ItemsSource.ToString();
            ListViewItem listViewItem = new ListViewItem();
            //listviewUsers.SelectedItems[index] = listViewItem.IsSelected;


            string str = (string)((DataRowView)listviewUsers.SelectedItems[0])[1].ToString();
            DataTemplate dataTemplate = new DataTemplate();


            int index1 = index + 1;



            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);
            Komedi komedi = new Komedi();

            try
            {
                DataTable dt_user = komedi.Select("SELECT * FROM [dbo].[Izbrannoe] WHERE [Name] = '" + str + "' AND [Login] = '" + Login.login + "'");
                if (dt_user.Rows.Count == 0) // если такая запись существует       
                {
                    conn.Open();
                    StringBuilder strBuilder = new StringBuilder();
                    strBuilder.Append("insert into Izbrannoe(Login, Name, Zanr, Image) Select '" + Login.login + "', NAME, ZANR, IMAGE from Fils Where  NAME = '" + str + "' ");
                    string sqlQuery = strBuilder.ToString();
                    using (SqlCommand com = new SqlCommand(sqlQuery, conn))
                    {
                        com.ExecuteNonQuery();


                    }
                    strBuilder.Clear();
                }
                else { Dobav.Content = "Уже добавлено"; }
            }
            catch (Exception ex)
            {

                conn.Close();
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private void Opisanie(object sender, RoutedEventArgs e)
        {
            string str = (string)((DataRowView)listviewUsers.SelectedItems[0])[1].ToString();

            Opis opis = new Opis();
            opis.names.Text = str;

            opis.Show();
        }
    }
}
