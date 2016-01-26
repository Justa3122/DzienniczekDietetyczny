using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class DietCalendar
    {
        public static DietCalendarContext dcc = new DietCalendarContext(false);
        public static bool AddMeal(Meal meal)
        {
            var query = from dbmeal in dcc.Meals where dbmeal.MealName == meal.MealName select dbmeal.MealId;
            if (query.Count() == 0)
            {
                try
                {
                    dcc.Meals.Add(meal);
                    dcc.SaveChanges();
                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }
        public static bool AddLogin(Login login)
        {
            lock (dcc)
            {
                var query = from dblogin in dcc.Logins where login.Name == dblogin.Name select login.LoginId;
                if (query.Count() == 0)
                {
                    try
                    {
                        dcc.Logins.Add(login);
                        dcc.SaveChanges();
                        return true;
                    }
                    catch (Exception) { }
                }
                return false; 
            }
        }
        public static bool AddFavorite(Favorite favorite)
        {
            lock (dcc)
            {
                if (!FavoriteExist(favorite))
                {
                    try
                    {
                        dcc.Favorites.Add(favorite);
                        dcc.SaveChanges();
                        return true;
                    }
                    catch (Exception) { }
                }
                return false; 
            }
        }
        public static bool AddFavoriteComponent(FavoriteComponent favoriteComponent)
        {
            lock (dcc)
            {
                try
                {
                    dcc.FavoriteCompontents.Add(favoriteComponent);
                    dcc.SaveChanges();
                    return true;
                }
                catch (Exception) { }
                return false; 
            }
        }
        public static bool AddConsumed(Consumed consumed)
        {
            lock (dcc)
            {
                try
                {
                    dcc.Consumeds.Add(consumed);
                    dcc.SaveChanges();
                    return true;
                }
                catch (Exception) { }
                return false; 
            }
        }
        public static List<Favorite> DownloadFavorites(Login login)
        {
            List<Favorite> favList = (from log1 in dcc.Logins where log1.Name == login.Name && log1.Password == login.Password select log1.Favorites).First();
            foreach (var favItem in favList)
            {
                favItem.FavoriteCompontents = new List<FavoriteComponent>();
                foreach (var CompItem in DownloadFavoriteComponents(favItem))
                {
                    CompItem.Meal = DownloadMeal(CompItem);
                    favItem.FavoriteCompontents.Add(CompItem);
                }
            }
            return favList;
        }
        public static List<Consumed> DownloadConsumed(Login login)
        {
            List<Consumed> consumedList = new List<Consumed>();
            foreach (var consumed in dcc.Consumeds)
            {
                if (GetFavorite(consumed).LoginId == GetLoginId(login))
                {
                    consumed.Favorite.FavoriteCompontents = DownloadFavoriteComponents(consumed.Favorite);
                    foreach (var component in consumed.Favorite.FavoriteCompontents)
                    {
                        component.Meal = DownloadMeal(component);
                    }
                    consumedList.Add(consumed);
                }
            }

            return consumedList;
        }
        public static bool Login(Login login)
        {
            lock (dcc)
            {
                var query = from log1 in dcc.Logins where login.Name == log1.Name && log1.Password == login.Password select login.LoginId;
                if (query.Count() == 1)
                {
                    return true;
                }
                return false; 
            }
        }

        private static List<FavoriteComponent> DownloadFavoriteComponents(Favorite favorite)
        {
            return (from component in dcc.FavoriteCompontents where component.FavoriteId == favorite.FavoriteId select component).ToList();
        }
        private static Meal DownloadMeal(FavoriteComponent favoriteComponent)
        {
            return (from meal in dcc.Meals where meal.MealId == favoriteComponent.MealId select meal).First();
        }
        public static List<Meal> DownloadAllMeals()
        {
            return (from meal in dcc.Meals select meal).ToList();
        }
        private static Favorite GetFavorite(Consumed consumed)
        {
            return (from favorite in dcc.Favorites where favorite.FavoriteId == consumed.FavoriteId select favorite).First();
        }
        public static int GetLoginId(Login login)
        {
            return (from log1 in dcc.Logins where log1.Name == login.Name && log1.Password == login.Password select log1.LoginId).First();
        }
        public static int GetMealId(string mealName)
        {
            return (from meal1 in dcc.Meals where meal1.MealName == mealName select meal1.MealId).First();
        }
        public static int GetFavoriteId(int LoginId, string FavoriteName)
        { 
            return (from favorite in dcc.Favorites 
                    where favorite.LoginId == LoginId && favorite.FavoriteName == FavoriteName 
                    select favorite.FavoriteId).First();
        }
        public static bool FavoriteExist(Favorite favorite)
        {
            var query = from favorite1 in dcc.Favorites where favorite1.LoginId == favorite.LoginId & favorite1.FavoriteName == favorite.FavoriteName select favorite.FavoriteId;
            if (query.Count() > 0)
            {
                return true;
            }
            return false;
        }
   }
}
