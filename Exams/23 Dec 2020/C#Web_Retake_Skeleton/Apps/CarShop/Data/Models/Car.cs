using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        //[MinLength(5)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(8)]
        //[RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}