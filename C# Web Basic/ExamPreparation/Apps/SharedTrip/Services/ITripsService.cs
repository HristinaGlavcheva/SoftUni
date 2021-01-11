using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(AddTripInputModel input);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsVeiwModel GetDetails(string id);

        void AddUserToTrip(string userId, string tripId);

        bool IsUserJoinedIn(string userId, string tripId);

        bool AreThereAvailaleSeats(string tripId);
    }
}
