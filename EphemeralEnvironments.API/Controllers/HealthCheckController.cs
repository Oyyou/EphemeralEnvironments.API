using Microsoft.AspNetCore.Mvc;

namespace EphemeralEnvironments.API.Controllers
{
    [ApiController]
    [Route("api/healthcheck")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IConfiguration _config;

        public HealthCheckController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }

        [HttpGet("connectionstring")]
        public IActionResult GetConnectionString()
        {
            return Ok(_config.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("environment")]
        public IActionResult GetEnvironment()
        {
            var environmentVariables = Environment.GetEnvironmentVariables();
            return Ok(environmentVariables);
        }
    }
}
