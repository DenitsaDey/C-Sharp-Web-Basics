using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ITripsService tripsService;

        public TripsController(
            IValidator validator,
            ITripsService tripsService)
        {
            this.validator = validator;
            this.tripsService = tripsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        [Authorize]
        public HttpResponse Add() => this.View();


        [HttpPost]
        [Authorize]
        public HttpResponse Add(RegisterTripInputModel input)
        {
            var modelErrors = this.validator.ValidateTrip(input);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            this.tripsService.Create(input);
            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.tripsService.GetDetails(tripId);
            return this.View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("No seats avaialble!");
            }

            var userId = this.User.Id;
            if (!this.tripsService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
            this.tripsService.AddUserToTrip(userId, tripId);
            return this.Redirect("/Trips/All");
        }
    }
}
