using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietCalendarServiceLibrary;
using System.ServiceModel;

namespace DietCalendarHost
{
    class Program
    {
        /// <summary>
        /// Program Hostujący serwis, jako że serwis stworzony został jako biblioteka,
        /// musi istnieć program go hostujący np. Konsola
        /// </summary>
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DietCalendarServiceLibrary.Service1));
            ServiceHost host2 = new ServiceHost(typeof(DietCalendarServiceLibrary.Service2));
            host.Open();
            host2.Open();

            Console.WriteLine("Gotowe");
            Console.ReadKey();
        }
    }
}
