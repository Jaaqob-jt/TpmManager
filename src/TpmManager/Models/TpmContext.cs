using Microsoft.EntityFrameworkCore;

namespace TpmManager.Models
{

    public class TpmContext : DbContext
    {
        public TpmContext(DbContextOptions<TpmContext> options) : base(options)
        {

        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}