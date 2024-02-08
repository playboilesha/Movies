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
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;

namespace Kursovaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        /*const int STD_INPUT_HANDLE = -10;
        const int STD_OUTPUT_HANDLE = -11;
        const int STD_ERROR_HANDLE = -12;
        [DllImport("kernel32")]
        public static extern void AllocConsole();

        [DllImport("kernel32")]
        public static extern void FreeConsole();

        [DllImport("kernel32")]
        public static extern IntPtr GetStdHandle(int h);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsole(
            IntPtr h,
            [MarshalAs(UnmanagedType.LPWStr)] string s,
            int l,
            ref int lw,
            IntPtr zero);

        public static IntPtr hcon = IntPtr.Zero;*/




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



        }


        public MainWindow()
        {
            InitializeComponent();
            Main main = new Main();
            /* int wc = 0;
             AllocConsole();
             hcon = GetStdHandle(STD_OUTPUT_HANDLE);*/



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

        public void Button_click(object sender, RoutedEventArgs e)
        {

            if (TextBox1.Text == "root" && TextBox2.Text == "root")
            {
                this.Close();
                Root root = new Root();
                root.Show();


            }
            else
            {

                MainWindow mainWindow = new MainWindow();
                if (TextBox1.Text.Length > 0) // проверяем введён ли логин     
                {
                    if (TextBox2.Text.Length > 0) // проверяем введён ли пароль         
                    {             // ищем в базе данных пользователя с такими данными         
                        DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[User] WHERE [login] = '" + TextBox1.Text + "' AND [password] = '" + TextBox2.Text + "'");
                        if (dt_user.Rows.Count > 0) // если такая запись существует       
                        {
                            Vvedi.Text = "Пользователь авторизовался"; // говорим, что авторизовался  
                            Main main = new Main();

                         
                            Login.login = TextBox1.Text;
                            main.login.Content = TextBox1.Text;
                            this.Close();

                            main.Show();


                        }
                        else Vvedi.Text = "Пользователя не найден"; // выводим ошибку  
                    }
                    else Vvedi.Text = "Введите пароль"; // выводим ошибку    
                }
                else Vvedi.Text = "Введите логин"; // выводим ошибку 

            }
            

           
         














        }
        public void Regist(object sender, RoutedEventArgs e)
        {
            this.Close();
            Registr registr = new Registr();
            registr.Show();
        }
    }
}
