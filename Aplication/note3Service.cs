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
    public class note3Service<TDTO, TModel> : IAddService<TDTO, TModel>
    {
        private readonly IAddRespository<TModel> _repository;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TModel> _mapperModel;

        public note3Service(IAddRespository<TModel> repository, IMapper<TDTO, Note> mapperEntity, IMapper<TDTO, TModel> mapperModel)
        {
            _repository = repository;
            _mapperEntity = mapperEntity;
            _mapperModel = mapperModel;
        }
        public async Task AddAsync(TDTO item)
        {
            var note = _mapperEntity.Map(item);

            /// Here you can add any business logic or validation for the Note entity
            if (note.Message.Length < 5) { 
                throw new ArgumentException("Message must be at least 5 characters long");
            }
            var model = _mapperModel.Map(item);
            await _repository.AddAsync(model);
        }
    }
}
