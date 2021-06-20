using CarShop.Data;
using CarShop.Models;
using CarShop.ViewModel;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Linq;

using static CarShop.Constants.DataConstants;

namespace CarShop.Controllers
{
   public class IssuesController:Controller
    {
        private ApplicationDbContext context;

        public IssuesController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [Authorize]
        public ActionResult CarIssues(string carId)
        {
            ;

            var carWithIssues = context.Cars.Where(x => x.Id == carId).Select(x => new CarWithIssuesViewModel()
            {
                Id=x.Id,
                Model=x.Model,
                Issues=x.Issues.Select(i=> new IssueViewModel()
                {
                    Id = i.Id,
                    
                    Description = i.Description,
                    IsItFixed = i.IsFixed ? "Yes" : "Not yet"

                }).ToList()
                

               
            })
                .FirstOrDefault()
                ;

            if (carWithIssues == null)
            {
                return Error($"Car with ID '{carId}' does not exist.");
            }



            return View(carWithIssues);

        }

        [Authorize]
        public ActionResult Fix(string issueId,string CarId)
        {
            bool isMechanic = context.Users.First(x => x.Id == this.User.Id).IsMechanic;

            if (isMechanic)
            {

            context
                .Issues
                .FirstOrDefault(x => x.Id == issueId && x.CarId == CarId).IsFixed=true;

            
            context.SaveChanges();

            }


            return Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        [Authorize]
        public ActionResult Delete(string issueId, string CarId)
        {
            var issue=
            context
                .Issues
                .FirstOrDefault(x => x.Id == issueId && x.CarId == CarId);

            context.Issues.Remove(issue);

            ;

            context.SaveChanges();

            return Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        [Authorize]
        public ActionResult Add(string CarId)
        {

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(string CarId,string description)
        {
            ;
            if (description.Length < 5)
            {
                return Error("Description Lenght must be greater than 5");
            }

            context.Cars.FirstOrDefault(x => x.Id == CarId).Issues.Add(new Issue
            {
                Description = description,
                IsFixed = false,
                CarId = CarId
            }) ;

            context.SaveChanges();

            return this.CarIssues(CarId);
        }



    }
}
