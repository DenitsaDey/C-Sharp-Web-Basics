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
        //private readonly IUsersService usersService;

        public IssuesController(IIssuesService issuesService)
        {
            this.issuesService = issuesService;
            //this.usersService = usersService;
        }

        public HttpResponse Add(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View(carId);
        }

        [HttpPost]
        public HttpResponse Add(string description, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) ||
                description.Length < 5)
            {
                return this.Error("Description is required");
            }
            if (!this.issuesService.CarIdIsValid(carId))
            {
                return this.Error($"Car with ID {carId} does not exist.");
            }

            this.issuesService.AddIssue(description, carId);
            return this.Redirect($"/Issues/Carissues?carId={carId}");
        }

        public HttpResponse CarIssues(string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var carWithIssues = this.issuesService.GetAll(carId);
            //if(carWithIssues == null)
            //{
            //    return this.Error($"Car with ID {carId} does not exist.");
            //}
            return this.View(carWithIssues);
        }

        public HttpResponse Fix(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            if (!this.issuesService.UserCanFixIssue(userId))
            {
                return this.Error("Clients cannot fix issues.");
            }
            this.issuesService.FixIssue(issueId, carId);
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public HttpResponse Delete(string issueId, string carId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.issuesService.DeleteIssue(issueId);
            return this.Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
