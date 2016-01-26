using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class DietCalendarContext : DbContext
    {
        public DietCalendarContext(bool error) : base("DieCal2")
        {
            if (error)
            {
                Database.SetInitializer<DietCalendarContext>(new DropCreateDatabaseAlways<DietCalendarContext>());
            }
            //Database.SetInitializer<DietCalendarContext>(new CreateDatabaseIfNotExists<DietCalendarContext>());
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<FavoriteComponent> FavoriteCompontents { get; set; }
        public DbSet<Consumed> Consumeds { get; set; }
    }
}
