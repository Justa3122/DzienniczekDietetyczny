using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using DzienniczekDietetycznyEF.ServiceReference1;
using System.Threading;

namespace DzienniczekDietetycznyEF
{
/// <summary>
///     Tworzenie ze skladnikow wlasnego zestawu
/// </summary>
    public partial class FavoriteWindow : Window
    {
        public DietCalendarService2Client cl2 = new DietCalendarService2Client();
        public ServiceReference1.WcfLogin logg;
        public List<WcfMeal> meals = new List<WcfMeal>();
        public List<WcfFavoriteComponent> favComponents = new List<WcfFavoriteComponent>();
        public WcfMeal actualMeal = new WcfMeal();

        int grams = 0;
        private List<ListBox> listBoxes;
        private List<Button> buttons;
        public List<string> tmpFood = new List<string>(); //do listy dodaje tym sobie produkty z zestawu
        string nazwa; //aktualna nazwa produktu, ktora dodamy do zestawu
        List<double> sumOfCalories = new List<double>();
        List<double> listOfCalories = new List<double>();
        public double sumaKaloriiwZestawie;
        public int index = 1;
        ConsumeWindow w;


        public FavoriteWindow(ServiceReference1.WcfLogin logg2)
        {
            InitializeComponent();
            logg = logg2;
            
            textBoxGrams.Text = grams.ToString();

            listBoxes = new List<ListBox>();
            buttons = new List<Button>();

            w = new ConsumeWindow(logg);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox.Text != "")
                {
                    meals = cl2.DownloadAllMeals(textBox.Text.ToString()).ToList();
                }
                listBoxPrimary.Items.Clear();
                foreach (var meal in meals)
                {
                    listBoxPrimary.Items.Add(meal.MealName.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Za dużo rekordów, wpisz dłuższą fraze");
                throw;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxPrimary.SelectedItem!=null)
            {
                listBoxChoosen.Items.Clear();
                listBoxChoosen.Items.Add(listBoxPrimary.SelectedItem);
                nazwa = listBoxPrimary.SelectedItem.ToString();
                tmpFood.Add(nazwa); 
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBoxLastStep.Items.Add(string.Format("{0}, {1}g",nazwa,grams.ToString()));
            foreach (var meal in meals)
            {
                if (meal.MealName == nazwa)
                {
                    favComponents.Add(new WcfFavoriteComponent() { Meal = meal, Quantity = grams });
                }
            }
        }

        #region licznik gram
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //operowanie licznikiem przy wyborze gramow
            grams = grams + 10;
            textBoxGrams.Text = grams.ToString();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //operowanie licznikiem przy wyborze gramow
            if (grams > 9)
            {
                grams = grams - 10; ;
                textBoxGrams.Text = grams.ToString();
            }
        }
        #endregion

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            //usuwanie wybranej pozycji z ostatniej listy
            if (listBoxLastStep.HasItems && listBoxLastStep.SelectedItem != null)
            {
                int index = listBoxLastStep.SelectedIndex;
                listBoxLastStep.Items.Remove(listBoxLastStep.SelectedItem);
                foreach (var favComponent in favComponents)
                {
                    if (listBoxLastStep.SelectedItem.ToString().Contains(favComponent.Meal.MealName))
                    {
                        favComponents.Remove(favComponent);
                    }
                }
            }
        }

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            bool powiodloSie = false;
            if (TextBoxFavoriteName.Text.ToString() != "")
            {
                WcfFavorite fav = new WcfFavorite() { FavoriteCompontents = favComponents.ToArray(), FavoriteName = TextBoxFavoriteName.Text.ToString() };
                powiodloSie = cl2.AddFavorite(logg, fav);
            }
            else
            {
                MessageBox.Show("Podaj nazwe zestawu");
            }

            if (powiodloSie)
            {
                MessageBox.Show("Dodano");
                this.Close();
                w = new ConsumeWindow(logg);
                Thread.Sleep(500);
                w.Show(); 
            }
            else
            {
                MessageBox.Show("Nie udało się dodać zestawu");
            }
        }
        public void DeleteMeals()
        {
            listBoxes.Clear();
        }

        private void listBoxPrimary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox.Text.Length >= 3)
            {
                try
                {
                    meals = cl2.DownloadAllMeals(textBox.Text.ToString()).ToList();
                    listBoxPrimary.Items.Clear();
                    foreach (var meal in meals)
                    {
                        listBoxPrimary.Items.Add(meal.MealName.ToString());
                    }
                }
                catch
                { 
                
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            w.Show();
        }
    }
}
