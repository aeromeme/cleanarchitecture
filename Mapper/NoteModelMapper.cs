using Aplication.DTO;
using DBRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class NoteModelMapper : Aplication.Ports.IMapper<NoteDto, NoteModel>
    {
        public NoteModel Map(NoteDto source)
        {
            return new NoteModel
            {
                Id = source.Id,
                ItemId = source.ItemId,
                Message = source.Message,
                CreatedDate = DateTime.Now,
                Color = source.Color
            };
        }
    }
}
