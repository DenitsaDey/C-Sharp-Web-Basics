using Git.ViewModels.Commit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string description, string id, string userId);

        IEnumerable<CommitViewModel> GetAllCommits(string userId);

        bool UserCanDeleteCommit(string userId, string id);

        void DeleteCommit(string id);
    }
}
