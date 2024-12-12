using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public interface IPrint
    {
        void MakePrint(IEnumerable<Products> products);
        void MakePrint(IEnumerable<Customers> customers);
        void MakePrint(IEnumerable<Orders> orders);
    }
}
