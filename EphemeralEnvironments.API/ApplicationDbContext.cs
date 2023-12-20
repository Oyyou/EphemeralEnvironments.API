using EphemeralEnvironments.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EphemeralEnvironments.API
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vibes> Vibes { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {

        }
    }
}
