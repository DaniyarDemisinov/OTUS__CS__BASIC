using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public interface IDapperProductsRepository
    {
        Task<IEnumerable<Products>> GetAllProductsAsync(string commandText);
        Task<IEnumerable<Products>> GetProductsWhereAsync(string commandText, double price);
    }
}
