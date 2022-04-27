using Tienda.Exceptions;
using Tienda.Repository;
using Tienda.Service;

namespace Tienda.Business
{
    public class Purchase
    {
        public static readonly Double TAX = 0.12;
        IPayment payment;

        public void PurchaseProducts(ShoppingCart cart)
        {
            try
            {
                Client? client = JsonClient.GetClientById(cart.ClientId);
                Invoice invoice = new();
                Double subtotal = GetSubTotal(cart.Products);
                Double taxes = subtotal * TAX;
                Double total = subtotal + taxes;
                InvoiceDetails invoiceDetails = new(cart.Products,subtotal,taxes,0,total);
                invoice.Number = DateTime.Now.Millisecond.ToString();
                invoice.PurchaseDate = DateTime.Now;
                invoice.ClientNumber = client.Number;
                invoice.TotalPrice = invoiceDetails.Total;
                invoice.InvoiceDetails = invoiceDetails;
                payment.Pay();
                client.AddPurchase(invoice);
            }
            catch (Exception ex)
            {
                throw new PaymentException(ex.Message);
            }


        }

        public Double GetSubTotal(Dictionary<Int16, Object[]> products)
        {
            if (products.Count > 0)
            {
                Double Subtotal = 0;
                try
                {
                    foreach (var item in products)
                    {
                        Object[] value = item.Value;
                        short quantity = (short)value[0];
                        Subtotal += quantity * (Double)value[1];
                        Product p = new Product();
                        p = p.GetProductById(item.Key);
                        p.ReduceStock(quantity);
                    }
                    return Subtotal;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new EmptyShoppingCartException("Empty Shopping Cart!");
            }
        }
    }
}
