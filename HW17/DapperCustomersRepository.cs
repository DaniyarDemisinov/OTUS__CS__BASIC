using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    internal class DapperCustomersRepository : IDapperCustomersRepository
    {
        private NpgsqlConnection connection;
        private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=6p9xsyrqgc;Database=shop";
        public DapperCustomersRepository()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        public async Task<IEnumerable<Customers>> GetAllCustomersAsync(string comTxt)
        {
            var result = await connection.QueryAsync<Customers>(comTxt);
            return result;
        }
        public async Task<IEnumerable<Customers>> GetCustomersWhereAsync(string comTxt, int num1, int num2)
        {
            var queryArgs = new
            {
                a = num1,
                b = num2
            };
            var result = await connection.QueryAsync<Customers>(comTxt, queryArgs);
            return result;
        }
    }
}
