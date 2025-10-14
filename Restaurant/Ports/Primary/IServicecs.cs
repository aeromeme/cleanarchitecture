using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Ports.Primary
{
    public interface IServicecs
    {
        void AddProduct(Entities.Product product);
        List<Entities.Product> GetProducts();
        Entities.Product? GetProductById(int id);
        void UpdateProduct(Entities.Product product);
        void DeleteProduct(int id);
    }
}
