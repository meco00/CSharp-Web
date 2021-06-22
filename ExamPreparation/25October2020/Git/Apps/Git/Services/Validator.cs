using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static Git.Data.DataConstants;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateRepository(RepositoryCreateViewModel model)
        {
            var errorList = new List<string>();

            if (model.Name.Length < RepositoryMinLength || model.Name.Length > RepositoryMaxLength)
            {
                errorList.Add($"Repository '{model.Name}' is not valid . It must be between {RepositoryMinLength} - {RepositoryMaxLength} characters long");
            }

            if (model.RepositoryType != RepositoryPublicType && model.RepositoryType != RepositoryPrivateType)
            {
                errorList.Add($"Repository type can be either '{RepositoryPublicType}' or '{RepositoryPrivateType}'.");

            }

            return errorList;

        }

        public ICollection<string> ValidateUsers(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinLength || model.Username.Length >UserMaxLength)
            {
                errors.Add($"Username must be between {UserMinLength} - {UserMaxLength} characters long");
            }

            if (!Regex.IsMatch(model.Email,UserEmailValidatingRegex))
            {
                errors.Add($"Email is not valid");
            }

            if (model.Password.Length < UserPasswordMinLength || model.Password.Length > UserMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} - {UserMaxLength} characters long");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and ConfirmPassword are not identical");
            }






            return errors;



            //Has a Username – a string with min length 5 and max length 20(required)
        //•	Has an Email - a string (required)
        //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        }
    }
}
