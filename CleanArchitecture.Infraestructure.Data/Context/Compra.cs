using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class Compra
{
    public int Id { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? RazonSocial { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; } = new List<DetalleCompra>();
}
