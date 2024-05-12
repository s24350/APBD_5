using System;
using System.Collections.Generic;

namespace Zadanie7.ContextModels;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal Rating { get; set; }

    public int Reviews { get; set; }

    public int Price { get; set; }

    public string Published { get; set; } = null!;

    public string Genre { get; set; } = null!;
}
