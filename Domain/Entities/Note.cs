using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int ItemId { get; private set; }
        public string Message { get; private set; }

        public Note(int id, int itemId,string message) { 
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be null or empty", nameof(message));
            }
            if (message.Length > 100) { 
                throw new ArgumentException("Message cannot be longer than 100 characters", nameof(message));
            }
            Id= id;
            ItemId= itemId;
            Message= message;
        }
        public void updateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(Message))
            {
                throw new ArgumentException("Message cannot be null or empty", nameof(Message));
            }
            if (Message.Length > 100)
            {
                throw new ArgumentException("Message cannot be longer than 100 characters", nameof(Message));
            }
            Message= message;
        }
    }
}
