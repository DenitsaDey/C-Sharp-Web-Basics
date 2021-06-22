using Git.Services;
using Git.ViewModels.Commit;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Git.Controllers
{
    public class CommitsController : Controller 
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;
        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repoName = this.repositoriesService.GetRepositoryName(id);
            var viewModel = new CreateCommitToRepoViewModel
            {
                Id = id,
                Name = repoName
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel input, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(string.IsNullOrWhiteSpace(input.Description) ||
                input.Description.Length < 5)
            {
                return this.Error("Description is required to be at least 5 symbols.");
            }

            //if (string.IsNullOrEmpty(this.repositoriesService.GetRepositoryName(input.RepositoryId)))
            //{
            //    return this.Error("Invalid repository Id. Commits can only be made to existing repositories.");
            //}

            var userId = this.GetUserId();
            this.commitsService.Create(input.Description, id, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var allCommits = this.commitsService.GetAllCommits(userId);
            return this.View(allCommits);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            if(!this.commitsService.UserCanDeleteCommit(userId, id))
            {
                return this.Error("You don't own this commit.");
            }

            this.commitsService.DeleteCommit(id);

            return this.Redirect("/Commits/All");
        }
    }
}
