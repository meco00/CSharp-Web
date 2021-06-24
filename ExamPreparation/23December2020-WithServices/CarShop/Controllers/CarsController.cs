using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Linq;

namespace CarShop.Controllers
{
   public class CarsController:Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly IUsersService usersService;
        private readonly ICarsService carsService;

        public CarsController(ApplicationDbContext dbContext, IValidator validator,IUsersService usersService,ICarsService carsService)
        {
            this.data = dbContext;
            this.validator = validator;
            this.usersService = usersService;
            this.carsService = carsService;
        }

        [Authorize]
        public ActionResult All()
        {
            var cars = data.Cars.AsQueryable();

            if (!IsUserMechanic())
            {
                cars = cars.Where(x => x.OwnerId==this.User.Id);
            }
            else
            {
                cars = cars.Where(x => x.Issues.Any(i => !i.IsFixed));
            }

            var carsDto = cars
                
                .Select(x => new CarAllViewModel
                {
                    Id = x.Id,
                    Model=x.Model,
                    Year=x.Year,
                    ImageUrl=x.PictureUrl,
                    PlateNumber=x.PlateNumber,
                    RemainingIssues=x.Issues.Where(x=>!x.IsFixed).Count(),
                    FixedIssue=x.Issues.Where(x=>x.IsFixed).Count()
                   
                })
                .ToList();

            return this.View(carsDto);
        }

        [Authorize]
        public ActionResult Add()
        {
            if (IsUserMechanic())
            {
                return Redirect("/Cars/All");
            }

           return this.View();

        }


        [HttpPost]
        [Authorize]
        public ActionResult Add(CarAddViewModel model)
        {
            if (IsUserMechanic())
            {
                return Redirect("/Cars/All");
            }

            var errors = this.validator.ValidateCars(model);

            if (errors.Count >0)
            {
                return Error(errors);
            }

            this.carsService
                .CreateCar(model.Model, model.Year, model.Image, model.PlateNumber, this.User.Id);

            return Redirect("/Cars/All");



        }

        private bool IsUserMechanic()
            => this.usersService.IsUserMechanic(this.User.Id);

    }
}
