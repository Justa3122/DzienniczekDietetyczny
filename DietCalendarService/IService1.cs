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
    /// Interfejs zawiera wszystkie metody serwisu które korzystają z kolejki MSMQ
    /// </summary>
    [ServiceContract]
    public interface IDietCalendarService
    {
        [OperationContract(IsOneWay = true)]
        void Register(WcfLogin login);
    }

    /// <summary>
    /// Interfejs zawiera wszystkie metody serwisu nie korzystające z kolejki MSMQ,
    /// to znaczy że oczekują one za każdym razem na odpowiedź z serwisu.
    /// </summary>
    [ServiceContract]
    public interface IDietCalendarService2
    {
        [OperationContract]
        bool Login(WcfLogin login);
        [OperationContract]
        bool AddFavorite(WcfLogin login, WcfFavorite favorite);
        [OperationContract]
        bool AddConsumed(WcfLogin login, WcfConsumed consumed);
        [OperationContract]
        List<WcfFavorite> DownloadFavorites(WcfLogin login);
        [OperationContract]
        List<WcfConsumed> DownloadConsumed(WcfLogin login);
        [OperationContract]
        List<WcfMeal> DownloadAllMeals(string phrase);
    }

    [DataContract]
    public class WcfLogin
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }

        public WcfLogin(Login login)
        {
            this.Name = login.Name;
            this.Password = login.Password;
        }
    }

    [DataContract]
    public class WcfMeal
    {
        [DataMember]
        public string MealName { get; set; }
        [DataMember]
        public float Calories { get; set; }
        [DataMember]
        public float Protein { get; set; }
        [DataMember]
        public float Fat { get; set; }
        [DataMember]
        public float CarboHydrates { get; set; }

        public WcfMeal(Meal meal)
        {
            this.MealName = meal.MealName;
            this.Calories = meal.Calories;
            this.Protein = meal.Protein;
            this.Fat = meal.Fat;
            this.CarboHydrates = meal.CarboHydrates;
        }
    }

    [DataContract]
    public class WcfFavorite
    {
        [DataMember]
        public string FavoriteName { get; set; }
        [DataMember]
        public List<WcfFavoriteComponent> FavoriteCompontents { get; set; }

        public WcfFavorite(Favorite favorite)
        {
            this.FavoriteName = favorite.FavoriteName;
            FavoriteCompontents = new List<WcfFavoriteComponent>();
            foreach (var favcomp in favorite.FavoriteCompontents)
            {
                this.FavoriteCompontents.Add(new WcfFavoriteComponent(favcomp));
            }
        }
    }

    [DataContract]
    public class WcfFavoriteComponent
    {
        [DataMember]
        public float Quantity { get; set; }
        [DataMember]
        public WcfMeal Meal { get; set; }

        public WcfFavoriteComponent(FavoriteComponent favoriteComponent)
        {
            this.Quantity = favoriteComponent.Quantity;
            this.Meal = new WcfMeal(favoriteComponent.Meal);
        }
    }

    [DataContract]
    public class WcfConsumed
    {
        [DataMember]
        public DateTime ConsumeTime { get; set; }
        [DataMember]
        public WcfFavorite Favorite { get; set; }

        public WcfConsumed(Consumed consumed)
        {
            this.ConsumeTime = consumed.ConsumeTime;
            this.Favorite = new WcfFavorite(consumed.Favorite);
        }
    }
}
