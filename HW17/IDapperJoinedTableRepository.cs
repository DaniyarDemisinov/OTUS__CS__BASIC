using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public interface IDapperJoinedTableRepository
    {
        Task<IEnumerable<JoinedTable>> GetJoinedTable(string comTxt, int age, int id);
    }
}
