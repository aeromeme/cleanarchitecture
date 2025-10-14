using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGetRepository <T>
    {
        public Task<T?> GetById(int id);
    }
}
