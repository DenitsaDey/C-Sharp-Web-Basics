using Git.ViewModels.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(CreateRepoInputModel input, string userId);

        IEnumerable<RepositoryViewModel> GetAll();

        string GetRepositoryName(string repoId);
    }
}
