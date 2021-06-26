using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        public ApplicationDbContext data;

        public UserService(ApplicationDbContext context)
        {
            this.data = context;

        }

        public void Create(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
               

            };

            data.Users.Add(user);

            data.SaveChanges();
        }

        public string GetUserId(string username, string password)
       => data.Users
            .Where(x => x.Username == username && x.Password == password)
            .Select(x => x.Id)
            .FirstOrDefault();

        public bool IsEmailAvailable(string Email)
       => !data.Users.Any(x => x.Email == Email);

        public bool IsUsernameAvailable(string username)
        => !data.Users.Any(x => x.Username == username);
    }
}
