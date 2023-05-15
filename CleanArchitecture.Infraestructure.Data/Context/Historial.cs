using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class Historial
{
    public int IHistorialId { get; set; }

    public string DtFecha { get; set; } = null!;

    public string VcArea { get; set; } = null!;

    public string VcMedico { get; set; } = null!;

    public string VcDescripcion { get; set; } = null!;

    public string VcHospital { get; set; } = null!;

    public int IPacienteId { get; set; }

    public virtual Paciente IPaciente { get; set; } = null!;
}
