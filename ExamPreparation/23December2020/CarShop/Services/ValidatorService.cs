using CarShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CarShop.Constants.DataConstants;

namespace CarShop.Services
{
    public class ValidatorService : IValidatorService
    {
        public ICollection<string> ValidateCarAddAction(CarAddViewModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < CarModelMinLength || model.Model.Length > CarModelMaxLength)
            {
                errors.Add($"Model '{model.Model}' is not valid. It must be between {CarModelMinLength} and {CarModelMaxLength} characters long.");
            }

            if (model.Year < CarYearMinValue || model.Year > CarYearMaxValue)
            {
                errors.Add($"Year '{model.Year}' is not valid. It must be between {CarYearMinValue} and {CarYearMaxValue}.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not a valid URL.");
            }

            if (!Regex.IsMatch(model.PlateNumber, CarPlateNumberRegex))
            {
                errors.Add($"Plate number {model.PlateNumber} is not valid. It should be in format 'AA0000AA'.");
            }

            return errors;


            //•	Has a Model – a string with min length 5 and max length 20 (required)
            //•	Has a Year – a number(required)
            //•	Has a PictureUrl – string (required)
            //•	Has a PlateNumber – a string – Must be a valid Plate number(2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)
            //•	Has a OwnerId – a string (required)
            //•	Has a Owner – a User object
            //•	Has Issues collection – an Issue type
        }

        public ICollection<string> ValidateUserRegister(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserUsernameMinLength || model.Username.Length > UserUsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserUsernameMinLength} and {UserUsernameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegexPattern))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserPasswordMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserPasswordMinLength} and {UserPasswordMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            if (model.UserType != UserTypeMechanic && model.UserType != UserTypeClient)
            {
                errors.Add($"User should be either a '{UserTypeMechanic}' or '{UserTypeClient}'.");
            }


            return errors;

            //•	Has a Username – a string with min length 4 and max length 20 (required)
            //•	Has an Email - a string (required)
            //•	Has a Password – a string with min length 5 and max length 20  - hashed in the database(required)
            //•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client





        }
    }
}
