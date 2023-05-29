using Microsoft.AspNetCore.Mvc;

namespace MiddlewareDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        [Route("FastApi")]
        public IActionResult Get()
        {
            return Ok("Hello from FastApi");
        }

        [HttpGet]
        [Route("SlowApi")]
        public async Task<IActionResult> GetSlowAsync()
        {
            await Task.Delay(3000);
            return Ok("Hello from SlowApi"); 
        }
    }
}