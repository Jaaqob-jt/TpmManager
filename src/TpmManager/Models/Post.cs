using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TpmManager.Models
{
    public class Post
    {
        public Post(){}
        public Post(Post post)
        {
            PostId = post.PostId;
            MachineId = post.MachineId;
            Type = post.Type;
            CreationDate = post.CreationDate;
            Content = post.Content;
            Author = post.Author;
            Machine = post.Machine;
        }
        public Post(int id)
        {
            MachineId = id;
        }

        public int PostId { get; set; }
        public int MachineId { get; set; }
        public string Type { get; set; }
        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}", ApplyFormatInEditMode = false)]       
        public DateTime CreationDate { get; private set; } = DateTime.Now;
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public Machine Machine { get; set; }
    }
}