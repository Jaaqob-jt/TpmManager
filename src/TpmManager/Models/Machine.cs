using System;
using System.Collections.Generic;

namespace TpmManager.Models
{
    public class Machine
    {
        public int MachineID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public DateTime DateOfInstallation { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<Post> Posts { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public List<string> MediaConnected { get; set; }
    }
}