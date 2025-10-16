using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTO
{
    public class CreateNoteDto
    {
        public int ItemId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
