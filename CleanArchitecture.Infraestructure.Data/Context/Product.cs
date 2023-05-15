using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? ProductType { get; set; }

    public decimal? Price { get; set; }
}
