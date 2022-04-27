using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class PaymentException : Exception
    {
        public PaymentException(string msg) : base("Error during payment: \nCause:" + msg) 
        { 

        }
    }
}
