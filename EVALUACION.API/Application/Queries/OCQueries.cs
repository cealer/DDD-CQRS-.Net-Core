using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace EVALUACION.API.Application.Queries
{
    public class OCQueries : IOCQueries
    {
        private string _connectionString = string.Empty;

        public OCQueries(string constr, IHostingEnvironment env)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<OCViewModel>> ListarAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<OCViewModel>(
                   $@"SELECT [ID_HP_OC]
                    ,[N_ID_ESTADO]
                    ,[N_ID_PROVEEDOR]
                    ,[FECHA_REGISTRO]
                    FROM [EVALUACION_DB].[EVALUACION].[HP_OC]");

                return result;
            }
        }

        public async Task<OCViewModel> ObtenerOCAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<OCViewModel>(
                   $@"SELECT[ID_HP_OC]
                    ,[N_ID_ESTADO]
                    ,[N_ID_PROVEEDOR]
                    ,[FECHA_REGISTRO]
                    FROM [EVALUACION_DB].[EVALUACION].[HP_OC]                    
                    WHERE [ID_HP_OC]=@id", new { id });

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<OCViewModel>> ListarProductosAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<OCViewModel>(
                   $@"SELECT [ID_HP_OC]
                    ,[N_ID_ESTADO]
                    ,[N_ID_PROVEEDOR]
                    ,[FECHA_REGISTRO]
                    FROM [EVALUACION_DB].[EVALUACION].[HP_OC]");

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return result;
            }
        }
    }
}