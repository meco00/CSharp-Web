using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebDemo.Data
{
    public class DbContext
    {
        public IEnumerable<Cat> GetCats()
            => new List<Cat>()
            {
                new Cat
              {
                    Id=1,
                    Name="Sharo",
                    Age=2,
                    Owner=new Owner()
                    {
                        Id=1,
                        Name="Pesho"
                    }

                },
                   new Cat
              {
                    Id=2,
                    Name="Baro",
                    Age=3,
                    Owner=new Owner()
                    {
                        Id=2,
                        Name="Pesho"
                    }

                }


        };
    }
}
