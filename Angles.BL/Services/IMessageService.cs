using Angles.BL.DTOs;

namespace Angles.BL.Services
{
    public interface IMessageService
    {
        Task<bool> CreateMessageAsync(MessageDto messageDto);
        Task<IEnumerable<MessageDto>> GetAllMessagesAsync();
    }
}