using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebDemo.Controllers
{
    public class DateTimeController:Controller
    {
        public IActionResult Now()
        {
            var storedData = this.HttpContext.Session.GetString("CurrentDate");

            if (storedData==null)
            {
                storedData=DateTime.Now.ToString();

                this.HttpContext.Session.SetString("CurrentDate", storedData);

            }

            return Ok(storedData);
        }
    }
}
