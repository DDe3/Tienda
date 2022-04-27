using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class EmptyShoppingCartException : Exception
    {
        public EmptyShoppingCartException(string msg) : base(msg) { }
    }
}
