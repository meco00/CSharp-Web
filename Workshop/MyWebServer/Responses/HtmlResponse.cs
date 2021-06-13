using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text) :
            base(text, HttpContentType.Html)
        {
        }
    }
}
