using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool IsUserJoinedIn(string userId, string tripId)
        {
            return this.db.UsersTrips.Any(x => x.UserId == userId && x.TripId == tripId);
        }

        public bool AreThereAvailaleSeats(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId).Any(x => (x.Seats - x.UserTrips.Count) > 0);
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UsersTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public void Create(AddTripInputModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = input.DepartureTime,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new TripViewModel
            {
                Id = x.Id,
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime,
                AvailableSeats = x.Seats - x.UserTrips.Count(),
            }).ToList();

            return trips;
        }

        public TripDetailsVeiwModel GetDetails(string id)
        {
            var viewModel = this.db.Trips.Where(x => x.Id == id)
                .Select(x => new TripDetailsVeiwModel
                {
                    ImagePath = x.ImagePath,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("s"),
                    Seats = x.Seats - x.UserTrips.Count,
                    Description = x.Description,
                    Id = x.Id
                }).FirstOrDefault();

            return viewModel;
        }

       
    }
}
