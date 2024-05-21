using Microsoft.EntityFrameworkCore;
using Zadanie7.ContextModels;
using Zadanie7.Interfaces;
using Zadanie7.Models;

namespace Zadanie7.Repositories
{
    public class TripRepository : ITripsRepository
    {
        private readonly S24350Context _context;

        public TripRepository(S24350Context context) { 
            _context = context;
        }

        public async Task<IEnumerable<TripDTO>> GetTripsAsync() {
           
            var result = await _context
                .Trips
                .Select(e =>
                new TripDTO
                {
                    //precyzuje tu interesujacy mnie format
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Countries = e.IdCountries
                        .Select(e =>
                        new CountryDTO {Name = e.Name}),
                    Clients = e.ClientTrips
                        .Select(e=> new ClientDTO { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName})
                }).ToListAsync();
            
            return result;
        }

    }
}