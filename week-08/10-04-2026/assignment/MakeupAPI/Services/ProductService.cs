using MakeupAPI.Models;
using MakeupAPI.Data;

namespace MakeupAPI.Services
{
    public class ProductService
    {
        public List<Product> GetAll()
        {
            return ProductData.Products;
        }

        public Product GetById(int id)
        {
            return ProductData.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            product.Id = ProductData.Products.Count + 1;
            ProductData.Products.Add(product);
        }

        public bool Update(int id, Product updatedProduct)
        {
            var product = ProductData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            return true;
        }

        public bool Delete(int id)
        {
            var product = ProductData.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            ProductData.Products.Remove(product);
            return true;
        }
    }
}