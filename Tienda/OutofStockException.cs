using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class OutofStockException : Exception
    {
        public OutofStockException(string msg) : base(msg) { }
    }
}
