using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class InvoiceDetails
    {
        public static readonly Double TAX = 0.12;

        public Dictionary<Int16, Object[]> Products;  // <Product.Id, [quantity, price, name]>
        public Double Subtotal { get; set; }
        public Double Taxes { get; set; }
        public Double Discount { get; set; }
        public Double Total { get; set; }


        public InvoiceDetails()
        {
            Products = new Dictionary<Int16, Object[]>();
        }

        public InvoiceDetails(Dictionary<Int16, Object[]> products)
        {
            Products = products;
            if (Products.Count>0)
            {
                try
                {
                 foreach (var item in Products)
                    {
                        Object[] value = item.Value;
                        Subtotal += (int)value[0] * (Double)value[1];
                                            }
                    Taxes = Subtotal * TAX;
                    Discount = 10; // TODO coupons
                    Total = Subtotal + Taxes - Discount;

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                throw new EmptyShoppingCartException("Empty ShoppingCart");
            }

        }

    }
}
