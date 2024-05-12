using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class RodzajUruch
{
    public string Nazwa { get; set; } = null!;

    public decimal MaxKwota { get; set; }

    public virtual ICollection<Transze> Transzes { get; set; } = new List<Transze>();
}
