using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public string FavoriteName { get; set; }

        public int LoginId { get; set; }
        public virtual Login Login { get; set; }

        public virtual List<FavoriteComponent> FavoriteCompontents { get; set; }

        public Favorite()
        {
            FavoriteCompontents = new List<FavoriteComponent>();
        }
        public Favorite(WcfFavorite favorite, WcfLogin login)
        {
            this.FavoriteName = favorite.FavoriteName;
            this.LoginId = DietCalendar.GetLoginId(new Login(login));
        }
    }
}
