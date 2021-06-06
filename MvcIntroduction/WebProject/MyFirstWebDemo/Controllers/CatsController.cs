

using Microsoft.AspNetCore.Mvc;
using MyFirstWebDemo.Data;
using MyFirstWebDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebDemo.Controllers
{
    public class CatsController:Controller
    {
        private readonly DbContext data;

        public CatsController()
       => this.data = new DbContext();

        public IActionResult List()
        {
            var cats = data.GetCats()
                .Select(c=> new CatViewModel { Name=c.Name,Age=c.Age,Owner=c.Owner.Name} )
                .ToList();

            if (!cats.Any())
            {
                return NotFound();
            }

            return this.View(cats);
        }

     

        public IActionResult Search()
        {
            return View();
        }
    }
}
