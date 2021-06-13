

using MyWebServer.Common;

namespace MyWebServer.Http
{
   public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string Server = "Server";
        public const string Date = "Date";
        public const string Location = "Location";

        public HttpHeader(string name,string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            Name = name;
            Value = value;

        }
        public string Name { get; init; }

        public string Value { get;init; }

        public override string ToString()
        => $"{this.Name}: {this.Value}";
    }
}
