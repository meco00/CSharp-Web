using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUsersService usersService;

        public UsersController(IValidator validator, ApplicationDbContext data, IPasswordHasher passwordHasher,IUsersService usersService)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
            this.usersService = usersService;
        }



        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel userDto)
        {
        
            var userId = this.usersService
                .GetUserId(userDto.Username, HashPassword(userDto.Password));
           
            if (userId == null)
            {
                return Error("Username or Password are invalid");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        [Authorize]
        public ActionResult Logout()
        {
            this.SignOut();

            return Redirect("/Home/Index");
        }


        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {
            var errors = validator.ValidateUsers(model);

          
            bool isUsernameAvailable = this.usersService.IsUsernameAvailable(model.Username);

            if (!isUsernameAvailable)
            {
                errors.Add($"Username: {model.Username} already exists");

            }

            bool isEmailAvailable = this.usersService.IsEmailAvailable(model.Email);

            if (!isEmailAvailable)
            {
                errors.Add($"Email: {model.Email} already exists");

            }

            if (errors.Count > 0)
            {
                return Error(errors);
            }


            this.usersService.Create(model.Username, model.Email, HashPassword(model.Password), model.UserType);


            return Redirect("/Users/Login");
        }

        private string HashPassword(string password)
        => passwordHasher.HashPassword(password);
    }
}
