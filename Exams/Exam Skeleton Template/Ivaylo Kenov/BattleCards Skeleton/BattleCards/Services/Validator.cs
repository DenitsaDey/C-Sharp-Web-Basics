using BattleCards.ViewModels.Card;
using BattleCards.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleCards.Services
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

        public ICollection<string> ValidateCard(RegisterCardInputModel card)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(card.Name) || card.Name.Length < CardNameMinLength || card.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Name '{card.Name}' is not valid. Name should be be between {CardNameMinLength} and {CardNameMaxLength} characters long.");
            }

            if (string.IsNullOrWhiteSpace(card.Image) || !Uri.IsWellFormedUriString(card.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{card.Image}' is not valid. It must be a valid URL.");
            }

            if (string.IsNullOrWhiteSpace(card.Keyword))
            {
                errors.Add($"Keyword '{card.Keyword}' is required.");
            }

            if (card.Attack < 0)
            {
                errors.Add("Attack is required and cannot be of negative value.");
            }

            if (card.Health < 0)
            {
                errors.Add("Health is required and cannot be of negative value.");
            }

            if (string.IsNullOrWhiteSpace(card.Description) || card.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description '{card.Description}' is not valid. Description is required and should not be above {DescriptionMaxLength} characters long.");
            }

            return errors;
        }
    }
}
