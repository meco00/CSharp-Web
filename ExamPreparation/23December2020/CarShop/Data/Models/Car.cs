using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CarShop.Constants.DataConstants;

namespace CarShop.Models
{
   public class Car
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Model { get; init; }

        public int Year { get; init; }

        [Required]
        public string PictureUrl { get; init; }

        [Required]
        public string PlateNumber { get; init; }

        [Required]
        public string OwnerId { get; init; }

        public User Owner { get; init; }

       public ICollection<Issue> Issues { get; init; } = new List<Issue>();

        //        •	Has an Id – a string, Primary Key
        //•	Has a Model – a string with min length 5 and max length 20 (required)
        //•	Has a Year – a number(required)
        //•	Has a PictureUrl – string (required)
        //•	Has a PlateNumber – a string – Must be a valid Plate number(2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters (required)
        //•	Has a OwnerId – a string (required)
        //•	Has a Owner – a User object
        //•	Has Issues collection – an Issue type

    }
}
