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
            try
            {
                var allVibes = _vibesRepository
                    .GetVibes()
                    .Select(v => v.Vibe)
                    .ToList();
                return Ok(allVibes);
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }
    }
}
