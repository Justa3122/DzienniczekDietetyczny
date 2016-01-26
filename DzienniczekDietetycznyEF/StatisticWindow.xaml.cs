using DzienniczekDietetycznyEF.ServiceReference1;
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

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Interaction logic for StataisticWindow.xaml
    /// </summary>
    public partial class StataisticWindow : Window
    {
        DiagramsCreator dc;
        OxyPlotModel oxyPlotModel;
        WcfLogin Logg;

        public StataisticWindow(WcfLogin Login)
        {
            InitializeComponent();
            oxyPlotModel = new OxyPlotModel();
            this.DataContext = oxyPlotModel;
            Logg = Login;

            dc = new DiagramsCreator(new WcfLogin() { Name = Login.Name, Password = Login.Password }, oxyPlotModel);

            dc.SetConsumeDate(dataOd, dataDo);
        }

        private void RysujSpozycie_Click(object sender, RoutedEventArgs e)
        {
            dc.StartDate = Convert.ToDateTime(dataOd.SelectedItem.ToString());
            dc.EndDate = Convert.ToDateTime(dataDo.SelectedItem.ToString());
            dc.ViewCalories(KcalScreen);
        }

        private void rysujZestawy_Click(object sender, RoutedEventArgs e)
        {
            dc.ViewFavourites(FavouritesScreen);
            dc.PrepareTabItem3(wybierzZestaw);
        }

        private void rysujSkladniki_Click(object sender, RoutedEventArgs e)
        {
            dc.SelectedFavourite = wybierzZestaw.SelectedItem.ToString();
            dc.ViewComponents(ComponentsScreen);
            dc.PrepareTabItem4(WybierzSkladnik);
        }

        private void RysujWartosciOdzywcze_Click(object sender, RoutedEventArgs e)
        {
            dc.SelectedMeal = WybierzSkladnik.SelectedItem.ToString();
            dc.ViewNutritionalValues(NutritionalValueScreen);
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(Logg).Show();
            this.Close();
        }
    }
}
