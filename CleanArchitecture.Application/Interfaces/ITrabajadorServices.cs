using Agritracer.Application.OutputObjets;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ITrabajadorServices
    {
        Task<List<Trabajador>> ListaBusquedaTrabajador(string? numeroDocumento);
        Task<int> Insert(Trabajador trabajador);
        Task<List<TrabajadorDto>> ObtenerTrabajador();
        Task<OutResultData<TrabajadorDto>> CRUD(TrabajadorDto entity);


        //void UpdateFieldsSave(Compra compra);

        //Task Delete(int id);
    }
}
