﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Models
{
   public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}
