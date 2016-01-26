using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCalendarServiceLibrary.DietCalendarDb
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual List<Favorite> Favorites { get; set; }
        
        public Login()
        {
        }
        public Login(WcfLogin login)
        {
            this.LoginId = 0;
            this.Name = login.Name;
            this.Password = login.Password;
        }
    }
}
