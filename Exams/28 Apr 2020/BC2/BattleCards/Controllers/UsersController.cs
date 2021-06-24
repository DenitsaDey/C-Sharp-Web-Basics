using BattleCards.Services;
using BattleCards.ViewModels.User;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register() {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }

            if(string.IsNullOrWhiteSpace(input.Username) ||
                input.Username.Length<5 ||
                input.Username.Length > 20)
            {
                return this.Error("Username should be be between 5 and 20 characters long");
            }

            if (string.IsNullOrWhiteSpace(input.Email) ||
                !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if (string.IsNullOrWhiteSpace(input.Password) ||
                input.Password.Length < 6 ||
                input.Password.Length > 20)
            {
                return this.Error("Password is required and should be between 6 and 20 characters");
            }

            if (input.ConfirmPassword != input.Password)
            {
                return this.Error("Passwords do not match");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }

            this.usersService.Create(input);
            return this.Redirect("Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Cards/All");
            }
            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return this.Error("Ïnvalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
