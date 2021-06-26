using MyWebServer.Controllers;
using MyWebServer.Results;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Services;
using SharedTrip.ViewModels;
using System;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserService usersService;

        public UsersController(IValidator validator, ApplicationDbContext data, IPasswordHasher passwordHasher, IUserService usersService)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.usersService = usersService;
        }


        public ActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            bool isUsernameAvailable = this.usersService.IsUsernameAvailable(model.Username);

            if (!isUsernameAvailable)
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            bool isEmailAvailable = this.usersService.IsEmailAvailable(model.Email);

            if (!isEmailAvailable)
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Redirect("/Users/Register");

                //return Error(modelErrors);
            }

           this.usersService
              .Create(model.Username, model.Email, HashPassword(model.Password));

            return Redirect("/Users/Login");
        }

        public ActionResult Login() 
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.usersService
                .GetUserId(model.Username, HashPassword(model.Password));

            if (userId == null)
            {
                return Redirect("/Users/Login");

                //return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public ActionResult Logout()
        {
            this.SignOut();

            return Redirect("/");
        }

        private string HashPassword(string password)
        => passwordHasher.HashPassword(password);
    }
}
