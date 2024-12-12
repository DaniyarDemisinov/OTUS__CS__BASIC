using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace HW17
{
    public class DapperOrdersRepository: IDapperOrdersRepository
    {
        private NpgsqlConnection connection;
        private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=6p9xsyrqgc;Database=shop";
        public DapperOrdersRepository()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        public async Task<IEnumerable<Orders>> GetAllOrdersAsync(string comText)
        {
            var result = await connection.QueryAsync<Orders>(comText);
            return result;
        }
        public async Task<IEnumerable<Orders>> GetOrdersWhereAsync(string comText, int num1, int num2, int num3, int num4)
        {
            var queryArgs = new 
            {
                c1 = num1,
                c2 = num2,
                c3 = num3,
                p1 = num4
            };
            var result = await connection.QueryAsync<Orders>(comText, queryArgs);
            return result;
        }
    }
}
