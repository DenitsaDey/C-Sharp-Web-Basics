﻿namespace CarShop.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password, string userType);

        bool IsUsernameAvailable(string username);

        bool UserIsMechanic(string Userid);

        bool IsEmailAvailable(string email);
    }
}
