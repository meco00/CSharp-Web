using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
   public class User
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<Repository> Repositories { get; } = new List<Repository>();

        public ICollection<Commit> Commits { get; } = new List<Commit>();



        //        •	Has an Id – a string, Primary Key
        //•	Has a Username – a string with min length 5 and max length 20 (required)
        //•	Has an Email - a string (required)
        //•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
        //•	Has Repositories collection – a Repository type
        //•	Has Commits collection – a Commit type

    }
}
