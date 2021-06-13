using MyWebServer.Http;
using MyWebServer.Responses;
using System;
using System.Runtime.CompilerServices;

namespace MyWebServer
{
   public abstract class Controller
    {

        public Controller(HttpRequest request)
        => this.Request = request;

        protected HttpRequest Request { get; private set; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string text)
         => new HtmlResponse(text);

        protected HttpResponse Redirect(string location)
            => new RedirectResponse(location);

        protected HttpResponse View([CallerMemberName] string viewName = "")
            => View(viewName, (object)null);

        protected HttpResponse View( string viewName ,object model)
           => new ViewResponse(viewName, GetControllerName(),model);

        protected HttpResponse View(object model,[CallerMemberName] string viewName = "")
           => new ViewResponse(viewName, GetControllerName(),model);

        private string GetControllerName()
        => this.GetType().Name.Replace(nameof(Controller), string.Empty);

    }
}
