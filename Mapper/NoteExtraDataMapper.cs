using Aplication.DTO;
using Aplication.Ports;
using DBRepository.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class NoteExtraDataMapper :IMapper<NoteDto, NoteExtraData>
    {
        public NoteExtraData Map(NoteDto source)
        {
            return new NoteExtraData
            {
                Color = source.Color
            };
        }
    }
}
