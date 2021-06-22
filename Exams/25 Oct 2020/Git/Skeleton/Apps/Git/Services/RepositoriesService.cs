using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;
        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateRepoInputModel input, string userId)
        {
            var newRepo = new Repository
            {
                Name = input.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = input.RepositoryType == "Public" ? true : false,
                OwnerId = userId,
                Owner = this.db.Users.FirstOrDefault(u => u.Id == userId)
            };

            this.db.Repositories.Add(newRepo);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var allRepos = this.db.Repositories
                .Where(r => r.IsPublic)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    CreatedOn = r.CreatedOn,
                    Owner = r.Owner.Username,
                    CommitsCount = r.Commits.Count
                })
                .ToList();

            return allRepos;
        }

        public string GetRepositoryName(string repoId)
        {
            return this.db.Repositories.Where(r => r.Id == repoId).FirstOrDefault()?.Name;            
        }
    }
}
