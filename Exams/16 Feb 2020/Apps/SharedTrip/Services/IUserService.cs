using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
