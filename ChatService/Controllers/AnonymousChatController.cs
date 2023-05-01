﻿using ChatService.Domain.Entities;
using ChatService.Domain.Models;
using ChatService.Services.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "spd-chat-service")]
    public class AnonymousChatController : ControllerBase
    {
        IMessageService messageService;
        public AnonymousChatController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        // TODO :: получаем сообщение, получаем клиентский id, отправляем по chanelId сообщение в БД
        // клиент должен получить оповещение о новом сообщении
        [HttpPost(nameof(SendMessage))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult SendMessage(MessageModel message)
        {
            StringValues value;
            Request.Headers.TryGetValue("authorization", out value);
            string token = value[0].Replace("Bearer ", "");
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            string myClientId = jwt.Claims.FirstOrDefault(x => x.Type == "user_id").Value;
            messageService.SendMessage(Guid.Parse(myClientId), message);
            return Ok("Сообщение доставленно");
        }

        [HttpPost(nameof(GetMessages))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetMessages()
        {
            StringValues value;
            Request.Headers.TryGetValue("authorization", out value);
            string token = value[0].Replace("Bearer ", "");
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            string myClientId = jwt.Claims.FirstOrDefault(x => x.Type == "user_id").Value;
            List<MessageEntity> result = messageService.FindMessagesByChanelId(Guid.Parse(myClientId));
            return Ok(new { Messages = result });
        }

        [HttpPost(nameof(GetGroupMessages))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetGroupMessages([FromBody] Guid groupId)
        {
            bool isHaveGroup = messageService.ContainsByGroup(groupId);
            if (!isHaveGroup) return NotFound(new { Messages = "Group not found" });
            List <MessageEntity> result = messageService.FindMessagesByChanelId(groupId);
            return Ok(new { Messages = result });
        }

        [HttpPost(nameof(CreateGroupChat))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateGroupChat()
        {
            return Ok(new { GroupId = messageService.CreateGroup() });
        }
    }
}