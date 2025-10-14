using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; } = null!;

        public string? Color { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public ItemModel Item { get; set; }
    }
}
