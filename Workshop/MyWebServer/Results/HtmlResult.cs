using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response,string text) :
            base(response,text, HttpContentType.Html)
        {
        }
    }
}
