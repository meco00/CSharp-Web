
using System.ComponentModel.DataAnnotations;
using static SharedTrip.Data.DataConstants;

namespace SharedTrip.Models
{
    public class UserTrip
    {
        [Required]
        [MaxLength(IdMaxLength)]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        public string TripId { get; set; }

        public Trip Trip { get; set; }


    }
}