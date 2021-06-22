using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        //[MinLength(5)]
        public string Description { get; init; }

        public bool IsFixed { get; init; }

        [Required]
        public string CarId { get; init; }

        public virtual Car Car { get; init; }
    }
}