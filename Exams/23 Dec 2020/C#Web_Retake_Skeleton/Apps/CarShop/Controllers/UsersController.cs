using CarShop.Services;
using CarShop.ViewModels.User;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }
            return this.View();
        }
        
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            if (string.IsNullOrEmpty(input.Username) ||
                input.Username.Length < 4 ||
                input.Username.Length > 20)
            {
                return this.Error("Username should be be between 4 and 20 characters long");
            }

            if (string.IsNullOrEmpty(input.Email) ||
                !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if (string.IsNullOrEmpty(input.Password) ||
                input.Password.Length < 5 ||
                input.Password.Length > 20)
            {
                return this.Error("Password is required and should be  between 5 and 20 characters");
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

            if(input.UserType != "Mechanic" && input.UserType != "Client")
            {
                return this.Error("Usertype should be Mechanic or Client");
            }

            this.usersService.Create(input.Username, input.Email, input.Password, input.ConfirmPassword);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cars/All");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId == null)
            {
                return this.Error("Ïnvalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
