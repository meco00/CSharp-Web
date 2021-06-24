using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
   public interface IIssuesService
    {
        bool IsUserOwnsCar(string carId, string userId);

        void CreateIssue(string carId, string description);

        bool IsIntruder(string userId, string carId);

        Issue GetIssue(string issueId, string carId);

        void FixIssue(string issueId, string carId);

        void RemoveIssue(string issueId, string carId);

        CarIssuesViewModel GetCarIssues(string carId);

    }
}
