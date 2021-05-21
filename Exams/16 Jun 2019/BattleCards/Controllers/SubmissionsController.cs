using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }
        public HttpResponse Create(string id)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemsService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if(string.IsNullOrEmpty(code) || 
                code.Length < 30 ||
                code.Length > 800)
            {
                return this.Error("Code shoul=d be between 30 and 800 characters.");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(problemId, userId, code);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
