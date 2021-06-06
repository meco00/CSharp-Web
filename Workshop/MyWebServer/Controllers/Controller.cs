using MyWebServer.Http;
using MyWebServer.Responses;
using System;


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
    }
}
