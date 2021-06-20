using MyWebServer.Http;
using MyWebServer.Results;
using System;


namespace MyWebServer.App.Controllers
{
    public class HomeController:Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public ActionResult Index()
        => Text("Hello from Meco!");


        public ActionResult ToSoftUni()
            => Redirect("https://softuni.bg/");

        public ActionResult LocalRedirect()
           => Redirect("/Cats");


        public ActionResult ToYoutube()
     => Redirect("https://www.youtube.com/");

        public HttpResponse Error()
            => throw new InvalidOperationException();

        public ActionResult StaticFiles()
            => View();
    }
}
