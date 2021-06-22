using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;
        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string description, string id, string userId)
        {
            var newCommit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId,
                RepositoryId = id,
            };

            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAllCommits(string userId)
        {
            var allCommits = this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new CommitViewModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn,
                    Repository = c.Repository.Name
                })
                .ToList();

            return allCommits;
        }

        public bool UserCanDeleteCommit(string userId, string id)
        {
            return this.db.Commits.Any(c => c.CreatorId == userId && c.Id == id);
            //var repositoryOwnerId = this.db.Commits.Where(x => x.Id == commitId).Select(x => x.Repository.OwnerId).FirstOrDefault();

            //return repositoryOwnerId == userId ? true : false;
        }

        public void DeleteCommit(string commitId)
        {
            var commit = this.db.Commits.Find(commitId);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }
    }
}
