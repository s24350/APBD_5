using Microsoft.EntityFrameworkCore;
using Zadanie7.ContextModels;
using Zadanie7.Interfaces;

namespace Zadanie7.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly S24350Context _context;

        public ClientRepository(S24350Context context) { 
            this._context = context;
        }

        public async Task DeleteClientAsync(int idClient)
        {
            bool hasTrips = await _context.ClientTrips.AnyAsync(row => row.IdClient == idClient);

            if (hasTrips) throw new Exception("Client has one or more trips.");

            Client client = await _context.Clients.Where(row => row.IdClient == idClient).FirstOrDefaultAsync();
            _ = _context.Remove(client);
            //discards to create dummy variables, defined by the underscore character _. Discards are equal to unassigned variables.
            //The purpose of this feature is to use this variable when you want to intentionally skip the value by not creating a variable explicitly
            await _context.SaveChangesAsync();
        }
    }
}
