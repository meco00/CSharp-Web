

using System;
using System.ComponentModel.DataAnnotations;
using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
   public class Order
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Status { get; set; }


        [Required]
        public string ProductId { get; set; }
        public Product Product { get; set; }

        
        public int Quantity { get; set; }


        [Required]
        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
