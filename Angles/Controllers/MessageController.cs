using Angles.BL.DTOs;
using Angles.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Angles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] MessageDto messageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _messageService.CreateMessageAsync(messageDto);
            if (result)
                return Ok(new { message = "Message sent successfully." });

            return StatusCode(500, "An error occurred while sending your message.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }
    }
}