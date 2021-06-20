using CarShop.Data;
using CarShop.Models;
using CarShop.Services;
using CarShop.ViewModel;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Linq;

namespace CarShop.Controllers
{
    public class UsersController:Controller
    {
        private readonly IValidatorService validatorService;
        private readonly ApplicationDbContext data;
        private readonly IPasswordService passwordService;

        public UsersController(IValidatorService validatorService,ApplicationDbContext context,IPasswordService passwordService)
        {
            this.validatorService = validatorService;
            this.data = context;
            this.passwordService = passwordService;

        }

        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel userVM)
        {
            var userId = this.data
               .Users
               .Where(u => u.Username == userVM.Username && u.Password == this.passwordService.HashPassword(userVM.Password))
               .Select(u => u.Id)
               .FirstOrDefault();



            if (userId==null)
            {
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);
            

            return Redirect("/Cars/All");
        }

        public ActionResult Logout()
        {
            this.SignOut();

            return View("Home/Index");
        }




        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel user)
        {
            var list = validatorService.ValidateUserRegister(user);

            if (list.Count > 0)
            {
                return Error(list);
            }

            if (data.Users.Any(x=>x.Username==user.Username))
            {
                list.Add("Already exists User with this username");
            }
            if (data.Users.Any(x=>x.Email==user.Email))
            {
                list.Add("Already exists User with this email");
            }

            if (list.Count > 0)
            {
                return Error(list);
            }

            var userToImport = new User()
            {
                Username = user.Username,
                Password = passwordService.HashPassword(user.Password),
                Email=user.Email,
                IsMechanic= user.UserType == "Mechanic" ? true:false

            };

            data.Users.Add(userToImport);
            data.SaveChanges();



            return this.Redirect("/Users/Login");
        }
    }
}
