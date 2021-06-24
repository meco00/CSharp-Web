using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
  public  class CarIssuesViewModel
    {
       

        public string Id { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public ICollection<IssuesViewModel> Issues { get; set; } = new List<IssuesViewModel>();

    }


}
