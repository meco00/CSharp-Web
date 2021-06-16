﻿using System;
using System.Collections;
using System.Collections.Generic;


namespace MyWebServer.Http.Collections
{
   public class FormCollection: IEnumerable<string>
    {
        private readonly Dictionary<string, string> form;

        public FormCollection()
        => this.form = new(StringComparer.InvariantCultureIgnoreCase);

        public string this[string name]
         => this.form[name];

        public int Count => this.form.Count;

        public void Add(string name, string value)
            => this.form[name]= value;

        public bool Contains(string name)
            => this.form.ContainsKey(name);

        public IEnumerator<string> GetEnumerator()
            => this.form.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
         => this.GetEnumerator();
    }
}
