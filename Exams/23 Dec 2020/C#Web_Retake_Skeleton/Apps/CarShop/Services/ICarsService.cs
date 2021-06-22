using CarShop.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void AddCar(CarInputModel input, string ownerId);

       
        IEnumerable<CarViewModel> GetAll(string userId);
    }
}
