
using MyWebServer.App.Models.Animals;
using MyWebServer.Http;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.App.Controllers
{
   public class AnimalsController:Controller
    {
      

        public AnimalsController(HttpRequest request):base(request)
        {
           

        }

        public ActionResult Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";
            var query = this.Request.Query;

            var catName = 
                query.Contains(nameKey) ? query[nameKey] : "Cat";

            var catAge = query.Contains(ageKey) ? int.Parse(query[ageKey]) : 0;


            var catVM = new CatViewModel()
            {
                Name = catName,
                Age = catAge
            };


            return View(catVM,"Animals/Wild/Cats");

            
        }
      
        public ActionResult Dogs()
            =>  View(new DogViewModel 
            { 
                Name="Bobi",
                Age=3,
                Bread="German shapered"
            });
        
        public ActionResult Bunnies()
            =>  View("Rabbit");

        public ActionResult Turtles()
           => View("Animals/Wild/Turtles");
    }
}
