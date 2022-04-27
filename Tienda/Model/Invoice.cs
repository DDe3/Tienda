namespace Tienda
{
    public class Invoice
    {
        public Int32 Id { set; get; }
        public String Number { set; get; }
        public DateTime PurchaseDate { set; get; }
        public String ClientNumber { set; get; }
        public Double TotalPrice { set; get; }
        public InvoiceDetails InvoiceDetails { set; get; }

        public Invoice() { }

        public Invoice(short id, string number, string clientNumber, double totalPrice, InvoiceDetails invoiceDetails)
        {
            Id = id;
            Number = number;
            PurchaseDate = DateTime.Now;
            ClientNumber = clientNumber;
            TotalPrice = totalPrice;
            InvoiceDetails = invoiceDetails;
        }

    }
}
