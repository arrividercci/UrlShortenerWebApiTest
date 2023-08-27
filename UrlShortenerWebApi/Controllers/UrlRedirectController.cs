using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace UrlShortenerWebApi.Controllers
{
    [Route("short")]
    [ApiController]
    public class UrlRedirectController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UrlRedirectController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet("{shortUrl}")]
        public async Task<ActionResult> GetByShortUrl(string shortUrl)
        {
            var url = await serviceManager.UrlService.GetUrlByCodeAsync(shortUrl, false);
            
            if (url is null)
            {
                return NotFound();
            }
            else
            {
                return Redirect(url.OriginalUrl);
            }
        }
    }
}
