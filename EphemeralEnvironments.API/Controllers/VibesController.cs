using EphemeralEnvironments.API.Infrastructure.Settings;
using EphemeralEnvironments.API.Interfaces;
using EphemeralEnvironments.API.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EphemeralEnvironments.API.Controllers
{
    [ApiController]
    [Route("api/vibes")]
    public class VibesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IVibesRepository _vibesRepository;
        private readonly string _domainUrl;

        public VibesController(
            HttpClient httpClient,
            IVibesRepository vibesRepository,
            DomainCommunicationSettings domainCommunicationSettings
        )
        {
            _httpClient = httpClient;
            _vibesRepository = vibesRepository;
            _domainUrl = domainCommunicationSettings.DomainUrl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allVibes = _vibesRepository
                    .GetVibes()
                    .ToList();
                return Ok(allVibes);
            }
            catch (Exception e)
            {
                return Problem(e.ToString());
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateVibeRequest request)
        {
            try
            {
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_domainUrl}/domain", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Ok(responseData);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Forwarding request failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}