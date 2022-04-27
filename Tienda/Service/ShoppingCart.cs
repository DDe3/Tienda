namespace Tienda
{
    public class ShoppingCart
    {
        public Int16 ClientId;
        public Dictionary<Int16, Object[]> Products;


        public ShoppingCart(Int16 id)
        {
            this.ClientId = id;
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


    }
}
