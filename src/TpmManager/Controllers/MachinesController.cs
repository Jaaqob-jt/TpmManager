
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TpmManager.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class MachinesController : ControllerBase
    {

        // GET api/Machines
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "will", "show", "all", "machines"};
           // return NoContent();
        }

    }
}