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
using Microsoft.Win32;
using System.IO;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    ///     Wyswietla zestawy uzytkownika i pozwala na wybranie zjedzonego zestawu
    /// </summary>
    public partial class ConsumeWindow : Window
    {
        public static DietCalendarService2Client cl2 = new DietCalendarService2Client();
        public List<ListBox> listboxy = new List<ListBox>();
        public List<ServiceReference1.WcfFavorite> favorites = new List<ServiceReference1.WcfFavorite>();
        public List<Button> buttons = new List<Button>();
        public static WcfLogin logg;
        public FavoriteWindow w2;
        private int indexScroll = 0;
        public ConsumeWindow(WcfLogin logg2)
        {
            logg = logg2;
            InitializeComponent();
            listboxy.Add(listBox1); listboxy.Add(listBox2);
            listboxy.Add(listBox3); listboxy.Add(listBox4);
            buttons.Add(button_zestaw_1); buttons.Add(button_zestaw_2);
            buttons.Add(button_zestaw_3); buttons.Add(button_zestaw_4);
            
            PobierzZestawy(logg.Name, logg.Password);
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            w2 = new FavoriteWindow(logg);
            w2.Show();
            this.Close();   
        }

        private void button_zestaw_1_Click(object sender, RoutedEventArgs e)
        {
            WcfConsumed cons = new WcfConsumed()
                {ConsumeTime = DateTime.Now, Favorite = favorites[0 + indexScroll]};
            cl2.AddConsumed(logg, cons);
        }

        private void button_zestaw_2_Click(object sender, RoutedEventArgs e)
        {
           WcfConsumed cons = new WcfConsumed() 
            { ConsumeTime = DateTime.Now, Favorite = favorites[1 + indexScroll] };
            cl2.AddConsumed(logg, cons);
        }

        private void button_zestaw_3_Click(object sender, RoutedEventArgs e)
        {
            WcfConsumed cons = new WcfConsumed() 
            { ConsumeTime = DateTime.Now, Favorite = favorites[2 + indexScroll] };
            cl2.AddConsumed(logg, cons);
        }

        private void button_zestaw_4_Click(object sender, RoutedEventArgs e)
        {
            WcfConsumed cons = new WcfConsumed() 
            { ConsumeTime = DateTime.Now, Favorite = favorites[3 + indexScroll] };
            cl2.AddConsumed(logg, cons);
        }

        private void button_up_Click(object sender, RoutedEventArgs e)
        {
            if (indexScroll>0)
            {
                indexScroll--;
                PobierzZestawy(logg.Name,logg.Password);
            }
        }

        private void button_down_Click(object sender, RoutedEventArgs e)
        {
            if (indexScroll< favorites.Count -4)
            {
                indexScroll++;
                PobierzZestawy(logg.Name,logg.Password);
            }
        }
        public void PobierzZestawy(string login, string haslo)
        {
            foreach (ListBox item in listboxy)
            {
                item.Items.Clear();
                item.Visibility = System.Windows.Visibility.Visible;   
            }
            foreach (var item in buttons)
            {
                item.Visibility = System.Windows.Visibility.Visible;
            }
            WcfLogin log = new WcfLogin() { Name = login, Password = haslo };
            int index = 0, index2 = 0 ;
            favorites = cl2.DownloadFavorites(log).ToList();
            foreach (var favorite in favorites)
            {
                if (index2 >= indexScroll && index < 4)
                {
                    foreach (var favcomp in favorite.FavoriteCompontents)
                    {
                        listboxy[index].Items.Add(string.Format("{0}, {1}", favcomp.Meal.MealName.ToString(), favcomp.Quantity.ToString()));
                        buttons[index].Content = favorite.FavoriteName;
                    }
                    index++; 
                }
                index2++;
            }
            index = 0;

            if (favorites.Count < 4)
            {
                foreach (ListBox item in listboxy)
                {
                    if (item.Items.Count == 0)
                    {
                        item.Visibility = System.Windows.Visibility.Hidden;
                        buttons[index].Visibility = System.Windows.Visibility.Hidden;
                    }
                    index++;
                } 
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(logg).Show();
            this.Close();
        }

        private void ImportClick(object sender, RoutedEventArgs e)
        {
            //import button
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "Excell Files (.xlsx)|*.xlsx|Old Version Excell Files (*.xls*)|*.xls*";
            openDialog.FilterIndex = 1;
            openDialog.Multiselect = true;

            if (openDialog.ShowDialog() == true)
            {
                ExcelImporter eI = new ExcelImporter(openDialog.FileName.ToString(), logg);
                ImportButton.Content = "Zaimportowano!!!";
                
            }
            
        }

        private void DownloadClick(object sender, RoutedEventArgs e)
        {
            //download button
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excell Files (.xlsx)|*.xlsx|Old Version Excell Files (*.xls*)|*.xls*";
            saveDialog.FilterIndex = 1;

            FileInfo fi = new FileInfo(Directory.GetCurrentDirectory());
            
           
            if (saveDialog.ShowDialog() == true)
            {
                File.Copy( fi.DirectoryName.ToString() + @"\SzablonDoWprowadzaniaDanych.xlsx", saveDialog.FileName.ToString());
            }
        }
    }
}
