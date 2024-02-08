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
using System.Diagnostics;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
        }
        void Inst(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/an_3all_on")
            {

                UseShellExecute = true
            }); //открытие ссылки в браузере

        }
        void Vk(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/lsimakin")
            {

                UseShellExecute = true
            }); //открытие ссылки в браузере

        }
        void Twit(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://twitter.com")
            {

                UseShellExecute = true
            }); //открытие ссылки в браузере

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Main main = new Main();
            main.Show();
        }
    }
}
