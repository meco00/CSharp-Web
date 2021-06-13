using MyWebServer.Http;
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

        public HttpResponse CreateCat()
            => View();

        public HttpResponse Save()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            return Text($"{name} - {age}");
        }

    }
}
