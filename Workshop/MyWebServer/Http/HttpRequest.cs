namespace MyWebServer.Http
{
    using MyWebServer.Http.Collections;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HttpRequest
    {


        private static Dictionary<string, HttpSession> Sessions 
            = new Dictionary<string, HttpSession>();


        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public QueryCollection Query { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public FormCollection Form { get; private set; }

        public string Body { get; private set; }

        public HttpSession Session { get; private set; }


        public static HttpRequest Parse(string request)
        {
          var lines = request.Split(NewLine);

          var startLine = lines.First().Split(" ");

          var method = ParseMethod(startLine[0]);
          var url = startLine[1];

          var (path, query) = ParseUrl(url);

          var headers = ParseHeaders(lines.Skip(1));

          var cookies = ParseCookies(headers);

          var session = GetSession(cookies);

          var bodyLines = lines.Skip(headers.Count + 2).ToArray();

          var body = string.Join(NewLine, bodyLines);

          var form = ParseForm(headers, body);

          return new HttpRequest
          {
              Method = method,
              Path = path,
              Query = query,
              Headers = headers,
              Cookies = cookies,
              Session = session,
              Body = body,
              Form = form
          };
         
         
        }


        private static HttpMethod ParseMethod(string method)
            => method.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,
                "PUT" => HttpMethod.Put,
                "DELETE" => HttpMethod.Delete,
                _ => throw new InvalidOperationException($"Method {method} is not supported")
            };

        private static (string, QueryCollection) ParseUrl(string url)
        {
            var query = new QueryCollection();

            var urlParts = url.Split('?', 2);

            var path = urlParts[0];

            if (urlParts.Length>1)
            {
                ParseQuery(urlParts[1])
                    .ToList()
                    .ForEach(part => query.Add(part.Key, part.Value));

            }

            

            return (path, query);
        }

        private static Dictionary<string,string> ParseQuery(string queryString)
            => queryString
                .Split('&')
                .Select(part => part.Split('='))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], part => part[1]);

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }

        private static HttpSession GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(HttpSession.SessionCookieName)
                ? cookies[HttpSession.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {

                Sessions[sessionId] = new HttpSession(sessionId);
               
            }

            return Sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookieCollection = new CookieCollection();

            if (headers.Contains(HttpHeader.Cookie))
            {
                var cookieHeader = headers[HttpHeader.Cookie];

                var allCookies = cookieHeader.Split(';');

                foreach (var cookieText in allCookies)
                {
                    var cookieParts = cookieText.Split('=');

                    var cookieName = cookieParts[0].Trim();
                    var cookieValue = cookieParts[1].Trim();

                    cookieCollection.Add(cookieName, cookieValue);
                }



            }

            return cookieCollection;
        }

        private static FormCollection ParseForm(HeaderCollection headers, string body)
        {
            var result = new FormCollection();

            if (headers.Contains(HttpHeader.ContentType)
                &&headers[HttpHeader.ContentType] == HttpContentType.UrlEncoded)
            {
                ParseQuery(body)
                    .ToList()
                    .ForEach(x=> result.Add(x.Key,x.Value));
            }

            return result;
        }

       
    }
}