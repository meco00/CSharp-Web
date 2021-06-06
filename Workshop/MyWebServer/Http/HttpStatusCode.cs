using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Http
{
   public enum HttpStatusCode
    {
        Ok=200,
        Found=302,
        BadRequest=400,
        NotFound=404
    }
}
