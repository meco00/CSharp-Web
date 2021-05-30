

using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWorkshop.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string URL { get; private set; }

        public HttpHeaderCollection Headers { get; private set; } = new();

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(NewLine);

            var startLine = lines[0].Split(" ");

            var method = ParseHttpMethod(startLine[0]);

            var url = startLine[1];

            var headers = ParseHttpHeaders(lines.Skip(1).ToArray());

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(NewLine,
                bodyLines);

            return new HttpRequest()
            {
                Method = method,
                URL = url,
                Headers = headers,
                Body = body,

            };

        }

        private static HttpMethod ParseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET"=>HttpMethod.GET,
                "POST"=>HttpMethod.POST,
                "PUT"=>HttpMethod.PUT,
                "DELETE"=>HttpMethod.DELETE,
                _=>throw new InvalidOperationException($"Method {method} is not implemented ")


            };
        }

        private static HttpHeaderCollection ParseHttpHeaders(string[] lines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in lines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":",2);

                if (headerParts.Length!=2)
                {
                    throw new InvalidOperationException("Request is not valid");

                }

                var header = new HttpHeader
                {
                    Key = headerParts[0],
                    Value = headerParts[1].Trim()
                };

                headerCollection.Add(header);

            }

            return headerCollection;



        }

        

    }
}
