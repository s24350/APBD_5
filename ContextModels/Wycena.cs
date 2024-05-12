using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Wycena
{
    public int Id { get; set; }

    public DateTime DataWyceny { get; set; }

    public decimal Pum { get; set; }

    public decimal Puu { get; set; }

    public string Etap { get; set; } = null!;

    public int ProjektId { get; set; }

    public decimal SredniaLiczbaKond { get; set; }

    public decimal Wartosc { get; set; }

    public virtual Projekt Projekt { get; set; } = null!;

    public virtual ICollection<WycenaSkorygowana> WycenaSkorygowanas { get; set; } = new List<WycenaSkorygowana>();
}
