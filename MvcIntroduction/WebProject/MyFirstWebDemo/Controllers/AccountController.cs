using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebDemo.Controllers
{
    public class AccountController:Controller
    {
        public IActionResult Login()
        {

            this.Response.Cookies.Append("Authentication", "Ivaylo");


            return this.View();
        }
    }
}
