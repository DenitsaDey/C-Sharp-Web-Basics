using SharedTrip.ViewModels.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(RegisterTripInputModel trip);
        IEnumerable<TripViewModel> GetAll();

        TripDetailsViewModel GetDetails(string id);

        bool HasAvailableSeats(string tripId);
        bool AddUserToTrip(string userId, string tripId);
    }
}
