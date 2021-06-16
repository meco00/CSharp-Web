﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Http.Collections
{
    public class QueryCollection : IEnumerable<string>
    {
        private readonly Dictionary<string, string> query;

        public QueryCollection()
        => this.query = new(StringComparer.InvariantCultureIgnoreCase);

        public int Count => this.query.Count;

        public string this[string name]
         => this.query[name];

        public void Add(string name, string value)
            => this.query[name] = value;

        public bool Contains(string name)
            => this.query.ContainsKey(name);


        public IEnumerator<string> GetEnumerator()
        => this.query.Values.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator()
       => this.GetEnumerator();
    }
}
