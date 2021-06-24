using CarShop.Data;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext data;
        

        public CarsService(ApplicationDbContext data)
        {
            this.data = data;
            
        }

        public void CreateCar(string model, int year, string image, string plateNumber, string userId)
        {
            var car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = image,
                PlateNumber = plateNumber,
                OwnerId = userId

            };


            data.Cars.Add(car);

            data.SaveChanges();
        }
    }
}
