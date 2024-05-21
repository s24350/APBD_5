﻿using Microsoft.AspNetCore.Mvc;
using Zadanie7.Interfaces;

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
            var result = await _tripsRepository.GetTripsAsync();
            return Ok(result);
        }
        
    }
}
