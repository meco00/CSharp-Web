using MyWebServer.Http;
using System.Collections.Generic;

namespace MyWebServer.Results
{
    public class ActionResult : HttpResponse
    {

        public ActionResult(      
            HttpResponse response) 
            : base(response.StatusCode)
        {
            
            this.PrepareHeaders(response.Headers);

            this.PrepareCookies(response.Cookies);
        }

        

        private void PrepareHeaders(IDictionary<string,HttpHeader> headers)
        {
            foreach (var (_,header) in headers)
            {
                this.AddHeader(header.Name, header.Value);


            }
        }

        private void PrepareCookies(IDictionary<string, HttpCookie> cookies)
        {
            foreach (var (_,cookie) in cookies)
            {
                this.AddCookie(cookie.Name, cookie.Value);
            }
        }
    }
}
