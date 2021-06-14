using MyWebServer.Http;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.App.Controllers
{
   public class CatsController : Controller
    {
        public CatsController(HttpRequest request) : 
            base(request)
        {
        }

        public ActionResult CreateCat()
            => View();

        public ActionResult Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }

    }
}
