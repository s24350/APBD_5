using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

namespace Zadanie7.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripControllers : ControllerBase
    {
        private readonly ITripsRepository _tripsRepository;

        public TripControllers(ITripsRepository tripsRepository) {
            _tripsRepository = tripsRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetTrips() {

        //}

    }
}
