using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class ShoppingCart
    {
        public Dictionary<Int16, Object[]> Products;
        

        public ShoppingCart() 
        {
            Products = new Dictionary<Int16, Object[]>();
        }

        public void AddProduct(int quantity, Product product)
        {
            Object[] obj = { quantity, product.Price, product.Name };
            Products.Add(product.Id, obj);
        }

        public void RemoveProduct(Product product)
        {
            Object[] obj;
            if (Products.TryGetValue(product.Id, out obj))
            {
                Products.Remove(product.Id);
            }
        }

        public void RemoveQuantityOfProduct(int quantity, Product product)
        {
            Object[] obj;
            if (Products.TryGetValue(product.Id, out obj))
            {
                int checkQuantity = (int)obj[0] - quantity;
                int newQuantity = checkQuantity < 0 ? 0 : checkQuantity;
                obj[1] = newQuantity;
            }
        }

        public void Pay(Payment payment)
        {
            try
            {
                Invoice invoice = new();
                InvoiceDetails invoiceDetails = new(Products);
                invoice.Number = DateTime.Now.Millisecond.ToString();
                invoice.PurchaseDate = DateTime.Now;
                invoice.ClientNumber = payment.client.Number;
                invoice.TotalPrice = invoiceDetails.Total;
                invoice.InvoiceDetails = invoiceDetails;
                payment.Pay();
                payment.client.AddPurchase(invoice);

            } catch (Exception ex)
            {
                throw new PaymentException(ex.Message);
            }
            

        } 
    }
}
