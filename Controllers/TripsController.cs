using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;
using Zadanie7.Models;

namespace Zadanie7.Controllers
{
    [Route("api/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsRepository _tripsRepository;

        public TripsController(ITripsRepository tripsRepository) {
            _tripsRepository = tripsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips() {
            try
            {
                var result = await _tripsRepository.GetTripsAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddTripToClient([FromRoute] int idTrip, [FromBody] AddTripToClientRequestDTO dto)
        {
            try
            {
                await _tripsRepository.AddTripToClientAsync(idTrip, dto);
                return Ok("Request ok.");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        
    }
}
