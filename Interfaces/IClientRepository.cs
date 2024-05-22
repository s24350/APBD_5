using Microsoft.AspNetCore.Mvc;

namespace Zadanie7.Interfaces
{
    public interface IClientRepository
    {
        Task DeleteClientAsync(int idClient);
    }
}
