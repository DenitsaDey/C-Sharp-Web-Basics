using SharedTrip.ViewModels.Trip;
using SharedTrip.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserInputModel input);

        ICollection<string> ValidateTrip(RegisterTripInputModel input);
    }
}
