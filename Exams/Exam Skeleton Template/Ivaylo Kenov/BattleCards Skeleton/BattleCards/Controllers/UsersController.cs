using BattleCards.Data;
using BattleCards.Services;
using BattleCards.ViewModels.User;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;

        public UsersController(IValidator validator,
            IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Cards/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Cards/All");
            }

            var modelErrors = this.validator.ValidateUser(input);

            if (!this.userService.IsUsernameAvailable(input.Username))
            {
                modelErrors.Add($"User with '{input.Username}' username already exists.");
            }

            if (!this.userService.IsEmailAvailable(input.Email))
            {
                modelErrors.Add($"User with '{input.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.userService.Create(input);

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Cards/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserInputModel input)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Cards/All");
            }
            var userId = this.userService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return Error("Ïnvalid username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
