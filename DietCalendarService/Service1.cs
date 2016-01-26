using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DietCalendarServiceLibrary.DietCalendarDb;

namespace DietCalendarServiceLibrary
{
    /// <summary>
    /// Klasa implementuje metody korzystające z kolejki MSMQ
    /// </summary>
    public class Service1 : IDietCalendarService
    {
        /// <summary>
        /// Tworzy konto użytkownika
        /// </summary>
        /// <param name="login">Dane logowania</param>
        public void Register(WcfLogin login)
        {
            bool b = DietCalendar.AddLogin(new Login(login));
        }
    }

    /// <summary>
    /// Klasa implementuje metody nie korzystające z kolejki MSMQ
    /// </summary>
    public class Service2 : IDietCalendarService2
    {
        /// <summary>
        /// Sprawdza czy użytkownik wprowadził poprawne dane
        /// </summary>
        /// <param name="login">Dane logowania</param>
        /// <returns>True jeśli istnieje taki login i hasło</returns>
        public bool Login(WcfLogin login)
        {
            return DietCalendar.Login(new Login(login));
        }
        /// <summary>
        /// Dodaje zestaw i przypisuje go do użytkownika
        /// </summary>
        /// <param name="login">Dane logowania</param>
        /// <param name="favorite">Obiekt zawierający dane o zestawie</param>
        /// <returns>True jeśli zestaw został dodany pomyślnie</returns>
        public bool AddFavorite(WcfLogin login, WcfFavorite favorite)
        {
            if (DietCalendar.Login(new Login(login)))
            {
                DietCalendar.AddFavorite(new Favorite(favorite, login));
                int favId = DietCalendar.GetFavoriteId(DietCalendar.GetLoginId(new Login(login)), favorite.FavoriteName);
                foreach (var favComp in favorite.FavoriteCompontents)
                {
                    DietCalendar.AddFavoriteComponent(new FavoriteComponent(favComp, favId));
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Dodaje informacje że użytkownik spożył jeden z zestawów
        /// </summary>
        /// <param name="login">Dane Logowania</param>
        /// <param name="consumed">Obiekt zawierający date konsumpcji oraz informacje o zestawie</param>
        /// <returns>True jeśli prawidłowo dodano rekord konsumpcji</returns>
        public bool AddConsumed(WcfLogin login, WcfConsumed consumed)
        {
            if (DietCalendar.Login(new Login(login)))
            {
                DietCalendar.AddConsumed(new Consumed(consumed, login));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Pobiera wszystkie zestawy użytkownika
        /// </summary>
        /// <param name="login">Dane logowania</param>
        /// <returns>Listę zestawów</returns>
        public List<WcfFavorite> DownloadFavorites(WcfLogin login)
        {
            List<WcfFavorite> favList = new List<WcfFavorite>();
            foreach (var favorite in DietCalendar.DownloadFavorites(new Login(login)))
	        {
		        favList.Add(new WcfFavorite(favorite));
	        }
            return favList;
        }
        /// <summary>
        /// Pobiera dane konsumpcji zestawów przez użytkownika w okresie: od podanej daty do teraz,
        /// </summary>
        /// <param name="login">Dane logowania</param>
        /// <param name="time">Data od której mają zostać pobrane dane</param>
        /// <returns>Liste danych o konsumpcji</returns>
        public List<WcfConsumed> DownloadConsumed(WcfLogin login)
        {

            List<WcfConsumed> consList = new List<WcfConsumed>();
            foreach (var consumed in DietCalendar.DownloadConsumed(new Login(login)))
                consList.Add(new WcfConsumed(consumed));
            
            return consList;
        }
        /// <summary>
        /// Pobiera wszystkie składniki z bazy, z których są składane zestawy
        /// </summary>
        /// <returns>Lista składników</returns>
        public List<WcfMeal> DownloadAllMeals(string phrase)
        {
            List<WcfMeal> mealsList = new List<WcfMeal>();
            foreach (var meal in DietCalendar.DownloadAllMeals())
            {
                if (meal.MealName.ToLower().Contains(phrase.ToLower()))
                {
                    mealsList.Add(new WcfMeal(meal)); 
                }
            }
            return mealsList;
        }
    }

}