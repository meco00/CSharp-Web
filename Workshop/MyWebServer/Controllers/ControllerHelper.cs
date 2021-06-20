using System;


namespace MyWebServer.Controllers
{
   public static class ControllerHelper
    {
        public static string GetControllerName(this Type type)
            => type.Name
               .Replace(nameof(Controller), string.Empty);
    }
}
