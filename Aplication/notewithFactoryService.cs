using Aplication.Ports;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class notewithFactoryService<TDTO,TExtraData> : IAddService<TDTO, TExtraData>
    {
        public readonly IFactoryRepository<IAddRespository<Note>, TExtraData> _factoryRepository;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TExtraData> _mapperExtraData;

        public notewithFactoryService(IFactoryRepository<IAddRespository<Note>, TExtraData> factoryRepository, IMapper<TDTO, Note> mapperEntity, IMapper<TDTO, TExtraData> mapperExtraData)
        {
            _factoryRepository = factoryRepository;
            _mapperEntity = mapperEntity;
            _mapperExtraData = mapperExtraData;
        }
        public async Task AddAsync(TDTO item)
        {
            var note = _mapperEntity.Map(item);
            /// Here you can add any business logic or validation for the Note entity
            if (note.Message.Length < 5)
            {
                throw new ArgumentException("Message must be at least 5 characters long");
            }
            var extraData = _mapperExtraData.Map(item);
            var repository = _factoryRepository.CreateRepository(extraData);
            await repository.AddAsync(note);
        }

    }
}
