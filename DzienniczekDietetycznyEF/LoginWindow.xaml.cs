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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DietCalendarService2Client cl2 = new DietCalendarService2Client();
        private WcfLogin logg;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            if (TextBoxLogin.Text != "" && TextBoxPassword.Text != "")
            {
                try
                {
                    logg = new WcfLogin()
                    {
                        Name = TextBoxLogin.Text.ToString(),
                        Password = TextBoxPassword.Text.ToString()
                    };
                    if (cl2.Login(logg))
                    {
                        MenuWindow mw = new MenuWindow(logg);
                        mw.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędny login lub hasło");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Serwis jest aktualnie niedostępny");
                    
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            rw.Show();
        }
    }
}
