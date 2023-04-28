using ChatService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;

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
                
        [HttpPost(nameof(GetUserIdOutJwt))]
        [Authorize(Roles = "spd-chat-service")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetUserIdOutJwt()
        {
            StringValues value;
            Request.Headers.TryGetValue("authorization", out value);
            string token = value[0].Replace("Bearer ", "");
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            var userId = jwt.Claims.FirstOrDefault(x=> x.Type == "user_id").Value;
            return Ok(userId);
        }

//Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJMT0NBTCBBVVRIT1JJVFkiOiJNeUF1dGhTZXJ2ZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJ1c2VyX2lkIjoiNjQzMjQ4YzctYmEyMi00MzhmLThkOGItZTY4OTNlZGEwYTEwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjpbImFkbWluIiwidXNlciIsInNwZC1jaGF0LXNlcnZpY2UiXSwiZXhwIjoxNjgyNjk1NzYwLCJpc3MiOiJNeUF1dGhTZXJ2ZXIiLCJhdWQiOiJNeUF1dGhDbGllbnQifQ.z-Hgh7LdYIPH4FWpQGHgEtKUO-dFBkmuzGN9v9VJpIY

        // TODO :: получаем сообщение, получаем клиентский id, отправляем по chanelId сообщение в БД
        // клиент должен получить оповещение о новом сообщении
        [HttpPost(nameof(SendMessage))]
        [Authorize(Roles = "spd-chat-service")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SendMessage(MessageModel message)
        {
            StringValues value;
            Request.Headers.TryGetValue("authorization", out value);
            string token = value[0].Replace("Bearer ", "");
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            var userId = jwt.Claims.FirstOrDefault(x => x.Type == "user_id").Value;
            return Ok(userId);
        }

    }
}
