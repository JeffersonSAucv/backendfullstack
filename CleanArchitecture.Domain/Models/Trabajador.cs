using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models;

public partial class Trabajador
{
 
    public int i_trabajador_id { get; set; }

    public string? vc_dni { get; set; }

    public string? vc_apellido_paterno { get; set; }
    public string? vc_apellido_materno { get; set; }
    public string? vc_nombre { get; set; }
    public DateTime? dt_fecha_nacimiento { get; set; }
    public string? vc_sexo { get; set; }
    public string? vc_direccion { get; set; }
    public string? vc_telefono { get; set; }
    public string? vc_correo { get; set; }
    public string? vc_procedencia { get; set; }
    public DateTime? dt_fecha_ingreso { get; set; }

}
