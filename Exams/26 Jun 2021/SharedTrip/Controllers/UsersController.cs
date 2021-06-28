using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUsersService usersService;

        public UsersController(
            IValidator validator,
            IUsersService usersService)
        {
            this.validator = validator;
            this.usersService = usersService;
        }

        //public HttpResponse Register() => View();

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            var modelErrors = this.validator.ValidateUser(input);

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                modelErrors.Add($"User with '{input.Username}' username already exists.");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                modelErrors.Add($"User with '{input.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.usersService.Create(input);

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.User.IsAuthenticated)
            {
                return this.Redirect("/Trips/All");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId == null)
            {
                return Error("Ïnvalid username or password");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
