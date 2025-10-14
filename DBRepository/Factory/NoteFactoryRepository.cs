using DBRepository.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Ports;
using Domain.Interfaces;
using DBRepository.Extra;

namespace DBRepository.Factory
{
    public class NoteFactoryRepository : IAddRespository<Note>
    {
        private readonly TaskDBContext _context;
        private NoteExtraData _extraData;

        public NoteFactoryRepository(TaskDBContext context, NoteExtraData extraData)
        {
            _context = context;
            _extraData = extraData;
        }
        public Task AddAsync(Note item)
        {
           var model= new NoteModel
            {
                Id = item.Id,
                Message = item.Message,
                ItemId = item.ItemId,
               CreatedDate = DateTime.Now,
               Color = _extraData.Color // Use extra data here
            };
            _context.Notes.Add(model);
            return _context.SaveChangesAsync();
        }
    }
}
