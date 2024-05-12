namespace Zadanie7.Interfaces
{
    public interface ITripsRepository
    {
        Task<IEnumerable<Models.TripDTO>> GetTripsAsync();
    }
}
