using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public class DapperJoinedTableRepository: IDapperJoinedTableRepository
    {
        private NpgsqlConnection connection;
        private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=6p9xsyrqgc;Database=shop";
        public DapperJoinedTableRepository()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        public async Task<IEnumerable<JoinedTable>> GetJoinedTable(string commandText, int age, int id)
        {
            var queryAgs = new 
            {
                a = age,
                i = id
            };
            var result = await connection.QueryAsync<JoinedTable>(commandText, queryAgs);
            return result;
        }
    }
}
