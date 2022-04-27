using Newtonsoft.Json;
using Tienda.Exceptions;

namespace Tienda.Repository
{
    /*
     * Clase para simular una base de datos usando NewtonSoft.JSON 
     */
    public class JsonProduct
    {
        static String[] JSON_Products =
        {
            @"{'id': 142,
                                    'name': 'Producto Generico #1',
                                    'category': 'Categoria #1',
                                    'stock': 150,
                                    'price': 12.99
                                  }",
            @"{'id': 143,
                                    'name': 'Producto Generico #2',
                                    'category': 'Categoria #2',
                                    'stock': 10,
                                    'price': 9.99
                                  }",
            @"{'id': 144,
                                    'name': 'Producto Generico #3',
                                    'category': 'Categoria #3',
                                    'stock': 40,
                                    'price': 299.99
                                  }"
    };

        public static List<Product> GetAllProducts()
        {
            List<Product> ProductList = new List<Product>();
            foreach (String json in JSON_Products)
            {
                Product? product = JsonConvert.DeserializeObject<Product>(json);
                if (product != null)
                {
                    ProductList.Add(product);
                }
            }
            return ProductList;
        }

        public static Product GetProductById(Int16 id)
        {
            List<Product> AllProducts = GetAllProducts();
            foreach (var product in AllProducts)
            {
                if (product.Id.Equals(id))
                {
                    return product;
                }
            }
            throw new ProductNotFoundException(id.ToString());
        }

        public static List<Product> GetProductsByCategory(Category category)
        {
            return GetAllProducts().Where(x => x.Category == category).ToList();
        }

    }

}
