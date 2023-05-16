using Agritracer.Application.OutputObjets;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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

        public Task<OutResultData<TrabajadorDto>> CRUD(TrabajadorDto trabajador)
        {
            return Task.Run(() =>
            {
                OutResultData<TrabajadorDto> resultData = new OutResultData<TrabajadorDto>();
                String msgRespuesta = "";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", trabajador.Id);
                parameters.Add("@dni", trabajador.dni);
                parameters.Add("@apellidoMaterno", trabajador.apellidoMaterno);
                parameters.Add("@apellidoPaterno", trabajador.apellidoPaterno);
                parameters.Add("@nombre", trabajador.nombre);
                parameters.Add("@fechaNacimiento", trabajador.fechaNacimiento);
                parameters.Add("@sexo", trabajador.sexo);
                parameters.Add("@direccion", trabajador.direccion);
                parameters.Add("@telefono", trabajador.telefono);
                parameters.Add("@correo", trabajador.correo);
                parameters.Add("@procedencia", trabajador.procedencia);
                parameters.Add("@fechaIngreso", trabajador.fechaIngreso);
                parameters.Add("@accion", trabajador.accion);
                parameters.Add("@resultado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                using var connection = new SqlConnection(_connectionString);
                connection.OpenAsync();
                try
                {
                    connection.Execute("usp_app_CRUD_trabajadores", parameters, commandType: CommandType.StoredProcedure);
                    connection.CloseAsync();
                    Int32 resultado = parameters.Get<Int32>("@resultado");
                    String mensaje = parameters.Get<String>("@mensaje");

                    resultData.statusCode = resultado;
                    resultData.message = mensaje;

                }
                catch (Exception ex)
                {
                    resultData.statusCode = -1;
                    resultData.message = ex.Message;
                }

                return resultData;
            });
        }
    }
}
