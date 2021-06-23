using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Controllers
{
   public class HomeController:Controller
    {
        public ActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("Products/All");
            }
            return this.View();
        }

    
    }

}
