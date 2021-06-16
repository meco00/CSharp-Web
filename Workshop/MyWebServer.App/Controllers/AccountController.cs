using MyWebServer.Http;
using MyWebServer.Results;
using System;

namespace MyWebServer.App.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request) 
            : base(request)
        {

        }

        //public ActionResult Register()
        //{

        //}

        public ActionResult LogIn()
        {
            var someUserId = "MyUserId"; //Should get from db

            this.SignIn(someUserId);



            return Text("User authenticated!");
        }

        public ActionResult LogOut()
        {
            this.SignOut();

           return Text("User signed out!");

        }
             

        public ActionResult AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated User : {this.User.Id}");

            }

            return Text("User is not recognized");
        }

        public ActionResult CookiesCheck()
        {
            const string cookieName= "My-Cookie";

            if (this.Request.Cookies.Contains(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.Cookies.Add("My-Cookie", "My Value");
            this.Response.Cookies.Add("My-Second-Cookie", "My Second Value");

            return Text("Cookies set!");
        }

        public ActionResult SessionCheck()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var currentDate = this.Request.Session[currentDateKey];

                return Text($"Stored date:{currentDate}");

            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return Text($"Current Date stored!");
        }
    }
}
