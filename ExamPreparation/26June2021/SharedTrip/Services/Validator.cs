using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateTrip(TripAddFormModel trip)
        {
            var errors = new List<string>();

            if (trip.StartPoint == null )
            {
                errors.Add($"StartPoint '{trip.StartPoint}' is not valid.");
            }

            if (trip.EndPoint == null)
            {
                errors.Add($"EndPoint '{trip.StartPoint}' is not valid.");
            }

            if (trip.StartPoint.ToLower() == trip.EndPoint.ToLower())
            {
                errors.Add("StartPoint and EndPoint cannot be the same.");
            }

            if (trip.ImagePath!=null && !Uri.IsWellFormedUriString(trip.ImagePath, UriKind.Absolute))
            {
                errors.Add($"Image '{trip.ImagePath}' is not valid. It must be a valid URL.");
            }

            if (trip.Seats < TripSeatMinValue || trip.Seats > TripSeatMaxValue)
            {
                errors.Add($"Seats '{trip.Seats}' is not valid. It must be between {TripSeatMinValue} and {TripSeatMaxValue}.");
            }

            if (trip.Description == null || trip.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"Description '{trip.Description}' is not valid.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UserMinUsername || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < UserMinPassword || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
