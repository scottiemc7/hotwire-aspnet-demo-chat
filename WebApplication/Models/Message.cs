using System;

namespace WebApplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        
        public int RoomId { get; set; }
        
        public virtual Room Room { get; set; }

        public DateTime Created { get; set; }
    }
}