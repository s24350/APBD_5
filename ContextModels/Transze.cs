using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Transze
{
    public int Id { get; set; }

    public int NrUruchomienia { get; set; }

    public DateTime DataUruchomienia { get; set; }

    public decimal Kwota { get; set; }

    public int ProjektId { get; set; }

    public string RodzajUruchNazwa { get; set; } = null!;

    public virtual Projekt Projekt { get; set; } = null!;

    public virtual RodzajUruch RodzajUruchNazwaNavigation { get; set; } = null!;
}
