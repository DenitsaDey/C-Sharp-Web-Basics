using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        //[MinLength(5)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        //[MinLength(6)]
        //[MaxLength(20)] as it's hashed no need to add attribute here
        public string Password { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; } = new HashSet<UserTrip>();
    }
}
