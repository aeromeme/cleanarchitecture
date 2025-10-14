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
    public class CompleteTaskService : ICompleteService
    {
        public ICompleteRepository _completeRepository;
        public IGetRepository<Item> getRepository;
        public CompleteTaskService(ICompleteRepository completeRepository, IGetRepository<Item> getRepository)
        {
            _completeRepository = completeRepository;
            this.getRepository = getRepository;
        }
        public async Task Complete(int id)
        {
            var item= await getRepository.GetById(id);
            if ( item ==null)
            {
                throw new Exception(" task not found");
            }
            await _completeRepository.Complete(id);
        }
    }
}
