using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
   public class Receipt
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public DateTime IssuedOn { get; set; }




        [Required]
        public string CashierId { get; set; }

        public User Cashier { get; set; }

        public ICollection<Order> Orders { get; init; } = new List<Order>();
       
    }
}
