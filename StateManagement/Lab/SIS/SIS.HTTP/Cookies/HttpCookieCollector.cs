using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollector : IHttpCookieCollector
    {

        private List<HttpCookie> httpCookies = new List<HttpCookie>();


        public void AddCookie(HttpCookie cookie)
        {
            httpCookies.Add(cookie);
        }

        public bool ContainsCookie(string key)
        {
            return httpCookies.Any(x => x.Key == key);
        }

        public HttpCookie GetCookie(string key)
        {
            return httpCookies.FirstOrDefault(x => x.Key == key);
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return httpCookies.GetEnumerator();
        }

        public bool HasCookies()
        {
            return httpCookies.Any();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join('/', this.httpCookies.Select(x => x.Value));
        }
    }
}
