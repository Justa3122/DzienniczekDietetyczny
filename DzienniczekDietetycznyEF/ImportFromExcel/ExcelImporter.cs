using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using DzienniczekDietetycznyEF.ServiceReference1;
using System.IO;

namespace DzienniczekDietetycznyEF
{
    /// <summary>
    /// Klasa importująca do bazy danych dzienniczek dietetyczny w formie pliku excel
    /// </summary>
    public class ExcelImporter
    {
        string ConnectionString { get; set; }
        WcfLogin Login { get; set; }
        OleDbConnection Con { get; set; }
        DietCalendarService2Client Cl { get; set; }
        


        public ExcelImporter(string excelFilePath, WcfLogin login)
        {
            ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
            this.Login = login;
            Con = new OleDbConnection(ConnectionString);
            Cl = new DietCalendarService2Client();
    
            AddFavouriteFromExcel();
            AddConsumedFromExcel();
        }

        /// <summary>
        /// Funkcja dodająca zaimportowane zestawy do bazy, dodaje tylko nieistniejace
        /// </summary>
        private void AddFavouriteFromExcel()
        {
            List<WcfFavorite> allFavouriteFromExcel = GetFavourites();
            List<WcfFavorite> allFavouriteFromDb = Cl.DownloadFavorites(Login).ToList();

            for (int i = 0; i < allFavouriteFromExcel.Count; i++)
            {
                if (allFavouriteFromDb.Any(x => x.FavoriteName == allFavouriteFromExcel[i].FavoriteName))
                    continue;
                else
                    Cl.AddFavorite(Login, allFavouriteFromExcel[i]);
            }

        }

        /// <summary>
        /// Funkcja dodająca spożyty posiłek do bazy
        /// </summary>
        private void AddConsumedFromExcel()
        {
            List<WcfConsumed> allConsumedFromExcell = GetConsumed();
            List<WcfConsumed> allConsumedFromDb = Cl.DownloadConsumed(Login).ToList();

            for (int i = 0; i < GetConsumed().Count; i++)
                if (allConsumedFromDb.Any(x => x.ConsumeTime == allConsumedFromExcell[i].ConsumeTime
                    && x.Favorite.FavoriteName == allConsumedFromExcell[i].Favorite.FavoriteName))
                    continue;
                else
                    Cl.AddConsumed(Login, GetConsumed()[i]);
        }

        /// <summary>
        /// Funkcja zwracająca spożyte posiłki użytkownika, ich czas spożycia i nazwę zestawu
        /// </summary>
        /// <returns></returns>
        private List<WcfConsumed> GetConsumed()
        {
            List<List<string>> allDate = GetAllRows("Zjedzone");

            List<WcfConsumed> allConsumed = new List<WcfConsumed>();
            for (int i = 0; i < allDate.Count; i++)
            {
                allConsumed.Add(new WcfConsumed()
                {
                    ConsumeTime = Convert.ToDateTime(allDate[i][0]),
                    Favorite = new WcfFavorite()
                    {
                        FavoriteName = allDate[i][1]
                    }
                });
            }

            return allConsumed;
        }

        /// <summary>
        /// Funkcja zwracająca listę zestawów użytkownika zawartych w pobranych rekordach z pliku excell
        /// </summary>
        /// <returns></returns>
        private List<WcfFavorite> GetFavourites()
        {
            List<List<string>> allData = GetAllRows("Zestawy");

            var groups = allData.GroupBy(x => x[0]).Select(x => x.Key).ToList();

            List<WcfFavorite> allFavourite = new List<WcfFavorite>();
            for (int i = 0; i < groups.Count; i++)
            {
                List<WcfFavoriteComponent> favCompList = new List<WcfFavoriteComponent>();
                for (int j = 0; j < allData.Count; j++)
                {
                    if (allData[j][0] == groups[i])
                    {
                        favCompList.Add(new WcfFavoriteComponent()
                        {
                            Meal = new WcfMeal() { MealName = allData[j][1] },
                            Quantity = Convert.ToSingle(allData[j][2])
                        });
                    }
                }
                allFavourite.Add(new WcfFavorite()
                {
                    FavoriteName = groups[i],
                    FavoriteCompontents = favCompList.ToArray()
                });

            }
            return allFavourite;
        }

        /// <summary>
        /// Funkcja pobierająca wszystkie rekordy z pliku excell
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<List<string>> GetAllRows(string table)
        {
            Con.Open();
            string query = "Select * from [" + table + "$]";
            OleDbCommand cmd = new OleDbCommand(query, Con);
            OleDbDataReader rd = cmd.ExecuteReader();

            List<List<string>> allRows = new List<List<string>>();

            while (rd.Read())
            {
                List<string> row = new List<string>();
                for (int i = 0; i < rd.FieldCount; i++)
                    row.Add(rd[i].ToString());

                allRows.Add(row);
            }

            rd.Close();
            Con.Close();

            return allRows;
        }

    }
}
