
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TpmManager.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

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

        // GET api/Posts/{id}
        [HttpGet, Route("api/Posts/{id}")]
        public ActionResult<IEnumerable<Post>> GetMachinePosts(int id)
        {
            var values = _context.Posts.Where(x => x.MachineId == id).ToList();
            if (values.Any())
            {
                return values;
            }
            return NotFound();
        }

        // GET api/Posts
        [HttpGet, Route("api/Posts")]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            var values = _context.Posts.ToList();
            if (values.Any())
            {
                return values;
            }
            return NoContent();
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
        
        // POST api/Post
        [HttpPost, Route("api/Post/{id}")]
        public ActionResult<IEnumerable<Post>> PostNextPost(Post post, int id)
        {
            var putter = new Post(post){MachineId = id};
            _context.Posts.Add(putter);

            try
            {
                _context.SaveChanges();
            } catch
            {
                return BadRequest();
            }
            return CreatedAtAction("PostNextPost", new Post{MachineId = putter.MachineId}, putter);
        }
    
        // POST api/Machines
        [HttpPost, Route("api/Machines")]
        public ActionResult<Machine> PostNewMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            try
            {
                _context.SaveChanges();
            } catch
            {
                return BadRequest();
            }
            return CreatedAtAction("PostNewMachine", new Machine{MachineId = machine.MachineId}, machine);
        }
    

        // PUT api/Machines/{id}
        [HttpPut, Route("api/Machines/{id}")]
        public ActionResult PutMachine(int id, Machine machine)
        {
            if (id != machine.MachineId)
            {
                return BadRequest();
            }
            _context.Entry(machine).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}