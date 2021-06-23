using MUSACA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSACA.Services
{
   public interface IValidatorService
    {
        public ICollection<string> ValidateUsers(UserRegisterViewModel model);
    }
}
