using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Dtos
{
    public class TrabajadorDto
    {
        public int Id { get; set; }

        public string dni { get; set; }

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombre { get; set; }
        public string fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string procedencia { get; set; }
        public string fechaIngreso { get; set; }

    }
}
