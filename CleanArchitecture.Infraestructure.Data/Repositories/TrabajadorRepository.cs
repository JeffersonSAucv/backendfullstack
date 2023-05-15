using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Repositories
{
    public class TrabajadorRepository : RepositoryTrabajadorEF<Trabajador>, ITrabajadorRepository
    {
        protected readonly string _connectionString;
        public TrabajadorRepository(DbContext context, string connectionString) : base(context)
        {
            repositoryTrabajadorEF = new RepositoryTrabajadorEF<Trabajador>(context);
            _connectionString = connectionString;
        }
        public IRepositoryTrabajadorEF<Trabajador> repositoryTrabajadorEF { get; set; }

        public async Task<List<Trabajador>> listaBusquedaTrabajador(string? vc_dni)
        {
            var listaBusqueda = new List<Trabajador>();
            listaBusqueda = await repositoryTrabajadorEF.ObtenerList<Trabajador>(a => (a.vc_dni == vc_dni || string.IsNullOrEmpty(vc_dni)));
            return listaBusqueda;
        }
        public async Task<int> Insert(Trabajador trabajador)
        {
            return await repositoryTrabajadorEF.Insert(trabajador);
        }

        public async Task<List<TrabajadorDto>> ObtenerTrabajador()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var parameters = new DynamicParameters();
            var resultado = await connection.QueryAsync<TrabajadorDto>("sp_lista_trabajadores", parameters, commandType: CommandType.StoredProcedure);
            var listTrabajador = resultado.Cast<TrabajadorDto>().ToList();
            await connection.CloseAsync();
            return listTrabajador;
        }
    }
}
