using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse() : base(HttpStatusCode.NotFound)
        {

        }
    }
}
