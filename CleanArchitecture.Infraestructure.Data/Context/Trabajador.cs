using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class Trabajador
{
    public int ITrabajadorId { get; set; }

    public string? VcDni { get; set; }

    public string? VcApellidoPaterno { get; set; }

    public string? VcApellidoMaterno { get; set; }

    public string? VcNombre { get; set; }

    public DateTime? DtFechaNacimiento { get; set; }

    public string? VcSexo { get; set; }

    public string? VcDireccion { get; set; }

    public string? VcTelefono { get; set; }

    public string? VcCorreo { get; set; }

    public string? VcProcedencia { get; set; }

    public DateTime? DtFechaIngreso { get; set; }
}
