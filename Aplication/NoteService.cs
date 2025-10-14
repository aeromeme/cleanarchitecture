using Aplication.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplication
{
    public class NoteService : ICommonService<Note>
    {
        private ICommonRepository<Note> _noteRepository;
        public NoteService(ICommonRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task AddEntity(Note entity)
        {
            await _noteRepository.Add(entity);
            await _noteRepository.SaveChanges();
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
           return await _noteRepository.GetAll();
        }

        public Task<Note?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
