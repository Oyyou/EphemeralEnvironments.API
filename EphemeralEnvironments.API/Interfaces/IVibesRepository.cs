using EphemeralEnvironments.API.Entities;

namespace EphemeralEnvironments.API.Interfaces
{
    public interface IVibesRepository
    {
        public IEnumerable<Vibes> GetVibes();
    }
}
