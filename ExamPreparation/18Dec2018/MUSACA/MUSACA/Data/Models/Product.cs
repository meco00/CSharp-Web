using System;
using System.ComponentModel.DataAnnotations;

using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
   public class Product
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; init; }

        
        public decimal Price { get; init; }

        [Required]
        public string Barcode { get; init; }

        [Required]
        public string Picture { get; init; }
    }
}
