using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Entities.Item>> GetAll();
        Task<Entities.Item?> GetById(int id);
        Task  Add(Entities.Item item);
        Task Update(Entities.Item item);
        Task Delete(int id);
        Task SaveChanges();
    }
}
