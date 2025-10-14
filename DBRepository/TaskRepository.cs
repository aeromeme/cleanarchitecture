using DBRepository.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public class TaskRepository : IRepository, ICompleteRepository, IGetRepository<Item>
    {
        public TaskDBContext _context;
        public TaskRepository(TaskDBContext context)
        {
            _context = context;
        }
        public async Task Add(Item item)
        {
            await _context.Items.AddAsync(new ItemModel { Id = item.Id, Title = item.Title, IsCompleted = item.IsCompleted, CreatedDate=DateTime.Now });
        }

        public async Task Complete(int id)
        {
            var model = await _context.Items.FindAsync(id);
            if (model != null)
            {
                model.IsCompleted = true;
                _context.Items.Update(model);
                await _context.SaveChangesAsync();
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
           return  await _context.Items.Select(i => new Item(i.Id, i.Title, i.IsCompleted)).ToListAsync();
        }

        public async Task<Item?> GetById(int id)
        {
            var data= await _context.Items
                .FindAsync(id);
            if (data == null) return null;
            return  new Item(data.Id, data.Title, data.IsCompleted);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
