using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Poo.Bussisness
{
    public class Beer : Bebida,ISalable
    {
        private decimal _alcohol;

        public decimal Discount { get; set; }
        public decimal Alcohol
        {
            get => _alcohol;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Alcohol must be between 0 and 100");
                }
                _alcohol = value;
            }
        }
        public override string GetInfo()
        {
            return $"Beer: {Name}, Price: {Price.ToString("C")}, Category: {GetCategory()}";
        }

        public string GetInfo(string prefix)
        {
            return $"{prefix}" + GetInfo();
        }

        public override string GetCategory()
        {
            return $"Alcoholic Beverage : {Category}";
        }

        public Beer(string name, decimal price): base(name, price,"Alcohol")
        {
            Name = name;
            Price = price;
            Discount = 1m;
        }
        public Beer() : base("", 0, "Alcohol") {
            Discount = 1m;
        }
    }

}
