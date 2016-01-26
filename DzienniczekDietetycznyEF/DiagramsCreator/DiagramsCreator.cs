

using DzienniczekDietetycznyEF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Klasa pobierająca dane z bazy i przygotowująca odpowiednie wartości do rysowania wykresó
    /// </summary>
    public class DiagramsCreator
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SelectedFavourite { get; set; }
        public string SelectedMeal { get; set; }


        private DietCalendarService2Client cl { get; set; }
        private WcfLogin Login { get; set; }
        private OxyPlotModel OxyPlotModel;

        private List<DateTime> AllDate { get; set; }


        private List<WcfConsumed> Consumed { get; set; }
        private List<WcfFavorite> Favourites { get; set; }
        private List<WcfMeal> Meals { get; set; }


        public DiagramsCreator(WcfLogin Login, OxyPlotModel oxyPlotModel)
        {
            cl = new DietCalendarService2Client();
            this.Login = Login;
            Consumed = cl.DownloadConsumed(Login).ToList();
            AllDate = GetaDate(Consumed);
            this.OxyPlotModel = oxyPlotModel;
        }


        /// <summary>
        /// Ustawia daty spożycia posiłków użytkownika w comboboxach
        /// </summary>
        /// <param name="com1"></param>
        /// <param name="com2"></param>
        public void SetConsumeDate(ComboBox com1, ComboBox com2)
        {
            FillComboBox(com1, AllDate.Select(x => Convert.ToString(x)).ToList());
            FillComboBox(com2, AllDate.Select(x => Convert.ToString(x)).ToList());
        }

        /// <summary>
        /// Wypełnia TabItem1 danymi o spożyciu kalorii, daty, sumę kalorii i rysuje wykres interpolowany na tych wartościach
        /// </summary>
        /// <param name="listBox"></param>
        public void ViewCalories(ListBox listBox)
        {
            Consumed = GetConsumed();
            var q = GetCalories().Select(x => new { Date = x.Key, Kcall = x.Value }).ToList();
            for (int i = 0; i < q.Count; i++)
                listBox.Items.Add(i + 1 + "\t" + q[i].Date + "\t" + q[i].Kcall);


            var fx = q.Select(x => x.Kcall).ToList();

            Nodes nodes = new Nodes(fx);

            OxyPlotModel.DrawSeries("Spożyte kalorie", nodes.X, nodes.Y, "Dni", "Kalorie");
            OxyPlotModel.PlotModel.InvalidatePlot(true);
        }

        /// <summary>
        /// Wypełnia TabItem2 rankingiem spożycia zestawów i rysuje wykres interpolowany na tych wartościach
        /// </summary>
        /// <param name="listBox"></param>
        public void ViewFavourites(ListBox listBox)
        {
            listBox.Items.Clear();
            var favouriteName = GetFavouriteCount().Select(x => new { Name = x.Key, Value = x.Value }).ToList();

            for (int i = 0; i < favouriteName.Count; i++)
                listBox.Items.Add(i + 1 + "\t" + favouriteName[i].Name + "\t ilość = " + favouriteName[i].Value);

            var fx = GetFavouriteCount().Select(x => x.Value).ToList();

            Nodes nodes = new Nodes(fx);

            OxyPlotModel.DrawSeries("Ulubione zestawy", nodes.X, nodes.Y, "Zestawy", "Ranking");
            OxyPlotModel.PlotModel.InvalidatePlot(true);

        }

        /// <summary>
        /// Wypełnia combobox w TabItem3 nazwami spożytych zestawów
        /// </summary>
        /// <param name="com"></param>
        public void PrepareTabItem3(ComboBox com)
        {
            com.Items.Clear();
            FillComboBox(com, GetFavouritesName());
        }

        /// <summary>
        /// Wypełnia TabItem3 danymi na temat ilości użytych składników zestawu i rysuje wykres interpolowany na tych wartościach
        /// </summary>
        /// <param name="listbox"></param>
        public void ViewComponents(ListBox listbox)
        {
            listbox.Items.Clear();

            var q = Consumed.Select(x => x.Favorite)
                .Where(y => y.FavoriteName == SelectedFavourite)
                .First()
                .FavoriteCompontents
                .Select(x => new { Name = x.Meal.MealName, Quantity = x.Quantity }).ToList();

            for (int i = 0; i < q.Count; i++)
                listbox.Items.Add(i + 1 + "\t" + q[i].Name + "\t ilość = " + q[i].Quantity + "gram");

            Nodes nodes = new Nodes(q.Select(x => Convert.ToDouble(x.Quantity)).ToList());

            OxyPlotModel.DrawSeries("Składniki zestawu", nodes.X, nodes.Y, "Składniki", "Ilość gram");
            OxyPlotModel.PlotModel.InvalidatePlot(true);

            Meals = GetMeals();
        }
        /// <summary>
        /// Wypełnia combobox w TabItem4 nazwami składników zawartych w zestawie
        /// </summary>
        /// <param name="com"></param>
        public void PrepareTabItem4(ComboBox com)
        {
            com.Items.Clear();
            FillComboBox(com, GetMealsName());
        }

        /// <summary>
        /// Wypełnia TabItem4 wartościami odżywczymi wybranego składnika posiłku i rysuje wykres interpolowany na tych wartościach
        /// </summary>
        /// <param name="listBox"></param>
        public void ViewNutritionalValues(ListBox listBox)
        {
            listBox.Items.Clear();
            var meal = Meals.Where(x => x.MealName == SelectedMeal)
                .OrderBy(x => x)
                .First();

            listBox.Items.Add("1. Kalorie = " + meal.Calories + "\n"
                + "2. Tłuszcze = " + meal.Fat + "\n"
                + "3. Węglowodany = " + meal.CarboHydrates + "\n"
                + "4. Białko = " + meal.Protein);

            var values = new List<double>()
            {
                meal.Calories,
                meal.Fat,
                meal.CarboHydrates,
                meal.Protein
            };
            Nodes nodes = new Nodes(values);

            OxyPlotModel.DrawSeries("Wartości odżywcze", nodes.X, nodes.Y, "Składniki", "Ilość na 100/g");
            OxyPlotModel.PlotModel.InvalidatePlot(true);

        }


        /// <summary>
        /// Zwraca słownik odpowiadający za ranking spożytych zestawów, ilość wystąpień w spożyciu decyduje o pozycji
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, double> GetFavouriteCount()
        {
            Dictionary<string, double> favourites = new Dictionary<string, double>();

            var fav = Consumed.Select(x => x.Favorite)
                .GroupBy(g => g.FavoriteName)
                .Select(group => new { FavouriteName = group.Key, count = group.Count() });

            foreach (var item in fav)
                favourites.Add(item.FavouriteName, Convert.ToDouble(item.count));

            return favourites;
        }

        /// <summary>
        /// Zwraca słownik zjedzonych posiłków, kluczem jest data spożycia a wartością suma kalori spożytych w tym czasie
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, double> GetCalories()
        {
            Dictionary<string, double> caloriesCount = new Dictionary<string, double>();

            var groups = Consumed.GroupBy(g => g.ConsumeTime)
                .Select(g =>
                    new
                    {
                        Date = g.Key,
                        Calories = g.Select(x => x.Favorite.FavoriteCompontents
                            .Sum(y => ConvertMealValue(y.Meal.Calories, y.Quantity))).Sum()
                    });

            foreach (var item in groups)
            {
                caloriesCount.Add(item.Date.ToString(), item.Calories);
            }

            return caloriesCount;
        }

        /// <summary>
        /// Zwraca nazwy składników wybranego zestawu
        /// </summary>
        /// <returns></returns>
        private List<String> GetMealsName()
        {
            return Meals.Select(x => x.MealName).ToList();
        }

        /// <summary>
        /// Zwraca składniki wybranego zestawu
        /// </summary>
        /// <returns></returns>
        private List<WcfMeal> GetMeals()
        {
            var favourite = Consumed
                .Where(x => x.Favorite.FavoriteName == SelectedFavourite)
                .OrderBy(x => x.ConsumeTime)
                .First();

            return favourite.Favorite.FavoriteCompontents.Select(x => x.Meal).ToList();
        }

        /// <summary>
        /// Zwraca nazwy spożytych zestawów
        /// </summary>
        /// <returns></returns>
        private List<string> GetFavouritesName()
        {
            return GetFavouriteCount().Select(x => x.Key).ToList();
        }

        /// <summary>
        /// Wypełnia combobox przekazywaną listą obiektów
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="items"></param>
        private void FillComboBox(ComboBox comboBox, List<string> items)
        {
            foreach (var item in items)
                comboBox.Items.Add(item);
        }


        /// <summary>
        /// Przelicza wartości odżywcze według spożytej ilości składnika
        /// </summary>
        /// <param name="cons"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private double ConvertMealValue(double cons, double quantity)
        {
            return ((cons * quantity) / 100);
        }


        /// <summary>
        /// Pobiera daty bez powtórzeń z kolekcji WcfConsumed
        /// </summary>
        /// <param name="consumed"></param>
        /// <returns></returns>
        private List<DateTime> GetaDate(List<WcfConsumed> consumed)
        {
            List<DateTime> dates = new List<DateTime>();
            dates.Add(consumed.First().ConsumeTime);

            for (int i = 0; i < consumed.Count; i++)
                if (dates.Any(x => x == consumed[i].ConsumeTime))
                    continue;
                else
                    dates.Add(consumed[i].ConsumeTime);

            return dates.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Wybiera kolekcję WcfConsumed pomiędzy określonymi datami
        /// </summary>
        /// <returns></returns>
        private List<WcfConsumed> GetConsumed()
        {
            List<WcfConsumed> consumed = cl.DownloadConsumed(Login).ToList();
            List<WcfConsumed> newConsumed = new List<WcfConsumed>();
            for (int i = 0; i < consumed.Count; i++)
                if (consumed[i].ConsumeTime >= StartDate && consumed[i].ConsumeTime <= EndDate)
                    newConsumed.Add(consumed[i]);
                else
                    continue;

            return newConsumed;

        }
    }
}
