using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpmManager.Models
{
    public class Machine
    {
        [Required]
        public int MachineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Type { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfInstallation { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdated { get; set; }
        public List<Post> Posts { get; set; }
        [Required]
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public List<string> MediaConnected { get; set; }
    }
}