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
using System.Windows.Shapes;
using DzienniczekDietetycznyEF.ServiceReference1;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private WcfLogin logg;
        public MenuWindow(WcfLogin logg2)
        {
            logg = logg2;
            InitializeComponent();
        }

        private void DodajPosilek_Click(object sender, RoutedEventArgs e)
        {
            new ConsumeWindow(logg).Show();
            this.Close();
        }

        private void Statystki_Click(object sender, RoutedEventArgs e)
        {
            new StataisticWindow(logg).Show();
            this.Close();
        }

        private void Autorzy_Click(object sender, RoutedEventArgs e)
        {
            new AuthorsWindow().Show();
        }

        private void Wyjscie_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
