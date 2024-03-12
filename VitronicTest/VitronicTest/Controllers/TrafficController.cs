using Microsoft.AspNetCore.Mvc;
using VitronicAPI.Infrastructure.Data;
using VitronicAPI.Infrastructure.DTO;

namespace VitronicTest.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TrafficController : ControllerBase
  {
    private readonly ITrafficDataService trafficDataService;
    private readonly ILogger<TrafficController> _logger;

    public TrafficController(ITrafficDataService trafficDataService, ILogger<TrafficController> logger)
    {
      this.trafficDataService = trafficDataService;
      _logger = logger;
    }

    [HttpGet(Name = "GetTrafficData")]
    public IActionResult GetTrafficData(string category)
    {
      try
      {
        var data = trafficDataService.GetTrafficData(category);
        return Ok(data);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
