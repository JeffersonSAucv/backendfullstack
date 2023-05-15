using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class RegistroMarcacion
{
    public int IRegistroMarcacion { get; set; }

    public int? ITrabajadorId { get; set; }

    public DateTime? DtFechaRegistro { get; set; }

    public int? IIngresoSalida { get; set; }

    public DateTime? DtFechaHoraMarcacion { get; set; }
}
