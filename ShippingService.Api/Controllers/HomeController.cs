using Microsoft.AspNetCore.Mvc;

namespace ShippingService.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult HealthCheckMethod()
        {
            return Ok("Welcome to shipping service");
        }
    }
}