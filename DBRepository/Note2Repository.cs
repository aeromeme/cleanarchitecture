using Aplication.DTO;
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
    public class Note2Repository : ICommonRepository<NoteDto>
    {
        private readonly TaskDBContext _context;
        public Note2Repository(TaskDBContext context)
        {
            _context = context;
        }
        public async Task Add(NoteDto item)
        {
            var existingItem = await _context.Items.FindAsync(item.ItemId);
            if (existingItem == null)
            {
                throw new ArgumentException($"Item with Id {item.ItemId} does not exist.");
            }
            var model = new NoteModel
            {
                Id = item.Id,
                ItemId = item.ItemId,
                Message = item.Message,
                CreatedDate = DateTime.Now,
                Color = item.Color

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
        public async Task<IEnumerable<NoteDto>> GetAll()
        {
            return await _context.Notes.Select(n => new NoteDto() {Id= n.Id, ItemId=n.ItemId, Message= n.Message, Color=n.Color }).ToListAsync();
        }
        public async Task<NoteDto?> GetById(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note != null ? new NoteDto() { Id = note.Id, ItemId = note.ItemId, Message = note.Message, Color = note.Color } : null;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Update(NoteDto item)
        {
            throw new NotImplementedException();
        }
    }
 }
