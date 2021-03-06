using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Trips
{
    public class TripViewModel
    {
        public string Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DepartureTimeAsString => this.DepartureTime.ToString("dd.MM.yyyy HH:mm");
        public int AvailableSeats { get; set; }
        //or
        //public int AvailableSeats => this.Seats - this.UsedSeats;
        //public byte Seats { get; set; }
        //public int UsedSeats { get; set; }
    }
}
