using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.ViewModels
{
   public class RepositoryCreateViewModel
    {
        public string Name { get; set; }

        public string RepositoryType { get; set; }



        //Has a Name – a string with min length 3 and max length 10 (required)
    }
}
