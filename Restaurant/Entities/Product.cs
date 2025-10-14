using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities
{
    public class Product
    {
        private string _name;
        private decimal _price;
        public int Id { get; set; }
        public string Name { get => _name; set {
                if (string.IsNullOrEmpty(value)){ 
                    throw new ArgumentException("Name cannot be null or empty");
                }
                _name = value;
            } }
        public decimal Price
        {
            get => _price; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                _price = value;
            }
        }
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
