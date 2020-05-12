using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpmManager.Models
{
    public class Post
    {
        [Required]
        public int MachineId { get; set; }
        [Required]
        public int PostId { get; set; }
        public string Type { get; set; }
        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm", ApplyFormatInEditMode = false)]
        public DateTime CreationDate { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public Machine Machine { get; set; }
    }
}