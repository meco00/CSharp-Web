using MUSACA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static MUSACA.Data.DataConstants;

namespace MUSACA.Services
{
    public class ValidatorService : IValidatorService
    {
        public ICollection<string> ValidateUsers(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinLength || model.Username.Length > UserMaxLength)
            {
                errors.Add($"Username must be between {UserMinLength} - {UserMaxLength} characters long");
            }

            if (!Regex.IsMatch(model.Email, UserEmailValidatingRegex))
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
        }
    }
}
