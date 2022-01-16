using Dapper;
using estudo_aspnet_core6.Models;
using Microsoft.Data.SqlClient;

namespace estudo_aspnet_core6.Services
{
    public interface IRepository_conta
    {
        Task Criar(Contas contas);
        Task<IEnumerable<Contas>> GetAll();
    }


    public class Repository_Conta : IRepository_conta
    {
        private readonly string connectionString;

        public Repository_Conta(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Criar(Contas contas)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"INSERT INTO TB_Contas(Nome,TipoContaId,Descricao,Balance) Values (@Nome,@TipoContaId,@Descricao,@Balance)", contas);
        }

        public async Task<IEnumerable<Contas>> GetAll()
        {
            using var connection = new SqlConnection();
            return await connection.QueryAsync<Contas>(@"SELECT CO.Nome,CO.Balance,TC.Nome FROM TB_Contas CO
                                                            INNER JOIN TB_TipoConta TC
                                                            ON TC.Id = CO.TipoContaId
                                                            ORDER BY TC.Nome") ;

        }



    }


    
}
