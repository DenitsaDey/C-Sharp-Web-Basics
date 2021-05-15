using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
{
    class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.userService.GetUserId(input.Username, input.Password);
            if(userId == null)
            {
                return this.Error("Ïnvalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if(string.IsNullOrEmpty(input.Username) || 
                input.Username.Length < 5 ||
                input.Username.Length > 20)
            {
                return this.Error("Username should be be between 5 and 20 characters long");
            }

            if(string.IsNullOrEmpty(input.Email) ||
                !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email.");
            }

            if(string.IsNullOrEmpty(input.Password) ||
                input.Password.Length < 6 ||
                input.Password.Length > 20)
            {
                return this.Error("Password is required and should be  between 6 and 20 characters");
            }

            if(input.ConfirmPassword != input.Password)
            {
                return this.Error("Passwords do not match");
            }

            if (!this.userService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email already taken");
            }

            if (!this.userService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username already taken.");
            }
            this.userService.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }
    }

}
