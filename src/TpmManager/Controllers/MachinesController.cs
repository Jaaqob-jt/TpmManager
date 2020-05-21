
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TpmManager.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System;
using TpmManager.DTO;

namespace TpmManager.Controllers
{
    [ApiController]
    public class MachinesController : ControllerBase
    {

        public readonly TpmContext _context;
        public MachinesController(TpmContext context) => _context = context;

        #region REST-RAW-API
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

        // DELETE api/Machines/{id}
        [HttpDelete, Route("api/Machines/{id}")]
        public object DeleteMachineById(int id)
        {
            var trash = _context.Machines.Find(id);
            if (trash == null)
            {
                return BadRequest();
            }
            _context.Machines.Remove(trash);
            _context.SaveChanges();
            return Ok();
        }
    
        #endregion
    
        #region REST-DTO

        // GET api/dto/Machines
        [HttpGet, Route("api/dto/Machines")]
        public ActionResult<IEnumerable<MachineDTO>> GetMachinesDTO()
        {
            var result = _context
                .Machines
                .Include("Post")
                .Select(m => new MachineDTO
                {
                    MachineId = m.MachineId,
                    Name = m.Name,
                    Location = m.Location,
                    Description = m.Description,
                    Status = m.Status,
                    Post = m.Post.Select(p => new PostsDTO
                    {
                        PostId = p.PostId,
                        Author = p.Author,
                        Content = p.Content
                    })
                }).ToList();
                return result;
        }

                // GET api/MachinesWP
        [HttpGet, Route("api/MachinesWP")]
        public ActionResult<IEnumerable<Machine>> GetMachinesWP()
        {
            var result = _context
                .Machines
                .Include("Post")
                .Select(m => new Machine
                {
                    MachineId = m.MachineId,
                    Name = m.Name,
                    Location = m.Location,
                    Type = m.Type,
                    DateOfInstallation = m.DateOfInstallation,
                    Description = m.Description,
                    Status = m.Status,
                    Post = m.Post.Select(p => new Post
                    {
                        PostId = p.PostId,
                        MachineId = p.MachineId,
                        Author = p.Author,
                        Content = p.Content
                    })
                }).ToList();
                return result;
        }

        #endregion
    }
}