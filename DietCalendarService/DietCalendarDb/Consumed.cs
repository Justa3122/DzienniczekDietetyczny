using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class Consumed
    {
        public int ConsumedId { get; set; }
        public DateTime ConsumeTime { get; set; }

        public int FavoriteId { get; set; }
        public virtual Favorite Favorite { get; set; }

        public Consumed()
        {

        }
        public Consumed(WcfConsumed consumed,WcfLogin login)
        {
            this.ConsumedId = 0;
            this.Favorite = null;
            this.ConsumeTime = consumed.ConsumeTime;
            this.FavoriteId = DietCalendar.GetFavoriteId(DietCalendar.GetLoginId(new Login(login)), consumed.Favorite.FavoriteName);
        }
    }
}
