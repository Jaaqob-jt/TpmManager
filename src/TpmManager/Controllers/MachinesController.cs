
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TpmManager.Models;

namespace TpmManager.Controllers
{
    [ApiController]
    public class MachinesController : ControllerBase
    {

        public readonly TpmContext _context;
        public MachinesController(TpmContext context) => _context = context;


        // GET api/Machines
        [HttpGet, Route("api/Machines")]
        public ActionResult<IEnumerable<Machine>> GetMachines()
        {
            var values = _context.Machines;
            if (values.Any())
            {
                return values;
            }
            return NoContent();
        }

        // GET api/Machines/{id}
        [HttpGet, Route("api/Machines/{id}")]
        public ActionResult<IEnumerable<Post>> GetMachinePosts(int id)
        {
            var values = _context.Posts.Where(x => x.MachineId == id).ToList();
            if (values.Any())
            {
                return values;
            }
            return NoContent();
        }


    }
}