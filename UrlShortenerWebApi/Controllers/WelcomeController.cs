using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok(new Welcome());
        }
    }
}
