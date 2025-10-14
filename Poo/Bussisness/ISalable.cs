using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poo.Bussisness
{
    public interface ISalable
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
