using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Wojewodztwo
{
    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Powiat> Powiats { get; set; } = new List<Powiat>();
}
