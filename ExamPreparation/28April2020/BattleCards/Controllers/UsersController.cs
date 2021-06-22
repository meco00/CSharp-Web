using BattleCards.Data;
using BattleCards.Models;
using BattleCards.Services;
using BattleCards.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidator validator, ApplicationDbContext data, IPasswordHasher passwordHasher)
        {
            this.validator = validator;
            this.data = data;
            this.passwordHasher = passwordHasher;
        }



        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel userDto)
        {
            var userId = data
                .Users
                .Where(x => x.Username == userDto.Username
                && x.Password == passwordHasher.HashPassword(userDto.Password))
                .Select(x => x.Id).FirstOrDefault();


            if (userId == null)
            {
                return Error("Username or Password are invalid");
            }

            this.SignIn(userId);

            return Redirect("/Cards/All");
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
        public ActionResult Register(UserRegisterViewModel user)
        {
            var errors = validator.ValidateUsers(user);

            

            if (data.Users.Any(x => x.Username == user.Username))
            {
                errors.Add($"Username: {user.Username} already exists");

            }

           
            if (data.Users.Any(x => x.Email == user.Email))
            {
                errors.Add($"Email: {user.Email} already exists");

            }

            if (errors.Count > 0)
            {
                return Error(errors);
            }


            var userToImportInData = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = passwordHasher.HashPassword(user.Password)

            };

            data.Users.Add(userToImportInData);

            data.SaveChanges();


            return Redirect("/Users/Login");
        }
    }
}
