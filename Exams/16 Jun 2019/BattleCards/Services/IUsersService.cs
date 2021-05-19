using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string passowrd);
        bool IsUsernameAvailable(string username);
        bool IsEmailAvailable(string email);
    }
}
