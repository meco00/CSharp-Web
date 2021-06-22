using System;
using System.ComponentModel.DataAnnotations;

using static BattleCards.Models.DataConstants;
namespace BattleCards.Models
{
    public class UserCard
    {
      

        [Required]
        [MaxLength(IdMaxLength)]
        public string UserId { get; set; }

        public User User { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; }

   

    }
}