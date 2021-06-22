using CarShop.Data;
using CarShop.Data.Models;
using CarShop.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarShop.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext db;
        public CarsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCar(CarInputModel input, string userId)
        {
            var newCar = new Car
            {
                Model = input.Model,
                Year = input.Year,
                PictureUrl = input.Image,
                PlateNumber = input.PlateNumber,
                OwnerId = userId,
                Owner = this.db.Users.FirstOrDefault(u=>u.Id == userId)
            };

            this.db.Cars.Add(newCar);
            this.db.SaveChanges();
        }

        

        public IEnumerable<CarViewModel> GetAll(string userId)
        {
            var carsAvailable = new List<CarViewModel>();
            var currentUser = this.db.Users.FirstOrDefault(u => u.Id == userId);

            if (currentUser.IsMechanic)
            {
                carsAvailable = this.db.Cars
                    .Where(x => x.Issues.Where(i => !i.IsFixed).Count() > 0)
                    .Select(x => new CarViewModel
                    {
                        Id = x.Id,
                        Model = x.Model,
                        Year = x.Year,
                        Image = x.PictureUrl,
                        PlateNumber = x.PlateNumber,
                        FixedIssues = x.Issues.Where(i => i.IsFixed).Count(),
                        RemainingIssues = x.Issues.Where(i => !i.IsFixed).Count()
                    })
                .ToList();
            }
            else
            {
                carsAvailable = this.db.Cars
                    .Where(c => c.OwnerId == userId)
                    .Select(x => new CarViewModel
                    {
                        Id = x.Id,
                        Model = x.Model,
                        Year = x.Year,
                        Image = x.PictureUrl,
                        PlateNumber = x.PlateNumber,
                        FixedIssues = x.Issues.Where(i => i.IsFixed).Count(),
                        RemainingIssues = x.Issues.Where(i => !i.IsFixed).Count()
                    })
                .ToList();
            }

            return carsAvailable;
        }
    }
}
