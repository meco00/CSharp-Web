using MyWebServer.App;
using MyWebServer.App.Controllers;
using MyWebServer.Results;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MyWebServer.Controllers;

namespace MyWebServer.App
{
   public class StartUp
    {
        //localhost 127.01.01
        public static async Task Main(string[] args)
        => await new HttpServer(9090,
            routes => routes
                    .MapGet<HomeController>("/", c=>c.Index())
                     .MapGet<HomeController>("/Softuni",c=>c.ToSoftUni())
                     .MapGet<HomeController>("/ToYoutube",c=>c.ToYoutube())
                     .MapGet<HomeController>("/ToCats",c=>c.LocalRedirect())
                     .MapGet<HomeController>("/Error",c=>c.Error())
                      .MapGet<AnimalsController>("/Cats", c=>c.Cats())
                      .MapGet<AnimalsController>("/Dogs",c=>c.Dogs())
                      .MapGet<AnimalsController>("/Turtles",c=>c.Turtles())
                      .MapGet<AnimalsController>("/Bunnies",c=>c.Bunnies())
                    .MapGet<AccountController>("/Cookies",c=>c.CookiesCheck())
                    .MapGet<AccountController>("/Sessions",c=>c.SessionCheck())
                    .MapGet<AccountController>("/LogIn",c=>c.LogIn())
                    .MapGet<AccountController>("/LogOut",c=>c.LogOut())
                    .MapGet<AccountController>("/Authorized",c=>c.AuthenticationCheck())

                      .MapPost<CatsController>("/Cats/Save", c=>c.Save())
                      .MapGet<CatsController>("/Cats/Create",c=>c.CreateCat()))
              .Start();


    }
}
