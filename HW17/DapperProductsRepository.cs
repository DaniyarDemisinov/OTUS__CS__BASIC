using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public class DapperProductsRepository: IDapperProductsRepository
    {
        private NpgsqlConnection connection;
        private const string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=6p9xsyrqgc;Database=shop";
        public DapperProductsRepository()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }
        public async Task<IEnumerable<Products>> GetAllProductsAsync(string comTxt)
        {
            var result = await connection.QueryAsync<Products>(comTxt);
            return result;
        }
        public async Task<IEnumerable<Products>> GetProductsWhereAsync(string comTxt, double price)
        {
            var queryArgs = new
            {
                p = price
            };
            var result = await connection.QueryAsync<Products>(comTxt, queryArgs);
            return result;
        }
    }
}
