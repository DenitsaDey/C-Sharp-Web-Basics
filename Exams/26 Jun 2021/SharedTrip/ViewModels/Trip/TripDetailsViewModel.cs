using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.ViewModels.Trip
{
    public class TripDetailsViewModel : TripViewModel
    {
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string DepartureTimeFormatted => this.DepartureTime.ToString("s");
    }
}
