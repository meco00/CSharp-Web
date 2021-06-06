
using MyWebServer.Http;
using MyWebServer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.App.Controllers
{
   public class AnimalsController:Controller
    {
      

        public AnimalsController(HttpRequest request):base(request)
        {
           

        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "Cats";

            var result = $"<h1>Hello from {catName}</h1>";



            return new HtmlResponse(result);

            
        }

        public HttpResponse Dogs()
            => new HtmlResponse("<h1>Hello from Dogs!</h1>");
    }
}
