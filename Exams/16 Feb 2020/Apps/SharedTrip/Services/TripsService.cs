using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;
        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);
            if (userInTrip)
            {
                return;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };
            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                 .Select(x => new { x.Seats, TakenSears = x.UserTrips.Count() })
                 .FirstOrDefault();
            var availableSeats = trip.Seats - trip.TakenSears;
            if(availableSeats <= 0)
            {
                return false;
            }
            return true;
            //or shorter return availableSeats > 0;
        }

        public void Create(AddTripInputModel trip)
        {
            var dbTrip = new Trip
            {
                DepartureTime = DateTime.ParseExact(
                                trip.DepartureTime,
                                "dd.MM.yyyy HH:mm",
                                CultureInfo.InvariantCulture),
                Description = trip.Description,
                EndPoint = trip.EndPoint,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats,
                StartPoint = trip.StartPoint
            };
            this.db.Trips.Add(dbTrip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var tripsAvailable = this.db.Trips.Select(x => new TripViewModel
            {
                DepartureTime = x.DepartureTime,
                EndPoint = x.EndPoint,
                StartPoint = x.StartPoint,
                Id = x.Id,
                AvailableSeats = x.Seats - x.UserTrips.Count(),
            })
                .ToList();
            return tripsAvailable;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            var trip = this.db.Trips.Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    AvailableSeats = x.Seats - x.UserTrips.Count(),
                    StartPoint = x.StartPoint,
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
