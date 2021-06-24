using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CarShop.Data.Models.DataConstants;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserMaxLength)]
        public string Model { get; set; }


        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(PlateNumberMaxLength)]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId {get;set;}

        public User Owner {get;set;}


        public ICollection<Issue> Issues { get; init; } = new List<Issue>();
    }
}
