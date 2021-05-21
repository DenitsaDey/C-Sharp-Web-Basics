using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Data
{
    public class Problem
    {
        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        //[MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        //[Range(50, 300)]
        public int Points { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}
