using MyWebServer.Controllers;

using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
  

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Repositories/All");
            }

            return this.View();
        }
    }
}
