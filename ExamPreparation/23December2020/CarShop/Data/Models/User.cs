using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CarShop.Constants.DataConstants;

namespace CarShop.Models
{
   public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserUsernameMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }


        public bool IsMechanic { get; init; }


        //        •	Has an Id – a string, Primary Key
        //•	Has a Username – a string with min length 4 and max length 20 (required)
        //•	Has an Email - a string (required)
        //•	Has a Password – a string with min length 5 and max length 20  - hashed in the database(required)
        //•	Has а IsMechanic – a bool indicating if the user is a mechanic or a client

    }
}
