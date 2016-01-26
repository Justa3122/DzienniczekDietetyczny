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
using DzienniczekDietetycznyEF.ServiceReference2;
using DzienniczekDietetycznyEF.ServiceReference1;
using System.Threading;

namespace DzienniczekDietetycznyEF
{
    public partial class RegisterWindow : Window
    {
        private DietCalendarServiceClient cl = new DietCalendarServiceClient();
        private DietCalendarService2Client cl2 = new DietCalendarService2Client();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text != "" && TextBoxPassword.Text != "")
            {
                var logg = new ServiceReference2.WcfLogin()
                {
                    Name = TextBoxLogin.Text.ToString(),
                    Password = TextBoxPassword.Text.ToString()
                };
                cl.Register(logg);
                Thread.Sleep(2000);
                var logg2 = new ServiceReference1.WcfLogin()
                {
                    Name = TextBoxLogin.Text.ToString(),
                    Password = TextBoxPassword.Text.ToString()
                };
                try
                {
                    if (cl2.Login(logg2))
                    {
                        MessageBox.Show("Rejestracja przebiegła pomyślnie");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login już jest zajęty");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Serwis aktualnie jest niedostępny");
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }   
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
