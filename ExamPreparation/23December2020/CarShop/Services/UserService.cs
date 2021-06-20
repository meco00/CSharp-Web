using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        
             private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data) => this.data = data;

        public bool IsMechanic(string userId)
            => this.data
                .Users
                .Any(u => u.Id == userId && u.IsMechanic);
    }

    }

