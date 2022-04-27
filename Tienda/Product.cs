using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public enum Category
    {
        Cleaning,
        Home,
        Pets,
        Food,
        Beverages,
    }

    public class Product
    {
        public Int16 Id { set; get; }
        public String Barcode { set; get; }
        public String Name { set; get; }
        public Category Category { set; get; }
        public Int16 Stock { set; get; }
        public Double Price { set; get; }

        public Product() { }

        public Product(Int16 id, String barcode, String name, Category category, Int16 stock, Double price)
        {
            this.Id = id;
            this.Barcode = barcode;
            this.Name = name;
            this.Category = category;
            this.Stock = stock;
            this.Price = price;
        }

        public void ReduceStock(Int16 quantity)
        {
            if ((this.Stock - quantity) >= 0 )
            {
                this.Stock -= quantity;
            } else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Out of stock on item: {this.Name} with id: {this.Id}");
                throw new OutofStockException(sb.ToString());
            }
        }
    }
}
