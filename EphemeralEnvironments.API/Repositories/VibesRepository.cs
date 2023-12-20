using EphemeralEnvironments.API.Entities;
using EphemeralEnvironments.API.Interfaces;

namespace EphemeralEnvironments.API.Repositories
{
    public class VibesRepository : IVibesRepository
    {
        private ApplicationDbContext _context;
        public VibesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vibes> GetVibes()
        {
            return _context.Vibes;
        }
    }
}
