using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        //[MinLength(4)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        [MaxLength(20)]
        //[MinLength(5)]
        public string Password { get; init; }

        public bool IsMechanic { get; init; }

    }
}
