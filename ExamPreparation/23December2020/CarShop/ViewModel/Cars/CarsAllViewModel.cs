using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModel
{
   public class CarsAllViewModel
    {
        public string Id { get; set; }

        public string PlateNumber { get; set; }

        public string ImageUrl { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }

    }
}
