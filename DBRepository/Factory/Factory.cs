using DBRepository.Extra;
using DBRepository.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Factory
{
    public class Factory : IFactoryRepository<IAddRespository<Note>, NoteExtraData>
    {
        private readonly TaskDBContext _context;
        public Factory(TaskDBContext context)
        {
            _context = context;
        }
        public IAddRespository<Note> CreateRepository(NoteExtraData extraData)
        {
            return new NoteFactoryRepository(_context, extraData);
        }
    }
}
