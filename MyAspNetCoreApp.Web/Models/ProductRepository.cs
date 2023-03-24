namespace MyAspNetCoreApp.Web.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "Iphone 13 256gb", Price = 31000, Stock = 10 },
            new () { Id = 2, Name = "Iphone 13 Pro Max 1TB", Price = 44000, Stock = 15 },
            new () { Id = 3, Name = "Iphone 14 Pro Max 1TB", Price = 54000, Stock = 30 }
        };

        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({id})'ye sahip ürün bulunmamaktadır..");
            }
            _products.Remove(hasProduct);

        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"Bu id({updateProduct.Id})'ye sahip ürün bulunmamaktadır..");
            }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[index] = hasProduct;
        }

    }
}
