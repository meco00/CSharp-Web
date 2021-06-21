﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Commit
    {

        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }

        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string RepositoryId { get; set; }

        public Repository Repository { get; set; }

        //        •	Has an Id – a string, Primary Key
        //•	Has a Description – a string with min length 5 (required)
        //•	Has a CreatedOn – a datetime(required)
        //•	Has a CreatorId – a string
        //•	Has Creator – a User object
        //•	Has RepositoryId – a string
        //•	Has Repository– a Repository object

    }
}