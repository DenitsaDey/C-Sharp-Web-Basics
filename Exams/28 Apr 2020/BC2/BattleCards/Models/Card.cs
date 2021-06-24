using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        //required
        public int Attack { get; set; }

        //required
        public int Health { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public virtual ICollection<UserCard> UserCards { get; set; } = new HashSet<UserCard>();
    }
}
