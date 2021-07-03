using Microsoft.AspNetCore.Mvc;
using RazorViews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorViews.Controllers
{
    public class CatsController:Controller
    {
        public IActionResult All()
        {
            var cats = new List<CatViewModel>()
            {
               new CatViewModel(){ Name="Sharo" ,Age=15 } ,
               new CatViewModel(){ Name="Moro" ,Age=15 } ,
               new CatViewModel(){ Name="Boro" ,Age=15 } ,
             
            };

            ViewData["Cats"] = cats;

            ViewBag.Bag = cats;

            ViewBag.AdvancedLayout = true;

           return View(cats);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CatViewModel model) => Ok(model);

        public IActionResult Test1()
        {
            var cats = new List<CatViewModel>()
            {
               new CatViewModel(){ Name="Sharo" ,Age=15 } ,
               new CatViewModel(){ Name="Moro" ,Age=15 } ,
               new CatViewModel(){ Name="Boro" ,Age=15 } ,

            };

           return View(cats);
        }
       
    }
}
