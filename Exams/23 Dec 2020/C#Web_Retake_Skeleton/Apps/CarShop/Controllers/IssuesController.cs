using CarShop.Services;
using CarShop.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IUsersService usersService;

        public IssuesController(IIssuesService issuesService)
        {
            this.issuesService = issuesService;
            this.usersService = usersService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddIssueInputModel input, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Description) ||
                input.Description.Length < 5)
            {
                return this.Error("Description is required");
            }
            if (!this.issuesService.CarIdIsValid(carId))
            {
                return this.Error($"Car with ID {carId} does not exist.");
            }
            
            var userId = this.GetUserId();
            this.issuesService.AddIssue(input, userId);
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();

            //if (!this.usersService.UserIsMechanic(userId))
            //{
            //    return 
            //}
            var carWithIssues = this.issuesService.GetAll(carId);
            if(carWithIssues == null)
            {
                return this.Error($"Car with ID {carId} does not exist.");
            }
            return this.View(carWithIssues);
        }


    }
}
