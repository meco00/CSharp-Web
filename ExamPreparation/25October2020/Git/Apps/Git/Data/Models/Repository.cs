using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryMaxLength)]
        public string Name { get; init; }


        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        public bool IsPublic { get; init; }

        [Required]
        public string OwnerId { get; init; }

        public User Owner{ get; init; }

        public ICollection<Commit> Commits { get; } = new List<Commit>();

        //        •	Has an Id – a string, Primary Key
        //•	Has a Name – a string with min length 3 and max length 10 (required)
        //•	Has a CreatedOn – a datetime(required)
        //•	Has a IsPublic – bool (required)
        //•	Has a OwnerId – a string
        //•	Has a Owner – a User object
        //•	Has Commits collection – a Commit type

    }
}