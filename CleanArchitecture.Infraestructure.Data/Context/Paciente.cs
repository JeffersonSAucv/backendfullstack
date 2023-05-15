using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class Paciente
{
    public int IPacienteId { get; set; }

    public string VcDocumento { get; set; } = null!;

    public string VcNombres { get; set; } = null!;

    public int Edad { get; set; }

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();
}
