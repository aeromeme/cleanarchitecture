using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Bussisness
{
    public class ExpiringBeer: Beer
    {
        public DateTime ExpirationDate { get; set; }
        public bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }
        public override string GetInfo()
        {
            return $"Beer: {Name}, Price: {Price.ToString("C")}, Expiring: {IsExpired()}, Category: {GetCategory()}";
        }

        public ExpiringBeer(string name, decimal price, DateTime expirationDate) : base(name, price)
        {
            ExpirationDate = expirationDate;
        }
        public ExpiringBeer() { }
    }
}
