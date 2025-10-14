using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Ports
{
    public interface ICommonService<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity?> GetById(int id);

        public Task AddEntity(TEntity entity);

    }
}
