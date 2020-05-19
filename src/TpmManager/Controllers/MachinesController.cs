
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
        public ActionResult<Machine> GetSingleMachine(int id)
        {
            var value = _context.Machines
                .Where(x => x.MachineId == id)
                .Select(machine => new Machine(machine));

            if (value.Any())
            {
                return value.First();
            }
            return NotFound();
        }

        // GET api/Machines/{id}/Posts
        [HttpGet, Route("api/Machines/Posts/{id}")]
        public ActionResult<IEnumerable<Post>> GetMachinePosts(int id)
        {
            var values = _context.Posts.Where(x => x.MachineId == id).ToList();
            if (values.Any())
            {
                return values;
            }
            return NotFound();
        }

        // GET api/Post/{pid}
        [HttpGet, Route("api/Post/{pid}")]
        public ActionResult<Post> GetSinglePost(int pid)
        {
            var value = _context.Posts.Where(x => x.PostId == pid).Select(post => new Post(post));
            if (value.Any())
            {
                return value.First();
            }
            return NotFound();
        }
        // POST api/Machines/{id}
        [HttpPost, Route("api/Machines/{id}")]
        public ActionResult<IEnumerable<Post>> PostNextPost(int id)
        {
            return NoContent();
        }
    }
}