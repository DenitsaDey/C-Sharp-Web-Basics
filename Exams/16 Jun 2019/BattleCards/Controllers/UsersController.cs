<<<<<<< HEAD
﻿using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);
            if(userId == null)
            {
                return this.Error("Invalid username  or passowrd.");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if(string.IsNullOrEmpty(input.Username) || 
                input.Username.Length < 5 ||
                input.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username is not available.");
            }

            if(string.IsNullOrEmpty(input.Email) || 
                new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email address.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email is not available.");
            }

            if (string.IsNullOrEmpty(input.Password) ||
                input.Password.Length < 6 ||
                input.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters.");
            }

            if(input.Password != input.ConfirmPassowrd)
            {
                return this.Error("Passwords don't match");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
=======
﻿using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);
            if(userId == null)
            {
                return this.Error("Invalid username  or passowrd.");
            }
            this.SignIn(userId);
            return this.Redirect("/");
        }
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if(string.IsNullOrEmpty(input.Username) || 
                input.Username.Length < 5 ||
                input.Username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters.");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("Username is not available.");
            }

            if(string.IsNullOrEmpty(input.Email) || 
                new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email address.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("Email is not available.");
            }

            if (string.IsNullOrEmpty(input.Password) ||
                input.Password.Length < 6 ||
                input.Password.Length > 20)
            {
                return this.Error("Password must be between 6 and 20 characters.");
            }

            if(input.Password != input.ConfirmPassowrd)
            {
                return this.Error("Passwords don't match");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
