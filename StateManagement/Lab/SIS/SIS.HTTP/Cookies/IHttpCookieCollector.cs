using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Cookies
{
   public interface IHttpCookieCollector:IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie cookie);


        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();


    }
}
