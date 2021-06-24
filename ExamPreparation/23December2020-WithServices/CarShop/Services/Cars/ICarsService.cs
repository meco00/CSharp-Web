using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
  public interface ICarsService
    {
        void CreateCar(string model, int year, string image, string plateNumber, string userId);

        
            

    }
}
