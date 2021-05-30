

namespace FirstWorkshop.Server.Http
{
  public  class HttpResponse
    {
        public HttpStatusCode httpStatusCode { get; init; }

        public HttpHeaderCollection headerCollection = new();

        public string Content { get; init; }
    }
}
