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
    public class NoteRepository: ICommonRepository<Note>
    {
        private readonly TaskDBContext _context;
        public NoteRepository(TaskDBContext context)
        {
            _context = context;
        }
        public async Task Add(Note item)
        {
            var existingItem = await _context.Items.FindAsync(item.ItemId);
            if (existingItem == null)
            {
                throw new ArgumentException($"Item with Id {item.ItemId} does not exist.");
            }
            var model= new NoteModel
            {
                Id = item.Id,
                ItemId = item.ItemId,
                Message = item.Message,
                CreatedDate=DateTime.Now
            };
            _context.Notes.Add(model);
        }
        public void Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }
        }
        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _context.Notes.Select(n => new Note(n.Id,n.ItemId,n.Message)).ToListAsync();
        }
        public async Task<Note?> GetById(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note != null ? new Note(note.Id, note.ItemId, note.Message) : null;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Update(Note item)
        {
            throw new NotImplementedException();
        }
    }
}
