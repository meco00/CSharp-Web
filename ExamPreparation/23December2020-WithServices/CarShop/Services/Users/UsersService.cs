using CarShop.Data;
using CarShop.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop.Services
{
    public class UsersService: IUsersService
    {
        public ApplicationDbContext data;

        public UsersService(ApplicationDbContext context)
        {
            this.data = context;

        }

        public void Create(string username, string email, string password, string userType)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                IsMechanic = userType == "Mechanic" ? true : false

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
        

        public bool IsUserMechanic(string Userid)
        => data.Users.Any(x => x.Id == Userid && x.IsMechanic);
        

        public bool IsUsernameAvailable(string username)
        => !data.Users.Any(x => x.Username == username);


        
    }
}
