using Restaurant.Entities;
using Restaurant.Ports.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlRepository
{
    public class XmlProductRepository : IRepository
    {
        private readonly string _filePath;
        public XmlProductRepository(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
            {
                var doc = new System.Xml.XmlDocument();
                var declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(declaration);
                var root = doc.CreateElement("Products");
                doc.AppendChild(root);
                doc.Save(_filePath);
            }
        }
        public void AddProduct(Product product)
        {
           var doc =XDocument.Load(_filePath);
            if (doc.Root == null)
            {
                doc.Add(new XElement("Products"));
            }
            if (doc.Root.Elements("Product").Any(x => (int)x.Element("Id") == product.Id))
            {
                throw new ArgumentException($"Product with Id {product.Id} already exists.");
            }
            var productElement = new XElement("Product",
                new XElement("Id", product.Id),
                new XElement("Name", product.Name),
                new XElement("Price", product.Price)
                );
            doc.Root.Add(productElement);
            doc.Save(_filePath);
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
            var doc= XDocument.Load(_filePath);
            var products = doc.Root?.Elements("Product")
                .Select(x => new Product(
                    (int)x.Element("Id"),
                    (string)x.Element("Name"),
                    (decimal)x.Element("Price")))
                .ToList() ?? new List<Product>();
            return products;

        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
