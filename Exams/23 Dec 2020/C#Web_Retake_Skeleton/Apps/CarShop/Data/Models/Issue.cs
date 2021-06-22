using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        [Required]
        [MaxLength(40)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        //[MinLength(5)]
        public string Description { get; set; }

        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
