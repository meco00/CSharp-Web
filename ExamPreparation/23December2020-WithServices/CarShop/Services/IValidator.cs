using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
   public interface IValidator
    {
        public ICollection<string> ValidateUsers(UserRegisterViewModel model);

        public ICollection<string> ValidateCars(CarAddViewModel model);

        public ICollection<string> ValidateIssues(IssueAddViewModel model);
    }
}
