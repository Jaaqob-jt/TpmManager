using System;
using System.ComponentModel.DataAnnotations;

namespace TpmManager.Models
{
    public class Post
    {
        [Required]
        public int MachineId { get; set; }
        [Required]
        public int PostId { get; set; }
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public Machine Machine { get; set; }
        
    }
}