using Microsoft.AspNetCore.Mvc;
using Vivet.AspNetCore.RequestTimeZone;

namespace TimeZones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeZoneController : ControllerBase
    {
        private readonly ILogger<TimeZoneController> _logger;

        public TimeZoneController(ILogger<TimeZoneController> logger)
        {
            _logger = logger;
        }

        // Some Linux Distro's dont come with the Linux TimeZone files, so these two methods test a few timezones via Swagger....
        [HttpGet]
        [Route("GetLocalTime")]
        public IActionResult GetLocalTime(string tz = "E. Australia Standard Time")
        {
            var utc = DateTimeInfo.UtcNow;  // Gets utc datetime
            var local = DateTimeInfo.Now; // Gets local datetime

            return Ok("Local: " + local.ToString() + "  UTC: " + utc.ToString() );
        }

        [HttpGet]
        [Route("GetWestEuropeStandardTime")]
        public IActionResult GetWestEuropeStandardTime(string tz="W. Europe Standard Time")
        {
            var utc = DateTimeInfo.UtcNow;  // Gets utc datetime
            var local = DateTimeInfo.Now; // Gets local datetime
            
            return Ok("W Europe: " + local.ToString() + "  UTC: " + utc.ToString());
        }
    }
}