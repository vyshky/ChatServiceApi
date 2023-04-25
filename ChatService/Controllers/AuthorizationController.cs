using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnonymousChatController : ControllerBase
    {

        // TODO :: написать метод, который будет отправляь
        // в боди content и id_chanel
        [HttpPost(nameof(TestBearer))]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult TestBearer()
        {
            return Ok("Success");
        } 
        
        
        [HttpPost(nameof(TestServiceAuth))]
        [Authorize(Roles = "spd-chat-service")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult TestServiceAuth()
        {
            return Ok("Success");
        }
    }
}
