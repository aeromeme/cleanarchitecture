using DBRepository.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    public class Note3Respository : IAddRespository<NoteModel>
    {
        private readonly TaskDBContext _context;
        public Note3Respository(TaskDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(NoteModel item)
        {
           _context.Notes.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
