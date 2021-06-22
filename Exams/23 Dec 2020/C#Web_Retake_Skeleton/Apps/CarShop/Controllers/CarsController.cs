using CarShop.Data;
using CarShop.Services;
using CarShop.ViewModels.Car;
using Microsoft.AspNetCore.Authorization;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService carsService;
        private readonly IUsersService usersService;

        public CarsController(ICarsService carsService, IUsersService usersService)
        {
            this.carsService = carsService;
            this.usersService = usersService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string userId = this.GetUserId();
            if (this.usersService.UserIsMechanic(userId))
            {
                return this.Error("Mechanics cannot add cars.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CarInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string userId = this.GetUserId();
            if (this.usersService.UserIsMechanic(userId))
            {
                return this.Error("Mechanics cannot add cars.");
            }
            if (string.IsNullOrEmpty(input.Model) ||
                input.Model.Length < 5 ||
                input.Model.Length > 20)
            {
                return this.Error("Model is required");
            }

            if (input.Year < 1900 || input.Year > (int)DateTime.UtcNow.Year)
            {
                return this.Error("Year is not valid.");
            }

            if (string.IsNullOrEmpty(input.Image) ||
                !Uri.IsWellFormedUriString(input.Image, UriKind.Absolute))
            {
                return this.Error("A valid image url is required.");
            }
            if (!Regex.IsMatch(input.PlateNumber, @"^[A-Z]{2}[0-9]{4}[A-Z]{2}$") ||
                input.PlateNumber.Length != 8)
            {
                return this.Error("Plate number must bevalid");
            }

            this.carsService.AddCar(input, userId);
            return this.Redirect("/Cars/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            string userId = this.GetUserId();
            var cars = this.carsService.GetAll(userId);
            return this.View(cars);
        }
    }
}
