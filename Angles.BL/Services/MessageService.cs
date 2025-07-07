using Angles.BL.DTOs;
using Angles.DAL.Models;

namespace Angles.BL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<bool> CreateMessageAsync(MessageDto messageDto)
        {
            try
            {
                var message = new Message
                {
                    UserId = messageDto.UserId,
                    FirstName = messageDto.FirstName,
                    LastName = messageDto.LastName,
                    Email = messageDto.Email,
                    Phone = messageDto.Phone,
                    Content = messageDto.Content,
                    CreatedAt = DateTime.UtcNow
                };

                await _messageRepository.CreateAsync(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<MessageDto>> GetAllMessagesAsync()
        {
            var messages = await _messageRepository.GetAllAsync();
            return messages.Select(m => new MessageDto
            {
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                Phone = m.Phone,
                Content = m.Content,
                UserId = m.UserId
            });
        }
    }
}