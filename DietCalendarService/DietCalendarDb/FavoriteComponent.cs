using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class FavoriteComponent
    {
        public int FavoriteComponentId { get; set; }
        public int FavoriteId { get; set; }
        public int MealId { get; set; }
        public float Quantity { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Favorite Favorite { get; set; }

        public FavoriteComponent()
        {

        }
        public FavoriteComponent(WcfFavoriteComponent component,int FavoriteId)
        {
            this.FavoriteComponentId = 0;
            this.FavoriteId = FavoriteId;
            this.MealId = DietCalendar.GetMealId(component.Meal.MealName);
            this.Quantity = component.Quantity;
        }
    }
}
