using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.DataTransferObjects;
using System.Security.Claims;

namespace UrlShortenerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public UrlController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet("all")]
        [Authorize(Roles = RolesString.User)]
        public async Task<IActionResult> GetAllUrlsAsync()
        {
            var urls = await serviceManager.UrlService.GetAllUrlAsync(false);

            if (urls is null)
            {
                return NotFound();
            }

            return Ok(urls);
        }

        [HttpGet]
        [Authorize(Roles = RolesString.User)]
        [Authorize(Roles = RolesString.Admin)]
        public async Task<IActionResult> GetUrlsByUserIdAsync()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            var urls = await serviceManager.UrlService.GetUrlsAsync(userId, false);

            if (urls is null)
            {
                return NotFound();
            }

            return Ok(urls);
        }

        [HttpPost]
        [Authorize(Roles = RolesString.User)]
        public async Task<IActionResult> CreateShortenerUrl([FromBody] UrlForCreationDto urlForCreationDto)
        {
            if (urlForCreationDto is null)
            {
                return BadRequest("UrlForCreationDto object is null");
            }

            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            var urlToReturn = await serviceManager.UrlService.CreateUrlForUserAsync(userId, urlForCreationDto);

            return Ok(urlToReturn);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = RolesString.User)]
        public async Task<IActionResult> DeleteUrlAsync(int id)
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            await serviceManager.UrlService.DeleteUrlAsync(userId, id, false);

            return NoContent();
        }

        [HttpPut("id:int")]
        [Authorize(Roles = RolesString.User)]
        public async Task<IActionResult> UpdateUrlAsync(int id, [FromBody] UrlForUpdateDto updateDto)
        {
            if (updateDto is null)
            {
                return BadRequest("UrlForUpdateDto object is null");
            }

            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            await serviceManager.UrlService.UpdateUrlAsync(userId, id, updateDto, trackChangesForUpdate: true);

            return NoContent();
        }

    }
}
