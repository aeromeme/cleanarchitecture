using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Sale
    {
        public List<Product> Products { get; } = new();

        public DateTime Date { get; set; }
        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Customer name cannot be null or empty.", nameof(value));
                _customerName = value;
            }
        }

        public Sale(DateTime date, string customerName)
        {
            Date = date;
            CustomerName = customerName;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            Products.Add(product);
        }

        public bool RemoveProduct(Product product)
        {
            return Products.Remove(product);
        }

        public decimal GetTotal()
        {
            return Products.Sum(p => p.Price);
        }
    }
}
