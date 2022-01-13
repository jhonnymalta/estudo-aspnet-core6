using Dapper;
using estudo_aspnet_core6.Models;
using Microsoft.Data.SqlClient;

namespace estudo_aspnet_core6.Services
{
    public interface IRepository_TipoConta
    {
        Task Criar(TipoConta tipoConta);
        Task<IEnumerable<TipoConta>> GetAll();
    }
    public class Repository_TipoConta : IRepository_TipoConta
    {
        private readonly string connectionString;
        public Repository_TipoConta(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //metodos crud
        public async Task Criar(TipoConta tipoConta)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO TB_TipoConta (Nome, UsuarioId,Ordem) VALUES (@Nome , @UsuarioId,0);
                                                    SELECT SCOPE_IDENTITY();",tipoConta);

            tipoConta.Id = id;
        }

        public async Task<IEnumerable<TipoConta>> GetAll()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoConta>("SELECT Nome FROM TB_TipoConta");

        }




    }
}
