using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Magazyn
{
    public int? IdPozycji { get; set; }

    public string? Nazwa { get; set; }

    public int? Ilosc { get; set; }
}
