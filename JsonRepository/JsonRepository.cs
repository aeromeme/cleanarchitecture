using Restaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonRepository
{
    public class JsonRepository : Restaurant.Ports.Secondary.IRepository
    {
        private readonly string _filePath;
        public JsonRepository(string filePath)
        {
            _filePath = filePath;
        }
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            var products = GetProducts();
            if (products.Any(p => p.Id == product.Id))
            {
                throw new ArgumentException($"Product with Id {product.Id} already exists.");
            }
            products.Add(product);
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(products, options);
            File.WriteAllText(_filePath, json);

        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product? GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Product>();
            }
            var json = File.ReadAllText(_filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
