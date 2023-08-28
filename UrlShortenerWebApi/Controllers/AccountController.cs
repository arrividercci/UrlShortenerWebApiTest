using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.DataTransferObjects;

namespace UrlShortenerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserModel user)
        {
            await serviceManager.UserService.Register(user);
            
            return Accepted();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginUserModel user)
        {
                var userDto = await serviceManager.UserService.Login(user);

                return Ok(userDto);
        }
    }
}
