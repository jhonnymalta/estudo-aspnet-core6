using Dapper;
using estudo_aspnet_core6.Models;
using Microsoft.Data.SqlClient;

namespace estudo_aspnet_core6.Services
{
    public interface IRepository_TipoConta
    {
        Task Atualizar(TipoConta tipoConta);
        Task Criar(TipoConta tipoConta);
        Task Deletar(int id);
        Task<IEnumerable<TipoConta>> GetAll();
        Task<TipoConta> GetByID(int id, int usuarioId);
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
            return await connection.QueryAsync<TipoConta>("SELECT Id,Nome FROM TB_TipoConta");

        }
        public async Task Atualizar(TipoConta tipoConta)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE TB_TipoConta SET Nome = @Nome WHERE Id = @id", tipoConta);
        }
        public async Task<TipoConta> GetByID(int id,int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<TipoConta>(@"SELECT Id,Nome,Ordem From TB_TipoConta WHERE Id = @Id and UsuarioId = @UsuarioId", new {id,usuarioId});
        }

        public async Task Deletar(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"DELETE TB_TipoConta WHERE ID = @ID", new { id });
        }




    }
}
