using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext data;
        private readonly IUsersService usersService;

        public IssuesService(ApplicationDbContext data, IUsersService usersService)
        {
            this.data = data;
            this.usersService = usersService;
        }

        public void CreateIssue(string carId, string description)
        {
            var issue = new Issue
            {
                Description = description,
                CarId = carId

            };

            data.Issues.Add(issue);

            data.SaveChanges();
        }

        public void FixIssue(string issueId, string carId)
        {
            var issue = GetIssue(issueId, carId);


            if (issue==null || !issue.IsFixed)
            {
                return;
            }

            issue.IsFixed = true;
            data.SaveChanges();
        }

        public CarIssuesViewModel GetCarIssues(string carId)
        => data.Cars.Where(x => x.Id == carId).Select(x => new CarIssuesViewModel()
            {
                Id = x.Id,
                Model = x.Model,
                Year = x.Year.ToString(),
                Issues = x.Issues.Select(i => new IssuesViewModel()
                {
                    Id = i.Id,
                    Description = i.Description,
                    IsItFixed = i.IsFixed ? "Yes" : "Not yet"

                }).ToList()

            })
               .FirstOrDefault();
               

      

        public Issue GetIssue(string issueId, string carId)
        => data.Issues.FirstOrDefault(x => x.Id == issueId && x.CarId == carId);

        public bool IsIntruder(string userId, string carId)
        {
            var isMechanic = this.usersService.IsUserMechanic(userId);
            var isUsersCar = IsUserOwnsCar(carId, userId);

            if (!isUsersCar
                && !isMechanic)
            {
                return true;
            }

            return false;
        }

        public bool IsUserOwnsCar(string carId, string userId)
        => data.Cars.Any(x => x.Id == carId && x.OwnerId == userId);

        public void RemoveIssue(string issueId, string carId)
        {
            var issue = GetIssue(issueId, carId);

            if (issue == null)
            {
                return;
            }

            data.Issues.Remove(issue);

            data.SaveChanges();
        }
    }
}
