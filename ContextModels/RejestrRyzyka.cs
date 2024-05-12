using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class RejestrRyzyka
{
    public int Id { get; set; }

    public string NazwaRyzyka { get; set; } = null!;

    public DateTime DataRejestracji { get; set; }

    public string Status { get; set; } = null!;

    public short Poziom { get; set; }

    public int ProjektId { get; set; }

    public virtual Projekt Projekt { get; set; } = null!;
}
