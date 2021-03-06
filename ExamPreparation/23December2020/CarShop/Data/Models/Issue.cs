using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Issue
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; init; }


        public bool IsFixed { get; set; }

        [Required]
        public string CarId { get; init; }


        public Car Car { get; init; }

        //        •	Has an Id – a string, Primary Key
        //•	Has a Description – a string with min length 5 (required)
        //•	Has a IsFixed – a bool indicating if the issue has been fixed or not (required)
        //•	Has a CarId – a string (required)
        //•	Has Car – a Car object

    }
}