﻿namespace Zadanie7.Models
{
    public class TripDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public int MaxPeople { get; set; }

        //public virtual

    }
}