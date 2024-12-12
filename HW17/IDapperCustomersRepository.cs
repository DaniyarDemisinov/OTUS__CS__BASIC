using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public interface IDapperCustomersRepository
    {
        Task<IEnumerable<Customers>> GetAllCustomersAsync(string commandText);
        Task<IEnumerable<Customers>> GetCustomersWhereAsync(string commandText, int num1, int num2);
    }
}
