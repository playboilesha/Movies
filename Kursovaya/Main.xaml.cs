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
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace Kursovaya
{ /// <summary>
  /// Логика взаимодействия для Main.xaml
  /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            login.Content = Login.login;
          
        }
       private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow auto = new MainWindow();


        }
        public void MainStr(object sender, RoutedEventArgs e)
        {
            
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
        public void Search(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Close();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
            this.Close();
        }
    }
}
