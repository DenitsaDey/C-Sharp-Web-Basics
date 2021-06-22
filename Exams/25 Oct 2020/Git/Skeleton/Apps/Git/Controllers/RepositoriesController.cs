using Git.Services;
using Git.ViewModels.Repository;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepoInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(string.IsNullOrWhiteSpace(input.Name) ||
                input.Name.Length < 3 ||
                input.Name.Length > 10)
            {
                return this.Error("Repository name should be between 3 and 10 symbols.");
            }

            var userId = this.GetUserId();
            this.repositoriesService.Create(input, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var allRepos = this.repositoriesService.GetAll();
            
            return this.View(allRepos);
        }
    }
}
