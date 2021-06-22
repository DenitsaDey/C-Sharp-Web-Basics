using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Commit
{
    public class CreateCommitInputModel
    {
        public string Description { get; set; }
        public string RepositoryId { get; set; }
    }
}
