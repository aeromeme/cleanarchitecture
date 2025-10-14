using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Ports
{
    public interface IService
    {
        public Task<IEnumerable<Item>> getItems();

        public Task<Item?> getItemById(int id);

        public Task addItem(string title);

    }
}
