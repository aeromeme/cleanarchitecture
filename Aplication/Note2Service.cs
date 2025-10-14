using Aplication.DTO;
using Aplication.Ports;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class Note2Service :ICommonService<NoteDto>
    {
        private ICommonRepository<NoteDto> _repository;
        public Note2Service(ICommonRepository<NoteDto> repo)
        {
            _repository = repo;
        }
        public async Task AddEntity(NoteDto entity)
        {
            await _repository.Add(entity);
            await _repository.SaveChanges();
        }
        public async Task<IEnumerable<NoteDto>> GetAll()
        {
            var notes = await _repository.GetAll();
            return notes;
        }
        public Task<NoteDto?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
