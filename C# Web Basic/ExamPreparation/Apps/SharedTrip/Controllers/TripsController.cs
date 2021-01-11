using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var tripViewModel = this.tripsService.GetAll();
            return this.View(tripViewModel);
        }

        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Start point is required.");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End point is required.");
            }

            if (string.IsNullOrEmpty(input.DepartureTime.ToString("dd.MM.yyyy HH:mm")))
            {
                return this.Error("Invalid departure time.");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats shoud be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 80)
            {
                return this.Error("Descripiton is required and should be up to 80 characters long.");
            }

            
            this.tripsService.Create(input);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {

            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.tripsService.GetDetails(tripId);
            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var userId = this.GetUserId();

            if (this.tripsService.IsUserJoinedIn(userId, tripId))
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (!this.tripsService.AreThereAvailaleSeats(tripId))
            {
                return this.Error("There are not available seats for this trip.");
            }

            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/Trips/All");
        }
    }
}
