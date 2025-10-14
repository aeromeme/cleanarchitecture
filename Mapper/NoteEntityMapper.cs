using Aplication.DTO;
using Aplication.Ports;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class NoteEntityMapper : IMapper<NoteDto, Note>
    {
        public Note Map(NoteDto source)
        {
            return new Note (source.Id, source.ItemId, source.Message);
        }
    }
}
