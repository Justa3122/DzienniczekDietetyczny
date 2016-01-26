using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Klasa przygotowaujaca węzły o współrzędnych x i y do narysowania wykresu
    /// </summary>
    public class Nodes
    {
        public List<double> X { get; private set; }
        public List<double> Y { get; private set; }

        Interpolation interpolation;
        double[] indexValue;

        public Nodes(List<double> Values)
        {
            this.indexValue = new double[Values.Count];
            for (int i = 0; i < Values.Count; i++)
                indexValue[i] = Convert.ToDouble(i + 1);

            interpolation = new Interpolation(indexValue, Values.ToArray());
            GetPoints();
        }

        /// <summary>
        /// Funkcja przypisująca współrzędne x i y do listy
        /// </summary>
        private void GetPoints()
        {
            X = new List<double>();
            Y = new List<double>();
            double step = 0.01; //* (indexValue.Count()/600);
            for (double i = 0; i < indexValue.Count() + 1; i += step)
            {
                X.Add(i);
                Y.Add(interpolation.GetValue(i));
            }
        }
    }
}
