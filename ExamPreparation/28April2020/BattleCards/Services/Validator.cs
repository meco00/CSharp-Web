using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static BattleCards.Models.DataConstants;

namespace BattleCards.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateCards(CardAddViewModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < MinLength || model.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Name '{model.Name}' is not valid . It must be between {MinLength} - {CardNameMaxLength} characters long");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image Url is not valid.");
            }

            if (model.Attack < CardStatsMinValue )
            {
                errors.Add($"Attack must be {CardStatsMinValue} or greater");
            }
            if (model.Health < CardStatsMinValue)
            {
                errors.Add($"Health must be {CardStatsMinValue} or greater");
            }

            if (model.Description.Length > CardDescriptionMaxLength)
            {
                errors.Add($"Description can not be more than {CardDescriptionMaxLength} characters long.");
            }

            return errors;


           
        }

        public ICollection<string> ValidateUsers(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < MinLength || model.Username.Length > UserMaxLength)
            {
                errors.Add($"Username must be between {MinLength} - {UserMaxLength} characters long");
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
