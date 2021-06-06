using MyWebServer.Http;
using MyWebServer.Responses;
using System;


namespace MyWebServer.App.Controllers
{
    public class HomeController:Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }

        public HttpResponse Index()
        => Text("Hello from Meco!");


        public HttpResponse ToSoftUni()
            => Redirect("https://softuni.bg/");

        public HttpResponse LocalRedirect()
           => Redirect("/Cats");


        public HttpResponse ToYoutube()
     => Redirect("https://www.youtube.com/");
    }
}
