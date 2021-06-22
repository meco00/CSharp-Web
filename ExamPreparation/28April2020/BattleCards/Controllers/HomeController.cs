using BattleCards.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using MyWebServer.Results;

namespace BattleCards.Controllers
{

    
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Cards/All");
            }

            return this.View();
        }
      
    }
}