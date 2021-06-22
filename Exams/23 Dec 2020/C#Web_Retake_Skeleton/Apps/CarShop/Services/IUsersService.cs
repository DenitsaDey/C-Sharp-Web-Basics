using CarShop.ViewModels.User;

namespace CarShop.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(RegisterInputModel input);

        bool IsUsernameAvailable(string username);

        bool UserIsMechanic(string Userid);

        bool IsEmailAvailable(string email);
    }
}
