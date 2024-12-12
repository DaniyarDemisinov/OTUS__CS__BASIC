using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public interface IDapperOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync(string commandText);
        Task<IEnumerable<Orders>> GetOrdersWhereAsync(string commandText, int num1, int num2, int num3, int num4);
    }
}
