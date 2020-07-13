using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpmManager.Models
{
    public class Machine
    {
        public Machine(){}
        public Machine(Machine mach)
        {
            MachineId = mach.MachineId;
            Name = mach.Name;
            Location = mach.Location;
            Type = mach.Type;
            DateOfInstallation = mach.DateOfInstallation;
            Post = mach.Post;
            Description = mach.Description;
            Status = mach.Status;
        }
        
        
        [Required]
        public int MachineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfInstallation { get; set; } = DateTime.Now;
        [Required]
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public IEnumerable<Post> Post { get; set; }
        
    }
}