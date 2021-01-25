using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}