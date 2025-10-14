using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Ports
{
    public interface IAddService<TDTO, TModel>
    {
        Task AddAsync(TDTO item);
    }
}
