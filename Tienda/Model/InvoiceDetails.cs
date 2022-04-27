using Tienda.Exceptions;

namespace Tienda
{
    public class InvoiceDetails
    {

        public Dictionary<Int16, Object[]> Products;  // <Product.Id, [quantity, price, name]>
        public Double Subtotal { get; set; }
        public Double Taxes { get; set; }
        public Double Discount { get; set; }
        public Double Total { get; set; }


        public InvoiceDetails()
        {
            Products = new Dictionary<Int16, Object[]>();
        }

        public InvoiceDetails(Dictionary<short, object[]> products, double subtotal, double taxes, double discount, double total)
        {
            Products = products;
            Subtotal = subtotal;
            Taxes = taxes;
            Discount = discount;
            Total = total;
        }
    }
}
