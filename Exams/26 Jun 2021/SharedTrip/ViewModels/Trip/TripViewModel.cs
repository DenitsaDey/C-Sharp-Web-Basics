using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.ViewModels.Trip
{
    public class TripViewModel
    {
        public string Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureTimeAsString => this.DepartureTime.ToString("dd.MM.yyyy HH:mm");
        public int AvailableSeats { get; set; }
    }
}
