using MyWebServer.Controllers;
using MyWebServer.Http;
using MyWebServer.Identity;
using MyWebServer.Results;
using System;
using System.Runtime.CompilerServices;

namespace MyWebServer
{
   public abstract class Controller
    {
        private const string UserSessionKey = "AuthenticatedUserId";


        public Controller(HttpRequest request)
        {
            this.Request = request;

            this.User = this.Request.Session.ContainsKey(UserSessionKey)
                ? new UserIdentity() { Id = this.Request.Session[UserSessionKey] } 
                : new();



        }
            
        

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Response { get; private init; } = new HttpResponse(HttpStatusCode.Ok);

        protected UserIdentity User { get; private set; } 

        protected void SignIn(string userId)
        {
            this.Request.Session[UserSessionKey] = userId;

            this.User = new UserIdentity() { Id = userId };

        }

        protected void SignOut()
        {
            this.Request.Session.Remove(UserSessionKey);
            this.User = new();
        }

        protected ActionResult Text(string text)
            => new TextResult(this.Response,text);

        protected ActionResult Html(string text)
         => new HtmlResult(this.Response,text);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response,location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => View(viewName, (object)null);

        protected ActionResult View( string viewName ,object model)
           => new ViewResult(this.Response,viewName, this.GetType().GetControllerName(),model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
           => View(viewName, model);

       

    }
}
