using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ITrabajadorRepository
    {
        Task<List<Trabajador>> listaBusquedaTrabajador(string? numeroDocumento);
        Task<int> Insert(Trabajador trabajador);
        Task<List<TrabajadorDto>> ObtenerTrabajador();


        //void UpdateFieldsSave(Compra compra);

        //Task Delete(int id);
    }
}
