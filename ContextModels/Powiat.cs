using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Powiat
{
    public int Id { get; set; }

    public string Powiat1 { get; set; } = null!;

    public string WojewodztwoNazwa { get; set; } = null!;

    public virtual ICollection<Miejscowosc> Miejscowoscs { get; set; } = new List<Miejscowosc>();

    public virtual Wojewodztwo WojewodztwoNazwaNavigation { get; set; } = null!;
}
