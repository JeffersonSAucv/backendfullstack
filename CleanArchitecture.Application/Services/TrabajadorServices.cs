using Agritracer.Application.OutputObjets;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services
{
    public class TrabajadorServices : ITrabajadorServices
    {
        protected ITrabajadorRepository _trabajadorRepository { get; set; }
        public TrabajadorServices(DbContext context, string connectionString)
        {
            _trabajadorRepository = new TrabajadorRepository(context, connectionString);
        }
        public async Task<List<Trabajador>> ListaBusquedaTrabajador(string? numeroDocumento)
        {
            return await _trabajadorRepository.listaBusquedaTrabajador(numeroDocumento);
        }
        public async Task<int> Insert(Trabajador trabajador)
        {
            return await _trabajadorRepository.Insert(trabajador);
        }

        public async Task<List<TrabajadorDto>> ObtenerTrabajador()
        {
            return await _trabajadorRepository.ObtenerTrabajador();
        }

        public async Task<OutResultData<TrabajadorDto>> CRUD(TrabajadorDto entity)
        {
            return await this._trabajadorRepository.CRUD(entity);
        }

        //public void UpdateFieldsSave(Compra compra)
        //{
        //    _trabajadorRepository.UpdateFieldsSave(compra);
        //}
        //public async Task Delete(int id)
        //{
        //    await _trabajadorRepository.Delete(id);
        //}
    }
}
