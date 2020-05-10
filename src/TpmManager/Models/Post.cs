using System;

namespace TpmManager.Models
{
    public class Post
    {
        public int MachineId { get; set; }
        public int PostId { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        
    }
}