using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Miejscowosc
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public int LiczbaMieszkancow { get; set; }

    public int PowiatId { get; set; }

    public virtual Powiat Powiat { get; set; } = null!;

    public virtual ICollection<Projekt> Projekts { get; set; } = new List<Projekt>();
}
