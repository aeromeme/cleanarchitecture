using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Ports
{
    public interface IMapper<in TSource, out TDestination>
    {
        public TDestination Map(TSource source);
    }
}
