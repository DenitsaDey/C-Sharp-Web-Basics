using BattleCards.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(RegisterUserInputModel input);

        bool IsUsernameAvailable(string username);


        bool IsEmailAvailable(string email);
    }
}
