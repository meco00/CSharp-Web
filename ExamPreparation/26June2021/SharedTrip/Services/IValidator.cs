using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;

namespace SharedTrip.Services
{
   public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel user);

        ICollection<string> ValidateTrip(TripAddFormModel trip);
    }
}
