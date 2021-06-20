using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModel
{
   public class CarWithIssuesViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }


        public ICollection<IssueViewModel> Issues { get; set; } = new List<IssueViewModel>();
    }
}
