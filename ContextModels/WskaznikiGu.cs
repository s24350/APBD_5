using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class WskaznikiGu
{
    public int Id { get; set; }

    public decimal Wartosc { get; set; }

    public virtual ICollection<WycenaSkorygowana> WycenaSkorygowanas { get; set; } = new List<WycenaSkorygowana>();
}
