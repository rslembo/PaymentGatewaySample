using Microsoft.AspNetCore.Mvc;

namespace PaymentGatewaySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to PaymentGatewaySample");
        }
    }
}