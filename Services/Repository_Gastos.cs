using Dapper;
using estudo_aspnet_core6.Models;
using Microsoft.Data.SqlClient;

namespace estudo_aspnet_core6.Services
{
    public interface IRepository_Gastos
    {
        Task Criar(Gasto gasto);
    }

    public class Repository_Gastos : IRepository_Gastos
    {

        private readonly string connectionString;

        public Repository_Gastos (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Criar(Gasto gasto)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"INSERT INTO TB_Gastos (Nome,Valor,DiaGasto) Value (@Nome,@Valor,@DiaGasto);", gasto);
        }

    }
}
