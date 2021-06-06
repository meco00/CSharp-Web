﻿

using System.Collections;
using System.Collections.Generic;

namespace MyWebServer.Http
{
   public class HttpHeaderCollection:IEnumerable<HttpHeader>
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
            => this.headers = new Dictionary<string, HttpHeader>();

        public void Add(string name, string value)
        {
            var header = new HttpHeader(name, value);

            this.headers.Add(name, header);
        }

        public IEnumerator<HttpHeader> GetEnumerator()
        => this.headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
        

        public int Count => headers.Count;
        
        
    }
}
