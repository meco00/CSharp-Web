using MyWebServer.Http;
using MyWebServer.Results;
using System;
using System.Runtime.CompilerServices;

namespace MyWebServer
{
   public abstract class Controller
    {

        public Controller(HttpRequest request)
        {

            this.Request = request;
            this.Response = new HttpResponse(HttpStatusCode.Ok);
        }

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Response { get; private init; }

        protected ActionResult Text(string text)
            => new TextResult(this.Response,text);

        protected ActionResult Html(string text)
         => new HtmlResult(this.Response,text);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response,location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => View(viewName, (object)null);

        protected ActionResult View( string viewName ,object model)
           => new ViewResult(this.Response,viewName, GetControllerName(),model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
           => View(viewName, model);

        private string GetControllerName()
        => this.GetType().Name.Replace(nameof(Controller), string.Empty);

    }
}
