

using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebDemo.Controllers
{
    public class CatsController:Controller
    {
        public IActionResult List()
        {
            var requestCookies = this.Request.Cookies;

            if (!requestCookies.ContainsKey("Authentication"))
            {
                return Unauthorized();
            }

            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
