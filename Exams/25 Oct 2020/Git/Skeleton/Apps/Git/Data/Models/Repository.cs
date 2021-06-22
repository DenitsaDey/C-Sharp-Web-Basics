using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Repository
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsPublic { get; set; }
        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}