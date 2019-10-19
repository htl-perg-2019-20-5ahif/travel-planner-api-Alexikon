using MC5_U3_TravelPlanner.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MC5_U3_TravelPlanner.Controllers
{
    [ApiController]
    [Route("api/travelPlan")]
    public class TravelPlannerController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITravelCalculator _calculator;
        private readonly ILogger<TravelPlannerController> _logger;

        public TravelPlannerController(IHttpClientFactory clientFactory, ITravelCalculator calculator, ILogger<TravelPlannerController> logger)
        {
            _clientFactory = clientFactory;
            _calculator = calculator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTravel([FromQuery(Name = "from")] string from, [FromQuery(Name = "to")] string to, [FromQuery(Name = "start")] string start)
        {
            var client = _clientFactory.CreateClient("travelPlanJson");
            var responseContent = await client.GetAsync("");
            var responseBody = await responseContent.Content.ReadAsStringAsync();
            var travels = JsonSerializer.Deserialize<List<Travel>>(responseBody);

            Departure departure = _calculator.calculateTravel(from, to, start, travels);

            if (departure == null)
            {
                return NotFound();
            }

            return Ok(departure);
        }
    }
}
