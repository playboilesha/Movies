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
    /// Логика взаимодействия для Zanry.xaml
    /// </summary>
    public partial class Zanry : Window
    {
        public Zanry()
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
            
        }
        public void Izbrannoe(object sender, RoutedEventArgs e)
        {
            this.Close();
            Izbrannoe izbrannoe = new Izbrannoe();
            izbrannoe.Show();
        }
      
      
        public void Exite(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void Horror(object sender, RoutedEventArgs e)
        {
            Horror horror = new Horror();
            horror.Show();
            this.Close();
        }
        public void Komedii(object sender, RoutedEventArgs e)
        {
            Komedi komedi = new Komedi();
            this.Close();
            komedi.Show();
        }
        public void Fentasy(object sender, RoutedEventArgs e)
        {
            Fasntasy fantazy = new Fasntasy();
            this.Close();
            fantazy.Show();
        }
        public void Dram(object sender, RoutedEventArgs e)
        {
            Drama dr = new Drama();
            this.Close();
            dr.Show();
        }

        public void Boy(object sender, RoutedEventArgs e)
        {
            Boevik bo = new Boevik();
            this.Close();
            bo.Show();
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
    }
}
