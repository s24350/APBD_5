﻿using Zadanie7.Models;

namespace Zadanie7.Interfaces
{
    public interface ITripsRepository
    {
        Task<IEnumerable<TripDTO>> GetTripsAsync();

    }
}
