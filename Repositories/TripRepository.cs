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

        public Task<IEnumerable<TripDTO>> GetTripsAsync() {
            var result = _context
                .Trips
                .Select(e =>
                new TripDTO
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Countries = e.IdCountries
                  .Select(e =>
                  new CountryDTO
                  {
                      Name = e.Name
                  }),
                    Clients = e.ClientsTrips
                    .Select
                });
               
        }

    }
}