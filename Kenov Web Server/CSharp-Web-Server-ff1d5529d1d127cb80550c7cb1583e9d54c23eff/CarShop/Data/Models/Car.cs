using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        //[MinLength(5)]
        public string Model { get; init; }

        public int Year { get; init; }

        [Required]
        public string PictureUrl { get; init; }

        [Required]
        [MaxLength(8)]
        //[RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        public string PlateNumber { get; init; }

        [Required]
        public string OwnerId { get; init; }

        public virtual User Owner { get; init; }

        public virtual ICollection<Issue> Issues { get; init; } = new HashSet<Issue>();
    }
}
