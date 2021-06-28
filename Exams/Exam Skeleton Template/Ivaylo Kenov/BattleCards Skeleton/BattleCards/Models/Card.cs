using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BattleCards.Models
{
    public class Card
    {
        [Key]
        [Required]
        [MaxLength(Data.DataConstants.IdMaxLength)]
        public int Id { get; set; }

        [Required]
        [MaxLength(Data.DataConstants.CardNameMaxLength)]
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
        [MaxLength(Data.DataConstants.DescriptionMaxLength)]
        public string Description { get; set; }
        public virtual ICollection<UserCard> UserCards { get; set; } = new HashSet<UserCard>();
    }
}