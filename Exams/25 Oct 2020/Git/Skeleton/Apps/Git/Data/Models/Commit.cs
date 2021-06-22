using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Commit
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description{get; set;}

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
        public string RepositoryId { get; set; }
        public virtual Repository Repository { get; set; }
    }
}