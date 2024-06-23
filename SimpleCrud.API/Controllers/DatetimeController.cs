using Microsoft.AspNetCore.Mvc;

namespace SimpleCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatetimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Current datetime: {DateTime.Now}");
        }
    }
}
