namespace Tienda.Exceptions
{
    public class OutofStockException : Exception
    {
        public OutofStockException(string msg) : base(msg) { }
    }

    public class PaymentException : Exception
    {
        public PaymentException(string msg) : base("Error during payment: \nCause:" + msg)
        {

        }
    }

    public class EmptyShoppingCartException : Exception
    {
        public EmptyShoppingCartException(string msg) : base(msg) { }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string msg) : base(msg + "\nCould not find any product with the given id: " + msg)
        {

        }
    }

    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string msg) : base(msg + "\nCould not find any registered client with the given id: " + msg)
        {

        }
    }

}
