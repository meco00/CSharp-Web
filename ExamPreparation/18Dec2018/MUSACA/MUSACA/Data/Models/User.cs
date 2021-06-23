using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;


using static MUSACA.Data.DataConstants;

namespace MUSACA.Data.Models
{
   public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        public string Email { get; init; }

       
    }
}
