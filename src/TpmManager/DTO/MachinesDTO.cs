using System;
using System.Collections.Generic;

namespace TpmManager.DTO
{
    public class MachineDTO
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IEnumerable<PostsDTO> Post { get; set; }
    }
}