﻿

using System.Collections.Generic;

namespace FirstWorkshop.Server.Http
{
   public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
            => this.headers = new Dictionary<string, HttpHeader>();

        public void Add(HttpHeader header)
            => this.headers.Add(header.Key, header);

        public int Count => headers.Count;
        
        
    }
}
