using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Klasa zwracająca funkcję interpolującą przesłanych do niej węzłów interpolacji
    /// </summary>
    public class Interpolation
    {
        private List<double> a;
        private double[] x;
        private double[] fx;

        public Interpolation(double[] x, double[] fx)
        {
            this.x = x;
            this.fx = fx;
            a = GetDirections();
        }

        /// <summary>
        /// Zwraca wartość y funkcji interpolującej dla wybranego punktu x 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double GetValue(double x)
        {
            double y = 0;
            for (int i = 0; i < a.Count; i++)
                y = (y * x) + a[i];

            return y;
        }

        /// <summary>
        /// Funkcja układająca macierz i zwracająca współczynniki kierunkowe do wzoru funkcji interpolującej
        /// </summary>
        /// <returns></returns>
        private List<double> GetDirections()
        {
            int n = x.Length;

            // Deklaracja Macierzy
            double[][] A = new double[n][];
            for (int i = 0; i < n; i++)
                A[i] = new double[n];

            // Wypełnienie
            for (int i = 0; i < n; i++)
                for (int j = 0, k = n - 1; k >= 0; j++, k--)
                    A[i][j] = (Math.Pow(x[i], k));

            return GausianElimination(A, fx);
        }

        /// <summary>
        /// Funkcja obliczająca niewiadome za pomocą eliminacji Gaussa, sprowadza macież do diagonalnej
        /// </summary>
        /// <param name="A"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private List<double> GausianElimination(double[][] A, double[] b)
        {
            int n = A.GetLength(0);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double s = A[j][i] / A[i][i];
                    for (int k = i; k < n; k++)
                    {
                        A[j][k] -= A[i][k] * s;
                    }
                    b[j] -= b[i] * s;
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                b[i] /= A[i][i];
                A[i][i] /= A[i][i];
                for (int j = i - 1; j >= 0; j--)
                {
                    double s = A[j][i] / A[i][i];
                    A[j][i] -= s;
                    b[j] -= b[i] * s;
                }
            }

            return Enumerable.Range(0, n).Select(i => b[i] / A[i][i]).ToList();
        }

    }
}
