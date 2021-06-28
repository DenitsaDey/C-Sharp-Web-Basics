using BattleCards.ViewModels.Card;
using BattleCards.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserInputModel input);

        ICollection<string> ValidateCard(RegisterCardInputModel input);
    }
}
