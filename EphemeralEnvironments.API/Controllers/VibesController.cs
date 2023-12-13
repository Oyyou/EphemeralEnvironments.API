using EphemeralEnvironments.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EphemeralEnvironments.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController : ControllerBase
    {
        private IVibesRepository _vibesRepository;

        public VibesController(
            IVibesRepository vibesRepository
        )
        {
            _vibesRepository = vibesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allVibes = _vibesRepository.GetVibes();
            return Ok(allVibes);
        }
    }
}
