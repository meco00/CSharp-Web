
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BattleCards.Models.DataConstants;

namespace BattleCards.Models
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserMaxLength)]
        public string Username { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Password { get; init; }

        public ICollection<UserCard> UserCards { get; } = new List<UserCard>();

    }
}
