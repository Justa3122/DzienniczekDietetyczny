using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class Meal
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public float Calories { get; set;}
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float CarboHydrates { get; set; }

        public Meal()
        {

        }
        public Meal(WcfMeal meal)
        {
            this.MealId = DietCalendar.GetMealId(meal.MealName);
            this.MealName = meal.MealName;
            this.Calories = meal.Calories;
            this.Protein = meal.Protein;
            this.Fat = meal.Fat;
            this.CarboHydrates = meal.CarboHydrates;
        }
    }
}
