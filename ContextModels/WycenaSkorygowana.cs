using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class WycenaSkorygowana
{
    public int Id { get; set; }

    public DateTime DataWycenySk { get; set; }

    public int WycenaId { get; set; }

    public int WskaznikiGusId { get; set; }

    public virtual WskaznikiGu WskaznikiGus { get; set; } = null!;

    public virtual Wycena Wycena { get; set; } = null!;
}
