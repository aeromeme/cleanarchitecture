using Restaurant.Entities;
using Restaurant.Ports.Primary;
using Restaurant.Ports.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class ProductService : IServicecs
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        public void AddProduct(Product product)
        {
            _repository.AddProduct(product);
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
            return _repository.GetProducts();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
