
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static CarShop.Data.Models.DataConstants;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateCars(CarAddViewModel model)
        {
            var errors = new List<string>();

            if (model.Model == null || model.Model.Length < UserPasswordMinLength || model.Model.Length > UserMaxLength)
            {
                errors.Add($"Model '{model.Model}'is not valid. It must be between {UserMinLength} - {UserMaxLength} characters long");
            }

            if (model.PlateNumber==null || !Regex.IsMatch(model.PlateNumber, PlateNumberRegex))
            {
                errors.Add($"Plate number is not valid . It must be in format 'CA0000SD'");
            }

            if (model.Image==null || !Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image Url is not valid.");
            }

            if (model.Year < CarYearMinValue || model.Year > CarYearMaxValue)
            {
                errors.Add($"Car year must be between {CarYearMinValue} - {CarYearMaxValue}");
            }

            return errors;
        }

        public ICollection<string> ValidateIssues(IssueAddViewModel model)
        {
            var errors = new List<string>();

            if (model.carId == null)
            {
                errors.Add($"Car ID cannot be empty.");
            }

            if (model.Description == null || model.Description.Length < IssueDescriptionMinLength)
            {
                errors.Add($"Description '{model.Description}' is not valid. It must have more than {IssueDescriptionMinLength} characters.");
            }

            return errors;

        }

        public ICollection<string> ValidateUsers(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username==null || model.Username.Length < UserMinLength || model.Username.Length > UserMaxLength)
            {
                errors.Add($"Username '{model.Username}'is not valid. It must be between {UserMinLength} - {UserMaxLength} characters long");
            }

            if (!Regex.IsMatch(model.Email, UserEmailValidatingRegex))
            {
                errors.Add($"Email is not valid");
            }

            if (model.Password==null || model.Password.Length < UserPasswordMinLength || model.Password.Length > UserMaxLength)
            {
                errors.Add($"Password must be between {UserPasswordMinLength} - {UserMaxLength} characters long");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.ConfirmPassword ==null || model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and ConfirmPassword are not identical");
            }

            if (model.UserType == null || model.UserType!=UserClientType&&model.UserType!=UserMechanicType)
            {
                errors.Add($"UserType: '{model.UserType}' is not valid . It must be either {UserClientType} or {UserMechanicType}");
            }

            return errors;
        }
    }
}
