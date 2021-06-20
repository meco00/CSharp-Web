using CarShop.Data;
using CarShop.Models;
using CarShop.Services;
using CarShop.ViewModel;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
   public class CarsController:Controller
    {
        private readonly IValidatorService validatorService;
        private readonly ApplicationDbContext context;
        private readonly IUserService userService;

       

        public CarsController(ApplicationDbContext context, IValidatorService service,IUserService userService)
        {
            this.context = context;
            this.validatorService = service;
            this.userService = userService;
        }

        [Authorize]
        public ActionResult Add()
        {   
            bool isMechanic=context.Users.First(x=>x.Id==this.User.Id).IsMechanic;



            if (this.userService.IsMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(CarAddViewModel car)
        {

            var list = validatorService.ValidateCarAddAction(car);

            if (list.Count > 0)
            {
                return Error(list);
            }

            bool containsSamePlateNumber = context.Cars.Any(x => x.PlateNumber == car.PlateNumber);

            if (containsSamePlateNumber)
            {
                list.Add("Car with this plate number already exists");
                return Error(list);
            }

            var carToImport = new Car()
            {
                Model = car.Model,
                Year = car.Year,
                PictureUrl = car.Image,
                PlateNumber = car.PlateNumber,
                OwnerId = this.User.Id
            };


            context.Cars.Add(carToImport);
            context.SaveChanges();


            return Redirect("/Cars/All");

        }

        [Authorize]
        public ActionResult All()
        {
            var carsQuery = this.context.Cars.AsQueryable();

            if (this.userService.IsMechanic(this.User.Id))
            {
                carsQuery = carsQuery.Where(c => c.Issues.Any(i => !i.IsFixed));
            }
            else
            {
                carsQuery = carsQuery.Where(c => c.OwnerId == this.User.Id);
            }


          
            var cars = carsQuery.Select(x => new CarsAllViewModel()
            {
                Id = x.Id,
                ImageUrl = x.PictureUrl,
                PlateNumber = x.PlateNumber,
                RemainingIssues = x.Issues.Where(x => !(x.IsFixed)).Count(),
                FixedIssues= x.Issues.Where(x => x.IsFixed).Count()
            }).ToList();



            return this.View(cars);
        }
    }
}
