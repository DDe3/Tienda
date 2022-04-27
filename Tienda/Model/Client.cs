using Tienda.Repository;

namespace Tienda
{
    public class Client
    {
        public Int16? Id { set; get; }

        public String Number { set; get; }
        public String? Name { set; get; }
        public String? LastName { set; get; }
        public DateTime? FirstPurchase { set; get; }
        public DateTime? LastPurchase { set; get; }

        public List<Invoice>? Purchases;

        public Client()
        {
            Purchases = new List<Invoice>();
        }

        public Client(short id, string number, string name, string lastName)
        {
            this.Id = id;
            this.Number = number;
            this.Name = name;
            this.LastName = lastName;
            this.Purchases = new List<Invoice>();
        }

        public void AddPurchase(Invoice invoice)
        {
            if (FirstPurchase == null)
            {
                this.FirstPurchase = DateTime.Now;
            }
            this.LastPurchase = DateTime.Now;
            this.Purchases.Add(invoice);
        }

        public Client GetClientById(Int16 id)
        {
            return JsonClient.GetClientById(id);
        }
    }
}
