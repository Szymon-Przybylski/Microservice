using Microsoft.AspNetCore.Mvc;

namespace ShippingService.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        public ActionResult HealthCheckMethod()
        {
            return Ok("Welcome to shipping service");
        }
    }
}