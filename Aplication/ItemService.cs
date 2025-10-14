using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Aplication
{
    public class ItemService: Ports.IService
    {
        private readonly IRepository _repository;
        public ItemService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Domain.Entities.Item>> getItems()
        {
            return  await _repository.GetAll();
        }
        public async Task<Domain.Entities.Item?> getItemById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task addItem(string title)
        {
            var item = new Domain.Entities.Item(0, title, false);
            await _repository.Add(item);
            await _repository.SaveChanges();
        }
    }
}
