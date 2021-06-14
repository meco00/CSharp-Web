using MyWebServer.Common;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Results
{
    public class TextResult : ContentResult
    {
        public TextResult(HttpResponse response,string text)
           : base(response,text, HttpContentType.PlainText)
        {

        }
    }
}
