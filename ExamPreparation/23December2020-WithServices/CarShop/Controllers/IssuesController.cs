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
   public class IssuesController:Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IUsersService usersService;
        private readonly IIssuesService issuesService;
        private readonly IValidator validator;

        public IssuesController(ApplicationDbContext data,IUsersService usersService, IIssuesService issuesService, IValidator validator)
        {
            this.data = data;
            this.usersService = usersService;
            this.issuesService = issuesService;
            this.validator = validator;
        }


        [Authorize]
        public ActionResult Add(string carId)
       => this.View();

        [HttpPost]
        [Authorize]
        public ActionResult Add(IssueAddViewModel model)
        {
            if (this.issuesService.IsIntruder(this.User.Id,model.carId))
            {
                return BadRequest();
            }
            var errors = this.validator.ValidateIssues(model);

            if (errors.Count>0)
            {
                return Error(errors);
            }

            this.issuesService.CreateIssue(model.carId, model.Description);

            return Redirect($"/Issues/CarIssues?carId={model.carId}");
        }

        [Authorize]
        public ActionResult CarIssues(string carId)
        {
            if (this.issuesService.IsIntruder(this.User.Id,carId))
            {
                return BadRequest();

            }
            var carIssues = this.issuesService.GetCarIssues(carId);

            if (carIssues==null)
            {
                return NotFound();
            }
            return View(carIssues);
        }

        [Authorize]
        public ActionResult Fix(string issueId,string CarId)
        {
            if (!this.usersService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }
            this.issuesService.FixIssue(issueId, CarId);

            return Redirect($"/Issues/CarIssues?carId={CarId}");
        }

        [Authorize]
        public ActionResult Delete(string issueId, string CarId)
        {
            if (this.issuesService.IsIntruder(this.User.Id, CarId))
            {
                return Unauthorized();
            }

          this.issuesService.RemoveIssue(issueId,CarId);

            return Redirect($"/Issues/CarIssues?carId={CarId}");
        }

    }
}
