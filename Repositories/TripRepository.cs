using Microsoft.AspNetCore.Mvc;
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
                }).OrderBy(e=>e.DateFrom).ToListAsync();
            
            return result;
        }

        public async Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDTO dto)
        {
            //Czy klient o danym numerze PESEL istnieje
            bool clientExists = await _context.Clients.AnyAsync(r => r.Pesel == dto.Pesel);

            Client wantedClient;
            //jesli klient nie istnieje ...
            if (!clientExists)
            {
                //... to tworzymy klienta ...
                wantedClient = new Client
                {
                    IdClient = await _context.Clients.Select(row => row.IdClient).MaxAsync() + 1,
                    FirstName = dto.FisrtName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Telephone = dto.Telephone,
                    Pesel = dto.Pesel
                };

                //... i dodajemy go do bazy danych
                await _context.Clients.AddAsync(wantedClient);
                // faktyczny insert na bazie danych
                await _context.SaveChangesAsync();
            }
            else
            { 
                //w przeciwnym przypadku klient to ten klient, ktorego pesel pokrywa sie z peselem z dto
                wantedClient = await _context.Clients.FirstOrDefaultAsync(row=> row.Pesel == dto.Pesel);
            }
            
            //sprawdzenie czy wycieczka o podanym id istnieje, jesli nie to exception
            bool TripExists = await _context.Trips.AnyAsync(row => row.IdTrip == idTrip);
            if (!TripExists) throw new Exception($"There is no trip with id: {idTrip}!");

            //sprawdzenie czy wycieczka jest juz przypisana do danego klienta
            bool clientAlreadyReservedThisTrip = await _context.ClientTrips.AnyAsync(row => row.IdClient == wantedClient.IdClient && row.IdTrip == idTrip);
            if (clientAlreadyReservedThisTrip) throw new Exception("Trip already reserved by this client");

            //dodanie wiersza do tabeli KlientWycieczka
            await _context.ClientTrips.AddAsync(new ClientTrip
            {
                IdClient = wantedClient.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = dto.PaymentDate
            });
            await _context.SaveChangesAsync();
        }
    }
}