using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public abstract class Payment
    {
        public Double Total { get; set; }
        public Client client { get; set; }

        public abstract void Pay();
    }
}
