using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
   public class CarAllViewModel
    {
        public string Id { get; set; }

        public int Year { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssue { get; set; }

        public string ImageUrl { get; set; }


    }
}
