using BattleCards.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(RegisterUserInputModel input);

        bool IsUsernameAvailable(string username);


        bool IsEmailAvailable(string email);
    }
}
