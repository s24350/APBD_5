﻿using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<ProductWarehouse> ProductWarehouses { get; set; } = new List<ProductWarehouse>();
}
