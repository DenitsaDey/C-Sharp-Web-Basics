using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        //[MinLength(4)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        //[MaxLength(20)]
        //[MinLength(5)]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
