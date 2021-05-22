<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        //[MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        //[EmailAddress]
        public string Email { get; set; }

        [Required]
        //[MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        //[MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        //[EmailAddress]
        public string Email { get; set; }

        [Required]
        //[MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();
    }
}
>>>>>>> 91886ece345b5bfab24f0a2a1b2d4acb61d4237e
