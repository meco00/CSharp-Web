using System;


namespace SharedTrip.Services
{
   public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string Email);
    }
}
