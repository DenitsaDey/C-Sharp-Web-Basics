using SharedTrip.ViewModels.Trip;
using SharedTrip.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    using static Data.DataConstants;
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserInputModel user)
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

        public ICollection<string> ValidateTrip(RegisterTripInputModel trip)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(trip.StartPoint))
            {
                errors.Add($"StartPoint is required.");
            }

            if (string.IsNullOrWhiteSpace(trip.EndPoint))
            {
                errors.Add($"EndPoint is required.");
            }

            if (!DateTime.TryParseExact(
                trip.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime currentDeparturTime))
            {
                errors.Add("Invalid departure time. Please use dd.MM.yyyy HH:mm format");
            }

            if (trip.Seats < SeatsMinValue || trip.Seats > SeatsMaxValue)
            {
                errors.Add($"Seats should be between '{SeatsMinValue}' and '{SeatsMaxValue}'.");
            }

            if (string.IsNullOrWhiteSpace(trip.Description) || trip.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description '{trip.Description}' is not valid. Description is required and should not be above {DescriptionMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(trip.ImagePath) || !Uri.IsWellFormedUriString(trip.ImagePath, UriKind.Absolute))
            {
                errors.Add($"Image '{trip.ImagePath}' is not valid. It must be a valid URL.");
            }

            return errors;
        }
    }
}
