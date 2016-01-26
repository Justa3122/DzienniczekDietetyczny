using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Klasa tworząca i modyfikujaca wykresy
    /// </summary>
    public class OxyPlotModel : INotifyPropertyChanged
    {
        private LineSeries pointsSeries;

        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get
            {
                return plotModel;
            }
            set
            {
                plotModel = value;
                OnPropertyChanged("PlotModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public OxyPlotModel()
        {
            plotModel = new PlotModel();
        }

        /// <summary>
        /// Funkcja przygotowujaca układ współrzędnych, ustala skale osi, tytuły, legendę i kolorystykę układu
        /// </summary>
        /// <param name="xMax"></param>
        /// <param name="yMax"></param>
        /// <param name="titleX"></param>
        /// <param name="titleY"></param>
        public void SetUpLegend(double xMax, double yMax, string titleX, string titleY)
        {
            plotModel.LegendTitle = "Legenda";
            plotModel.LegendOrientation = LegendOrientation.Horizontal;
            plotModel.LegendPlacement = LegendPlacement.Outside;
            plotModel.LegendPosition = LegendPosition.BottomRight;
            plotModel.LegendBackground = OxyColor.FromAColor(200, OxyPlot.OxyColors.White);
            plotModel.LegendBorder = OxyColors.Black;

            var xAxis = new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                Title = titleX,
                Minimum = 0,
                Maximum = xMax
            };
            plotModel.Axes.Add(xAxis);

            var yAxis = new LinearAxis()
            {
                Position = AxisPosition.Left,
                Title = titleY,
                Minimum = 0,
                Maximum = yMax
            };
            plotModel.Axes.Add(yAxis);
        }

        /// <summary>
        /// Rysuje w układzie współrzędnych wykres oparty na dwóch listach wartości x i y wzajemnie tworzących węzły wykresu
        /// </summary>
        /// <param name="title"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="titleX"></param>
        /// <param name="titleY"></param>
        public void DrawSeries(string title, List<double> x, List<double> y, string titleX, string titleY)
        {

            plotModel.Series.Clear();
            plotModel.Axes.Clear();
            pointsSeries = new LineSeries()
            {
                Title = title,
            };

            SetUpLegend(x.Last(), y.OrderBy(o => o).Last(), titleX, titleY);

            for (int i = 0; i < x.Count; i++)
                pointsSeries.Points.Add(new DataPoint(x[i], y[i]));

            plotModel.Series.Add(pointsSeries);
        }
    }
}
