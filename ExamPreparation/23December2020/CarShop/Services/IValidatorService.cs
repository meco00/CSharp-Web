using CarShop.ViewModel;
using System.Collections.Generic;

namespace CarShop.Services
{
   public interface IValidatorService
    {
         ICollection<string> ValidateUserRegister(UserRegisterViewModel user);

         ICollection<string> ValidateCarAddAction(CarAddViewModel car);
    }
}
