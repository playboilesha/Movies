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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
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
        public void Button_click(object sender, RoutedEventArgs e)
        {



            string connString = @"Data Source=LESHA\GAD;Initial Catalog=connection;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            if (TextBox1.Text.Length > 0) // проверяем логин
              {
                if (TextBox2.Text.Length > 0) // проверяем пароль
	            {
                    if (TextBox3.Text.Length > 0) // проверяем второй пароль
                    {


                    }
                    else Vvedi.Text = "Повторите пароль";
                }else Vvedi.Text = "Укажите пароль";
            }else Vvedi.Text = "Укажите логин";
            if (TextBox2.Text.Length >= 6)
             {
                bool en = true; // английская раскладка
                bool symbol = false; // символ
                bool number = false; // цифра

                for (int i = 0; i < TextBox2.Text.Length; i++) // перебираем символы
                {
                    if (TextBox2.Text[i] >= 'А' && TextBox2.Text[i] <= 'Я') en = false; // если русская раскладка
                if (TextBox2.Text[i] >= '0' && TextBox2.Text[i] <= '9') number = true; // если цифры
                if (TextBox2.Text[i] == '_' || TextBox2.Text[i] == '-' || TextBox2.Text[i] == '!') symbol = true; // если символ
            }

            if (!en)
                    Vvedi.Text = "Доступна только английская раскладка"; // выводим сообщение
            else if (!symbol)
                    Vvedi.Text = "Добавьте один из следующих символов: _ - !"; // выводим сообщение
            else if (!number)
                    Vvedi.Text = "Добавьте хотя бы одну цифру"; // выводим сообщение
            if (en && symbol && number) // проверяем соответствие
            {
             
                }
           
            }Vvedi.Text = "пароль слишком короткий, минимум 6 символов";
            if (TextBox2.Text == TextBox3.Text) // проверка на совпадение паролей
            {
                Vvedi.Text = "Пользователь зарегистрирован";
                try
                {
                    Registr registr = new Registr();
                    DataTable dt_user = registr.Select("SELECT * FROM [dbo].[User] WHERE [login] = '" + TextBox1.Text + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        Vvedi.Text = "Пользователь уже существует";
                    }
                    else
                    {
                        conn.Open();
                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.Append("Insert into [dbo].[User] values('" + TextBox1.Text + "' , '" + TextBox2.Text + "');");
                        string sqlQuery = strBuilder.ToString();
                        using (SqlCommand com = new SqlCommand(sqlQuery, conn))
                        {
                            com.ExecuteNonQuery();


                        }
                        strBuilder.Clear();
                    }
                }
                catch (Exception ex)
                {

                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
            else Vvedi.Text = "Пароли не совподают";
          









        }
        public void Vhod(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
