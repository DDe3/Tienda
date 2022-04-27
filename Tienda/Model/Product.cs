using System.Text;
using Tienda.Exceptions;
using Tienda.Repository;

namespace Tienda
{
    public enum Category
    {
        Default,   // Categoria puede ser nulo si no necesita, o agregar más
    }

    public class Product
    {
        public Int16 Id { set; get; }
        public String Name { set; get; }
        public Category? Category { set; get; }
        public Int16 Stock { set; get; }
        public Double Price { set; get; }

        public Product() { }

        public Product(Int16 id, String name, Int16 stock, Double price, Category category = Tienda.Category.Default)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Stock = stock;
            this.Price = price;
        }

        public void ReduceStock(Int16 quantity)
        {
            if ((this.Stock - quantity) >= 0)
            {
                this.Stock -= quantity;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Out of stock on item: {this.Name} with id: {this.Id}");
                throw new OutofStockException(sb.ToString());
            }
        }

        public Product GetProductById(Int16 id)
        {
            return JsonProduct.GetProductById(id);
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            return JsonProduct.GetProductsByCategory(category);
        }
    }
}
