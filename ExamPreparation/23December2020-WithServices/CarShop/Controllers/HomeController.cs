

using MyWebServer.Controllers;
using MyWebServer.Results;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("Cars/All");
            }
            return this.View();
        }
    }
}
