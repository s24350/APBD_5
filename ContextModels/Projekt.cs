using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Projekt
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string? Portfel { get; set; }

    public string Status { get; set; } = null!;

    public int MiejscowoscId { get; set; }

    public virtual Miejscowosc Miejscowosc { get; set; } = null!;

    public virtual ICollection<RejestrRyzyka> RejestrRyzykas { get; set; } = new List<RejestrRyzyka>();

    public virtual ICollection<Transze> Transzes { get; set; } = new List<Transze>();

    public virtual ICollection<Wycena> Wycenas { get; set; } = new List<Wycena>();
}
